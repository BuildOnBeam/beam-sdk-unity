using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Beam.Extensions;
using Beam.Models;
using Beam.Storage;
using Beam.Util;
using BeamPlayerClient.Api;
using BeamPlayerClient.Client;
using BeamPlayerClient.Model;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Beam
{
    public class BeamClient : MonoBehaviour
    {
        public IAssetsApi AssetsApi => new AssetsApi(GetConfiguration());
        public IExchangeApi ExchangeApi => new ExchangeApi(GetConfiguration());
        public IHealthApi HealthApi => new HealthApi(GetConfiguration());
        public IMarketplaceApi MarketplaceApi => new MarketplaceApi(GetConfiguration());
        public ISessionsApi SessionsApi => new SessionsApi(GetConfiguration());
        public ITransactionsApi TransactionsApi => new TransactionsApi(GetConfiguration());
        public IUsersApi UsersApi => new UsersApi(GetConfiguration());
        public IOperationApi OperationApi => new OperationApi(GetConfiguration());
        public IConnectorApi ConnectorApi => new ConnectorApi(GetConfiguration());
        public IRampApi RampApi => new RampApi(GetConfiguration());

        protected const int DefaultTimeoutInSeconds = 240;

        protected string m_BeamApiKey;
        protected string m_BeamApiUrl;
        protected bool m_DebugLog;
        protected Action<string> m_UrlToOpen = url => Application.OpenURL(url);
        protected IStorage m_Storage = new PlayerPrefsStorage();
        protected bool m_IsInFocus = true;

        #region Config

        public BeamClient()
        {
            SetEnvironment(BeamEnvironment.Testnet);
        }

        /// <summary>
        /// Sets Publishable Beam API key on the client. WARNING: Do not use keys other than Publishable, they're meant to be private, server-side only!
        /// </summary>
        /// <param name="publishableApiKey">Publishable Beam API key</param>
        /// <returns>BeamClient</returns>
        public BeamClient SetBeamApiKey(string publishableApiKey)
        {
            m_BeamApiKey = publishableApiKey;
            return this;
        }

        /// <summary>
        /// Sets Environment on the client.
        /// </summary>
        /// <param name="environment">BeamEnvironment.Mainnet or BeamEnvironment.Testnet (defaults to Testnet)</param>
        /// <returns>BeamClient</returns>
        public BeamClient SetEnvironment(BeamEnvironment environment)
        {
            string apiUrl;
            switch (environment)
            {
                case BeamEnvironment.Mainnet:
                    apiUrl = "https://api.onbeam.com";
                    break;
                default:
                    apiUrl = "https://api.testnet.onbeam.com";
                    break;
            }

            m_BeamApiUrl = apiUrl;

            return this;
        }

        /// <summary>
        /// Sets custom storage for Session related information. Defaults to <see cref="PlayerPrefsStorage"/>.
        /// </summary>
        /// <param name="storage">Storage that implements IStorage</param>
        /// <returns>BeamClient</returns>
        public BeamClient SetStorage(IStorage storage)
        {
            m_Storage = storage;
            return this;
        }

        /// <summary>
        /// Set to true, to enable Debug.Log() statements. Defaults to false.
        /// </summary>
        /// <param name="enable">True to enable</param>
        /// <returns>BeamClient</returns>
        public BeamClient SetDebugLogging(bool enable)
        {
            m_DebugLog = enable;
            return this;
        }

        /// <summary>
        /// Sets a custom callback that should open URLs. By default uses Application.OpenUrl().
        /// Might be useful when running WebGL to avoid popup blocking, by using various js interop plugins, or when custom WebView is needed.
        /// </summary>
        /// <param name="url">Url to open in a browser or webview. Must keep all query params and casing to work.</param>
        /// <returns>BeamClient</returns>
        public BeamClient SetUrlOpener(Action<string> url)
        {
            m_UrlToOpen = url;
            return this;
        }

        #endregion

        /// <summary>
        /// Will connect given EntityId for your game to a User.
        /// This will also happen on first possible action signed by user in the browser but can be used on it's own to
        /// simplify the first interaction.
        /// </summary>
        /// <param name="entityId">Entity Id of the User performing signing</param>
        /// <param name="chainId">ChainId to perform operation on. Defaults to 13337.</param>
        /// <param name="secondsTimeout">Optional timeout in seconds, defaults to 240</param>
        /// <param name="authProvider">Optional authProvider, if set to Any(default), User will be able to choose social login provider. Useful if you want to present Google/Discord/Apple/etc options within your UI.</param>
        /// <param name="cancellationToken">Optional CancellationToken</param>
        /// <returns>UniTask</returns>
        public async UniTask<BeamResult<GetConnectionRequestResponse.StatusEnum>> ConnectUserToGameAsync(
            string entityId,
            int chainId = Constants.DefaultChainId,
            int secondsTimeout = DefaultTimeoutInSeconds,
            CreateConnectionRequestInput.AuthProviderEnum authProvider =
                CreateConnectionRequestInput.AuthProviderEnum.Any,
            CancellationToken cancellationToken = default)
        {
            Log("Retrieving connection request");
            CreateConnectionRequestResponse connRequest;
            try
            {
                connRequest = await ConnectorApi.CreateConnectionRequestAsync(
                    new CreateConnectionRequestInput(entityId, authProvider: authProvider, chainId: chainId),
                    cancellationToken);
            }
            catch (ApiException e)
            {
                return new BeamResult<GetConnectionRequestResponse.StatusEnum>(BeamResultType.Error, e.Message);
            }

            Log($"Opening ${connRequest.Url}");
            // open browser to connect user
            OpenUrl(connRequest.Url);

            var pollingResult = await PollForResult(
                actionToPerform: () => ConnectorApi.GetConnectionRequestAsync(connRequest.Id, cancellationToken),
                shouldRetry: res => res.Status == GetConnectionRequestResponse.StatusEnum.Pending,
                secondsTimeout: secondsTimeout,
                secondsBetweenPolls: 1,
                cancellationToken: cancellationToken);

            Log($"Got polling connection request result: {pollingResult.Status.ToString()}");

            return new BeamResult<GetConnectionRequestResponse.StatusEnum>(pollingResult.Status);
        }

        /// <summary>
        /// Retrieves active, valid session.
        /// </summary>
        /// <param name="entityId">Entity Id of the User performing signing</param>
        /// <param name="chainId">ChainId to perform operation on. Defaults to 13337.</param>
        /// <param name="cancellationToken">Optional CancellationToken</param>
        /// <returns>UniTask</returns>
        public async UniTask<BeamResult<BeamSession>> GetActiveSessionAsync(
            string entityId,
            int chainId = Constants.DefaultChainId,
            CancellationToken cancellationToken = default)
        {
            Log("Retrieving active session");
            var (activeSession, _) = await GetActiveSessionAndKeysAsync(entityId, chainId, cancellationToken);

            if (activeSession == null)
            {
                Log("No active session found");
                return new BeamResult<BeamSession>(BeamResultType.Error, "No active session found");
            }

            return new BeamResult<BeamSession>(activeSession);
        }

        /// <summary>
        /// Revokes given Session Address. Always opens Browser as User has to sign it with his key.
        /// </summary>
        /// <param name="entityId">Entity Id of the User performing signing</param>
        /// <param name="sessionAddress">address of a Session to revoke</param>
        /// <param name="chainId">ChainId to perform operation on. Defaults to 13337.</param>
        /// <param name="secondsTimeout">Optional timeout in seconds, defaults to 240</param>
        /// <param name="authProvider">Optional authProvider, if set to Any(default), User will be able to choose social login provider. Useful if you want to present Google/Discord/Apple/etc options within your UI.</param>
        /// <param name="cancellationToken">Optional CancellationToken</param>
        /// <returns>UniTask</returns>
        public async UniTask<BeamResult<PlayerOperationResponse.StatusEnum>> RevokeSessionAsync(
            string entityId,
            string sessionAddress,
            int chainId = Constants.DefaultChainId,
            int secondsTimeout = DefaultTimeoutInSeconds,
            RevokeSessionRequestInput.AuthProviderEnum authProvider = RevokeSessionRequestInput.AuthProviderEnum.Any,
            CancellationToken cancellationToken = default)
        {
            Log("Retrieving active session");

            PlayerOperationResponse operation;

            try
            {
                operation = await SessionsApi.RevokeSessionAsync(entityId,
                    new RevokeSessionRequestInput(sessionAddress, chainId: chainId, authProvider: authProvider),
                    cancellationToken);
            }
            catch (ApiException e)
            {
                Log($"Failed RevokeSessionAsync: {e.Message} {e.ErrorContent}");
                return new BeamResult<PlayerOperationResponse.StatusEnum>(BeamResultType.Error, e.Message);
            }

            var result = await SignOperationUsingBrowserAsync(operation, secondsTimeout, authProvider: null, cancellationToken);
            return result;
        }

        /// <summary>
        /// Opens an external browser to sign a Session.
        /// </summary>
        /// <param name="entityId">Entity Id of the User performing signing</param>
        /// <param name="suggestedExpiry">Suggested expiration date for Session. It will be presented in the identity.onbea.com as pre-selected.</param>
        /// <param name="chainId">ChainId to perform operation on. Defaults to 13337.</param>
        /// <param name="secondsTimeout">Optional timeout in seconds, defaults to 240</param>
        /// <param name="authProvider">Optional authProvider, if set to Any(default), User will be able to choose social login provider. Useful if you want to present Google/Discord/Apple/etc options within your UI.</param>
        /// <param name="cancellationToken">Optional CancellationToken</param>
        /// <returns>UniTask</returns>
        public async UniTask<BeamResult<BeamSession>> CreateSessionAsync(string entityId,
            DateTime? suggestedExpiry = null,
            int chainId = Constants.DefaultChainId,
            int secondsTimeout = DefaultTimeoutInSeconds,
            GenerateSessionUrlRequestInput.AuthProviderEnum authProvider =
                GenerateSessionUrlRequestInput.AuthProviderEnum.Any,
            CancellationToken cancellationToken = default)
        {
            Log("Retrieving active session");
            var (activeSession, _) = await GetActiveSessionAndKeysAsync(entityId, chainId, cancellationToken);

            if (activeSession != null)
            {
                Log("Already has an active session, ending early");
                return new BeamResult<BeamSession>(BeamResultType.Error, "Already has an active session")
                {
                    Result = activeSession
                };
            }

            Log("No active session found, refreshing local KeyPair");

            // refresh keypair to make sure we have no conflicts with existing sessions
            var newKeyPair = GetOrCreateSigningKeyPair(entityId, refresh: true);

            // retrieve operation Id to pass further and track result
            GenerateSessionRequestResponse beamSessionRequest;
            try
            {
                var res = await SessionsApi.CreateSessionRequestAsync(entityId,
                    new GenerateSessionUrlRequestInput(newKeyPair.Account.Address, suggestedExpiry: suggestedExpiry,
                        chainId: chainId, authProvider: authProvider), cancellationToken);

                Log($"Created session request: {res.Id} to check for session result");
                beamSessionRequest = res;
            }
            catch (ApiException e)
            {
                Log($"Failed creating session request: {e.Message} {e.ErrorContent}");
                return new BeamResult<BeamSession>(e);
            }

            Log($"Opening {beamSessionRequest.Url}");
            // open identity.onbeam.com
            OpenUrl(beamSessionRequest.Url);

            var beamResultModel = new BeamResult<BeamSession>();

            Log("Started polling for Session creation result");
            // start polling for results of the operation
            var error = false;

            var pollingResult = await PollForResult(
                actionToPerform: () => SessionsApi.GetSessionRequestAsync(beamSessionRequest.Id, cancellationToken),
                shouldRetry: res => res.Status == GetSessionRequestResponse.StatusEnum.Pending,
                secondsTimeout: secondsTimeout,
                secondsBetweenPolls: 1,
                cancellationToken: cancellationToken);

            if (pollingResult == null)
            {
                return new BeamResult<BeamSession>(BeamResultType.Error,
                    "Polling for created session encountered an error or timed out");
            }

            switch (pollingResult.Status)
            {
                case GetSessionRequestResponse.StatusEnum.Pending:
                    beamResultModel.Status = BeamResultType.Pending;
                    break;
                case GetSessionRequestResponse.StatusEnum.Accepted:
                    beamResultModel.Status = BeamResultType.Success;
                    break;
                case GetSessionRequestResponse.StatusEnum.Error:
                    beamResultModel.Status = BeamResultType.Error;
                    beamResultModel.Error = "Encountered an error when requesting a session";
                    error = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Log("Retrieving newly created Session");
            // retrieve newly created session
            if (!error)
            {
                var (beamSession, _) = await GetActiveSessionAndKeysAsync(entityId, chainId, cancellationToken);
                if (beamSession != null)
                {
                    beamResultModel.Result = beamSession;
                    Log(
                        $"Retrieved a session: {beamSession.SessionAddress}, valid from: {beamSession.StartTime:o}, to: {beamSession.EndTime:o}");
                }
                else
                {
                    beamResultModel.Error = "Could not retrieve session after it was created";
                    beamResultModel.Status = BeamResultType.Error;
                }
            }

            return beamResultModel;
        }

        /// <summary>
        /// Opens an external browser or uses an existing Session to sign a transaction.
        /// </summary>
        /// <param name="entityId">Entity Id of the User performing signing</param>
        /// <param name="operationId">Id of the Operation to sign. Returned by Beam API.</param>
        /// <param name="chainId">ChainId to perform operation on. Defaults to 13337.</param>
        /// <param name="signingBy">If set to Auto, will try to use a local Session and open Browser if there is no valid Session.</param>
        /// <param name="authProvider">If included, will override AuthProvider used when creating Operation. Ignored if signing via Session.</param>
        /// <param name="secondsTimeout">Optional timeout in seconds, defaults to 240</param>
        /// <param name="cancellationToken">Optional CancellationToken</param>
        /// <returns>UniTask</returns>
        public async UniTask<BeamResult<PlayerOperationResponse.StatusEnum>> SignOperationAsync(
            string entityId,
            string operationId,
            int chainId = Constants.DefaultChainId,
            OperationSigningBy signingBy = OperationSigningBy.Auto,
            PlayerOperationResponse.AuthProviderEnum? authProvider = null,
            int secondsTimeout = DefaultTimeoutInSeconds,
            CancellationToken cancellationToken = default)
        {
            PlayerOperationResponse operation;
            Log($"Retrieving operation({operationId})");
            try
            {
                var res = await OperationApi.GetOperationAsync(operationId, cancellationToken);
                operation = res;
            }
            catch (ApiException e)
            {
                if (e.ErrorCode == 404)
                {
                    Log($"No operation({operationId}) was found, ending");
                    return new BeamResult<PlayerOperationResponse.StatusEnum>
                    {
                        Status = BeamResultType.Error,
                        Error = "Operation was not found"
                    };
                }

                Log($"Encountered an error retrieving operation({operationId}): {e.Message} {e.ErrorContent}");
                return new BeamResult<PlayerOperationResponse.StatusEnum>(e);
            }

            if (signingBy is OperationSigningBy.Auto or OperationSigningBy.Session)
            {
                Log("Retrieving active session");
                var (activeSession, activeSessionKeyPair) =
                    await GetActiveSessionAndKeysAsync(entityId, chainId, cancellationToken);

                var hasActiveSession = activeSessionKeyPair != null && activeSession != null;
                if (hasActiveSession)
                {
                    Log($"Has an active session until: {activeSession.EndTime:o}, using it to sign the operation");
                    return await SignOperationUsingSessionAsync(operation, activeSessionKeyPair,
                        cancellationToken);
                }
            }

            if (signingBy is OperationSigningBy.Auto or OperationSigningBy.Browser)
            {
                Log("No active session found, using browser to sign the operation");
                return await SignOperationUsingBrowserAsync(operation, secondsTimeout, authProvider, cancellationToken);
            }

            Log($"No active session found, {nameof(signingBy)} set to {signingBy.ToString()}");
            return new BeamResult<PlayerOperationResponse.StatusEnum>
            {
                Result = PlayerOperationResponse.StatusEnum.Error,
                Status = BeamResultType.Error,
                Error = $"No active session found, {nameof(signingBy)} set to {signingBy.ToString()}"
            };
        }

        /// <summary>
        /// Clears any details of local Session like private key, or Session validity details. Useful when f.e. switching users on the same device.
        /// </summary>
        /// <param name="entityId">EntityId</param>
        public void ClearLocalSession(string entityId)
        {
            m_Storage.Delete(Constants.Storage.BeamSigningKey + entityId);
        }

        protected async UniTask<BeamResult<PlayerOperationResponse.StatusEnum>> SignOperationUsingBrowserAsync(
            PlayerOperationResponse operation,
            int secondsTimeout,
            PlayerOperationResponse.AuthProviderEnum? authProvider,
            CancellationToken cancellationToken = default)
        {
            var url = operation.Url;
            if (authProvider.HasValue)
            {
                // override provider param if needed
                var uriBuilder = new UriBuilder(url);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query.Set("provider", authProvider.ToString());
                uriBuilder.Query = query.ToString();
                url = uriBuilder.ToString();

            }
            Log($"Opening {url}...");

            // open identity.onbeam.com, give it operation id
            OpenUrl(url);

            // start polling for results of the operation
            var now = DateTimeOffset.Now;
            var pollingResult = await PollForResult(
                actionToPerform: () => OperationApi.GetOperationAsync(operation.Id, cancellationToken),
                shouldRetry: res => 
                                    // no response
                                    res == null ||
                                    // operation is pending
                                    res.Status == PlayerOperationResponse.StatusEnum.Pending ||
                                    // operation had an error or was rejected and we're retrying it
                                    (res.Status != PlayerOperationResponse.StatusEnum.Pending &&
                                    res.UpdatedAt != null && res.UpdatedAt < now),
                secondsTimeout: secondsTimeout,
                secondsBetweenPolls: 1,
                cancellationToken: cancellationToken);

            Log($"Got operation({operation.Id}) result: {pollingResult?.Status.ToString()}");
            var beamResult =
                new BeamResult<PlayerOperationResponse.StatusEnum>(pollingResult?.Status ??
                                                                   PlayerOperationResponse.StatusEnum.Error);

            switch (pollingResult?.Status)
            {
                case PlayerOperationResponse.StatusEnum.Pending:
                case PlayerOperationResponse.StatusEnum.Executed:
                case PlayerOperationResponse.StatusEnum.Rejected:
                case PlayerOperationResponse.StatusEnum.Signed:
                    beamResult.Status = BeamResultType.Success;
                    break;
                case PlayerOperationResponse.StatusEnum.Error:
                    beamResult.Status = BeamResultType.Error;
                    beamResult.Error = "Operation encountered an error";
                    break;
                default:
                    beamResult.Status = BeamResultType.Error;
                    beamResult.Error = "Polling for operation encountered an error or timed out";
                    break;
            }

            return beamResult;
        }

        protected async UniTask<BeamResult<PlayerOperationResponse.StatusEnum>> SignOperationUsingSessionAsync(
            PlayerOperationResponse operation,
            KeyPair activeSessionKeyPair,
            CancellationToken cancellationToken = default)
        {
            if (operation?.Actions?.Any() != true)
            {
                Log($"Operation({operation?.Id}) has no actions to sign, ending");
                return new BeamResult<PlayerOperationResponse.StatusEnum>
                {
                    Result = PlayerOperationResponse.StatusEnum.Error,
                    Status = BeamResultType.Error,
                    Error = "Operation has no actions to sign"
                };
            }

            var confirmationModel = new ConfirmOperationRequest(
                ConfirmOperationRequest.StatusEnum.Pending,
                actions: new List<ConfirmOperationRequestTransactionsInner>());

            Log($"Signing operation({operation.Id}) actions...");
            foreach (var action in operation.Actions)
            {
                try
                {
                    if (action.Type == PlayerOperationAction.TypeEnum.SessionRevoke)
                    {
                        throw new Exception(
                            $"Revoke Session Operation has to be performed via {nameof(RevokeSessionAsync)}() method only");
                    }

                    if (action.Signature == null)
                    {
                        throw new Exception("Signature object is null, operation is most likely not signable");
                    }

                    string signature;
                    switch (action.Signature.Type)
                    {
                        case PlayerOperationActionSignature.TypeEnum.Message:
                            signature = activeSessionKeyPair.SignMessage(Convert.ToString(action.Signature.Data));
                            break;
                        case PlayerOperationActionSignature.TypeEnum.TypedData:
                            signature = activeSessionKeyPair.SignMarketplaceTransactionHash(action.Signature.Hash);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    confirmationModel.Actions.Add(new ConfirmOperationRequestTransactionsInner(action.Id, signature));
                }
                catch (ApiException e)
                {
                    Log(
                        $"Encountered an error when signing action({action.Id}): {e.Message} {e.ErrorContent}");
                    return new BeamResult<PlayerOperationResponse.StatusEnum>(e,
                        $"Encountered an exception while approving action{action.Id} of type {action.Type.ToString()}");
                }
            }

            Log($"Confirming operation({operation.Id})...");
            try
            {
                var res = await OperationApi.ProcessOperationAsync(operation.Id, confirmationModel,
                    cancellationToken);
                var didFail = res.Status != PlayerOperationResponse.StatusEnum.Executed &&
                              res.Status != PlayerOperationResponse.StatusEnum.Signed &&
                              res.Status != PlayerOperationResponse.StatusEnum.Pending;

                Log(
                    $"Confirmed operation({operation.Id}), status: {res.Status.ToString()}");
                return new BeamResult<PlayerOperationResponse.StatusEnum>
                {
                    Status = didFail ? BeamResultType.Error : BeamResultType.Success,
                    Result = res.Status
                };
            }
            catch (ApiException e)
            {
                Log(
                    $"Confirming operation({operation.Id}) encountered an error: {e.ErrorContent}");
                return new BeamResult<PlayerOperationResponse.StatusEnum>
                {
                    Status = BeamResultType.Error,
                    Error = e.Message ??
                            $"Encountered unknown error when confirming operation {operation.Id}"
                };
            }
        }

        // only enable outside of editor due to various issues with OnApplicationPause
        // m_IsInFocus is hardcoded to true in this case
        #if !UNITY_EDITOR
        public void OnApplicationPause(bool pauseStatus)
        {
            Log($"OnApplicationPause: {pauseStatus}");
            m_IsInFocus = !pauseStatus;
        }
        #endif

        /// <summary>
        /// Will retry or return null if received 404.
        /// </summary>
        protected async UniTask<T> PollForResult<T>(
            Func<UniTask<T>> actionToPerform,
            Func<T, bool> shouldRetry,
            int secondsTimeout = DefaultTimeoutInSeconds,
            int secondsBetweenPolls = 1,
            CancellationToken cancellationToken = default)
            where T : class
        {
            await UniTask.Delay(4000, cancellationToken: cancellationToken);

            var endTime = DateTime.Now.AddSeconds(secondsTimeout);

            while ((endTime - DateTime.Now).TotalSeconds > 0)
            {
                // if we're not in focus, there's no point in polling
                if (m_IsInFocus)
                {
                    T result;
                    try
                    {
                        result = await actionToPerform.Invoke();
                    }
                    catch (ApiException e)
                    {
                        if (e.ErrorCode == 404)
                        {
                            return null;
                        }

                        throw;
                    }

                    var retry = shouldRetry.Invoke(result);
                    if (!retry)
                    {
                        return result;
                    }
                }

                await UniTask.Delay(secondsBetweenPolls * 1000, cancellationToken: cancellationToken);
            }

            return null;
        }

        protected async UniTask<(BeamSession, KeyPair)> GetActiveSessionAndKeysAsync(
            string entityId,
            int chainId,
            CancellationToken cancellationToken = default)
        {
            BeamSession beamSession = null;
            var keyPair = GetOrCreateSigningKeyPair(entityId);

            // check if we have the session in API for current KeyPair
            // we need to always get it from remote to make sure User didn't revoke it
            try
            {
                var res = await SessionsApi.GetActiveSessionV2Async(entityId, keyPair.Account.Address,
                    chainId, cancellationToken);
                if (res.Session != null)
                {
                    beamSession = new BeamSession
                    {
                        Id = res.Session.Id,
                        StartTime = res.Session.StartTime,
                        EndTime = res.Session.EndTime,
                        SessionAddress = res.Session.SessionAddress
                    };
                }
                else
                {
                    Log($"No active session found for {entityId}");
                }
            }
            catch (ApiException e)
            {
                Log($"GetActiveSessionInfo returned: {e.Message} {e.ErrorContent}");
            }

            // make sure session we just retrieved is valid and owned by current KeyPair
            if (beamSession.IsActive() && beamSession.IsOwnedBy(keyPair))
            {
                return (beamSession, keyPair);
            }

            return (null, keyPair);
        }

        protected KeyPair GetOrCreateSigningKeyPair(string entityId, bool refresh = false)
        {
            if (!refresh)
            {
                var privateKey = m_Storage.Get(Constants.Storage.BeamSigningKey + entityId);
                if (privateKey != null)
                {
                    return KeyPair.Load(privateKey);
                }
            }

            var newKeyPair = KeyPair.Generate();
            m_Storage.Set(Constants.Storage.BeamSigningKey + entityId, newKeyPair.PrivateHex);

            return newKeyPair;
        }

        protected Configuration GetConfiguration()
        {
            var config = new Configuration
            {
                BasePath = m_BeamApiUrl,
            };
            config.ApiKey.Add("x-api-key", m_BeamApiKey);
            config.DefaultHeaders.Add("x-beam-sdk", "unity");
            return config;
        }

        protected void Log(string message)
        {
            if (m_DebugLog)
            {
                Debug.Log(message);
            }
        }

        protected void OpenUrl(string url)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            // we append this to try and close the custom tab afterwards via window.close()
            url += "&attemptClosure=true";
#endif
            m_UrlToOpen(url);
        }
    }
}