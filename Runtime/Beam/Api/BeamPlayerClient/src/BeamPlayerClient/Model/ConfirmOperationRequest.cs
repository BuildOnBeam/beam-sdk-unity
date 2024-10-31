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
    /// ConfirmOperationRequest
    /// </summary>
    [DataContract(Name = "ConfirmOperationRequest")]
    [UnityEngine.Scripting.Preserve]
    public partial class ConfirmOperationRequest
    {
        /// <summary>
        /// Defines Status
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Pending for value: Pending
            /// </summary>
            [EnumMember(Value = "Pending")]
            Pending = 1,

            /// <summary>
            /// Enum Signed for value: Signed
            /// </summary>
            [EnumMember(Value = "Signed")]
            Signed = 2,

            /// <summary>
            /// Enum Rejected for value: Rejected
            /// </summary>
            [EnumMember(Value = "Rejected")]
            Rejected = 3,

            /// <summary>
            /// Enum Executed for value: Executed
            /// </summary>
            [EnumMember(Value = "Executed")]
            Executed = 4,

            /// <summary>
            /// Enum Error for value: Error
            /// </summary>
            [EnumMember(Value = "Error")]
            Error = 5
        }


        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmOperationRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        [UnityEngine.Scripting.Preserve]
        protected ConfirmOperationRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmOperationRequest" /> class.
        /// </summary>
        /// <param name="status">status (required).</param>
        /// <param name="transactions">transactions.</param>
        [UnityEngine.Scripting.Preserve]
        public ConfirmOperationRequest(StatusEnum status = default(StatusEnum), List<ConfirmOperationRequestTransactionsInner> transactions = default(List<ConfirmOperationRequestTransactionsInner>))
        {
            this.Status = status;
            this.Transactions = transactions;
        }

        /// <summary>
        /// Gets or Sets Transactions
        /// </summary>
        [DataMember(Name = "transactions", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public List<ConfirmOperationRequestTransactionsInner> Transactions { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        [UnityEngine.Scripting.Preserve]
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ConfirmOperationRequest {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Transactions: ").Append(Transactions).Append("\n");
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
