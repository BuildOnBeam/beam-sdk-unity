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
    /// CommonOperationResponseTransactionsInner
    /// </summary>
    [DataContract(Name = "CommonOperationResponse_transactions_inner")]
    public partial class CommonOperationResponseTransactionsInner
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum OpenfortTransaction for value: OpenfortTransaction
            /// </summary>
            [EnumMember(Value = "OpenfortTransaction")]
            OpenfortTransaction = 1,

            /// <summary>
            /// Enum OpenfortReservoirOrder for value: OpenfortReservoirOrder
            /// </summary>
            [EnumMember(Value = "OpenfortReservoirOrder")]
            OpenfortReservoirOrder = 2,

            /// <summary>
            /// Enum OpenfortRevokeSession for value: OpenfortRevokeSession
            /// </summary>
            [EnumMember(Value = "OpenfortRevokeSession")]
            OpenfortRevokeSession = 3
        }


        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public TypeEnum Type { get; set; }
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
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonOperationResponseTransactionsInner" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CommonOperationResponseTransactionsInner() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonOperationResponseTransactionsInner" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="status">status (required).</param>
        /// <param name="id">id (required).</param>
        /// <param name="externalId">externalId (required).</param>
        /// <param name="signature">signature (required).</param>
        /// <param name="transactionHash">transactionHash (required).</param>
        /// <param name="operationId">operationId (required).</param>
        /// <param name="data">data.</param>
        /// <param name="hash">hash (required).</param>
        public CommonOperationResponseTransactionsInner(TypeEnum type = default(TypeEnum), StatusEnum status = default(StatusEnum), string id = default(string), string externalId = default(string), string signature = default(string), string transactionHash = default(string), string operationId = default(string), CommonOperationResponseTransactionsInnerData data = default(CommonOperationResponseTransactionsInnerData), string hash = default(string))
        {
            this.Type = type;
            this.Status = status;
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for CommonOperationResponseTransactionsInner and cannot be null");
            }
            this.Id = id;
            // to ensure "externalId" is required (not null)
            if (externalId == null)
            {
                throw new ArgumentNullException("externalId is a required property for CommonOperationResponseTransactionsInner and cannot be null");
            }
            this.ExternalId = externalId;
            // to ensure "signature" is required (not null)
            if (signature == null)
            {
                throw new ArgumentNullException("signature is a required property for CommonOperationResponseTransactionsInner and cannot be null");
            }
            this.Signature = signature;
            // to ensure "transactionHash" is required (not null)
            if (transactionHash == null)
            {
                throw new ArgumentNullException("transactionHash is a required property for CommonOperationResponseTransactionsInner and cannot be null");
            }
            this.TransactionHash = transactionHash;
            // to ensure "operationId" is required (not null)
            if (operationId == null)
            {
                throw new ArgumentNullException("operationId is a required property for CommonOperationResponseTransactionsInner and cannot be null");
            }
            this.OperationId = operationId;
            // to ensure "hash" is required (not null)
            if (hash == null)
            {
                throw new ArgumentNullException("hash is a required property for CommonOperationResponseTransactionsInner and cannot be null");
            }
            this.Hash = hash;
            this.Data = data;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets ExternalId
        /// </summary>
        [DataMember(Name = "externalId", IsRequired = true, EmitDefaultValue = true)]
        public string ExternalId { get; set; }

        /// <summary>
        /// Gets or Sets Signature
        /// </summary>
        [DataMember(Name = "signature", IsRequired = true, EmitDefaultValue = true)]
        public string Signature { get; set; }

        /// <summary>
        /// Gets or Sets TransactionHash
        /// </summary>
        [DataMember(Name = "transactionHash", IsRequired = true, EmitDefaultValue = true)]
        public string TransactionHash { get; set; }

        /// <summary>
        /// Gets or Sets OperationId
        /// </summary>
        [DataMember(Name = "operationId", IsRequired = true, EmitDefaultValue = true)]
        public string OperationId { get; set; }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name = "data", EmitDefaultValue = true)]
        public CommonOperationResponseTransactionsInnerData Data { get; set; }

        /// <summary>
        /// Gets or Sets Hash
        /// </summary>
        [DataMember(Name = "hash", IsRequired = true, EmitDefaultValue = true)]
        public string Hash { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CommonOperationResponseTransactionsInner {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ExternalId: ").Append(ExternalId).Append("\n");
            sb.Append("  Signature: ").Append(Signature).Append("\n");
            sb.Append("  TransactionHash: ").Append(TransactionHash).Append("\n");
            sb.Append("  OperationId: ").Append(OperationId).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  Hash: ").Append(Hash).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

    }

}
