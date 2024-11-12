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
    /// CreateOperationRequestInputActionsInner
    /// </summary>
    [DataContract(Name = "CreateOperationRequestInput_actions_inner")]
    [UnityEngine.Scripting.Preserve]
    public partial class CreateOperationRequestInputActionsInner
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
            Sign = 1
        }


        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOperationRequestInputActionsInner" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CreateOperationRequestInputActionsInner() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOperationRequestInputActionsInner" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="signature">signature (required).</param>
        /// <param name="transaction">transaction (required).</param>
        /// <param name="context">context (required).</param>
        [UnityEngine.Scripting.Preserve]
        public CreateOperationRequestInputActionsInner(TypeEnum type = default(TypeEnum), CreateCustomTransactionActionSignature signature = default(CreateCustomTransactionActionSignature), CreateTransaction transaction = default(CreateTransaction), ContextExchangeUnwrap context = default(ContextExchangeUnwrap))
        {
            this.Type = type;
            // to ensure "signature" is required (not null)
            if (signature == null)
            {
                throw new ArgumentNullException("signature is a required property for CreateOperationRequestInputActionsInner and cannot be null");
            }
            this.Signature = signature;
            // to ensure "transaction" is required (not null)
            if (transaction == null)
            {
                throw new ArgumentNullException("transaction is a required property for CreateOperationRequestInputActionsInner and cannot be null");
            }
            this.Transaction = transaction;
            // to ensure "context" is required (not null)
            if (context == null)
            {
                throw new ArgumentNullException("context is a required property for CreateOperationRequestInputActionsInner and cannot be null");
            }
            this.Context = context;
        }

        /// <summary>
        /// Gets or Sets Signature
        /// </summary>
        [DataMember(Name = "signature", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public CreateCustomTransactionActionSignature Signature { get; set; }

        /// <summary>
        /// Gets or Sets Transaction
        /// </summary>
        [DataMember(Name = "transaction", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public CreateTransaction Transaction { get; set; }

        /// <summary>
        /// Gets or Sets Context
        /// </summary>
        [DataMember(Name = "context", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public ContextExchangeUnwrap Context { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        [UnityEngine.Scripting.Preserve]
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CreateOperationRequestInputActionsInner {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Signature: ").Append(Signature).Append("\n");
            sb.Append("  Transaction: ").Append(Transaction).Append("\n");
            sb.Append("  Context: ").Append(Context).Append("\n");
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
