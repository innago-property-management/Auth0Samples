namespace Abstractions;

using System.Collections.Generic;

using JetBrains.Annotations;

/// <summary>
/// Represents the information required to update an organization.
/// </summary>
[PublicAPI]
public record OrganizationUpdateInfo(string DisplayName, Dictionary<string, string>? Metadata = null);
