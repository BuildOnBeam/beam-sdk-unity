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
    /// GenerateSessionUrlRequestInput
    /// </summary>
    [DataContract(Name = "GenerateSessionUrlRequestInput")]
    [UnityEngine.Scripting.Preserve]
    public partial class GenerateSessionUrlRequestInput
    {
        /// <summary>
        /// Auth Provider for the user to use. If it&#39;s Any, user will be able to choose his preferred login method. Useful when you want to present social login choice in your UI.
        /// </summary>
        /// <value>Auth Provider for the user to use. If it&#39;s Any, user will be able to choose his preferred login method. Useful when you want to present social login choice in your UI.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AuthProviderEnum
        {
            /// <summary>
            /// Enum Any for value: Any
            /// </summary>
            [EnumMember(Value = "Any")]
            Any = 1,

            /// <summary>
            /// Enum Google for value: Google
            /// </summary>
            [EnumMember(Value = "Google")]
            Google = 2,

            /// <summary>
            /// Enum Discord for value: Discord
            /// </summary>
            [EnumMember(Value = "Discord")]
            Discord = 3,

            /// <summary>
            /// Enum Apple for value: Apple
            /// </summary>
            [EnumMember(Value = "Apple")]
            Apple = 4
        }


        /// <summary>
        /// Auth Provider for the user to use. If it&#39;s Any, user will be able to choose his preferred login method. Useful when you want to present social login choice in your UI.
        /// </summary>
        /// <value>Auth Provider for the user to use. If it&#39;s Any, user will be able to choose his preferred login method. Useful when you want to present social login choice in your UI.</value>
        [DataMember(Name = "authProvider", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public AuthProviderEnum? AuthProvider { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateSessionUrlRequestInput" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GenerateSessionUrlRequestInput() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateSessionUrlRequestInput" /> class.
        /// </summary>
        /// <param name="address">address (required).</param>
        /// <param name="entityId">entityId.</param>
        /// <param name="suggestedExpiry">suggestedExpiry.</param>
        /// <param name="authProvider">Auth Provider for the user to use. If it&#39;s Any, user will be able to choose his preferred login method. Useful when you want to present social login choice in your UI. (default to AuthProviderEnum.Any).</param>
        /// <param name="contracts">List of contract addresses to be used in the session.</param>
        /// <param name="chainId">chainId (default to 13337).</param>
        [UnityEngine.Scripting.Preserve]
        public GenerateSessionUrlRequestInput(string address = default(string), string entityId = default(string), DateTime? suggestedExpiry = default(DateTime?), AuthProviderEnum? authProvider = AuthProviderEnum.Any, List<string> contracts = default(List<string>), long chainId = 13337)
        {
            // to ensure "address" is required (not null)
            if (address == null)
            {
                throw new ArgumentNullException("address is a required property for GenerateSessionUrlRequestInput and cannot be null");
            }
            this.Address = address;
            this.EntityId = entityId;
            this.SuggestedExpiry = suggestedExpiry;
            this.AuthProvider = authProvider;
            this.Contracts = contracts;
            this.ChainId = chainId;
        }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name = "address", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets EntityId
        /// </summary>
        [DataMember(Name = "entityId", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string EntityId { get; set; }

        /// <summary>
        /// Gets or Sets SuggestedExpiry
        /// </summary>
        [DataMember(Name = "suggestedExpiry", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public DateTime? SuggestedExpiry { get; set; }

        /// <summary>
        /// List of contract addresses to be used in the session
        /// </summary>
        /// <value>List of contract addresses to be used in the session</value>
        [DataMember(Name = "contracts", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public List<string> Contracts { get; set; }

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
            sb.Append("class GenerateSessionUrlRequestInput {\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  EntityId: ").Append(EntityId).Append("\n");
            sb.Append("  SuggestedExpiry: ").Append(SuggestedExpiry).Append("\n");
            sb.Append("  AuthProvider: ").Append(AuthProvider).Append("\n");
            sb.Append("  Contracts: ").Append(Contracts).Append("\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
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
