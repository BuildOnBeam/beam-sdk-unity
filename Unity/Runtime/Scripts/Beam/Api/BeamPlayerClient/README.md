# BeamPlayerClient - the C# library for the Player API

The Player API is a service to integrate your game with Beam

This C# SDK is automatically generated by the [OpenAPI Generator](https://openapi-generator.tech) project:

- API version: 1.0.0
- SDK version: 1.0.0
- Generator version: 7.9.0
- Build package: org.openapitools.codegen.languages.CSharpClientCodegen

<a id="version-support"></a>
## Version support
This generator should support all current LTS versions of Unity
- Unity 2020.3 (LTS) and up
- .NET Standard 2.1 / .NET Framework

<a id="dependencies"></a>
## Dependencies

- [Newtonsoft.Json](https://docs.unity3d.com/Packages/com.unity.nuget.newtonsoft-json@3.0/manual/index.html) - 3.0.2 or later
- [Unity Test Framework](https://docs.unity3d.com/Packages/com.unity.test-framework@1.1/manual/index.html) - 1.1.33 or later

<a id="installation"></a>
## Installation
Add the dependencies to `Packages/manifest.json`
```
{
  "dependencies": {
    ...
    "com.unity.nuget.newtonsoft-json": "3.0.2",
    "com.unity.test-framework": "1.1.33",
  }
}
```

Then use the namespaces:
```csharp
using BeamPlayerClient.Api;
using BeamPlayerClient.Client;
using BeamPlayerClient.Model;
```

<a id="getting-started"></a>
## Getting Started

```csharp
using System;
using System.Collections.Generic;
using UnityEngine;
using BeamPlayerClient.Api;
using BeamPlayerClient.Client;
using BeamPlayerClient.Model;

namespace BeamPlayerClientExample
{

    public class GetAssetActivityExample : MonoBehaviour
    {
        async void Start()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // Configure API key authorization: beam-api-key
            config.ApiKey.Add("x-api-key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.ApiKeyPrefix.Add("x-api-key", "Bearer");

            var apiInstance = new ActivityApi(config);
            var assetAddress = "assetAddress_example";  // string | 
            var assetId = "assetId_example";  // string | 
            var commonAssetActivityRequestInput = new CommonAssetActivityRequestInput(); // CommonAssetActivityRequestInput | 

            try
            {
                // Get asset activity
                CommonActivityResponse result = await apiInstance.GetAssetActivityAsync(assetAddress, assetId, commonAssetActivityRequestInput);
                Debug.Log(result);
                Debug.Log("Done!");
            }
            catch (ApiException e)
            {
                Debug.LogError("Exception when calling ActivityApi.GetAssetActivity: " + e.Message );
                Debug.LogError("Status Code: "+ e.ErrorCode);
                Debug.LogError(e.StackTrace);
            }

        }
    }
}
```

<a id="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *http://localhost*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*ActivityApi* | [**GetAssetActivity**](ActivityApi.md#getassetactivity) | **POST** /v1/player/activity/assets/{assetAddress}/asset/{assetId} | Get asset activity
*ActivityApi* | [**GetContractActivity**](ActivityApi.md#getcontractactivity) | **POST** /v1/player/activity/assets/{assetAddress} | Get contract activity
*ActivityApi* | [**GetUserActivity**](ActivityApi.md#getuseractivity) | **POST** /v1/player/activity/users/{entityId} | Get user activity
*AssetsApi* | [**GetAsset**](AssetsApi.md#getasset) | **GET** /v1/player/assets/{assetAddress}/assets/{assetId} | Get a single NFT (e.g. ERC721 / ERC1155)
*AssetsApi* | [**GetAssetsForContract**](AssetsApi.md#getassetsforcontract) | **POST** /v1/player/assets/{assetAddress}/assets | Get all the assets of contract (NFT assets, e.g. ERC721 / ERC1155)
*AssetsApi* | [**GetAttributes**](AssetsApi.md#getattributes) | **GET** /v1/player/assets/{assetAddress}/attributes | 
*AssetsApi* | [**GetOwnerAssets**](AssetsApi.md#getownerassets) | **POST** /v1/player/assets/{assetAddress}/owners/{ownerAddress}/assets | 
*AssetsApi* | [**GetOwners**](AssetsApi.md#getowners) | **GET** /v1/player/assets/{assetAddress}/owners | 
*AssetsApi* | [**GetUserAssetsForGamePost**](AssetsApi.md#getuserassetsforgamepost) | **POST** /v1/player/assets/users/{entityId} | Get all the assets of a profile (NFT assets, e.g. ERC721 / ERC1155)
*AssetsApi* | [**GetUserCurrencies**](AssetsApi.md#getusercurrencies) | **GET** /v1/player/assets/users/{entityId}/currencies | Get all the currencies owned by an account (ERC20)
*AssetsApi* | [**GetUserNativeCurrency**](AssetsApi.md#getusernativecurrency) | **GET** /v1/player/assets/users/{entityId}/native | Get the native token balance
*AssetsApi* | [**TransferAsset**](AssetsApi.md#transferasset) | **POST** /v1/player/assets/users/{entityId}/transfer-asset | Transfer an asset (NFT assets, ERC721 / ERC1155)
*AssetsApi* | [**TransferNativeToken**](AssetsApi.md#transfernativetoken) | **POST** /v1/player/assets/users/{entityId}/transfer-native | Transfer the native token
*AssetsApi* | [**TransferToken**](AssetsApi.md#transfertoken) | **POST** /v1/player/assets/users/{entityId}/transfer-token | Transfer a token (token assets, ERC20)
*ConnectorApi* | [**CreateConnectionRequest**](ConnectorApi.md#createconnectionrequest) | **POST** /v1/connection/request | 
*ConnectorApi* | [**GetConnectionRequest**](ConnectorApi.md#getconnectionrequest) | **GET** /v1/connection/request/{requestId} | 
*ContractApi* | [**ReadContract**](ContractApi.md#readcontract) | **POST** /v1/contract/{contractAddress}/read | Calls a readable contract function
*ExchangeApi* | [**ConvertInput**](ExchangeApi.md#convertinput) | **POST** /v1/player/exchange/users/{entityId}/convert/input | Swap an exact amount of `tokenIn` for a minimum amount of `tokenOut`
*ExchangeApi* | [**ConvertToOutput**](ExchangeApi.md#converttooutput) | **POST** /v1/player/exchange/users/{entityId}/convert/output | Swap a maximum amount of `tokenIn` for an exact amount of `tokenOut`
*ExchangeApi* | [**GetQuoteForInput**](ExchangeApi.md#getquoteforinput) | **GET** /v1/player/exchange/quote/input | Returns the maximum necessary input amount for a token trade, given a desired output amount
*ExchangeApi* | [**GetQuoteForOutput**](ExchangeApi.md#getquoteforoutput) | **GET** /v1/player/exchange/quote/output | Returns the minimum expected output amount for a token trade, given an input amount
*ExchangeApi* | [**UnwrapNative**](ExchangeApi.md#unwrapnative) | **POST** /v1/player/exchange/users/{entityId}/native/unwrap | Unwrap an amount of wrapped to native token
*ExchangeApi* | [**WrapNative**](ExchangeApi.md#wrapnative) | **POST** /v1/player/exchange/users/{entityId}/native/wrap | Wrap an amount of native token to wrapped native token
*HealthApi* | [**Check**](HealthApi.md#check) | **GET** /v1/health/services | 
*MarketplaceApi* | [**AcceptAssetOffer**](MarketplaceApi.md#acceptassetoffer) | **POST** /v1/player/marketplace/users/{entityId}/offers/{offerId}/accept | Accept an offer for an asset
*MarketplaceApi* | [**BuyListedAsset**](MarketplaceApi.md#buylistedasset) | **POST** /v1/player/marketplace/users/{entityId}/listing/{orderId} | Buy listed asset
*MarketplaceApi* | [**CancelAssetOffer**](MarketplaceApi.md#cancelassetoffer) | **DELETE** /v1/player/marketplace/users/{entityId}/offers/{offerId} | Cancel an offer for an asset
*MarketplaceApi* | [**CancelListing**](MarketplaceApi.md#cancellisting) | **DELETE** /v1/player/marketplace/users/{entityId}/listing/{orderId} | Cancel asset listing
*MarketplaceApi* | [**CreateAssetOffer**](MarketplaceApi.md#createassetoffer) | **POST** /v1/player/marketplace/users/{entityId}/offers | Make an offer for an asset
*MarketplaceApi* | [**GetAssetOffers**](MarketplaceApi.md#getassetoffers) | **GET** /v1/player/marketplace/offers/asset/{assetAddress}/{assetId} | Get all offers for an asset
*MarketplaceApi* | [**GetChainCurrencies**](MarketplaceApi.md#getchaincurrencies) | **GET** /v1/player/marketplace/chain-currencies/{chainId} | Get available currencies for given chain
*MarketplaceApi* | [**GetListedAssets**](MarketplaceApi.md#getlistedassets) | **POST** /v1/player/marketplace | Get all listed assets for a game (NFT assets, e.g. ERC721 / ERC1155)
*MarketplaceApi* | [**GetListedAssetsForUser**](MarketplaceApi.md#getlistedassetsforuser) | **POST** /v1/player/marketplace/users/{entityId} | Get all the assets listed by a profile (NFT assets, e.g. ERC721 / ERC1155)
*MarketplaceApi* | [**GetUserAssetOffers**](MarketplaceApi.md#getuserassetoffers) | **GET** /v1/player/marketplace/users/{entityId}/offers/asset/{assetAddress}/{assetId} | Get all asset offers that a user created for a specific asset
*MarketplaceApi* | [**GetUserOffers**](MarketplaceApi.md#getuseroffers) | **GET** /v1/player/marketplace/users/{entityId}/offers | Get all offers that a user created
*MarketplaceApi* | [**ListAsset**](MarketplaceApi.md#listasset) | **POST** /v1/player/marketplace/users/{entityId}/listing | List an asset for sale
*MarketplaceApi* | [**RefreshContract**](MarketplaceApi.md#refreshcontract) | **POST** /v1/player/marketplace/refresh/contract | Schedule a contract refresh in the indexer
*MarketplaceApi* | [**RefreshToken**](MarketplaceApi.md#refreshtoken) | **POST** /v1/player/marketplace/refresh/token | Schedule a token refresh in the indexer
*OperationApi* | [**DeleteOperation**](OperationApi.md#deleteoperation) | **DELETE** /v1/player/operation/{opId} | Delete an operation
*OperationApi* | [**ExecuteSignedOperation**](OperationApi.md#executesignedoperation) | **POST** /v1/player/operation/{opId}/execute | Executes operation for given id
*OperationApi* | [**GetOperation**](OperationApi.md#getoperation) | **GET** /v1/player/operation/{opId} | Returns operation data for given id. Used by Game SDKs to get transaction results.
*OperationApi* | [**ProcessOperation**](OperationApi.md#processoperation) | **PATCH** /v1/player/operation/{opId} | Updates operation result for given id
*RampApi* | [**CreateOnrampRequest**](RampApi.md#createonramprequest) | **POST** /v1/player/ramp/on/{entityId} | 
*RampApi* | [**GetOnRampQuote**](RampApi.md#getonrampquote) | **POST** /v1/player/ramp/quote/on/{entityId} | 
*SessionsApi* | [**CreateSessionRequest**](SessionsApi.md#createsessionrequest) | **POST** /v1/player/sessions/users/{entityId}/request | 
*SessionsApi* | [**CreateSessionRequestV2**](SessionsApi.md#createsessionrequestv2) | **POST** /v2/player/sessions/request | 
*SessionsApi* | [**GetActiveSession**](SessionsApi.md#getactivesession) | **GET** /v1/player/sessions/users/{entityId}/{accountAddress}/active | 
*SessionsApi* | [**GetActiveSessionV2**](SessionsApi.md#getactivesessionv2) | **GET** /v2/player/sessions/users/{entityId}/{accountAddress}/active | 
*SessionsApi* | [**GetAllActiveSessions**](SessionsApi.md#getallactivesessions) | **GET** /v1/player/sessions/users/{entityId}/active | 
*SessionsApi* | [**GetSessionRequest**](SessionsApi.md#getsessionrequest) | **GET** /v1/player/sessions/request/{requestId} | 
*SessionsApi* | [**RevokeSession**](SessionsApi.md#revokesession) | **POST** /v1/player/sessions/users/{entityId}/revoke | 
*StatsApi* | [**GetAssetStats**](StatsApi.md#getassetstats) | **POST** /v1/player/stats/{assetAddress}/assets/{assetId} | Get asset stats
*StatsApi* | [**GetContractStats**](StatsApi.md#getcontractstats) | **POST** /v1/player/stats/{assetAddress} | Get contract stats
*TransactionsApi* | [**CreateUserTransaction**](TransactionsApi.md#createusertransaction) | **POST** /v1/player/transactions/users/{entityId} | Creating a new transaction on behalf of a user
*TransactionsApi* | [**GetTransaction**](TransactionsApi.md#gettransaction) | **GET** /v1/player/transactions/{transactionId} | Getting a transaction
*TransactionsApi* | [**GetTransactions**](TransactionsApi.md#gettransactions) | **GET** /v1/player/transactions | Get a paginated list of transactions from your game
*TransactionsApi* | [**GetUserTransactions**](TransactionsApi.md#getusertransactions) | **GET** /v1/player/transactions/users/{entityId} | Get a paginated list of transactions created on behalf of a user
*UsersApi* | [**GetAllUsers**](UsersApi.md#getallusers) | **GET** /v1/player/users | Returns a list of users
*UsersApi* | [**GetUser**](UsersApi.md#getuser) | **GET** /v1/player/users/{entityId} | Returns a particular user
*UsersApi* | [**UnlinkUser**](UsersApi.md#unlinkuser) | **DELETE** /v1/player/users/{entityId} | Unlinks an entity ID from a user
*UsersApi* | [**UpdateUser**](UsersApi.md#updateuser) | **PATCH** /v1/player/users/{entityId} | Updates entityId for the user


<a id="documentation-for-models"></a>
## Documentation for Models

 - [Model.AcceptAssetOfferRequestInput](AcceptAssetOfferRequestInput.md)
 - [Model.BeamErrorResponse](BeamErrorResponse.md)
 - [Model.BuyAssetRequestInput](BuyAssetRequestInput.md)
 - [Model.CancelAssetListingRequestInput](CancelAssetListingRequestInput.md)
 - [Model.CancelAssetOfferRequestInput](CancelAssetOfferRequestInput.md)
 - [Model.Check200Response](Check200Response.md)
 - [Model.Check200ResponseInfoValue](Check200ResponseInfoValue.md)
 - [Model.Check503Response](Check503Response.md)
 - [Model.CommonActivityResponse](CommonActivityResponse.md)
 - [Model.CommonActivityResponseDataInner](CommonActivityResponseDataInner.md)
 - [Model.CommonActivityResponseDataInnerAsset](CommonActivityResponseDataInnerAsset.md)
 - [Model.CommonActivityResponseDataInnerContract](CommonActivityResponseDataInnerContract.md)
 - [Model.CommonActivityResponseDataInnerOrder](CommonActivityResponseDataInnerOrder.md)
 - [Model.CommonActivityResponseDataInnerTransaction](CommonActivityResponseDataInnerTransaction.md)
 - [Model.CommonAssetActivityRequestInput](CommonAssetActivityRequestInput.md)
 - [Model.CommonContractActivityRequestInput](CommonContractActivityRequestInput.md)
 - [Model.CommonStatsRequestInput](CommonStatsRequestInput.md)
 - [Model.CommonStatsResponse](CommonStatsResponse.md)
 - [Model.CommonStatsResponseCount](CommonStatsResponseCount.md)
 - [Model.CommonUserActivityRequestInput](CommonUserActivityRequestInput.md)
 - [Model.ConfirmOperationRequest](ConfirmOperationRequest.md)
 - [Model.ConfirmOperationRequestActionsInner](ConfirmOperationRequestActionsInner.md)
 - [Model.ConvertTokenRequestInput](ConvertTokenRequestInput.md)
 - [Model.CreateAssetOfferRequestInput](CreateAssetOfferRequestInput.md)
 - [Model.CreateConnectionRequestInput](CreateConnectionRequestInput.md)
 - [Model.CreateConnectionRequestResponse](CreateConnectionRequestResponse.md)
 - [Model.CreateOnrampRequestInput](CreateOnrampRequestInput.md)
 - [Model.CreateTransactionRequestInput](CreateTransactionRequestInput.md)
 - [Model.CreateTransactionRequestInputInteractionsInner](CreateTransactionRequestInputInteractionsInner.md)
 - [Model.GenerateSessionRequestResponse](GenerateSessionRequestResponse.md)
 - [Model.GenerateSessionUrlRequestInput](GenerateSessionUrlRequestInput.md)
 - [Model.GetActiveSessionResponse](GetActiveSessionResponse.md)
 - [Model.GetActiveSessionResponseV2](GetActiveSessionResponseV2.md)
 - [Model.GetActiveSessionResponseV2Session](GetActiveSessionResponseV2Session.md)
 - [Model.GetActiveSessionsResponse](GetActiveSessionsResponse.md)
 - [Model.GetActiveSessionsResponseSessionsInner](GetActiveSessionsResponseSessionsInner.md)
 - [Model.GetAllUsersResponse](GetAllUsersResponse.md)
 - [Model.GetAllUsersResponseDataInner](GetAllUsersResponseDataInner.md)
 - [Model.GetAllUsersResponseDataInnerWalletsInner](GetAllUsersResponseDataInnerWalletsInner.md)
 - [Model.GetAssetListingsResponse](GetAssetListingsResponse.md)
 - [Model.GetAssetListingsResponseDataInner](GetAssetListingsResponseDataInner.md)
 - [Model.GetAssetListingsResponseDataInnerPrice](GetAssetListingsResponseDataInnerPrice.md)
 - [Model.GetAssetListingsResponseDataInnerPriceAmount](GetAssetListingsResponseDataInnerPriceAmount.md)
 - [Model.GetAssetListingsResponseDataInnerPriceCurrency](GetAssetListingsResponseDataInnerPriceCurrency.md)
 - [Model.GetAssetResponse](GetAssetResponse.md)
 - [Model.GetAssetResponseOwnersInner](GetAssetResponseOwnersInner.md)
 - [Model.GetAssetsForContractBodyInput](GetAssetsForContractBodyInput.md)
 - [Model.GetAssetsForContractBodyInputAttributesInner](GetAssetsForContractBodyInputAttributesInner.md)
 - [Model.GetAssetsForContractResponse](GetAssetsForContractResponse.md)
 - [Model.GetAssetsForContractResponseDataInner](GetAssetsForContractResponseDataInner.md)
 - [Model.GetAssetsForUserBodyInput](GetAssetsForUserBodyInput.md)
 - [Model.GetAssetsForUserResponse](GetAssetsForUserResponse.md)
 - [Model.GetAssetsForUserResponseDataInner](GetAssetsForUserResponseDataInner.md)
 - [Model.GetAssetsForUserResponseDataInnerAttributesInner](GetAssetsForUserResponseDataInnerAttributesInner.md)
 - [Model.GetAttributesResponse](GetAttributesResponse.md)
 - [Model.GetAttributesResponseDataInner](GetAttributesResponseDataInner.md)
 - [Model.GetAttributesResponseDataInnerValuesInner](GetAttributesResponseDataInnerValuesInner.md)
 - [Model.GetChainCurrenciesResponse](GetChainCurrenciesResponse.md)
 - [Model.GetChainCurrenciesResponseDataInner](GetChainCurrenciesResponseDataInner.md)
 - [Model.GetConnectionRequestResponse](GetConnectionRequestResponse.md)
 - [Model.GetListedAssetsBodyInput](GetListedAssetsBodyInput.md)
 - [Model.GetOnRampQuoteResponse](GetOnRampQuoteResponse.md)
 - [Model.GetOnRampQuoteResponseQuote](GetOnRampQuoteResponseQuote.md)
 - [Model.GetOnRampQuoteResponseQuoteInput](GetOnRampQuoteResponseQuoteInput.md)
 - [Model.GetOnRampQuoteResponseQuoteOutput](GetOnRampQuoteResponseQuoteOutput.md)
 - [Model.GetOwnerAssetsBodyInput](GetOwnerAssetsBodyInput.md)
 - [Model.GetOwnerAssetsResponse](GetOwnerAssetsResponse.md)
 - [Model.GetOwnersResponse](GetOwnersResponse.md)
 - [Model.GetOwnersResponseDataInner](GetOwnersResponseDataInner.md)
 - [Model.GetOwnersResponsePagination](GetOwnersResponsePagination.md)
 - [Model.GetQuoteResponse](GetQuoteResponse.md)
 - [Model.GetSessionRequestResponse](GetSessionRequestResponse.md)
 - [Model.GetTransactionResponse](GetTransactionResponse.md)
 - [Model.GetTransactionResponsePolicy](GetTransactionResponsePolicy.md)
 - [Model.GetTransactionResponseUser](GetTransactionResponseUser.md)
 - [Model.GetTransactionResponseUserEntitiesInner](GetTransactionResponseUserEntitiesInner.md)
 - [Model.GetTransactionResponseUserWallet](GetTransactionResponseUserWallet.md)
 - [Model.GetTransactionsResponse](GetTransactionsResponse.md)
 - [Model.GetTransactionsResponseDataInner](GetTransactionsResponseDataInner.md)
 - [Model.GetTransactionsResponseDataInnerIntent](GetTransactionsResponseDataInnerIntent.md)
 - [Model.GetTransactionsResponseDataInnerIntentInteractionsInner](GetTransactionsResponseDataInnerIntentInteractionsInner.md)
 - [Model.GetTransactionsResponseDataInnerTransaction](GetTransactionsResponseDataInnerTransaction.md)
 - [Model.GetTransactionsResponseDataInnerTransactionLogsInner](GetTransactionsResponseDataInnerTransactionLogsInner.md)
 - [Model.GetUserCurrenciesResponse](GetUserCurrenciesResponse.md)
 - [Model.GetUserCurrenciesResponseDataInner](GetUserCurrenciesResponseDataInner.md)
 - [Model.GetUserNativeCurrencyResponse](GetUserNativeCurrencyResponse.md)
 - [Model.GetUserNativeCurrencyResponseNativeTokenBalance](GetUserNativeCurrencyResponseNativeTokenBalance.md)
 - [Model.GetUserResponse](GetUserResponse.md)
 - [Model.PlayerOperationAction](PlayerOperationAction.md)
 - [Model.PlayerOperationActionSignature](PlayerOperationActionSignature.md)
 - [Model.PlayerOperationActionTransaction](PlayerOperationActionTransaction.md)
 - [Model.PlayerOperationResponse](PlayerOperationResponse.md)
 - [Model.ReadContractRequest](ReadContractRequest.md)
 - [Model.ReadContractResonse](ReadContractResonse.md)
 - [Model.RefreshContractRequestBody](RefreshContractRequestBody.md)
 - [Model.RefreshTokenRequestBody](RefreshTokenRequestBody.md)
 - [Model.RevokeSessionRequestInput](RevokeSessionRequestInput.md)
 - [Model.SellAssetRequestInput](SellAssetRequestInput.md)
 - [Model.TransferAssetRequestInput](TransferAssetRequestInput.md)
 - [Model.TransferAssetRequestInputAssetsInner](TransferAssetRequestInputAssetsInner.md)
 - [Model.TransferNativeTokenRequestInput](TransferNativeTokenRequestInput.md)
 - [Model.TransferTokenRequestInput](TransferTokenRequestInput.md)
 - [Model.UnwrappingTokenInput](UnwrappingTokenInput.md)
 - [Model.UpdateUserRequest](UpdateUserRequest.md)
 - [Model.WrappingTokenInput](WrappingTokenInput.md)


<a id="documentation-for-authorization"></a>
## Documentation for Authorization


Authentication schemes defined for the API:
<a id="beam-api-key"></a>
### beam-api-key

- **Type**: API key
- **API key parameter name**: x-api-key
- **Location**: HTTP header

