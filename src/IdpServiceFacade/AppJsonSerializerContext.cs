namespace Innago.Security.IdpServiceFacade;

using System.Text.Json.Serialization;

[JsonSerializable(typeof(string))]
internal partial class AppJsonSerializerContext : JsonSerializerContext;
