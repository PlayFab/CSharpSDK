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


#### NuGet

https://www.nuget.org/packages/PlayFabAllSDK/


4. Usage Instructions:
----
#### Current Status:
[![Build status](https://ci.appveyor.com/api/projects/status/n3aw3s8jpgx9bhbq?svg=true)](https://ci.appveyor.com/project/MattAugustine/csharpsdk-jrl6i)


Full:

https://playfab-csharp-sdk-builds.s3-us-west-2.amazonaws.com/PlayFabSDK/bin/Release/PlayFabAllSDK.dll
https://playfab-csharp-sdk-builds.s3-us-west-2.amazonaws.com/PlayFabSDK/bin/Release/PlayFabAllSDK.pdb

Client:

https://playfab-csharp-sdk-builds.s3-us-west-2.amazonaws.com/PlayFabClientSDK/bin/Release/PlayFabClientSDK.dll
https://playfab-csharp-sdk-builds.s3-us-west-2.amazonaws.com/PlayFabClientSDK/bin/Release/PlayFabClientSDK.pdb

Server:

https://playfab-csharp-sdk-builds.s3-us-west-2.amazonaws.com/PlayFabServerSDK/bin/Release/PlayFabServerSDK.dll
https://playfab-csharp-sdk-builds.s3-us-west-2.amazonaws.com/PlayFabServerSDK/bin/Release/PlayFabServerSDK.pdb


5. Troubleshooting:
----
For a complete list of available APIs, check out the [online documentation](http://api.playfab.com/Documentation/).

#### Contact Us
We love to hear from our developer community!
Do you have ideas on how we can make our products and services better?

Our Developer Success Team can assist with answering any questions as well as process any feedback you have about PlayFab services.

[Forums, Support and Knowledge Base](https://community.playfab.com/hc/en-us)


6. Copyright and Licensing Information:
----
  Apache License --
  Version 2.0, January 2004
  http://www.apache.org/licenses/

  Full details available within the LICENSE file.

