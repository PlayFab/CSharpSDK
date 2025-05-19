using PlayFab.GroupsModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    public interface IPlayFabGroupsInstanceAPI
    {
        bool IsEntityLoggedIn();
        void ForgetAllCredentials();
        Task<PlayFabResult<EmptyResponse>> AcceptGroupApplicationAsync(AcceptGroupApplicationRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> AcceptGroupInvitationAsync(AcceptGroupInvitationRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> AddMembersAsync(AddMembersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<ApplyToGroupResponse>> ApplyToGroupAsync(ApplyToGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> BlockEntityAsync(BlockEntityRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> ChangeMemberRoleAsync(ChangeMemberRoleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<CreateGroupResponse>> CreateGroupAsync(CreateGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<CreateGroupRoleResponse>> CreateRoleAsync(CreateGroupRoleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> DeleteGroupAsync(DeleteGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> DeleteRoleAsync(DeleteRoleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetGroupResponse>> GetGroupAsync(GetGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<InviteToGroupResponse>> InviteToGroupAsync(InviteToGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<IsMemberResponse>> IsMemberAsync(IsMemberRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<ListGroupApplicationsResponse>> ListGroupApplicationsAsync(ListGroupApplicationsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<ListGroupBlocksResponse>> ListGroupBlocksAsync(ListGroupBlocksRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<ListGroupInvitationsResponse>> ListGroupInvitationsAsync(ListGroupInvitationsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<ListGroupMembersResponse>> ListGroupMembersAsync(ListGroupMembersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<ListMembershipResponse>> ListMembershipAsync(ListMembershipRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<ListMembershipOpportunitiesResponse>> ListMembershipOpportunitiesAsync(ListMembershipOpportunitiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> RemoveGroupApplicationAsync(RemoveGroupApplicationRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> RemoveGroupInvitationAsync(RemoveGroupInvitationRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> RemoveMembersAsync(RemoveMembersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> UnblockEntityAsync(UnblockEntityRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<UpdateGroupResponse>> UpdateGroupAsync(UpdateGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<UpdateGroupRoleResponse>> UpdateRoleAsync(UpdateGroupRoleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
