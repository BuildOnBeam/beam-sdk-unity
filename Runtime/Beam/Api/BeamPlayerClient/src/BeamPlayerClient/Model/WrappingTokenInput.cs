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
    /// WrappingTokenInput
    /// </summary>
    [DataContract(Name = "WrappingTokenInput")]
    [UnityEngine.Scripting.Preserve]
    public partial class WrappingTokenInput
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
        /// Initializes a new instance of the <see cref="WrappingTokenInput" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        [UnityEngine.Scripting.Preserve]
        protected WrappingTokenInput() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WrappingTokenInput" /> class.
        /// </summary>
        /// <param name="amount">amount (required).</param>
        /// <param name="optimistic">optimistic (default to false).</param>
        /// <param name="sponsor">sponsor (default to true).</param>
        /// <param name="policyId">policyId.</param>
        /// <param name="chainId">chainId (default to 13337M).</param>
        /// <param name="operationProcessing">operationProcessing (default to OperationProcessingEnum.Execute).</param>
        /// <param name="operationId">operationId.</param>
        [UnityEngine.Scripting.Preserve]
        public WrappingTokenInput(string amount = default(string), bool optimistic = false, bool sponsor = true, string policyId = default(string), decimal chainId = 13337M, OperationProcessingEnum? operationProcessing = OperationProcessingEnum.Execute, string operationId = default(string))
        {
            // to ensure "amount" is required (not null)
            if (amount == null)
            {
                throw new ArgumentNullException("amount is a required property for WrappingTokenInput and cannot be null");
            }
            this.Amount = amount;
            this.Optimistic = optimistic;
            this.Sponsor = sponsor;
            this.PolicyId = policyId;
            this.ChainId = chainId;
            this.OperationProcessing = operationProcessing;
            this.OperationId = operationId;
        }

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name = "amount", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string Amount { get; set; }

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
        public decimal ChainId { get; set; }

        /// <summary>
        /// Gets or Sets OperationId
        /// </summary>
        [DataMember(Name = "operationId", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string OperationId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        [UnityEngine.Scripting.Preserve]
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WrappingTokenInput {\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  Optimistic: ").Append(Optimistic).Append("\n");
            sb.Append("  Sponsor: ").Append(Sponsor).Append("\n");
            sb.Append("  PolicyId: ").Append(PolicyId).Append("\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
            sb.Append("  OperationProcessing: ").Append(OperationProcessing).Append("\n");
            sb.Append("  OperationId: ").Append(OperationId).Append("\n");
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
