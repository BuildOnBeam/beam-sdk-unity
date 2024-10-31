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
    /// CommonOperationResponseActionsInnerAllOfSignature
    /// </summary>
    [DataContract(Name = "CommonOperationResponse_actions_inner_allOf_signature")]
    [UnityEngine.Scripting.Preserve]
    public partial class CommonOperationResponseActionsInnerAllOfSignature
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum Message for value: Message
            /// </summary>
            [EnumMember(Value = "Message")]
            Message = 1,

            /// <summary>
            /// Enum TypedData for value: TypedData
            /// </summary>
            [EnumMember(Value = "TypedData")]
            TypedData = 2
        }


        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonOperationResponseActionsInnerAllOfSignature" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        [UnityEngine.Scripting.Preserve]
        protected CommonOperationResponseActionsInnerAllOfSignature() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonOperationResponseActionsInnerAllOfSignature" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="id">id (required).</param>
        /// <param name="data">data.</param>
        /// <param name="signature">signature (required).</param>
        /// <param name="actionId">actionId (required).</param>
        /// <param name="hash">hash.</param>
        [UnityEngine.Scripting.Preserve]
        public CommonOperationResponseActionsInnerAllOfSignature(TypeEnum type = default(TypeEnum), string id = default(string), Object data = default(Object), string signature = default(string), string actionId = default(string), string hash = default(string))
        {
            this.Type = type;
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for CommonOperationResponseActionsInnerAllOfSignature and cannot be null");
            }
            this.Id = id;
            // to ensure "signature" is required (not null)
            if (signature == null)
            {
                throw new ArgumentNullException("signature is a required property for CommonOperationResponseActionsInnerAllOfSignature and cannot be null");
            }
            this.Signature = signature;
            // to ensure "actionId" is required (not null)
            if (actionId == null)
            {
                throw new ArgumentNullException("actionId is a required property for CommonOperationResponseActionsInnerAllOfSignature and cannot be null");
            }
            this.ActionId = actionId;
            this.Data = data;
            this.Hash = hash;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name = "data", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public Object Data { get; set; }

        /// <summary>
        /// Gets or Sets Signature
        /// </summary>
        [DataMember(Name = "signature", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string Signature { get; set; }

        /// <summary>
        /// Gets or Sets ActionId
        /// </summary>
        [DataMember(Name = "actionId", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string ActionId { get; set; }

        /// <summary>
        /// Gets or Sets Hash
        /// </summary>
        [DataMember(Name = "hash", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string Hash { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        [UnityEngine.Scripting.Preserve]
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CommonOperationResponseActionsInnerAllOfSignature {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  Signature: ").Append(Signature).Append("\n");
            sb.Append("  ActionId: ").Append(ActionId).Append("\n");
            sb.Append("  Hash: ").Append(Hash).Append("\n");
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
