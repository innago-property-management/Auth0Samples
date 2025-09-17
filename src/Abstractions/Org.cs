namespace Abstractions;

using System.Collections.Generic;

using JetBrains.Annotations;

/// <summary>
/// Represents an organization with a unique identifier, name, display name, and associated metadata.
/// </summary>
/// <param name="Id">The unique identifier of the organization.</param>
/// <param name="Name">The name of the organization.</param>
/// <param name="DisplayName">The display-friendly name of the organization.</param>
/// <param name="Metadata">A dictionary containing additional metadata associated with the organization.</param>
[PublicAPI]
public record Org(string Id, string Name, string DisplayName, IReadOnlyDictionary<string, string>? Metadata = null);
