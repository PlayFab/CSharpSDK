using PlayFab.ProgressionModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab
{
    public interface IPlayFabProgressionInstanceAPI
    {
        bool IsEntityLoggedIn();
        void ForgetAllCredentials();
        Task<PlayFabResult<EmptyResponse>> CreateLeaderboardDefinitionAsync(CreateLeaderboardDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> CreateStatisticDefinitionAsync(CreateStatisticDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> DeleteLeaderboardDefinitionAsync(DeleteLeaderboardDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> DeleteLeaderboardEntriesAsync(DeleteLeaderboardEntriesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> DeleteStatisticDefinitionAsync(DeleteStatisticDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<DeleteStatisticsResponse>> DeleteStatisticsAsync(DeleteStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetEntityLeaderboardResponse>> GetFriendLeaderboardForEntityAsync(GetFriendLeaderboardForEntityRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetEntityLeaderboardResponse>> GetLeaderboardAsync(GetEntityLeaderboardRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetEntityLeaderboardResponse>> GetLeaderboardAroundEntityAsync(GetLeaderboardAroundEntityRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetLeaderboardDefinitionResponse>> GetLeaderboardDefinitionAsync(GetLeaderboardDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetEntityLeaderboardResponse>> GetLeaderboardForEntitiesAsync(GetLeaderboardForEntitiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetStatisticDefinitionResponse>> GetStatisticDefinitionAsync(GetStatisticDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetStatisticsResponse>> GetStatisticsAsync(GetStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<GetStatisticsForEntitiesResponse>> GetStatisticsForEntitiesAsync(GetStatisticsForEntitiesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<IncrementLeaderboardVersionResponse>> IncrementLeaderboardVersionAsync(IncrementLeaderboardVersionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<IncrementStatisticVersionResponse>> IncrementStatisticVersionAsync(IncrementStatisticVersionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<ListLeaderboardDefinitionsResponse>> ListLeaderboardDefinitionsAsync(ListLeaderboardDefinitionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<ListStatisticDefinitionsResponse>> ListStatisticDefinitionsAsync(ListStatisticDefinitionsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> UnlinkLeaderboardFromStatisticAsync(UnlinkLeaderboardFromStatisticRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> UpdateLeaderboardDefinitionAsync(UpdateLeaderboardDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> UpdateLeaderboardEntriesAsync(UpdateLeaderboardEntriesRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<EmptyResponse>> UpdateStatisticDefinitionAsync(UpdateStatisticDefinitionRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
        Task<PlayFabResult<UpdateStatisticsResponse>> UpdateStatisticsAsync(UpdateStatisticsRequest request, object customData = null, Dictionary<string, string> extraHeaders = null);
    }
}
