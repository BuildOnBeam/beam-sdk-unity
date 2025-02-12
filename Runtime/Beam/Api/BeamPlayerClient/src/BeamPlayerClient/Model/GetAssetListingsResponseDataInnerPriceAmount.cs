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
    /// GetAssetListingsResponseDataInnerPriceAmount
    /// </summary>
    [DataContract(Name = "GetAssetListingsResponse_data_inner_price_amount")]
    [UnityEngine.Scripting.Preserve]
    public partial class GetAssetListingsResponseDataInnerPriceAmount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAssetListingsResponseDataInnerPriceAmount" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetAssetListingsResponseDataInnerPriceAmount() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAssetListingsResponseDataInnerPriceAmount" /> class.
        /// </summary>
        /// <param name="raw">raw (required).</param>
        /// <param name="varDecimal">varDecimal (required).</param>
        /// <param name="usd">usd (required).</param>
        /// <param name="native">native (required).</param>
        [UnityEngine.Scripting.Preserve]
        public GetAssetListingsResponseDataInnerPriceAmount(string raw = default(string), decimal varDecimal = default(decimal), decimal usd = default(decimal), decimal native = default(decimal))
        {
            // to ensure "raw" is required (not null)
            if (raw == null)
            {
                throw new ArgumentNullException("raw is a required property for GetAssetListingsResponseDataInnerPriceAmount and cannot be null");
            }
            this.Raw = raw;
            this.Decimal = varDecimal;
            this.Usd = usd;
            this.Native = native;
        }

        /// <summary>
        /// Gets or Sets Raw
        /// </summary>
        [DataMember(Name = "raw", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string Raw { get; set; }

        /// <summary>
        /// Gets or Sets Decimal
        /// </summary>
        [DataMember(Name = "decimal", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public decimal Decimal { get; set; }

        /// <summary>
        /// Gets or Sets Usd
        /// </summary>
        [DataMember(Name = "usd", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public decimal Usd { get; set; }

        /// <summary>
        /// Gets or Sets Native
        /// </summary>
        [DataMember(Name = "native", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public decimal Native { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        [UnityEngine.Scripting.Preserve]
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GetAssetListingsResponseDataInnerPriceAmount {\n");
            sb.Append("  Raw: ").Append(Raw).Append("\n");
            sb.Append("  Decimal: ").Append(Decimal).Append("\n");
            sb.Append("  Usd: ").Append(Usd).Append("\n");
            sb.Append("  Native: ").Append(Native).Append("\n");
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
