/*
 * Player API
 *
 * The Player API is a service to integrate your game with Beam
 *
 * The version of the OpenAPI document: 1.0.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OpenAPIDateConverter = BeamPlayerClient.Client.OpenAPIDateConverter;

namespace BeamPlayerClient.Model
{
    /// <summary>
    /// TransferNFTsAction
    /// </summary>
    [DataContract(Name = "TransferNFTsAction")]
    [UnityEngine.Scripting.Preserve]
    public partial class TransferNFTsAction
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum Sign for value: Sign
            /// </summary>
            [EnumMember(Value = "Sign")]
            Sign = 1,

            /// <summary>
            /// Enum SessionRevoke for value: SessionRevoke
            /// </summary>
            [EnumMember(Value = "SessionRevoke")]
            SessionRevoke = 2,

            /// <summary>
            /// Enum MarketplaceCreateOffer for value: MarketplaceCreateOffer
            /// </summary>
            [EnumMember(Value = "MarketplaceCreateOffer")]
            MarketplaceCreateOffer = 3,

            /// <summary>
            /// Enum MarketplaceCancelOffer for value: MarketplaceCancelOffer
            /// </summary>
            [EnumMember(Value = "MarketplaceCancelOffer")]
            MarketplaceCancelOffer = 4,

            /// <summary>
            /// Enum MarketplaceAcceptOffer for value: MarketplaceAcceptOffer
            /// </summary>
            [EnumMember(Value = "MarketplaceAcceptOffer")]
            MarketplaceAcceptOffer = 5,

            /// <summary>
            /// Enum MarketplaceBuyAsset for value: MarketplaceBuyAsset
            /// </summary>
            [EnumMember(Value = "MarketplaceBuyAsset")]
            MarketplaceBuyAsset = 6,

            /// <summary>
            /// Enum MarketplaceListAsset for value: MarketplaceListAsset
            /// </summary>
            [EnumMember(Value = "MarketplaceListAsset")]
            MarketplaceListAsset = 7,

            /// <summary>
            /// Enum MarketplaceCancelListing for value: MarketplaceCancelListing
            /// </summary>
            [EnumMember(Value = "MarketplaceCancelListing")]
            MarketplaceCancelListing = 8,

            /// <summary>
            /// Enum ExchangeConvert for value: ExchangeConvert
            /// </summary>
            [EnumMember(Value = "ExchangeConvert")]
            ExchangeConvert = 9,

            /// <summary>
            /// Enum ExchangeWrap for value: ExchangeWrap
            /// </summary>
            [EnumMember(Value = "ExchangeWrap")]
            ExchangeWrap = 10,

            /// <summary>
            /// Enum ExchangeUnwrap for value: ExchangeUnwrap
            /// </summary>
            [EnumMember(Value = "ExchangeUnwrap")]
            ExchangeUnwrap = 11,

            /// <summary>
            /// Enum TransferNFTs for value: TransferNFTs
            /// </summary>
            [EnumMember(Value = "TransferNFTs")]
            TransferNFTs = 12,

            /// <summary>
            /// Enum TransferToken for value: TransferToken
            /// </summary>
            [EnumMember(Value = "TransferToken")]
            TransferToken = 13,

            /// <summary>
            /// Enum CustomTransaction for value: CustomTransaction
            /// </summary>
            [EnumMember(Value = "CustomTransaction")]
            CustomTransaction = 14
        }


        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransferNFTsAction" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        [UnityEngine.Scripting.Preserve]
        protected TransferNFTsAction() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransferNFTsAction" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="index">index (required).</param>
        /// <param name="type">type (required).</param>
        /// <param name="operationId">operationId (required).</param>
        /// <param name="signature">signature (required).</param>
        /// <param name="context">context (required).</param>
        /// <param name="transaction">transaction (required).</param>
        [UnityEngine.Scripting.Preserve]
        public TransferNFTsAction(string id = default(string), int index = default(int), TypeEnum type = default(TypeEnum), string operationId = default(string), BaseSignatureRequest signature = default(BaseSignatureRequest), ContextTransferNFTs context = default(ContextTransferNFTs), Transaction transaction = default(Transaction))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for TransferNFTsAction and cannot be null");
            }
            this.Id = id;
            this.Index = index;
            this.Type = type;
            // to ensure "operationId" is required (not null)
            if (operationId == null)
            {
                throw new ArgumentNullException("operationId is a required property for TransferNFTsAction and cannot be null");
            }
            this.OperationId = operationId;
            // to ensure "signature" is required (not null)
            if (signature == null)
            {
                throw new ArgumentNullException("signature is a required property for TransferNFTsAction and cannot be null");
            }
            this.Signature = signature;
            // to ensure "context" is required (not null)
            if (context == null)
            {
                throw new ArgumentNullException("context is a required property for TransferNFTsAction and cannot be null");
            }
            this.Context = context;
            // to ensure "transaction" is required (not null)
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction is a required property for TransferNFTsAction and cannot be null");
            }
            this.Transaction = transaction;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Index
        /// </summary>
        [DataMember(Name = "index", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public int Index { get; set; }

        /// <summary>
        /// Gets or Sets OperationId
        /// </summary>
        [DataMember(Name = "operationId", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string OperationId { get; set; }

        /// <summary>
        /// Gets or Sets Signature
        /// </summary>
        [DataMember(Name = "signature", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public BaseSignatureRequest Signature { get; set; }

        /// <summary>
        /// Gets or Sets Context
        /// </summary>
        [DataMember(Name = "context", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public ContextTransferNFTs Context { get; set; }

        /// <summary>
        /// Gets or Sets Transaction
        /// </summary>
        [DataMember(Name = "transaction", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public Transaction Transaction { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        [UnityEngine.Scripting.Preserve]
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TransferNFTsAction {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Index: ").Append(Index).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  OperationId: ").Append(OperationId).Append("\n");
            sb.Append("  Signature: ").Append(Signature).Append("\n");
            sb.Append("  Context: ").Append(Context).Append("\n");
            sb.Append("  Transaction: ").Append(Transaction).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        [UnityEngine.Scripting.Preserve]
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

    }

}
