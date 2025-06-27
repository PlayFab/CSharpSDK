#if !DISABLE_PLAYFABENTITY_API

using PlayFab.GroupsModels;
using PlayFab.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    /// <summary>
    /// The Groups API is designed for any permanent or semi-permanent collections of Entities (players, or non-players). If you
    /// want to make Guilds/Clans/Corporations/etc., then you should use groups. Groups can also be used to make chatrooms,
    /// parties, or any other persistent collection of entities.
    /// </summary>
    public interface IPlayFabGroupsInstanceAPI
    {
        /// <summary>
        /// Accepts an outstanding invitation to to join a group
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> AcceptGroupApplicationAsync(
            AcceptGroupApplicationRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Accepts an invitation to join a group
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> AcceptGroupInvitationAsync(
            AcceptGroupInvitationRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Adds members to a group or role.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> AddMembersAsync(
            AddMembersRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Applies to join a group
        /// </summary>
        Task<PlayFabResult<ApplyToGroupResponse>> ApplyToGroupAsync(
            ApplyToGroupRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Blocks a list of entities from joining a group.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> BlockEntityAsync(
            BlockEntityRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Changes the role membership of a list of entities from one role to another.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> ChangeMemberRoleAsync(
            ChangeMemberRoleRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a new group.
        /// </summary>
        Task<PlayFabResult<CreateGroupResponse>> CreateGroupAsync(
            CreateGroupRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Creates a new group role.
        /// </summary>
        Task<PlayFabResult<CreateGroupRoleResponse>> CreateRoleAsync(
            CreateGroupRoleRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes a group and all roles, invitations, join requests, and blocks associated with it.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteGroupAsync(
            DeleteGroupRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Deletes an existing role in a group.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> DeleteRoleAsync(
            DeleteRoleRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Gets information about a group and its roles
        /// </summary>
        Task<PlayFabResult<GetGroupResponse>> GetGroupAsync(
            GetGroupRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Invites a player to join a group
        /// </summary>
        Task<PlayFabResult<InviteToGroupResponse>> InviteToGroupAsync(
            InviteToGroupRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Checks to see if an entity is a member of a group or role within the group
        /// </summary>
        Task<PlayFabResult<IsMemberResponse>> IsMemberAsync(
            IsMemberRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all outstanding requests to join a group
        /// </summary>
        Task<PlayFabResult<ListGroupApplicationsResponse>> ListGroupApplicationsAsync(
            ListGroupApplicationsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all entities blocked from joining a group
        /// </summary>
        Task<PlayFabResult<ListGroupBlocksResponse>> ListGroupBlocksAsync(
            ListGroupBlocksRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all outstanding invitations for a group
        /// </summary>
        Task<PlayFabResult<ListGroupInvitationsResponse>> ListGroupInvitationsAsync(
            ListGroupInvitationsRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all members for a group
        /// </summary>
        Task<PlayFabResult<ListGroupMembersResponse>> ListGroupMembersAsync(
            ListGroupMembersRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all groups and roles for an entity
        /// </summary>
        Task<PlayFabResult<ListMembershipResponse>> ListMembershipAsync(
            ListMembershipRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Lists all outstanding invitations and group applications for an entity
        /// </summary>
        Task<PlayFabResult<ListMembershipOpportunitiesResponse>> ListMembershipOpportunitiesAsync(
            ListMembershipOpportunitiesRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes an application to join a group
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> RemoveGroupApplicationAsync(
            RemoveGroupApplicationRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes an invitation join a group
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> RemoveGroupInvitationAsync(
            RemoveGroupInvitationRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Removes members from a group.
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> RemoveMembersAsync(
            RemoveMembersRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Unblocks a list of entities from joining a group
        /// </summary>
        Task<PlayFabResult<EmptyResponse>> UnblockEntityAsync(
            UnblockEntityRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates non-membership data about a group.
        /// </summary>
        Task<PlayFabResult<UpdateGroupResponse>> UpdateGroupAsync(
            UpdateGroupRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);

        /// <summary>
        /// Updates metadata about a role.
        /// </summary>
        Task<PlayFabResult<UpdateGroupRoleResponse>> UpdateRoleAsync(
            UpdateGroupRoleRequest request,
            object customData = null,
            Dictionary<string, string> extraHeaders = null);
    }
}
#endif
