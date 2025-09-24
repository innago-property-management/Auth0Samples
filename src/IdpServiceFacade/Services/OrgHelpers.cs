namespace Innago.Security.IdpServiceFacade.Services;

using Abstractions;

using global::IdpServiceFacade;

internal static class OrgHelpers
{
    public static GetOrganizationReply ToGetOrganizationReply(this Org org)
    {
        Metadata metadata = new();

        if (org.Metadata?.Any() == true)
        {
            metadata.Item.AddRange(org.Metadata.Select(pair => new MetadataItem { Key = pair.Key, Value = pair.Value }));
        }

        GetOrganizationReply getOrganizationReply = new()
        {
            DisplayName = org.DisplayName,
            Id = org.Id,
            Metadata = metadata,
            Name = org.Name,
        };

        return getOrganizationReply;
    }

    internal static OrganizationReply ToOrganizationReply(this OkError result)
    {
        return new OrganizationReply
        {
            Ok = result.OK,
            Error = result.Error ?? string.Empty,
        };
    }
}
