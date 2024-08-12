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
    /// GetTransactionResponseUserWallet
    /// </summary>
    [DataContract(Name = "GetTransactionResponse_user_wallet")]
    [UnityEngine.Scripting.Preserve]
    public partial class GetTransactionResponseUserWallet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTransactionResponseUserWallet" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        [UnityEngine.Scripting.Preserve]
        protected GetTransactionResponseUserWallet() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTransactionResponseUserWallet" /> class.
        /// </summary>
        /// <param name="address">address (required).</param>
        [UnityEngine.Scripting.Preserve]
        public GetTransactionResponseUserWallet(string address = default(string))
        {
            // to ensure "address" is required (not null)
            if (address == null)
            {
                throw new ArgumentNullException("address is a required property for GetTransactionResponseUserWallet and cannot be null");
            }
            this.Address = address;
        }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name = "address", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string Address { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        [UnityEngine.Scripting.Preserve]
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GetTransactionResponseUserWallet {\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
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
