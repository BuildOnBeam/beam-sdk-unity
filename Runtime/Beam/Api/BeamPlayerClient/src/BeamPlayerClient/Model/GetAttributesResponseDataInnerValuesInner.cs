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
    /// GetAttributesResponseDataInnerValuesInner
    /// </summary>
    [DataContract(Name = "GetAttributesResponse_data_inner_values_inner")]
    public partial class GetAttributesResponseDataInnerValuesInner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAttributesResponseDataInnerValuesInner" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetAttributesResponseDataInnerValuesInner() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAttributesResponseDataInnerValuesInner" /> class.
        /// </summary>
        /// <param name="count">count.</param>
        /// <param name="value">value (required).</param>
        public GetAttributesResponseDataInnerValuesInner(decimal? count = default(decimal?), string value = default(string))
        {
            // to ensure "value" is required (not null)
            if (value == null)
            {
                throw new ArgumentNullException("value is a required property for GetAttributesResponseDataInnerValuesInner and cannot be null");
            }
            this.Value = value;
            this.Count = count;
        }

        /// <summary>
        /// Gets or Sets Count
        /// </summary>
        [DataMember(Name = "count", EmitDefaultValue = true)]
        public decimal? Count { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name = "value", IsRequired = true, EmitDefaultValue = true)]
        public string Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GetAttributesResponseDataInnerValuesInner {\n");
            sb.Append("  Count: ").Append(Count).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
