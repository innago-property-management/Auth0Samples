namespace Abstractions;

using JetBrains.Annotations;

/// <summary>
/// Represents the information required to create an organization.
/// </summary>
[PublicAPI]
public record OrganizationCreateInfo(string Name, string? LegacyId = null, string? LegacyUid = null);
