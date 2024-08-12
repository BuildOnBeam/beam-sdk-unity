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
    /// GetAssetResponseOwnersInner
    /// </summary>
    [DataContract(Name = "GetAssetResponse_owners_inner")]
    [UnityEngine.Scripting.Preserve]
    public partial class GetAssetResponseOwnersInner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAssetResponseOwnersInner" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        [UnityEngine.Scripting.Preserve]
        protected GetAssetResponseOwnersInner() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAssetResponseOwnersInner" /> class.
        /// </summary>
        /// <param name="address">address (required).</param>
        /// <param name="quantity">quantity (required).</param>
        /// <param name="entityId">entityId.</param>
        [UnityEngine.Scripting.Preserve]
        public GetAssetResponseOwnersInner(string address = default(string), decimal quantity = default(decimal), string entityId = default(string))
        {
            // to ensure "address" is required (not null)
            if (address == null)
            {
                throw new ArgumentNullException("address is a required property for GetAssetResponseOwnersInner and cannot be null");
            }
            this.Address = address;
            this.Quantity = quantity;
            this.EntityId = entityId;
        }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name = "address", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets Quantity
        /// </summary>
        [DataMember(Name = "quantity", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or Sets EntityId
        /// </summary>
        [DataMember(Name = "entityId", EmitDefaultValue = false)]
        [UnityEngine.Scripting.Preserve]
        public string EntityId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        [UnityEngine.Scripting.Preserve]
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GetAssetResponseOwnersInner {\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  EntityId: ").Append(EntityId).Append("\n");
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
