using Newtonsoft.Json.Linq;
using PlayFab.ClientModels;
using PlayFab.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab.UUnit
{
    /// <summary>
    /// A real system would potentially run only the client or server API, and not both.
    /// But, they still interact with eachother directly.
    /// The tests can't be independent for Client/Server, as the sequence of calls isn't really independent for real-world scenarios.
    /// The client logs in, which triggers a server, and then back and forth.
    /// For the purpose of testing, they each have pieces of information they share with one another, and that sharing makes various calls possible.
    /// </summary>
    public class PlayFabApiTest : UUnitTestCase
    {
        private const int TEST_STAT_BASE = 10;
        private const string TEST_STAT_NAME = "str";
        private const string CHAR_TEST_TYPE = "Test";

        // Functional
        private static bool TITLE_INFO_SET = false;
        private static bool TITLE_CAN_UPDATE_SETTINGS = false;

        // Fixed values provided from testInputs
        private static string USER_NAME;
        private static string USER_EMAIL;
        private static string USER_PASSWORD;
        private static string CHAR_NAME;

        // Information fetched by appropriate API calls
        private static string playFabId;

        /// <summary>
        /// PlayFab Title cannot be created from SDK tests, so you must provide your titleId to run unit tests.
        /// (Also, we don't want lots of excess unused titles)
        /// </summary>
        public static void SetTitleInfo(Dictionary<string, string> testInputs)
        {
            string eachValue;

            TITLE_INFO_SET = true;

            // Parse all the inputs
            TITLE_INFO_SET &= testInputs.TryGetValue("titleId", out eachValue);
            PlayFabSettings.TitleId = eachValue;
            TITLE_INFO_SET &= testInputs.TryGetValue("developerSecretKey", out eachValue);
            PlayFabSettings.DeveloperSecretKey = eachValue;

            TITLE_INFO_SET &= testInputs.TryGetValue("titleCanUpdateSettings", out eachValue);
            TITLE_INFO_SET &= bool.TryParse(eachValue, out TITLE_CAN_UPDATE_SETTINGS);

            TITLE_INFO_SET &= testInputs.TryGetValue("userName", out USER_NAME);
            TITLE_INFO_SET &= testInputs.TryGetValue("userEmail", out USER_EMAIL);
            TITLE_INFO_SET &= testInputs.TryGetValue("userPassword", out USER_PASSWORD);

            TITLE_INFO_SET &= testInputs.TryGetValue("characterName", out CHAR_NAME);

            // Verify all the inputs won't cause crashes in the tests
            TITLE_INFO_SET &= !string.IsNullOrEmpty(PlayFabSettings.TitleId)
                && !string.IsNullOrEmpty(PlayFabSettings.DeveloperSecretKey)
                && !string.IsNullOrEmpty(USER_NAME)
                && !string.IsNullOrEmpty(USER_EMAIL)
                && !string.IsNullOrEmpty(USER_PASSWORD)
                && !string.IsNullOrEmpty(CHAR_NAME);
        }

        protected override void SetUp()
        {
            if (!TITLE_INFO_SET)
                UUnitAssert.Skip(); // We cannot do client tests if the titleId is not given
        }

        protected override void TearDown()
        {
        }

        private static void WaitForResultSuccess<TResult>(Task<PlayFabResult<TResult>> task, string failMessage) where TResult : PlayFabResultCommon
        {
            task.Wait();
            UUnitAssert.NotNull(task.Result, failMessage);
            UUnitAssert.IsNull(task.Result.Error, failMessage);
            UUnitAssert.NotNull(task.Result.Result, failMessage);
        }

        private static string CompileErrorReport(PlayFabError error)
        {
            string fullReport = error.ErrorMessage;
            foreach (var detailPair in error.ErrorDetails)
                foreach (var msg in detailPair.Value)
                    fullReport += "\n" + detailPair.Key + ": " + msg;
            return fullReport;
        }

        /// <summary>
        /// CLIENT API
        /// Try to deliberately log in with an inappropriate password,
        ///   and verify that the error displays as expected.
        /// </summary>
        [UUnitTest]
        public void InvalidLogin()
        {
            // If the setup failed to log in a user, we need to create one.
            var request = new LoginWithEmailAddressRequest();
            request.TitleId = PlayFabSettings.TitleId;
            request.Email = USER_EMAIL;
            request.Password = USER_PASSWORD + "INVALID";
            var task = PlayFabClientAPI.LoginWithEmailAddressAsync(request);
            task.Wait();
            UUnitAssert.NotNull(task.Result);
            UUnitAssert.IsNull(task.Result.Result);
            UUnitAssert.NotNull(task.Result.Error);
            UUnitAssert.True(task.Result.Error.ErrorMessage.Contains("password"), task.Result.Error.ErrorMessage);
        }

        /// <summary>
        /// CLIENT API
        /// Try to deliberately register a user with an invalid email and password
        ///   Verify that errorDetails are populated correctly.
        /// </summary>
        [UUnitTest]
        public void InvalidRegistration()
        {
            var registerRequest = new RegisterPlayFabUserRequest();
            registerRequest.TitleId = PlayFabSettings.TitleId;
            registerRequest.Username = "x";
            registerRequest.Email = "x";
            registerRequest.Password = "x";
            var registerTask = PlayFabClientAPI.RegisterPlayFabUserAsync(registerRequest);
            UUnitAssert.NotNull(registerTask.Result);
            UUnitAssert.IsNull(registerTask.Result.Result);
            UUnitAssert.NotNull(registerTask.Result.Error);

            var expectedEmailMsg = "email address is not valid.";
            var expectedPasswordMsg = "password must be between";
            var fullReport = CompileErrorReport(registerTask.Result.Error);

            UUnitAssert.True(fullReport.ToLower().Contains(expectedEmailMsg), "Expected an error about bad email address: " + fullReport);
            UUnitAssert.True(fullReport.ToLower().Contains(expectedPasswordMsg), "Expected an error about bad password: " + fullReport);
        }

        /// <summary>
        /// CLIENT API
        /// Log in or create a user, track their PlayFabId
        /// </summary>
        [UUnitTest]
        public void LoginOrRegister()
        {
            var loginRequest = new LoginWithCustomIDRequest
            {
                TitleId = PlayFabSettings.TitleId,
                CustomId = PlayFabSettings.BuildIdentifier,
                CreateAccount = true
            };
            var loginTask = PlayFabClientAPI.LoginWithCustomIDAsync(loginRequest);
            WaitForResultSuccess(loginTask, "Login with advertId failed");
            loginTask.Wait(); // We don't care about success or fail here

            playFabId = loginTask.Result.Result.PlayFabId; // Needed for subsequent tests

            UUnitAssert.True(PlayFabClientAPI.IsClientLoggedIn(), "User login failed");
        }

        /// <summary>
        /// CLIENT API
        /// Test that the login call sequence sends the AdvertisingId when set
        /// </summary>
        [UUnitTest]
        public void LoginWithAdvertisingId()
        {
            PlayFabSettings.AdvertisingIdType = PlayFabSettings.AD_TYPE_ANDROID_ID;
            PlayFabSettings.AdvertisingIdValue = "PlayFabTestId";

            var loginRequest = new LoginWithCustomIDRequest
            {
                TitleId = PlayFabSettings.TitleId,
                CustomId = PlayFabSettings.BuildIdentifier,
                CreateAccount = true
            };
            var loginTask = PlayFabClientAPI.LoginWithCustomIDAsync(loginRequest);
            WaitForResultSuccess(loginTask, "Login with advertId failed");
            loginTask.Wait(); // We don't care about success or fail here

            UUnitAssert.StringEquals(PlayFabSettings.AD_TYPE_ANDROID_ID + "_Successful", PlayFabSettings.AdvertisingIdType);
        }

        /// <summary>
        /// CLIENT API
        /// Test a sequence of calls that modifies saved data,
        ///   and verifies that the next sequential API call contains updated data.
        /// Verify that the data is correctly modified on the next call.
        /// Parameter types tested: string, Dictionary<string, string>, DateTime
        /// </summary>
        [UUnitTest]
        public void UserDataApi()
        {
            string TEST_KEY = "testCounter";

            UserDataRecord testCounter;
            int testCounterValueExpected, testCounterValueActual;

            var getRequest = new GetUserDataRequest();
            var getDataTask1 = PlayFabClientAPI.GetUserDataAsync(getRequest);
            WaitForResultSuccess(getDataTask1, "UserData should have been retrieved from Api call");
            if (!getDataTask1.Result.Result.Data.TryGetValue(TEST_KEY, out testCounter))
            {
                testCounter = new UserDataRecord();
                testCounter.Value = "0";
            }
            int.TryParse(testCounter.Value, out testCounterValueExpected);
            testCounterValueExpected = (testCounterValueExpected + 1) % 100; // This test is about the expected value changing - but not testing more complicated issues like bounds

            var updateRequest = new UpdateUserDataRequest();
            updateRequest.Data = new Dictionary<string, string>();
            updateRequest.Data[TEST_KEY] = testCounterValueExpected.ToString();
            var updateTask = PlayFabClientAPI.UpdateUserDataAsync(updateRequest);
            WaitForResultSuccess(updateTask, "UpdateUserData call failed"); // The update doesn't return anything interesting except versionID.  It's better to just re-call GetUserData again below to verify the update

            getRequest = new GetUserDataRequest();
            var getDataTask2 = PlayFabClientAPI.GetUserDataAsync(getRequest);
            WaitForResultSuccess(getDataTask2, "UserData should have been retrieved from Api call");
            getDataTask2.Result.Result.Data.TryGetValue(TEST_KEY, out testCounter);
            UUnitAssert.NotNull(testCounter, "The updated UserData was not found in the Api results");
            int.TryParse(testCounter.Value, out testCounterValueActual);
            UUnitAssert.IntEquals(testCounterValueExpected, testCounterValueActual);

            var timeUpdated = testCounter.LastUpdated;
            var testMin = DateTime.UtcNow - TimeSpan.FromMinutes(5);
            var testMax = testMin + TimeSpan.FromMinutes(10);
            UUnitAssert.True(testMin <= timeUpdated && timeUpdated <= testMax);
        }

        /// <summary>
        /// CLIENT API
        /// Test a sequence of calls that modifies saved data,
        ///   and verifies that the next sequential API call contains updated data.
        /// Verify that the data is saved correctly, and that specific types are tested
        /// Parameter types tested: Dictionary<string, int> 
        /// </summary>
        [UUnitTest]
        public void UserStatisticsApi()
        {
            int testStatExpected, testStatActual;

            var getRequest = new GetUserStatisticsRequest();
            var getStatTask1 = PlayFabClientAPI.GetUserStatisticsAsync(getRequest);
            WaitForResultSuccess(getStatTask1, "UserStatistics should have been retrieved from Api call");
            if (!getStatTask1.Result.Result.UserStatistics.TryGetValue(TEST_STAT_NAME, out testStatExpected))
                testStatExpected = TEST_STAT_BASE;
            testStatExpected = ((testStatExpected + 1) % TEST_STAT_BASE) + TEST_STAT_BASE; // This test is about the expected value changing (incrementing through from TEST_STAT_BASE to TEST_STAT_BASE * 2 - 1)

            var updateRequest = new UpdateUserStatisticsRequest();
            updateRequest.UserStatistics = new Dictionary<string, int>();
            updateRequest.UserStatistics[TEST_STAT_NAME] = testStatExpected;
            var updateTask = PlayFabClientAPI.UpdateUserStatisticsAsync(updateRequest);
            WaitForResultSuccess(updateTask, "UpdateUserStatistics failed");

            getRequest = new GetUserStatisticsRequest();
            var getStatTask2 = PlayFabClientAPI.GetUserStatisticsAsync(getRequest);
            WaitForResultSuccess(getStatTask2, "UserStatistics should have been retrieved from Api call");
            getStatTask2.Result.Result.UserStatistics.TryGetValue(TEST_STAT_NAME, out testStatActual);
            UUnitAssert.IntEquals(testStatExpected, testStatActual);
        }

        /// <summary>
        /// SERVER API
        /// Get or create the given test character for the given user
        /// Parameter types tested: Contained-Classes, string
        /// </summary>
        [UUnitTest]
        public void UserCharacter()
        {
            var request = new ServerModels.ListUsersCharactersRequest();
            request.PlayFabId = playFabId; // Received from client upon login
            var getCharsTask = PlayFabServerAPI.GetAllUsersCharactersAsync(request);
            WaitForResultSuccess(getCharsTask, "Failed to GetChars");

            ServerModels.CharacterResult targetCharacter = null;
            foreach (var eachCharacter in getCharsTask.Result.Result.Characters)
                if (eachCharacter.CharacterName == CHAR_NAME)
                    targetCharacter = eachCharacter;

            if (targetCharacter == null)
            {
                // Create the targetCharacter since it doesn't exist
                var grantRequest = new ServerModels.GrantCharacterToUserRequest();
                grantRequest.PlayFabId = playFabId;
                grantRequest.CharacterName = CHAR_NAME;
                grantRequest.CharacterType = CHAR_TEST_TYPE;
                var grantTask = PlayFabServerAPI.GrantCharacterToUserAsync(grantRequest);
                WaitForResultSuccess(grantTask, "Grant character failed");

                // Attempt to get characters again
                getCharsTask = PlayFabServerAPI.GetAllUsersCharactersAsync(request);
                WaitForResultSuccess(getCharsTask, "Failed to GetChars");
                foreach (var eachCharacter in getCharsTask.Result.Result.Characters)
                    if (eachCharacter.CharacterName == CHAR_NAME)
                        targetCharacter = eachCharacter;
            }

            // Save the requested character
            UUnitAssert.NotNull(targetCharacter, "The test character did not exist, and was not successfully created");
        }

        /// <summary>
        /// CLIENT AND SERVER API
        /// Test that leaderboard results can be requested
        /// Parameter types tested: List of contained-classes
        /// </summary>
        [UUnitTest]
        public void LeaderBoard()
        {
            var clientRequest = new GetLeaderboardRequest();
            clientRequest.MaxResultsCount = 3;
            clientRequest.StatisticName = TEST_STAT_NAME;
            var clientTask = PlayFabClientAPI.GetLeaderboardAsync(clientRequest);
            WaitForResultSuccess(clientTask, "Failed to get client leaderboard");
            UUnitAssert.True(clientTask.Result.Result.Leaderboard.Count > 0, "Leaderboard does not contain enough entries.");

            var serverRequest = new ServerModels.GetLeaderboardRequest();
            serverRequest.MaxResultsCount = 3;
            serverRequest.StatisticName = TEST_STAT_NAME;
            var serverTask = PlayFabServerAPI.GetLeaderboardAsync(serverRequest);
            WaitForResultSuccess(serverTask, "Failed to get server leaderboard");
            UUnitAssert.True(serverTask.Result.Result.Leaderboard.Count > 0, "Leaderboard does not contain enough entries.");
        }

        /// <summary>
        /// CLIENT API
        /// Test that AccountInfo can be requested
        /// Parameter types tested: List of enum-as-strings converted to list of enums
        /// </summary>
        [UUnitTest]
        public void AccountInfo()
        {
            GetAccountInfoRequest request = new GetAccountInfoRequest();
            request.PlayFabId = playFabId;
            var task = PlayFabClientAPI.GetAccountInfoAsync(request);
            WaitForResultSuccess(task, "Failed to get accountInfo");
            UUnitAssert.True(Enum.IsDefined(typeof(UserOrigination), task.Result.Result.AccountInfo.TitleInfo.Origination.Value), "Origination Enum not valid");
        }

        /// <summary>
        /// CLIENT API
        /// Test that CloudScript can be properly set up and invoked
        /// </summary>
        [UUnitTest]
        public void CloudScript()
        {
            var request = new ExecuteCloudScriptRequest();
            request.FunctionName = "helloWorld";
            var cloudTask = PlayFabClientAPI.ExecuteCloudScriptAsync(request);
            WaitForResultSuccess(cloudTask, "Failed to Execute CloudScript");

            // Get the helloWorld return message
            JObject jobj = cloudTask.Result.Result.FunctionResult as JObject;
            UUnitAssert.NotNull(jobj);
            JToken jtok;
            jobj.TryGetValue("messageValue", out jtok);
            UUnitAssert.NotNull(jtok);
            JValue jval = jtok as JValue;
            UUnitAssert.NotNull(jval);
            string actualMessage = jval.Value as string;
            UUnitAssert.StringEquals("Hello " + playFabId + "!", actualMessage);
        }

        /// <summary>
        /// CLIENT API
        /// Test that the client can publish custom PlayStream events
        /// </summary>
        [UUnitTest]
        public void WriteEvent()
        {
            var request = new WriteClientPlayerEventRequest();
            request.EventName = "ForumPostEvent";
            request.Timestamp = DateTime.UtcNow;
            request.Body = new Dictionary<string, object>();
            request.Body["Subject"] = "My First Post";
            request.Body["Body"] = "My awesome post.";

            var writeTask = PlayFabClientAPI.WritePlayerEventAsync(request);
            WaitForResultSuccess(writeTask, "PlayStream WriteEvent failed");
        }
    }
}
