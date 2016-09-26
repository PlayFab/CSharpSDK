CSharpSDK README
========
1. Overview:
----
SDK for C#/.net environments other than Unity, including Microsoft CLR environments, Mono and Xamarin.


2. Prerequisites:
----
* Users should be very familiar with the topics covered in our [getting started guide](https://playfab.com/docs/getting-started-with-playfab/).

To connect to the PlayFab service, your machine must be running TLS v1.2 or better.
* For Windows, this means Windows 7 and above
* [Official Microsoft Documentation](https://msdn.microsoft.com/en-us/library/windows/desktop/aa380516%28v=vs.85%29.aspx)
* [Support for SSL/TLS protocols on Windows](http://blogs.msdn.com/b/kaushal/archive/2011/10/02/support-for-ssl-tls-protocols-on-windows.aspx)

3. Source Code & Key Repository Components:
----
This package contains three different versions of the PlayFab SDK.

* PlayFabClientSDK - This version contains only client libraries and is designed for integration with your game client
* PlayFabServerSDK - Contains server and admin APIs designed to be called from your custom logic server or build process
* PlayFabSDK - Contains all APIs in one SDK, as well as a unit-test project


4. Usage Instructions:
----
1) All users will want to download the latest SDK: https://github.com/PlayFab/CSharpSDK/releases
2) For beginners or quick evaluation, please start with the included example project, and add your own logic and api calls.  For advanced users, or users with an existing project, please copy the source from one of the SDK folders into your project.


5. A testTitleData.json file required for example UnitTestRunner project
----

This sdk includes an optional example project that is used by PlayFab to verify sdk features are fully functional.

Please read about the testTitleData.json format, and purpose here:
* https://github.com/PlayFab/SDKGenerator/blob/master/JenkinsConsoleUtility/testTitleData.md
When running the UnitTestRunner example/testing project, provide the command line inputs " -testInputsFile <file-path>".  This will read the json file at that location, and attempt to interpret it as the testTitleData.json format.


6. Troubleshooting:
----
For a complete list of available APIs, check out the [online documentation](http://api.playfab.com/Documentation/).

#### Contact Us
We love to hear from our developer community!
Do you have ideas on how we can make our products and services better?

Our Developer Success Team can assist with answering any questions as well as process any feedback you have about PlayFab services.

[Forums, Support and Knowledge Base](https://community.playfab.com/hc/en-us)


7. Copyright and Licensing Information:
----
  Apache License --
  Version 2.0, January 2004
  http://www.apache.org/licenses/

  Full details available within the LICENSE file.

