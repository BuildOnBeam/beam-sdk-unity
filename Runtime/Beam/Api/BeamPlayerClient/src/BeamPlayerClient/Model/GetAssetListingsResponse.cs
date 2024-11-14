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
    /// GetAssetListingsResponse
    /// </summary>
    [DataContract(Name = "GetAssetListingsResponse")]
    [UnityEngine.Scripting.Preserve]
    public partial class GetAssetListingsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAssetListingsResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetAssetListingsResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAssetListingsResponse" /> class.
        /// </summary>
        /// <param name="data">data (required).</param>
        /// <param name="continuation">continuation.</param>
        [UnityEngine.Scripting.Preserve]
        public GetAssetListingsResponse(List<GetAssetListingsResponseDataInner> data = default(List<GetAssetListingsResponseDataInner>), string continuation = default(string))
        {
            // to ensure "data" is required (not null)
            if (data == null)
            {
                throw new ArgumentNullException("data is a required property for GetAssetListingsResponse and cannot be null");
            }
            this.Data = data;
            this.Continuation = continuation;
        }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name = "data", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public List<GetAssetListingsResponseDataInner> Data { get; set; }

        /// <summary>
        /// Gets or Sets Continuation
        /// </summary>
        [DataMember(Name = "continuation", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string Continuation { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        [UnityEngine.Scripting.Preserve]
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GetAssetListingsResponse {\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  Continuation: ").Append(Continuation).Append("\n");
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
