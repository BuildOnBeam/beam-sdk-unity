using System;
using BeamPlayerClient.Model;

namespace Beam.Extensions
{
    public static class CommonOperationActionExtensions
    {
        public static BaseActionResponse.TypeEnum? GetActionType(this CommonOperationAction action)
        {
            var typeProp = action.ActualInstance.GetType().GetProperty("Type");
            if (typeProp == null)
            {
                return null;
            }

            var value = typeProp.GetValue(action.ActualInstance, null);
            var type = typeProp.PropertyType;
            // parse enums as string value since they're the same in BaseActionResponse enum and derived ones
            var enumNameValue = Enum.GetName(type, value);
            if (Enum.TryParse(typeof(BaseActionResponse.TypeEnum), enumNameValue, false, out var result))
            {
                return (BaseActionResponse.TypeEnum)result;
            }

            return null;
        }

        public static string GetActionId(this CommonOperationAction action)
        {
            var value = action.ActualInstance.GetType().GetProperty("Id")?.GetValue(action.ActualInstance, null);
            return value as string;
        }

        public static BaseActionSignatureResponse.TypeEnum? GetSignatureType(this CommonOperationAction action)
        {
            object signatureTypeValue = null;
            var actionType = action.GetActionType();
            switch (actionType)
            {
                case BaseActionResponse.TypeEnum.ExchangeConvert:
                {
                    signatureTypeValue =
                        action.GetExchangeConvertAction().Signature.Type;
                    break;
                }
                case BaseActionResponse.TypeEnum.ExchangeUnwrap:
                {
                    signatureTypeValue =
                        action.GetExchangeUnwrapAction().Signature.Type;
                    break;
                }
                case BaseActionResponse.TypeEnum.ExchangeWrap:
                {
                    signatureTypeValue =
                        action.GetExchangeWrapAction().Signature.Type;
                    break;
                }
                case BaseActionResponse.TypeEnum.MarketplaceAcceptOffer:
                {
                    signatureTypeValue =
                        action.GetMarketplaceAcceptOfferAction().Signature.Type;
                    break;
                }
                case BaseActionResponse.TypeEnum.MarketplaceBuyAsset:
                {
                    signatureTypeValue =
                        action.GetMarketplaceBuyAssetAction().Signature.Type;
                    break;
                }
                case BaseActionResponse.TypeEnum.MarketplaceCancelListing:
                {
                    signatureTypeValue =
                        action.GetMarketplaceCancelListingAction().Signature.Type;
                    break;
                }
                case BaseActionResponse.TypeEnum.MarketplaceCancelOffer:
                {
                    signatureTypeValue =
                        action.GetMarketplaceCancelOfferAction().Signature.Type;
                    break;
                }
                case BaseActionResponse.TypeEnum.MarketplaceCreateOffer:
                {
                    signatureTypeValue =
                        action.GetMarketplaceCreateOfferAction().Signature.Type;
                    break;
                }
                case BaseActionResponse.TypeEnum.MarketplaceListAsset:
                {
                    signatureTypeValue =
                        action.GetMarketplaceListAssetAction().Signature.Type;
                    break;
                }
                case BaseActionResponse.TypeEnum.SessionRevoke:
                {
                    signatureTypeValue =
                        action.GetSessionRevokeAction().Signature.Type;
                    break;
                }
                case BaseActionResponse.TypeEnum.TransferNFTs:
                {
                    signatureTypeValue =
                        action.GetTransferNFTsAction().Signature.Type;
                    break;
                }
                case BaseActionResponse.TypeEnum.TransferToken:
                {
                    signatureTypeValue =
                        action.GetTransferTokenAction().Signature.Type;
                    break;
                }
                case BaseActionResponse.TypeEnum.Sign:
                {
                    switch (action.GetSignAction().Signature.ActualInstance)
                    {
                        case SignatureRequestMessage signature:
                        {
                            signatureTypeValue = signature.Type;
                            break;
                        }
                        case SignatureRequestTypedData signature:
                        {
                            signatureTypeValue = signature.Type;
                            break;
                        }
                    }

                    break;
                }
                case BaseActionResponse.TypeEnum.CustomTransaction:
                {
                    switch (action.GetCustomTransactionAction().Signature.ActualInstance)
                    {
                        case SignatureRequestMessage signature:
                        {
                            signatureTypeValue = signature.Type;
                            break;
                        }
                        case SignatureRequestTypedData signature:
                        {
                            signatureTypeValue = signature.Type;
                            break;
                        }
                    }

                    break;
                }
                default:
                    System.Diagnostics.Debug.WriteLine(
                        $"Unknown CommonOperationAction Signature Type: {actionType.ToString()}");
                    break;
            }

            if (signatureTypeValue == null)
            {
                return null;
            }

            var signatureTypeInfo = signatureTypeValue.GetType();
            var enumNameValue = Enum.GetName(signatureTypeInfo, signatureTypeValue);
            if (Enum.TryParse(typeof(BaseActionSignatureResponse.TypeEnum), enumNameValue, false, out var result))
            {
                return (BaseActionSignatureResponse.TypeEnum)result;
            }

            return null;
        }

