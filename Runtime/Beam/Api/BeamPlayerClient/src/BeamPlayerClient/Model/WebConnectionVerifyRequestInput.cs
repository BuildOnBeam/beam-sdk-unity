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
    /// WebConnectionVerifyRequestInput
    /// </summary>
    [DataContract(Name = "WebConnectionVerifyRequestInput")]
    public partial class WebConnectionVerifyRequestInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebConnectionVerifyRequestInput" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected WebConnectionVerifyRequestInput() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WebConnectionVerifyRequestInput" /> class.
        /// </summary>
        /// <param name="accountAddress">accountAddress (required).</param>
        /// <param name="ownerAddress">ownerAddress (required).</param>
        /// <param name="chainId">chainId (default to 13337M).</param>
        public WebConnectionVerifyRequestInput(string accountAddress = default(string), string ownerAddress = default(string), decimal chainId = 13337M)
        {
            // to ensure "accountAddress" is required (not null)
            if (accountAddress == null)
            {
                throw new ArgumentNullException("accountAddress is a required property for WebConnectionVerifyRequestInput and cannot be null");
            }
            this.AccountAddress = accountAddress;
            // to ensure "ownerAddress" is required (not null)
            if (ownerAddress == null)
            {
                throw new ArgumentNullException("ownerAddress is a required property for WebConnectionVerifyRequestInput and cannot be null");
            }
            this.OwnerAddress = ownerAddress;
            this.ChainId = chainId;
        }

        /// <summary>
        /// Gets or Sets AccountAddress
        /// </summary>
        [DataMember(Name = "accountAddress", IsRequired = true, EmitDefaultValue = true)]
        public string AccountAddress { get; set; }

        /// <summary>
        /// Gets or Sets OwnerAddress
        /// </summary>
        [DataMember(Name = "ownerAddress", IsRequired = true, EmitDefaultValue = true)]
        public string OwnerAddress { get; set; }

        /// <summary>
        /// Gets or Sets ChainId
        /// </summary>
        [DataMember(Name = "chainId", EmitDefaultValue = false)]
        public decimal ChainId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WebConnectionVerifyRequestInput {\n");
            sb.Append("  AccountAddress: ").Append(AccountAddress).Append("\n");
            sb.Append("  OwnerAddress: ").Append(OwnerAddress).Append("\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
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
