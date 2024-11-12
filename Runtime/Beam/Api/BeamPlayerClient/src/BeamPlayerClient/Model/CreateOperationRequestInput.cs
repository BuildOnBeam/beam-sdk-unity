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
    /// CreateOperationRequestInput
    /// </summary>
    [DataContract(Name = "CreateOperationRequestInput")]
    [UnityEngine.Scripting.Preserve]
    public partial class CreateOperationRequestInput
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
        /// Initializes a new instance of the <see cref="CreateOperationRequestInput" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CreateOperationRequestInput() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOperationRequestInput" /> class.
        /// </summary>
        /// <param name="entityId">entityId (required).</param>
        /// <param name="actions">actions.</param>
        /// <param name="transactions">transactions.</param>
        /// <param name="chainId">chainId (default to 13337).</param>
        /// <param name="operationProcessing">operationProcessing (default to OperationProcessingEnum.Execute).</param>
        /// <param name="operationId">operationId.</param>
        [UnityEngine.Scripting.Preserve]
        public CreateOperationRequestInput(string entityId = default(string), List<CreateOperationRequestInputActionsInner> actions = default(List<CreateOperationRequestInputActionsInner>), List<CreateOperationRequestInputTransactionsInner> transactions = default(List<CreateOperationRequestInputTransactionsInner>), long chainId = 13337, OperationProcessingEnum? operationProcessing = OperationProcessingEnum.Execute, string operationId = default(string))
        {
            // to ensure "entityId" is required (not null)
            if (entityId == null)
            {
                throw new ArgumentNullException("entityId is a required property for CreateOperationRequestInput and cannot be null");
            }
            this.EntityId = entityId;
            this.Actions = actions;
            this.Transactions = transactions;
            this.ChainId = chainId;
            this.OperationProcessing = operationProcessing;
            this.OperationId = operationId;
        }

        /// <summary>
        /// Gets or Sets EntityId
        /// </summary>
        [DataMember(Name = "entityId", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string EntityId { get; set; }

        /// <summary>
        /// Gets or Sets Actions
        /// </summary>
        [DataMember(Name = "actions", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public List<CreateOperationRequestInputActionsInner> Actions { get; set; }

        /// <summary>
        /// Gets or Sets Transactions
        /// </summary>
        [DataMember(Name = "transactions", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public List<CreateOperationRequestInputTransactionsInner> Transactions { get; set; }

        /// <summary>
        /// Gets or Sets ChainId
        /// </summary>
        [DataMember(Name = "chainId", EmitDefaultValue = false)]
        [UnityEngine.Scripting.Preserve]
        public long ChainId { get; set; }

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
            sb.Append("class CreateOperationRequestInput {\n");
            sb.Append("  EntityId: ").Append(EntityId).Append("\n");
            sb.Append("  Actions: ").Append(Actions).Append("\n");
            sb.Append("  Transactions: ").Append(Transactions).Append("\n");
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
