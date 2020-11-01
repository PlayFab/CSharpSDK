using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using PlayFab.ClientModels;

namespace PlayFab
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class Unordered : Attribute
    {
        public string SortProperty { get; set; }

        public Unordered() { }

        public Unordered(string sortProperty)
        {
            SortProperty = sortProperty;
        }
    }

    public static partial class PlayFabUtil
    {
#pragma warning disable 0414
        private static string _localSettingsFileName = "playfab.local.settings.json";
#pragma warning restore 0414
        public static readonly string[] DefaultDateTimeFormats = { // All parseable ISO 8601 formats for DateTime.[Try]ParseExact - Lets us deserialize any legacy timestamps in one of these formats
            // These are the standard format with ISO 8601 UTC markers (T/Z)
            "yyyy-MM-ddTHH:mm:ss.FFFFFFZ",
            "yyyy-MM-ddTHH:mm:ss.FFFFZ",
            "yyyy-MM-ddTHH:mm:ss.FFFZ", // DEFAULT_UTC_OUTPUT_INDEX
            "yyyy-MM-ddTHH:mm:ss.FFZ",
            "yyyy-MM-ddTHH:mm:ssZ",

            // These are the standard format without ISO 8601 UTC markers (T/Z)
            "yyyy-MM-dd HH:mm:ss.FFFFFF",
            "yyyy-MM-dd HH:mm:ss.FFFF",
            "yyyy-MM-dd HH:mm:ss.FFF", // DEFAULT_LOCAL_OUTPUT_INDEX
            "yyyy-MM-dd HH:mm:ss.FF",
            "yyyy-MM-dd HH:mm:ss",
        };
        public const int DEFAULT_UTC_OUTPUT_INDEX = 2; // The default format everybody should use
        public const int DEFAULT_LOCAL_OUTPUT_INDEX = 7; // The default format if you want to use local time (This doesn't have universal support in all PlayFab code)

        public static string GenerateErrorReport(PlayFabError error)
        {
            if (error == null)
                return null;
            return error.GenerateErrorReport();
        }

#if NET45 || NETSTANDARD2_0
        [ThreadStatic]
        private static StringBuilder _sb;
        /// <summary>
        /// A threadsafe way to block and load a text file
        /// 
        /// Load a text file, and return the file as text.
        /// Used for small (usually json) files.
        /// </summary>
        private static string ReadAllFileText(string filename)
        {
            if (!File.Exists(filename))
            {
                return string.Empty;
            }

            if (_sb == null)
            {
                _sb = new StringBuilder();
            }
            _sb.Length = 0;

            using (var fs = new FileStream(filename, FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    while (br.BaseStream.Position != br.BaseStream.Length)
                    {
                        _sb.Append(br.ReadChar());
                    }
                }
            }
            return _sb.ToString();
        }

        internal static LocalSettingsFile GetLocalSettingsFile()
        {
            string envFileContent = null;
            string currDir = Directory.GetCurrentDirectory();
            string currDirEnvFile = Path.Combine(currDir, _localSettingsFileName);

            if (File.Exists(currDirEnvFile))
            {
                envFileContent = ReadAllFileText(currDirEnvFile);
            }
            else
            {
                string tempDir = Path.GetTempPath();
                string tempDirEnvFile = Path.Combine(tempDir, _localSettingsFileName);

                if (File.Exists(tempDirEnvFile))
                {
                    envFileContent = ReadAllFileText(tempDirEnvFile);
                }
            }

            if (!string.IsNullOrEmpty(envFileContent))
            {
                var jsonPlugin = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer);
                return jsonPlugin.DeserializeObject<LocalSettingsFile>(envFileContent);
            }

            return new LocalSettingsFile();
        }

        internal class LocalSettingsFile
        {
            public string LocalApiServer { get; set; }
        }
#endif

        private static readonly StringBuilder Sb = new StringBuilder();
        public static string GetCloudScriptErrorReport(PlayFabResult<ExecuteCloudScriptResult> result)
        {
            if (result.Error != null)
                return result.Error.GenerateErrorReport();
            if (result.Result.Error == null)
                return null;

            Sb.Length = 0;
            var hasError = !string.IsNullOrEmpty(result.Result.Error.Error);
            var hasMsg = !string.IsNullOrEmpty(result.Result.Error.Message);
            if (hasError)
                Sb.Append(result.Result.Error.Error);
            if (hasError && hasMsg)
                Sb.Append(" - ");
            if (hasMsg)
                Sb.Append(result.Result.Error.Message);

            var jsonPlugin = PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer);
            foreach (var eachLog in result.Result.Logs)
            {
                if (Sb.Length > 0)
                    Sb.Append("\n");
                Sb.Append(eachLog.Level);
                if (!string.IsNullOrEmpty(eachLog.Message))
                    Sb.Append(" - ").Append(eachLog.Message);
                if (eachLog.Data != null)
                    Sb.Append("\n").Append(jsonPlugin.SerializeObject(eachLog.Data));
            }
            return Sb.ToString();
        }

        public struct SynchronizationContextRemover : INotifyCompletion
        {
            public bool IsCompleted
            {
                get
                {
                    return SynchronizationContext.Current == null;
                }
            }

            public void OnCompleted(Action continuation)
            {
                var prevContext = SynchronizationContext.Current;
                try
                {
                    SynchronizationContext.SetSynchronizationContext(null);
                    continuation();
                }
                finally
                {
                    SynchronizationContext.SetSynchronizationContext(prevContext);
                }
            }

            public SynchronizationContextRemover GetAwaiter()
            {
                return this;
            }

            public void GetResult()
            {
            }
        }
    }
}
