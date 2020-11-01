using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class CopyPackageFiles : EditorWindow
    {
        private const string SdkSourceFolderPath = @"PlayFabSDK/source";
        private const string LicenseFile = "LICENSE*";
        private const string ReadmeFile = "README*";
        private const string PackageFolderPath = @"Packages/com.playfab.csharpskd";
        private const string SourceFolderPath = @"Runtime/source";

        private static CopyPackageFiles _window;

        [MenuItem("PlayFabSdkPackage/Copy Package Files")]
        private static void Init()
        {
            _window = (CopyPackageFiles) GetWindow(typeof(CopyPackageFiles));
            _window.Show();
        }

        private void OnGUI()
        {
            if (_window == null)
            {
                Init();
            }

            GUILayout.BeginVertical();

            var rootPathDir = GetDirectoryInfo(Application.dataPath, @"..\..\");
            if (PrintPathIfExists("Root dir", rootPathDir) == false)
            {
                return;
            }

            var licenceFile = GetSingleFileInfo(rootPathDir, LicenseFile);
            if (PrintPathIfExists("License", licenceFile) == false)
            {
                return;
            }
            
            var readmeFile = GetSingleFileInfo(rootPathDir, ReadmeFile);
            if (PrintPathIfExists("Readme", readmeFile) == false)
            {
                return;
            }
            
            GUILayout.Space(10);
            
            var sourceDir = GetDirectoryInfo(rootPathDir.FullName, SdkSourceFolderPath);
            if (PrintPathIfExists("Source dir", sourceDir) == false)
            {
                return;
            }
            
            GUILayout.Space(10);

            var packageDir = GetDirectoryInfo(Application.dataPath, @"..\", PackageFolderPath);
            if (PrintPathIfExists("Package dir", packageDir) == false)
            {
                return;
            }
            
            var packageSourceDir = GetDirectoryInfo(packageDir.FullName, SourceFolderPath);
            if (PrintPathIfExists("Package source dir", packageSourceDir) == false)
            {
                return;
            }
            
            GUILayout.Space(10);
            
            if (GUILayout.Button("Copy sdk source to package source"))
            {
                CopyFilesToDir(packageDir, licenceFile, readmeFile);
                CopyDirectory(sourceDir, packageSourceDir);
            }

            GUILayout.EndVertical();
        }

        private DirectoryInfo GetDirectoryInfo(params string[] paths)
        {
            var path = Path.Combine(paths);
            return new DirectoryInfo(path);
        }

        private bool PrintPathIfExists(string label, FileSystemInfo fileSystemInfo)
        {
            if (fileSystemInfo.Exists)
            {
                GUILayout.Label($"{label}: {fileSystemInfo.FullName}");
                return true;
            }

            GUILayout.Label($"{label} does not exist");
            return false;
        }

        private FileInfo GetSingleFileInfo(DirectoryInfo directoryInfo, string fileName)
        {
            var files = directoryInfo.GetFiles(fileName);
            var file = files.SingleOrDefault();
            return file;
        }

        private void CopyFilesToDir(DirectoryInfo directoryInfo, params FileInfo[] files)
        {
            foreach (var fileInfo in files)
            {
                var newFilePath = Path.Combine(directoryInfo.FullName, fileInfo.Name);
                
                fileInfo.CopyTo(newFilePath,true);
            }
        }

        private void CopyDirectory(DirectoryInfo from, DirectoryInfo to)
        {
            ClearDirectory(to);

            // Copy each file into the new directory.
            foreach (FileInfo fileInfo in from.GetFiles())
            {
                fileInfo.CopyTo(Path.Combine(to.FullName, fileInfo.Name), true);
            }
 
            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo fromSubDirs in from.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    to.CreateSubdirectory(fromSubDirs.Name);
                CopyDirectory(fromSubDirs, nextTargetSubDir);
            }
        }

        private void ClearDirectory(DirectoryInfo directoryInfo)
        {
            foreach (FileInfo file in directoryInfo.EnumerateFiles())
            {
                file.Delete(); 
            }
            foreach (DirectoryInfo dir in directoryInfo.EnumerateDirectories())
            {
                dir.Delete(true); 
            }
        }
        
    }
}