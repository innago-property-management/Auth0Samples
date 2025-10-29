namespace Innago.Security.IdpServiceFacade;

using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

using Microsoft.Extensions.Logging;

internal static partial class LoggingCertificateHttpClientHandler
{
    private static ILogger logger = null!;

    public static void SetCertificateValidationOptions(this IHttpClientBuilder builder, IConfiguration configuration)
    {
        SetLogger(builder.Services.BuildServiceProvider().GetRequiredService<ILoggerFactory>());

        builder.ConfigurePrimaryHttpMessageHandler(() =>
            new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = ServerCertificateCustomValidationCallback,
            });
    }

    private static void SetLogger(ILoggerFactory loggerFactory)
    {
        ILogger loggerInstance = loggerFactory.CreateLogger(nameof(LoggingCertificateHttpClientHandler));
        LoggingCertificateHttpClientHandler.logger = loggerInstance;
    }

    private static bool ServerCertificateCustomValidationCallback(
        HttpRequestMessage httpRequestMessage,
        X509Certificate2? certificate,
        X509Chain? certificateChain,
        SslPolicyErrors sslPolicyErrors)
    {
        try
        {
            LoggingCertificateHttpClientHandler.logger.LogCertificateValidationCallback();
            LoggingCertificateHttpClientHandler.logger.LogRequestUriUri(httpRequestMessage.RequestUri);

            // Inspect Authorization Header (JWT)
            if (httpRequestMessage.Headers.TryGetValues("Authorization", out IEnumerable<string>? authHeaders))
            {
                foreach (string authHeader in authHeaders)
                {
                    LoggingCertificateHttpClientHandler.logger.LogAuthorizationHeaderHeader(authHeader);

                    if (!authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    string token = authHeader.Substring(7);
                    InspectJwt(token);
                }
            }
            else
            {
                LoggingCertificateHttpClientHandler.logger.LogNoAuthorizationHeaderFoundInRequest();
            }

            // Inspect SSL Policy Errors
            LoggingCertificateHttpClientHandler.logger.LogSslPolicyErrorsErrors(sslPolicyErrors);

            if (sslPolicyErrors != SslPolicyErrors.None)
            {
                LoggingCertificateHttpClientHandler.logger.CertificateWarning("SSL Policy Errors Detected:");

                if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNotAvailable) != 0)
                {
                    LoggingCertificateHttpClientHandler.logger.CertificateWarning("  - Remote certificate not available");
                }

                if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNameMismatch) != 0)
                {
                    LoggingCertificateHttpClientHandler.logger.CertificateWarning("  - Remote certificate name mismatch");
                }

                if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateChainErrors) != 0)
                {
                    LoggingCertificateHttpClientHandler.logger.CertificateWarning("  - Remote certificate chain errors");
                }
            }

            // Inspect Certificate
            if (certificate != null)
            {
                LoggingCertificateHttpClientHandler.logger.LogCertificateDetails();
                LoggingCertificateHttpClientHandler.logger.LogSubjectSubject(certificate.Subject);
                LoggingCertificateHttpClientHandler.logger.LogIssuerIssuer(certificate.Issuer);
                LoggingCertificateHttpClientHandler.logger.LogThumbprintThumbprint(certificate.Thumbprint);
                LoggingCertificateHttpClientHandler.logger.LogValidFromNotBefore(certificate.NotBefore);
                LoggingCertificateHttpClientHandler.logger.LogValidUntilNotAfter(certificate.NotAfter);

                LoggingCertificateHttpClientHandler.logger.LogIsValidIsvalid(DateTime.Now >= certificate.NotBefore && DateTime.Now <= certificate.NotAfter);

                LoggingCertificateHttpClientHandler.logger.LogHasPrivateKeyHasPrivateKey(certificate.HasPrivateKey);
                LoggingCertificateHttpClientHandler.logger.LogSerialNumber(certificate.SerialNumber);
                LoggingCertificateHttpClientHandler.logger.LogVersionVersion(certificate.Version);
                LoggingCertificateHttpClientHandler.logger.LogSignatureAlgorithmAlgorithm(certificate.SignatureAlgorithm.FriendlyName);
            }
            else
            {
                LoggingCertificateHttpClientHandler.logger.CertificateWarning("Certificate is null");
            }

            // Inspect Certificate Chain
            if (certificateChain != null)
            {
                LoggingCertificateHttpClientHandler.logger.LogCertificateChainStatus();
                LoggingCertificateHttpClientHandler.logger.LogChainElementsCountCount(certificateChain.ChainElements.Count);

                for (int i = 0; i < certificateChain.ChainElements.Count; i++)
                {
                    X509ChainElement element = certificateChain.ChainElements[i];
                    LoggingCertificateHttpClientHandler.logger!.LogChainElementIndex(i);
                    LoggingCertificateHttpClientHandler.logger!.LogSubjectSubject(element.Certificate.Subject);
                    LoggingCertificateHttpClientHandler.logger!.LogIssuerIssuer(element.Certificate.Issuer);

                    if (element.ChainElementStatus.Length <= 0)
                    {
                        continue;
                    }

                    LoggingCertificateHttpClientHandler.logger!.CertificateWarning("Chain Element Status Issues:");

                    foreach (X509ChainStatus status in element.ChainElementStatus)
                    {
                        LoggingCertificateHttpClientHandler.logger?.CertificateStatusWarning(status.Status, status.StatusInformation);
                    }
                }

                if (certificateChain.ChainStatus.Length > 0)
                {
                    LoggingCertificateHttpClientHandler.logger?.CertificateWarning("Certificate Chain Issues:");

                    foreach (X509ChainStatus status in certificateChain.ChainStatus)
                    {
                        LoggingCertificateHttpClientHandler.logger?.CertificateStatusWarning(status.Status, status.StatusInformation);
                    }
                }
            }
            else
            {
                LoggingCertificateHttpClientHandler.logger.CertificateWarning("Certificate chain is null");
            }

            // Decide whether to accept the certificate
            bool isValid = sslPolicyErrors == SslPolicyErrors.None;
            LoggingCertificateHttpClientHandler.logger?.CertificateValidationResult(isValid ? "ACCEPTED" : "REJECTED");

            return isValid;
        }
        catch (Exception ex)
        {
            LoggingCertificateHttpClientHandler.logger.Error(ex);
            return false;
        }
    }

    private static void InspectJwt(string token)
    {
        try
        {
            string[] parts = token.Split('.');

            if (parts.Length != 3)
            {
                LoggingCertificateHttpClientHandler.logger.JwtFormatError(parts.Length);
                return;
            }

            // Decode header
            string header = DecodeBase64Url(parts[0]);
            LoggingCertificateHttpClientHandler.logger.JwtHeader(header);

            // Decode payload
            string payload = DecodeBase64Url(parts[1]);
            LoggingCertificateHttpClientHandler.logger.JwtPayload(payload);

            // Parse expiration if present
            if (payload.Contains("\"exp\""))
            {
                try
                {
                    Match expMatch = MyRegex().Match(payload);

                    if (expMatch.Success && long.TryParse(expMatch.Groups[1].Value, out long exp))
                    {
                        DateTimeOffset expirationDate = DateTimeOffset.FromUnixTimeSeconds(exp);
                        bool isExpired = DateTimeOffset.UtcNow > expirationDate;

                        LoggingCertificateHttpClientHandler.logger.JwtExpiration(
                            expirationDate,
                            isExpired);
                    }
                }
                catch (Exception ex)
                {
                    LoggingCertificateHttpClientHandler.logger.Error(ex);
                }
            }

            LoggingCertificateHttpClientHandler.logger.LogJwtSignatureTruncatedSignature(parts[2].Length > 20 ? parts[2].Substring(0, 20) + "..." : parts[2]);
        }
        catch (Exception ex)
        {
            LoggingCertificateHttpClientHandler.logger.LogErrorInspectingJwt(ex);
        }
    }

    private static string DecodeBase64Url(string base64Url)
    {
        string base64 = base64Url.Replace('-', '+').Replace('_', '/');

        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }

        byte[] bytes = Convert.FromBase64String(base64);
        return System.Text.Encoding.UTF8.GetString(bytes);
    }

    [System.Text.RegularExpressions.GeneratedRegex(@"""exp"":\s*(\d+)")]
    private static partial System.Text.RegularExpressions.Regex MyRegex();
}
