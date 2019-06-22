#if !DISABLE_PLAYFABENTITY_API

using PlayFab.GroupsModels;
using PlayFab.Internal;
using PlayFab.Json;
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
    public class PlayFabGroupsInstanceAPI
    {
        public readonly PlayFabApiSettings apiSettings = null;
        public readonly PlayFabAuthenticationContext authenticationContext = null;

        public PlayFabGroupsInstanceAPI(PlayFabAuthenticationContext context)
        {
            if (context == null)
                throw new PlayFabException(PlayFabExceptionCode.AuthContextRequired, "Context cannot be null, create a PlayFabAuthenticationContext for each player in advance, or get <PlayFabClientInstanceAPI>.authenticationContext");
            authenticationContext = context;
        }

        public PlayFabGroupsInstanceAPI(PlayFabApiSettings settings, PlayFabAuthenticationContext context)
        {
            if (context == null)
                throw new PlayFabException(PlayFabExceptionCode.AuthContextRequired, "Context cannot be null, create a PlayFabAuthenticationContext for each player in advance, or get <PlayFabClientInstanceAPI>.authenticationContext");
            apiSettings = settings;
            authenticationContext = context;
        }

        /// <summary>
        /// Verify entity login.
        /// </summary>
        public bool IsEntityLoggedIn()
        {
            return authenticationContext == null ? false : authenticationContext.IsEntityLoggedIn();
        }

        /// <summary>
        /// Clear the Client SessionToken which allows this Client to call API calls requiring login.
        /// A new/fresh login will be required after calling this.
        /// </summary>
        public void ForgetAllCredentials()
        {
            authenticationContext?.ForgetAllCredentials();
        }

        /// <summary>
        /// Accepts an outstanding invitation to to join a group
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> AcceptGroupApplicationAsync(AcceptGroupApplicationRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/AcceptGroupApplication", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Accepts an invitation to join a group
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> AcceptGroupInvitationAsync(AcceptGroupInvitationRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/AcceptGroupInvitation", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Adds members to a group or role.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> AddMembersAsync(AddMembersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/AddMembers", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Applies to join a group
        /// </summary>
        public async Task<PlayFabResult<ApplyToGroupResponse>> ApplyToGroupAsync(ApplyToGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/ApplyToGroup", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ApplyToGroupResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ApplyToGroupResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ApplyToGroupResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Blocks a list of entities from joining a group.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> BlockEntityAsync(BlockEntityRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/BlockEntity", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Changes the role membership of a list of entities from one role to another.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> ChangeMemberRoleAsync(ChangeMemberRoleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/ChangeMemberRole", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates a new group.
        /// </summary>
        public async Task<PlayFabResult<CreateGroupResponse>> CreateGroupAsync(CreateGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/CreateGroup", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateGroupResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateGroupResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateGroupResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Creates a new group role.
        /// </summary>
        public async Task<PlayFabResult<CreateGroupRoleResponse>> CreateRoleAsync(CreateGroupRoleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/CreateRole", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<CreateGroupRoleResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<CreateGroupRoleResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<CreateGroupRoleResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes a group and all roles, invitations, join requests, and blocks associated with it.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> DeleteGroupAsync(DeleteGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/DeleteGroup", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Deletes an existing role in a group.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> DeleteRoleAsync(DeleteRoleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/DeleteRole", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Gets information about a group and its roles
        /// </summary>
        public async Task<PlayFabResult<GetGroupResponse>> GetGroupAsync(GetGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/GetGroup", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<GetGroupResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<GetGroupResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<GetGroupResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Invites a player to join a group
        /// </summary>
        public async Task<PlayFabResult<InviteToGroupResponse>> InviteToGroupAsync(InviteToGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/InviteToGroup", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<InviteToGroupResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<InviteToGroupResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<InviteToGroupResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Checks to see if an entity is a member of a group or role within the group
        /// </summary>
        public async Task<PlayFabResult<IsMemberResponse>> IsMemberAsync(IsMemberRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/IsMember", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<IsMemberResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<IsMemberResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<IsMemberResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists all outstanding requests to join a group
        /// </summary>
        public async Task<PlayFabResult<ListGroupApplicationsResponse>> ListGroupApplicationsAsync(ListGroupApplicationsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/ListGroupApplications", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListGroupApplicationsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListGroupApplicationsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListGroupApplicationsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists all entities blocked from joining a group
        /// </summary>
        public async Task<PlayFabResult<ListGroupBlocksResponse>> ListGroupBlocksAsync(ListGroupBlocksRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/ListGroupBlocks", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListGroupBlocksResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListGroupBlocksResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListGroupBlocksResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists all outstanding invitations for a group
        /// </summary>
        public async Task<PlayFabResult<ListGroupInvitationsResponse>> ListGroupInvitationsAsync(ListGroupInvitationsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/ListGroupInvitations", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListGroupInvitationsResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListGroupInvitationsResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListGroupInvitationsResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists all members for a group
        /// </summary>
        public async Task<PlayFabResult<ListGroupMembersResponse>> ListGroupMembersAsync(ListGroupMembersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/ListGroupMembers", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListGroupMembersResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListGroupMembersResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListGroupMembersResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists all groups and roles for an entity
        /// </summary>
        public async Task<PlayFabResult<ListMembershipResponse>> ListMembershipAsync(ListMembershipRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/ListMembership", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListMembershipResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListMembershipResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListMembershipResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Lists all outstanding invitations and group applications for an entity
        /// </summary>
        public async Task<PlayFabResult<ListMembershipOpportunitiesResponse>> ListMembershipOpportunitiesAsync(ListMembershipOpportunitiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/ListMembershipOpportunities", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<ListMembershipOpportunitiesResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<ListMembershipOpportunitiesResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<ListMembershipOpportunitiesResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Removes an application to join a group
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> RemoveGroupApplicationAsync(RemoveGroupApplicationRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/RemoveGroupApplication", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Removes an invitation join a group
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> RemoveGroupInvitationAsync(RemoveGroupInvitationRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/RemoveGroupInvitation", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Removes members from a group.
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> RemoveMembersAsync(RemoveMembersRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/RemoveMembers", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Unblocks a list of entities from joining a group
        /// </summary>
        public async Task<PlayFabResult<EmptyResponse>> UnblockEntityAsync(UnblockEntityRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/UnblockEntity", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<EmptyResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<EmptyResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<EmptyResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Updates non-membership data about a group.
        /// </summary>
        public async Task<PlayFabResult<UpdateGroupResponse>> UpdateGroupAsync(UpdateGroupRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/UpdateGroup", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdateGroupResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdateGroupResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdateGroupResponse> { Result = result, CustomData = customData };
        }

        /// <summary>
        /// Updates metadata about a role.
        /// </summary>
        public async Task<PlayFabResult<UpdateGroupRoleResponse>> UpdateRoleAsync(UpdateGroupRoleRequest request, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            var requestSettings = apiSettings ?? PlayFabSettings.staticSettings;
            if ((request?.AuthenticationContext?.EntityToken ?? authenticationContext.EntityToken) == null) throw new PlayFabException(PlayFabExceptionCode.EntityTokenNotSet, "Must call GetEntityToken before calling this method");

            var httpResult = await PlayFabHttp.DoPost("/Group/UpdateRole", request, "X-EntityToken", authenticationContext.EntityToken, extraHeaders, requestSettings);
            if (httpResult is PlayFabError)
            {
                var error = (PlayFabError)httpResult;
                PlayFabSettings.GlobalErrorHandler?.Invoke(error);
                return new PlayFabResult<UpdateGroupRoleResponse> { Error = error, CustomData = customData };
            }

            var resultRawJson = (string)httpResult;
            var resultData = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).DeserializeObject<PlayFabJsonSuccess<UpdateGroupRoleResponse>>(resultRawJson);
            var result = resultData.data;

            return new PlayFabResult<UpdateGroupRoleResponse> { Result = result, CustomData = customData };
        }

    }
}
#endif
