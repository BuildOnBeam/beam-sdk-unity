# Beam SDK for Unity

## Installation
To install Beam SDK for Unity you have to add following dependencies to your manifest.json:  

#### Option 1 - manifest.json

Open Packages/manifest.json and add these lines:

```
"beam.sdk.client": "https://github.com/BuildOnBeam/beam-sdk-unity.git?path=/Unity",
"com.cysharp.unitask": "https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask"
```

##### Note: using  `https://github.com/BuildOnBeam/beam-sdk-unity.git?path=/Unity` will always default to the newest version of the main branch. You probably should lock the url to particular release to avoid potential compatibility issues. To do so, add `#vX.X.X` to the url, like this: `https://github.com/BuildOnBeam/beam-sdk-unity.git?path=/Unity#v1.0.0`.

#### Option 2 - Package Manager Editor UI

Follow these instructions:

https://docs.unity3d.com/Manual/upm-ui-giturl.html

And add these urls:  
```
https://github.com/BuildOnBeam/beam-sdk-unity.git?path=/Unity
https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask
```


## Usage
To use the package, initialize `BeamClient`:
```csharp
var beamClient = gameObject.AddComponent<BeamClient>()
                .SetBeamApiKey("your-publishable-api-key") // set your Publishable(!) API key
                .SetEnvironment(BeamEnvironment.Beta) // defaults to Beta
                .SetDebugLogging(true) // optional, defaults to false
                .SetStorage(yourCustomStorageImplementation); // optional, defaults to PlayerPrefs storage;
```

### Connecting your user to Beam
This is an operation that ideally should only be called once. You can assign the user your own label we call `entityId` and then use it to refer to that player. 
In case you don't want to assign it yourself, on first Connection to the game, user will be automatically assigned his EOA address and we will return it as a result of `ConnectUserToGameAsyncV2` or `CreateSessionAsync`. You can then store it and use it with other functionalities of Beam API/SDKs.
```csharp
            var result = await beamClient.ConnectUserToGameAsyncV2(BeamEntityId); // will also work without entityId
            if (result.Status == BeamResultType.Success)
            {
                var user = await beamClient.UsersApi.GetUserAsync(result.Result.EntityId);
                // you can now perform Operations with this User
            }
```


### Creating a session:
If you haven't connected your user to the game before, first `CreateSessionAsync` will do that for you(it will be part of the flow when user is on identity.onbeam.com).
```csharp
            var activeSessionResult = await m_BeamClient.CreateSessionAsync(BeamEntityId);
            if (activeSessionResult.Status == BeamResultType.Success)
            {
                var session = activeSessionResult.Result;
                // you can now sign Operations without leaving the game
            }
```


### Checking for an active session

```csharp
            var activeSessionResult = await m_BeamClient.GetActiveSessionAsync(BeamEntityId);
            if (activeSessionResult.Status == BeamResultType.Success)
            {
                var session = activeSessionResult.Result;
                var validUntil = session.EndTime;
                // (...)
            }
```

### Revoking a session:
```csharp
            var sessionAddress = "0x3c31...";
            var operationResult = await m_BeamClient.RevokeSessionAsync(
                entityId: BeamEntityId,
                sessionAddress: sessionAddress
                );
            if (operationResult.Status == BeamResultType.Success)
            {
                var operationStatus = operationResult.Result;
                // (...)
            }
```

### Signing an operation:
Once you get an operationId from Beam API, that requires signing by the user, you can call BeamClient.SignOperation() to sign and execute given operation:
```csharp
var operationId = "clxn9u(...)0c4bz7av";
            var operationResult = await m_BeamClient.SignOperationAsync(
                entityId: BeamEntityId,
                operationId: operationId,
                signingBy: OperationSigningBy.Auto  // accepts Auto, Browser and Session
                );
            if (operationResult.Status == BeamResultType.Success)
            {
                var operationStatus = operationResult.Result;
                switch (operationResult.Result)
                {
                    case CommonOperationResponse.StatusEnum.Signed:
                        break;
                    case CommonOperationResponse.StatusEnum.Pending:
                        break;
                    case CommonOperationResponse.StatusEnum.Rejected:
                        break;
                    case CommonOperationResponse.StatusEnum.Executed:
                        break;
                    case CommonOperationResponse.StatusEnum.Error:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
```

### Overriding URL Opener
By default, we use Unity's Application.OpenURL() to interact with identity.onbeam.com.
This causes a default browser app to be opened on all platforms which might not be optimal for you as it redirects the user away from your game.
If you prefer to use your WebView plugin of your choice, you can override the way we open URLs:
```csharp
m_BeamClient.SetUrlOpener((url) =>
{
    // your custom implementation
});
```
It's important to keep url structure and all search params as-is, as they are used by Beam Identity.

### Selecting AuthProvider
All main BeamClient methods accept an optional argument called `authProvider`. By passing a provider value other than `Any`, you force the User to sign into Beam Identity using that provider. This allows you to skip the initial screen with Social Provider login selection, at the cost of taking the choice away from the User. This can be useful if you want to present Social Providers to choose from within your UI. Please keep in mind that Social Providers we support might change in the future and might then require changes in your UI.

### WebGL
WebGL builds are optimized and have Code Stripping enabled by default. We made sure that our models are not stripped using [Preserve] attributes but if you notice a functionality that seemingly breaks with stripping, please let us know, so we can adjust accordingly.

### Android

We will attempt to use Chrome Custom Tabs if possible on Android, if there is no package that can handle it, we will default to opening *any* browser capable of handling the VIEW intent.

#### Custom gradle
In order for Beam SDK to work properly, we need `androidx.browser:browser:1.8.0` dependency.  
If you are using [EDM4U](https://github.com/googlesamples/unity-jar-resolver) you don't have to do anything.

If you don't, you have to enable custom Gradle file in project settings and add this dependency:
```gradle
implementation 'androidx.browser:browser:1.8.0'
```


#### Minification - ProGuard
If you enable Minify for your Android builds, you will need to also enable Custom Proguard File in project settings and add these to proguard-user.txt:
```
-dontwarn com.onbeam.**
-keep class com.onbeam.** { *; }
-keep interface com.onbeam.** { *; }

-dontwarn androidx.**
-keep class androidx.** { *; }
-keep interface androidx.** { *; }
```

##### Deeplink handling
When running Unity and building for Android, in order for interactions with Chrome Custom Tabs to work properly, we need you to add this Activity to your custom Manifest:
```xml
<activity
        android:name="com.onbeam.beamchrometabs.activities.CallbackActivity"
        android:exported="true" >
    <intent-filter>
        <action android:name="android.intent.action.VIEW" />
        <category android:name="android.intent.category.DEFAULT" />
        <category android:name="android.intent.category.BROWSABLE" />
        <data android:scheme="beamexample" android:host="callback" />
    </intent-filter>
</activity>
```
and replace `beamexample` with your game's unique scheme. Afterward, go to https://dashboard.onbeam.com/ and add the deeplink in form of `beamexample://callback` to your game's settings.
After this, we will be able to close the Chrome Custom Tab after user's flow is finished and get him back to your game automatically. Otherwise, user has to close the browser window himself.

You can enable custom Manifest by going to Build Settings -> Player Settings -> Android -> Publishing Settings -> Enable Custom Main Manifest under the Build section.


### Examples
You can find an example implementation using this demo in [beam-sdk-unity-example](https://github.com/BuildOnBeam/beam-sdk-unity-example/tree/main)