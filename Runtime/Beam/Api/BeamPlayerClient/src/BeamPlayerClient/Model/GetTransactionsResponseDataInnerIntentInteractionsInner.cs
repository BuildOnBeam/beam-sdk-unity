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
    /// GetTransactionsResponseDataInnerIntentInteractionsInner
    /// </summary>
    [DataContract(Name = "GetTransactionsResponse_data_inner_intent_interactions_inner")]
    [UnityEngine.Scripting.Preserve]
    public partial class GetTransactionsResponseDataInnerIntentInteractionsInner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTransactionsResponseDataInnerIntentInteractionsInner" /> class.
        /// </summary>
        /// <param name="to">to.</param>
        /// <param name="value">value.</param>
        /// <param name="contract">contract.</param>
        /// <param name="functionName">functionName.</param>
        /// <param name="functionArgs">functionArgs.</param>
        [UnityEngine.Scripting.Preserve]
        public GetTransactionsResponseDataInnerIntentInteractionsInner(string to = default(string), string value = default(string), string contract = default(string), string functionName = default(string), List<Object> functionArgs = default(List<Object>))
        {
            this.To = to;
            this.Value = value;
            this.Contract = contract;
            this.FunctionName = functionName;
            this.FunctionArgs = functionArgs;
        }

        /// <summary>
        /// Gets or Sets To
        /// </summary>
        [DataMember(Name = "to", EmitDefaultValue = false)]
        [UnityEngine.Scripting.Preserve]
        public string To { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        [UnityEngine.Scripting.Preserve]
        public string Value { get; set; }

        /// <summary>
        /// Gets or Sets Contract
        /// </summary>
        [DataMember(Name = "contract", EmitDefaultValue = false)]
        [UnityEngine.Scripting.Preserve]
        public string Contract { get; set; }

        /// <summary>
        /// Gets or Sets FunctionName
        /// </summary>
        [DataMember(Name = "functionName", EmitDefaultValue = false)]
        [UnityEngine.Scripting.Preserve]
        public string FunctionName { get; set; }

        /// <summary>
        /// Gets or Sets FunctionArgs
        /// </summary>
        [DataMember(Name = "functionArgs", EmitDefaultValue = false)]
        [UnityEngine.Scripting.Preserve]
        public List<Object> FunctionArgs { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        [UnityEngine.Scripting.Preserve]
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GetTransactionsResponseDataInnerIntentInteractionsInner {\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  Contract: ").Append(Contract).Append("\n");
            sb.Append("  FunctionName: ").Append(FunctionName).Append("\n");
            sb.Append("  FunctionArgs: ").Append(FunctionArgs).Append("\n");
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
