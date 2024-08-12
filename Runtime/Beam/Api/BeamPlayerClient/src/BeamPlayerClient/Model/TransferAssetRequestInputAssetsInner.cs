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
    /// TransferAssetRequestInputAssetsInner
    /// </summary>
    [DataContract(Name = "TransferAssetRequestInput_assets_inner")]
    [UnityEngine.Scripting.Preserve]
    public partial class TransferAssetRequestInputAssetsInner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransferAssetRequestInputAssetsInner" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        [UnityEngine.Scripting.Preserve]
        protected TransferAssetRequestInputAssetsInner() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransferAssetRequestInputAssetsInner" /> class.
        /// </summary>
        /// <param name="receiverEntityId">receiverEntityId.</param>
        /// <param name="receiverWalletAddress">receiverWalletAddress.</param>
        /// <param name="assetAddress">assetAddress (required).</param>
        /// <param name="assetId">assetId (required).</param>
        /// <param name="amountToTransfer">amountToTransfer (default to 1M).</param>
        [UnityEngine.Scripting.Preserve]
        public TransferAssetRequestInputAssetsInner(string receiverEntityId = default(string), string receiverWalletAddress = default(string), string assetAddress = default(string), string assetId = default(string), decimal amountToTransfer = 1M)
        {
            // to ensure "assetAddress" is required (not null)
            if (assetAddress == null)
            {
                throw new ArgumentNullException("assetAddress is a required property for TransferAssetRequestInputAssetsInner and cannot be null");
            }
            this.AssetAddress = assetAddress;
            // to ensure "assetId" is required (not null)
            if (assetId == null)
            {
                throw new ArgumentNullException("assetId is a required property for TransferAssetRequestInputAssetsInner and cannot be null");
            }
            this.AssetId = assetId;
            this.ReceiverEntityId = receiverEntityId;
            this.ReceiverWalletAddress = receiverWalletAddress;
            this.AmountToTransfer = amountToTransfer;
        }

        /// <summary>
        /// Gets or Sets ReceiverEntityId
        /// </summary>
        [DataMember(Name = "receiverEntityId", EmitDefaultValue = false)]
        [UnityEngine.Scripting.Preserve]
        public string ReceiverEntityId { get; set; }

        /// <summary>
        /// Gets or Sets ReceiverWalletAddress
        /// </summary>
        [DataMember(Name = "receiverWalletAddress", EmitDefaultValue = false)]
        [UnityEngine.Scripting.Preserve]
        public string ReceiverWalletAddress { get; set; }

        /// <summary>
        /// Gets or Sets AssetAddress
        /// </summary>
        [DataMember(Name = "assetAddress", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string AssetAddress { get; set; }

        /// <summary>
        /// Gets or Sets AssetId
        /// </summary>
        [DataMember(Name = "assetId", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string AssetId { get; set; }

        /// <summary>
        /// Gets or Sets AmountToTransfer
        /// </summary>
        [DataMember(Name = "amountToTransfer", EmitDefaultValue = false)]
        [UnityEngine.Scripting.Preserve]
        public decimal AmountToTransfer { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        [UnityEngine.Scripting.Preserve]
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TransferAssetRequestInputAssetsInner {\n");
            sb.Append("  ReceiverEntityId: ").Append(ReceiverEntityId).Append("\n");
            sb.Append("  ReceiverWalletAddress: ").Append(ReceiverWalletAddress).Append("\n");
            sb.Append("  AssetAddress: ").Append(AssetAddress).Append("\n");
            sb.Append("  AssetId: ").Append(AssetId).Append("\n");
            sb.Append("  AmountToTransfer: ").Append(AmountToTransfer).Append("\n");
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
