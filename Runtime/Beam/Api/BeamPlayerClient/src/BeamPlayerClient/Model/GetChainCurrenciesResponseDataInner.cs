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
    /// GetChainCurrenciesResponseDataInner
    /// </summary>
    [DataContract(Name = "GetChainCurrenciesResponse_data_inner")]
    [UnityEngine.Scripting.Preserve]
    public partial class GetChainCurrenciesResponseDataInner
    {
        /// <summary>
        /// Defines Symbol
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SymbolEnum
        {
            /// <summary>
            /// Enum BEAM for value: BEAM
            /// </summary>
            [EnumMember(Value = "BEAM")]
            BEAM = 1,

            /// <summary>
            /// Enum SOPH for value: SOPH
            /// </summary>
            [EnumMember(Value = "SOPH")]
            SOPH = 2,

            /// <summary>
            /// Enum WBEAM for value: WBEAM
            /// </summary>
            [EnumMember(Value = "WBEAM")]
            WBEAM = 3,

            /// <summary>
            /// Enum WSOPH for value: WSOPH
            /// </summary>
            [EnumMember(Value = "WSOPH")]
            WSOPH = 4,

            /// <summary>
            /// Enum RAT for value: RAT
            /// </summary>
            [EnumMember(Value = "RAT")]
            RAT = 5,

            /// <summary>
            /// Enum USDC for value: USDC
            /// </summary>
            [EnumMember(Value = "USDC")]
            USDC = 6
        }


        /// <summary>
        /// Gets or Sets Symbol
        /// </summary>
        [DataMember(Name = "symbol", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public SymbolEnum Symbol { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetChainCurrenciesResponseDataInner" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetChainCurrenciesResponseDataInner() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetChainCurrenciesResponseDataInner" /> class.
        /// </summary>
        /// <param name="decimals">decimals (required).</param>
        /// <param name="symbol">symbol (required).</param>
        /// <param name="address">address (required).</param>
        [UnityEngine.Scripting.Preserve]
        public GetChainCurrenciesResponseDataInner(decimal decimals = default(decimal), SymbolEnum symbol = default(SymbolEnum), string address = default(string))
        {
            this.Decimals = decimals;
            this.Symbol = symbol;
            // to ensure "address" is required (not null)
            if (address == null)
            {
                throw new ArgumentNullException("address is a required property for GetChainCurrenciesResponseDataInner and cannot be null");
            }
            this.Address = address;
        }

        /// <summary>
        /// Gets or Sets Decimals
        /// </summary>
        [DataMember(Name = "decimals", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public decimal Decimals { get; set; }

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
            sb.Append("class GetChainCurrenciesResponseDataInner {\n");
            sb.Append("  Decimals: ").Append(Decimals).Append("\n");
            sb.Append("  Symbol: ").Append(Symbol).Append("\n");
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
