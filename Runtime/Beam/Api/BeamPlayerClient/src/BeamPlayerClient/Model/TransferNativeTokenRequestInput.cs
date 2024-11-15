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
    /// TransferNativeTokenRequestInput
    /// </summary>
    [DataContract(Name = "TransferNativeTokenRequestInput")]
    [UnityEngine.Scripting.Preserve]
    public partial class TransferNativeTokenRequestInput
    {
        /// <summary>
        /// Defines OperationProcessing
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OperationProcessingEnum
        {
            /// <summary>
            /// Enum SignOnly for value: SignOnly
            /// </summary>
            [EnumMember(Value = "SignOnly")]
            SignOnly = 1,

            /// <summary>
            /// Enum Execute for value: Execute
            /// </summary>
            [EnumMember(Value = "Execute")]
            Execute = 2
        }


        /// <summary>
        /// Gets or Sets OperationProcessing
        /// </summary>
        [DataMember(Name = "operationProcessing", EmitDefaultValue = false)]
        [UnityEngine.Scripting.Preserve]
        public OperationProcessingEnum? OperationProcessing { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransferNativeTokenRequestInput" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TransferNativeTokenRequestInput() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransferNativeTokenRequestInput" /> class.
        /// </summary>
        /// <param name="receiverEntityId">receiverEntityId.</param>
        /// <param name="receiverWalletAddress">receiverWalletAddress.</param>
        /// <param name="amountToTransfer">amountToTransfer (required).</param>
        /// <param name="optimistic">optimistic (default to false).</param>
        /// <param name="sponsor">sponsor (default to true).</param>
        /// <param name="policyId">policyId.</param>
        /// <param name="chainId">chainId (default to 13337).</param>
        /// <param name="operationProcessing">operationProcessing (default to OperationProcessingEnum.Execute).</param>
        [UnityEngine.Scripting.Preserve]
        public TransferNativeTokenRequestInput(string receiverEntityId = default(string), string receiverWalletAddress = default(string), string amountToTransfer = default(string), bool optimistic = false, bool sponsor = true, string policyId = default(string), long chainId = 13337, OperationProcessingEnum? operationProcessing = OperationProcessingEnum.Execute)
        {
            // to ensure "amountToTransfer" is required (not null)
            if (amountToTransfer == null)
            {
                throw new ArgumentNullException("amountToTransfer is a required property for TransferNativeTokenRequestInput and cannot be null");
            }
            this.AmountToTransfer = amountToTransfer;
            this.ReceiverEntityId = receiverEntityId;
            this.ReceiverWalletAddress = receiverWalletAddress;
            this.Optimistic = optimistic;
            this.Sponsor = sponsor;
            this.PolicyId = policyId;
            this.ChainId = chainId;
            this.OperationProcessing = operationProcessing;
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
        /// Gets or Sets AmountToTransfer
        /// </summary>
        [DataMember(Name = "amountToTransfer", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string AmountToTransfer { get; set; }

        /// <summary>
        /// Gets or Sets Optimistic
        /// </summary>
        [DataMember(Name = "optimistic", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public bool Optimistic { get; set; }

        /// <summary>
        /// Gets or Sets Sponsor
        /// </summary>
        [DataMember(Name = "sponsor", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public bool Sponsor { get; set; }

        /// <summary>
        /// Gets or Sets PolicyId
        /// </summary>
        [DataMember(Name = "policyId", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string PolicyId { get; set; }

        /// <summary>
        /// Gets or Sets ChainId
        /// </summary>
        [DataMember(Name = "chainId", EmitDefaultValue = false)]
        [UnityEngine.Scripting.Preserve]
        public long ChainId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        [UnityEngine.Scripting.Preserve]
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TransferNativeTokenRequestInput {\n");
            sb.Append("  ReceiverEntityId: ").Append(ReceiverEntityId).Append("\n");
            sb.Append("  ReceiverWalletAddress: ").Append(ReceiverWalletAddress).Append("\n");
            sb.Append("  AmountToTransfer: ").Append(AmountToTransfer).Append("\n");
            sb.Append("  Optimistic: ").Append(Optimistic).Append("\n");
            sb.Append("  Sponsor: ").Append(Sponsor).Append("\n");
            sb.Append("  PolicyId: ").Append(PolicyId).Append("\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
            sb.Append("  OperationProcessing: ").Append(OperationProcessing).Append("\n");
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
