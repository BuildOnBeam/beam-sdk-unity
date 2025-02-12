# Beam SDK for Unity

## Installation
To install Beam SDK for Unity you have to add following dependencies to your manifest.json:  

#### Option 1 - manifest.json

Open Packages/manifest.json and add these lines:

```
"beam.sdk.client": "https://github.com/BuildOnBeam/beam-sdk-unity.git",
"com.cysharp.unitask": "https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask"
```

##### Note: using  `https://github.com/BuildOnBeam/beam-sdk-unity.git` will always default to the newest version of the main branch. You probably should lock the url to particular release to avoid potential compatibility issues. To do so, add `#vX.X.X` to the url, like this: `https://github.com/BuildOnBeam/beam-sdk-unity.git#v0.5.3`.

#### Option 2 - Package Manager Editor UI

Follow these instructions:

https://docs.unity3d.com/Manual/upm-ui-giturl.html

And add these urls:  
```
https://github.com/BuildOnBeam/beam-sdk-unity.git
https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask
```


## Usage
To use the package, initialize `BeamClient`:
```csharp
var beamClient = gameObject.AddComponent<BeamClient>()
                .SetBeamApiKey("your-publishable-api-key") // set your Publishable(!) API key
                .SetEnvironment(BeamEnvironment.Testnet) // defaults to Testnet
                .SetDebugLogging(true) // optional, defaults to false
                .SetStorage(yourCustomStorageImplementation); // optional, defaults to PlayerPrefs storage;
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

### Creating a session:
```csharp
            var activeSessionResult = await m_BeamClient.CreateSessionAsync(BeamEntityId);
            if (activeSessionResult.Status == BeamResultType.Success)
            {
                var session = activeSessionResult.Result;
                // you can now sign Operations without leaving the game
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

### Examples
You can find an example implementation using this demo in [beam-sdk-unity-example](https://github.com/BuildOnBeam/beam-sdk-unity-example/tree/main)

### Notes

#### Overriding URL Opener
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

#### Selecting AuthProvider
All main BeamClient methods accept an optional argument called `authProvider`. By passing a provider value other than `Any`, you force the User to sign into Beam Identity using that provider. This allows you to skip the initial screen with Social Provider login selection, at the cost of taking the choice away from the User. This can be useful if you want to present Social Providers to choose from within your UI. Please keep in mind that Social Providers we support might change in the future and might then require changes in your UI.

#### WebGL
WebGL builds are optimized and have Code Stripping enabled by default. We made sure that our models are not stripped using [Preserve] attributes but if you notice a functionality that seemingly breaks with stripping, please let us know, so we can adjust accordingly.