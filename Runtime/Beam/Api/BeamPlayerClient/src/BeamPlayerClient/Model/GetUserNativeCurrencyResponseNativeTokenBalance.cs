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
    /// GetUserNativeCurrencyResponseNativeTokenBalance
    /// </summary>
    [DataContract(Name = "GetUserNativeCurrencyResponse_nativeTokenBalance")]
    [UnityEngine.Scripting.Preserve]
    public partial class GetUserNativeCurrencyResponseNativeTokenBalance
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserNativeCurrencyResponseNativeTokenBalance" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetUserNativeCurrencyResponseNativeTokenBalance() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserNativeCurrencyResponseNativeTokenBalance" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        /// <param name="symbol">symbol (required).</param>
        /// <param name="decimals">decimals (required).</param>
        /// <param name="logoUri">logoUri.</param>
        /// <param name="chainId">chainId (required).</param>
        /// <param name="balance">balance (required).</param>
        [UnityEngine.Scripting.Preserve]
        public GetUserNativeCurrencyResponseNativeTokenBalance(string name = default(string), string symbol = default(string), decimal decimals = default(decimal), string logoUri = default(string), long chainId = default(long), string balance = default(string))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for GetUserNativeCurrencyResponseNativeTokenBalance and cannot be null");
            }
            this.Name = name;
            // to ensure "symbol" is required (not null)
            if (symbol == null)
            {
                throw new ArgumentNullException("symbol is a required property for GetUserNativeCurrencyResponseNativeTokenBalance and cannot be null");
            }
            this.Symbol = symbol;
            this.Decimals = decimals;
            this.ChainId = chainId;
            // to ensure "balance" is required (not null)
            if (balance == null)
            {
                throw new ArgumentNullException("balance is a required property for GetUserNativeCurrencyResponseNativeTokenBalance and cannot be null");
            }
            this.Balance = balance;
            this.LogoUri = logoUri;
        }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Symbol
        /// </summary>
        [DataMember(Name = "symbol", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or Sets Decimals
        /// </summary>
        [DataMember(Name = "decimals", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public decimal Decimals { get; set; }

        /// <summary>
        /// Gets or Sets LogoUri
        /// </summary>
        [DataMember(Name = "logoUri", EmitDefaultValue = false)]
        [UnityEngine.Scripting.Preserve]
        public string LogoUri { get; set; }

        /// <summary>
        /// Gets or Sets ChainId
        /// </summary>
        [DataMember(Name = "chainId", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public long ChainId { get; set; }

        /// <summary>
        /// Gets or Sets Balance
        /// </summary>
        [DataMember(Name = "balance", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string Balance { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        [UnityEngine.Scripting.Preserve]
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GetUserNativeCurrencyResponseNativeTokenBalance {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Symbol: ").Append(Symbol).Append("\n");
            sb.Append("  Decimals: ").Append(Decimals).Append("\n");
            sb.Append("  LogoUri: ").Append(LogoUri).Append("\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
            sb.Append("  Balance: ").Append(Balance).Append("\n");
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