        public static string GetMessageToSign(this CommonOperationAction action)
        {
            var actionType = action.GetActionType();
            switch (actionType)
            {
                case BaseActionResponse.TypeEnum.ExchangeConvert:
                {
                    return action.GetExchangeConvertAction().Signature.Data;
                }
                case BaseActionResponse.TypeEnum.ExchangeUnwrap:
                {
                    return action.GetExchangeUnwrapAction().Signature.Data;
                }
                case BaseActionResponse.TypeEnum.ExchangeWrap:
                {
                    return action.GetExchangeWrapAction().Signature.Data;
                }
                case BaseActionResponse.TypeEnum.MarketplaceAcceptOffer:
                {
                    return action.GetMarketplaceAcceptOfferAction().Signature.Data;
                }
                case BaseActionResponse.TypeEnum.MarketplaceBuyAsset:
                {
                    return action.GetMarketplaceBuyAssetAction().Signature.Data;
                }
                case BaseActionResponse.TypeEnum.MarketplaceCancelListing:
                {
                    return action.GetMarketplaceCancelListingAction().Signature.Data;
                }
                case BaseActionResponse.TypeEnum.MarketplaceCancelOffer:
                {
                    return action.GetMarketplaceCancelOfferAction().Signature.Data;
                }
                case BaseActionResponse.TypeEnum.MarketplaceCreateOffer:
                {
                    return action.GetMarketplaceCreateOfferAction().Signature.Hash;
                }
                case BaseActionResponse.TypeEnum.MarketplaceListAsset:
                {
                    return action.GetMarketplaceListAssetAction().Signature.Hash;
                }
                case BaseActionResponse.TypeEnum.SessionRevoke:
                {
                    return action.GetSessionRevokeAction().Signature.Data;
                }
                case BaseActionResponse.TypeEnum.TransferNFTs:
                {
                    return action.GetTransferNFTsAction().Signature.Data;
                }
                case BaseActionResponse.TypeEnum.TransferToken:
                {
                    return action.GetTransferTokenAction().Signature.Data;
                }
                case BaseActionResponse.TypeEnum.Sign:
                {
                    switch (action.GetSignAction().Signature.ActualInstance)
                    {
                        case SignatureRequestMessage signature:
                        {
                            return signature.Data;
                        }
                        case SignatureRequestTypedData signature:
                        {
                            return signature.Hash;
                        }
                    }

                    return null;
                }
                case BaseActionResponse.TypeEnum.CustomTransaction:
                {
                    switch (action.GetCustomTransactionAction().Signature.ActualInstance)
                    {
                        case SignatureRequestMessage signature:
                        {
                            return signature.Data;
                        }
                        case SignatureRequestTypedData signature:
                        {
                            return signature.Hash;
                        }
                    }

                    return null;
                }
                default:
                    System.Diagnostics.Debug.WriteLine($"Unknown CommonOperationAction Type: {actionType.ToString()}");
                    return null;
            }
        }
    }
}