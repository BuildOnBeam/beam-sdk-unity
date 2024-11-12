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
    /// GetChainCurrenciesResponse
    /// </summary>
    [DataContract(Name = "GetChainCurrenciesResponse")]
    [UnityEngine.Scripting.Preserve]
    public partial class GetChainCurrenciesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetChainCurrenciesResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetChainCurrenciesResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetChainCurrenciesResponse" /> class.
        /// </summary>
        /// <param name="data">data (required).</param>
        [UnityEngine.Scripting.Preserve]
        public GetChainCurrenciesResponse(List<GetChainCurrenciesResponseDataInner> data = default(List<GetChainCurrenciesResponseDataInner>))
        {
            // to ensure "data" is required (not null)
            if (data == null)
            {
                throw new ArgumentNullException("data is a required property for GetChainCurrenciesResponse and cannot be null");
            }
            this.Data = data;
        }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name = "data", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public List<GetChainCurrenciesResponseDataInner> Data { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        [UnityEngine.Scripting.Preserve]
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GetChainCurrenciesResponse {\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
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
