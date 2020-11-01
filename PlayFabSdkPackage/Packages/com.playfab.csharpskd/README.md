# CSharpSDK README


## 1. Overview:

SDK for C#/.net environments other than Unity, including Microsoft CLR environments, Mono and Xamarin.


## 2. Prerequisites:

* Users should be very familiar with the topics covered in our [getting started guide](https://api.playfab.com/docs/general-getting-started).

To connect to the PlayFab service, your machine must be running TLS v1.2 or better.
* For Windows, this means Windows 7 and above
* [Official Microsoft Documentation](https://msdn.microsoft.com/en-us/library/windows/desktop/aa380516%28v=vs.85%29.aspx)
* [Support for SSL/TLS protocols on Windows](http://blogs.msdn.com/b/kaushal/archive/2011/10/02/support-for-ssl-tls-protocols-on-windows.aspx)

## 3. Source Code & Key Repository Components:

This package contains three different versions of the PlayFab SDK.

* PlayFabClientSDK - This version contains only client libraries and is designed for integration with your game client
* PlayFabServerSDK - Contains server and admin APIs designed to be called from your custom logic server or build process
* PlayFabSDK - Contains all APIs in one SDK, as well as a unit-test project


## 4. Usage Instructions:

1. Most users will want to use our [NuGet SDK](https://www.nuget.org/packages/PlayFabAllSDK/)
    1. You can search "PlayFab" in Visual Studio 2017, NuGet package manager, and find "PlayFabAllSDK", which is our CSharp SDK.
1. Advanced users can download the latest SDK source: https://github.com/PlayFab/CSharpSDK/releases
1. Follow the steps in our [Getting Started Guide](https://api.playfab.com/docs/getting-started/csharp-getting-started) from there


## 5. A testTitleData.json file required for example UnitTestRunner project

This sdk includes an optional example project that is used by PlayFab to verify sdk features are fully functional.

Please read about the testTitleData.json format, and purpose here:
* https://github.com/PlayFab/SDKGenerator/blob/master/JenkinsConsoleUtility/testTitleData.md
When running the UnitTestRunner example/testing project, provide the command line inputs " -testInputsFile <file-path>".  This will read the json file at that location, and attempt to interpret it as the testTitleData.json format.


## 6. Troubleshooting:

For a complete list of available APIs, check out the [online documentation](http://api.playfab.com/Documentation/).

#### Contact Us
We love to hear from our developer community!
Do you have ideas on how we can make our products and services better?

Our Developer Success Team can assist with answering any questions as well as process any feedback you have about PlayFab services.

[Forums, Support and Knowledge Base](https://community.playfab.com/index.html)


## 7. Copyright and Licensing Information:

  Apache License --
  Version 2.0, January 2004
  http://www.apache.org/licenses/

  Full details available within the LICENSE file.

