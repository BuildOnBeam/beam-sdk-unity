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
    /// Check200Response
    /// </summary>
    [DataContract(Name = "check_200_response")]
    [UnityEngine.Scripting.Preserve]
    public partial class Check200Response
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Check200Response" /> class.
        /// </summary>
        /// <param name="status">status.</param>
        /// <param name="info">info.</param>
        /// <param name="error">error.</param>
        /// <param name="details">details.</param>
        [UnityEngine.Scripting.Preserve]
        public Check200Response(string status = default(string), Dictionary<string, Check200ResponseInfoValue> info = default(Dictionary<string, Check200ResponseInfoValue>), Dictionary<string, Check200ResponseInfoValue> error = default(Dictionary<string, Check200ResponseInfoValue>), Dictionary<string, Check200ResponseInfoValue> details = default(Dictionary<string, Check200ResponseInfoValue>))
        {
            this.Status = status;
            this.Info = info;
            this.Error = error;
            this.Details = details;
        }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        /*
        <example>ok</example>
        */
        [DataMember(Name = "status", EmitDefaultValue = false)]
        [UnityEngine.Scripting.Preserve]
        public string Status { get; set; }

        /// <summary>
        /// Gets or Sets Info
        /// </summary>
        /*
        <example>{&quot;database&quot;:{&quot;status&quot;:&quot;up&quot;}}</example>
        */
        [DataMember(Name = "info", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public Dictionary<string, Check200ResponseInfoValue> Info { get; set; }

        /// <summary>
        /// Gets or Sets Error
        /// </summary>
        /*
        <example>{}</example>
        */
        [DataMember(Name = "error", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public Dictionary<string, Check200ResponseInfoValue> Error { get; set; }

        /// <summary>
        /// Gets or Sets Details
        /// </summary>
        /*
        <example>{&quot;database&quot;:{&quot;status&quot;:&quot;up&quot;}}</example>
        */
        [DataMember(Name = "details", EmitDefaultValue = false)]
        [UnityEngine.Scripting.Preserve]
        public Dictionary<string, Check200ResponseInfoValue> Details { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        [UnityEngine.Scripting.Preserve]
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Check200Response {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Info: ").Append(Info).Append("\n");
            sb.Append("  Error: ").Append(Error).Append("\n");
            sb.Append("  Details: ").Append(Details).Append("\n");
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
