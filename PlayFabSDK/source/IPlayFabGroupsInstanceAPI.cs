using PlayFab.GroupsModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// Interface for PlayFab Groups Instance API, providing asynchronous methods for group and role management.
    /// </summary>
    public interface IPlayFabGroupsInstanceAPI
    {
        /// <summary>
        /// Checks if the entity is currently logged in.
        /// </summary>
        /// <returns>True if the entity is logged in; otherwise, false.</returns>
        bool IsEntityLoggedIn();

        /// <summary>
        /// Forgets all stored credentials for the current entity.
        /// </summary>
        void ForgetAllCredentials();

        /// <summary>
        /// Accepts an outstanding application to join a group.
        /// </summary>
        /// <param name="request">The request containing group and entity information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with an empty response on success.</returns>
        Task<PlayFabResult<EmptyResponse>> AcceptGroupApplicationAsync(AcceptGroupApplicationRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Accepts an outstanding invitation to join a group.
        /// </summary>
        /// <param name="request">The request containing group and entity information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with an empty response on success.</returns>
        Task<PlayFabResult<EmptyResponse>> AcceptGroupInvitationAsync(AcceptGroupInvitationRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds members to a group or role.
        /// </summary>
        /// <param name="request">The request containing group, role, and member information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with an empty response on success.</returns>
        Task<PlayFabResult<EmptyResponse>> AddMembersAsync(AddMembersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Applies to join a group.
        /// </summary>
        /// <param name="request">The request containing group and entity information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the application response.</returns>
        Task<PlayFabResult<ApplyToGroupResponse>> ApplyToGroupAsync(ApplyToGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Blocks entities from joining a group.
        /// </summary>
        /// <param name="request">The request containing group and entity information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with an empty response on success.</returns>
        Task<PlayFabResult<EmptyResponse>> BlockEntityAsync(BlockEntityRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Changes the role membership of entities within a group.
        /// </summary>
        /// <param name="request">The request containing group, origin role, destination role, and entity information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with an empty response on success.</returns>
        Task<PlayFabResult<EmptyResponse>> ChangeMemberRoleAsync(ChangeMemberRoleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a new group.
        /// </summary>
        /// <param name="request">The request containing group creation information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the group creation response.</returns>
        Task<PlayFabResult<CreateGroupResponse>> CreateGroupAsync(CreateGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a new role within an existing group.
        /// </summary>
        /// <param name="request">The request containing group and role information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the role creation response.</returns>
        Task<PlayFabResult<CreateGroupRoleResponse>> CreateRoleAsync(CreateGroupRoleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a group and all associated data.
        /// </summary>
        /// <param name="request">The request containing group information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with an empty response on success.</returns>
        Task<PlayFabResult<EmptyResponse>> DeleteGroupAsync(DeleteGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a role within a group.
        /// </summary>
        /// <param name="request">The request containing group and role information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with an empty response on success.</returns>
        Task<PlayFabResult<EmptyResponse>> DeleteRoleAsync(DeleteRoleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets information about a group.
        /// </summary>
        /// <param name="request">The request containing group information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the group information response.</returns>
        Task<PlayFabResult<GetGroupResponse>> GetGroupAsync(GetGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Invites an entity to join a group.
        /// </summary>
        /// <param name="request">The request containing group and entity information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the invitation response.</returns>
        Task<PlayFabResult<InviteToGroupResponse>> InviteToGroupAsync(InviteToGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Checks if an entity is a member of a group or role.
        /// </summary>
        /// <param name="request">The request containing group and entity information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the membership response.</returns>
        Task<PlayFabResult<IsMemberResponse>> IsMemberAsync(IsMemberRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all outstanding applications to join a group.
        /// </summary>
        /// <param name="request">The request containing group information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the list of group applications.</returns>
        Task<PlayFabResult<ListGroupApplicationsResponse>> ListGroupApplicationsAsync(ListGroupApplicationsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all entities blocked from joining a group.
        /// </summary>
        /// <param name="request">The request containing group information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the list of blocked entities.</returns>
        Task<PlayFabResult<ListGroupBlocksResponse>> ListGroupBlocksAsync(ListGroupBlocksRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all outstanding invitations for a group.
        /// </summary>
        /// <param name="request">The request containing group information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the list of group invitations.</returns>
        Task<PlayFabResult<ListGroupInvitationsResponse>> ListGroupInvitationsAsync(ListGroupInvitationsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets a list of members and their roles within a group.
        /// </summary>
        /// <param name="request">The request containing group information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the list of group members and roles.</returns>
        Task<PlayFabResult<ListGroupMembersResponse>> ListGroupMembersAsync(ListGroupMembersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists the groups and roles that an entity is a part of.
        /// </summary>
        /// <param name="request">The request containing entity information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the list of memberships.</returns>
        Task<PlayFabResult<ListMembershipResponse>> ListMembershipAsync(ListMembershipRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all outstanding group applications and invitations for an entity.
        /// </summary>
        /// <param name="request">The request containing entity information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the list of membership opportunities.</returns>
        Task<PlayFabResult<ListMembershipOpportunitiesResponse>> ListMembershipOpportunitiesAsync(ListMembershipOpportunitiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes an existing application to join a group.
        /// </summary>
        /// <param name="request">The request containing group and entity information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with an empty response on success.</returns>
        Task<PlayFabResult<EmptyResponse>> RemoveGroupApplicationAsync(RemoveGroupApplicationRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes an existing invitation to join a group.
        /// </summary>
        /// <param name="request">The request containing group and entity information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with an empty response on success.</returns>
        Task<PlayFabResult<EmptyResponse>> RemoveGroupInvitationAsync(RemoveGroupInvitationRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes members from a group.
        /// </summary>
        /// <param name="request">The request containing group and member information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with an empty response on success.</returns>
        Task<PlayFabResult<EmptyResponse>> RemoveMembersAsync(RemoveMembersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unblocks entities from joining a group.
        /// </summary>
        /// <param name="request">The request containing group and entity information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with an empty response on success.</returns>
        Task<PlayFabResult<EmptyResponse>> UnblockEntityAsync(UnblockEntityRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates data about a group, such as the name or default member role.
        /// </summary>
        /// <param name="request">The request containing group update information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the group update response.</returns>
        Task<PlayFabResult<UpdateGroupResponse>> UpdateGroupAsync(UpdateGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates the name of a role within a group.
        /// </summary>
        /// <param name="request">The request containing group and role update information.</param>
        /// <param name="customData">Optional custom data for the request.</param>
        /// <param name="extraHeaders">Optional extra headers for the request.</param>
        /// <returns>A task representing the asynchronous operation, with the role update response.</returns>
        Task<PlayFabResult<UpdateGroupRoleResponse>> UpdateRoleAsync(UpdateGroupRoleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
