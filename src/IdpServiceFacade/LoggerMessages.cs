namespace Innago.Security.IdpServiceFacade;

using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

using Microsoft.Extensions.Logging;

using Services;

internal static partial class LoggerMessages
{
    private static readonly Action<ILogger, string?, Exception?> ErrorDefinition =
        LoggerMessage.Define<string?>(LogLevel.Error, new EventId(0), "Error: {ErrorMessage}");

    private static readonly Action<ILogger, string?, string, Exception?> ErrorDefinition2 =
        LoggerMessage.Define<string?, string>(LogLevel.Error, new EventId(0), "Error: {ErrorMessage}; Data: {Data}");

    internal static void Error(this ILogger logger, Exception? exception)
    {
        LoggerMessages.ErrorDefinition(logger, exception?.Message, exception);
    }

    internal static void GetUsersByIdsError(this ILogger<UserService> logger, Exception? exception, string userIds)
    {
        LoggerMessages.ErrorDefinition2(logger, exception?.Message, userIds, exception);
    }

    [LoggerMessage(LogLevel.Error, EventName = nameof(OrganizationService.CreateOrganization), Message = "{Error}")]
    internal static partial void CreateOrganizationError(this ILogger<OrganizationService> logger, string? error);

    [LoggerMessage(LogLevel.Error, EventName = nameof(OrganizationService.ListOrganizations), Message = "{Error}")]
    internal static partial void ListOrganizationsError(this ILogger<OrganizationService> logger, string? error);

    [LoggerMessage(LogLevel.Information, "{Message}")]
    internal static partial void Information(this ILogger logger, string message);

    [LoggerMessage(LogLevel.Information, "{Email}", EventName = nameof(UserService.InitiatePasswordReset))]
    internal static partial void InitiatePasswordReset(this ILogger logger, string email);

    [LoggerMessage(LogLevel.Debug, "{Message}")]
    internal static partial void Debug(this ILogger logger, string message);

    [LoggerMessage(LogLevel.Warning, "{Message}")]
    internal static partial void CertificateWarning(this ILogger logger, string message);

    [LoggerMessage(LogLevel.Information, "Certificate Validation Result: {Result}")]
    internal static partial void CertificateValidationResult(this ILogger logger, string result);

    [LoggerMessage(LogLevel.Error, "Invalid JWT format - expected 3 parts, got {Count}")]
    internal static partial void JwtFormatError(this ILogger logger, int count);

    [LoggerMessage(LogLevel.Information, Message = "JWT Header: {Header}")]
    internal static partial void JwtHeader(this ILogger logger, string header);

    [LoggerMessage(LogLevel.Information, Message = "JWT Payload: {Payload}")]
    internal static partial void JwtPayload(this ILogger logger, string payload);

    [LoggerMessage(LogLevel.Information, Message = "JWT Expiration: {ExpirationDate} (UTC) - Expired: {IsExpired}")]
    internal static partial void JwtExpiration(this ILogger logger, DateTimeOffset expirationDate, bool isExpired);

    [LoggerMessage(LogLevel.Warning, Message = "      - {Status}: {Info}")]
    internal static partial void CertificateStatusWarning(
        this ILogger logger,
        X509ChainStatusFlags status,
        string info);

    [LoggerMessage(LogLevel.Information, "=== Certificate Validation Callback ===")]
    internal static partial void LogCertificateValidationCallback(this ILogger logger);

    [LoggerMessage(LogLevel.Information, "Request URI: {uri}")]
    internal static partial void LogRequestUriUri(this ILogger logger, Uri? uri);

    [LoggerMessage(LogLevel.Information, "Authorization Header: {header}")]
    internal static partial void LogAuthorizationHeaderHeader(this ILogger logger, string header);

    [LoggerMessage(LogLevel.Warning, "No Authorization header found in request")]
    internal static partial void LogNoAuthorizationHeaderFoundInRequest(this ILogger logger);

    [LoggerMessage(LogLevel.Information, "SSL Policy Errors: {errors}")]
    internal static partial void LogSslPolicyErrorsErrors(this ILogger logger, SslPolicyErrors errors);

    [LoggerMessage(LogLevel.Information, "Certificate Details:")]
    internal static partial void LogCertificateDetails(this ILogger logger);

    [LoggerMessage(LogLevel.Information, "  Subject: {subject}")]
    internal static partial void LogSubjectSubject(this ILogger logger, string subject);

    [LoggerMessage(LogLevel.Information, "  Issuer: {issuer}")]
    internal static partial void LogIssuerIssuer(this ILogger logger, string issuer);

    [LoggerMessage(LogLevel.Information, "  Thumbprint: {thumbprint}")]
    internal static partial void LogThumbprintThumbprint(this ILogger logger, string thumbprint);

    [LoggerMessage(LogLevel.Information, "  Valid From: {notBefore}")]
    internal static partial void LogValidFromNotBefore(this ILogger logger, DateTime notBefore);

    [LoggerMessage(LogLevel.Information, "  Valid Until: {notAfter}")]
    internal static partial void LogValidUntilNotAfter(this ILogger logger, DateTime notAfter);

    [LoggerMessage(LogLevel.Information, "  Is Valid: {isValid}")]
    internal static partial void LogIsValidIsvalid(this ILogger logger, bool isValid);

    [LoggerMessage(LogLevel.Information, "  Has Private Key: {hasPrivateKey}")]
    internal static partial void LogHasPrivateKeyHasPrivateKey(this ILogger logger, bool hasPrivateKey);

    [LoggerMessage(LogLevel.Information, "  Serial Number: {serialNumber}")]
    internal static partial void LogSerialNumber(this ILogger logger, string serialNumber);

    [LoggerMessage(LogLevel.Information, "  Version: {version}")]
    internal static partial void LogVersionVersion(this ILogger logger, int version);

    [LoggerMessage(LogLevel.Information, "  Signature Algorithm: {algorithm}")]
    internal static partial void LogSignatureAlgorithmAlgorithm(this ILogger logger, string? algorithm);

    [LoggerMessage(LogLevel.Information, "Certificate Chain Status:")]
    internal static partial void LogCertificateChainStatus(this ILogger logger);

    [LoggerMessage(LogLevel.Information, "  Chain Elements Count: {count}")]
    internal static partial void LogChainElementsCountCount(this ILogger logger, int count);

    [LoggerMessage(LogLevel.Information, "  Chain Element [{index}]:")]
    internal static partial void LogChainElementIndex(this ILogger logger, int index);

    [LoggerMessage(LogLevel.Information, "JWT Signature (truncated): {signature}")]
    internal static partial void LogJwtSignatureTruncatedSignature(this ILogger logger, string signature);

    [LoggerMessage(LogLevel.Error, "Error inspecting JWT")]
    internal static partial void LogErrorInspectingJwt(this ILogger? logger, Exception ex);
}
