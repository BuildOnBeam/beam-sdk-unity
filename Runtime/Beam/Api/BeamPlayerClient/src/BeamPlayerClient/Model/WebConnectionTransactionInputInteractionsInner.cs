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
    /// WebConnectionTransactionInputInteractionsInner
    /// </summary>
    [DataContract(Name = "WebConnectionTransactionInput_interactions_inner")]
    public partial class WebConnectionTransactionInputInteractionsInner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebConnectionTransactionInputInteractionsInner" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected WebConnectionTransactionInputInteractionsInner() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WebConnectionTransactionInputInteractionsInner" /> class.
        /// </summary>
        /// <param name="from">from (required).</param>
        /// <param name="to">to.</param>
        /// <param name="gas">gas.</param>
        /// <param name="gasPrice">gasPrice.</param>
        /// <param name="value">value.</param>
        /// <param name="data">data.</param>
        /// <param name="nonce">nonce.</param>
        public WebConnectionTransactionInputInteractionsInner(string from = default(string), string to = default(string), string gas = default(string), string gasPrice = default(string), string value = default(string), string data = default(string), string nonce = default(string))
        {
            // to ensure "from" is required (not null)
            if (from == null)
            {
                throw new ArgumentNullException("from is a required property for WebConnectionTransactionInputInteractionsInner and cannot be null");
            }
            this.From = from;
            this.To = to;
            this.Gas = gas;
            this.GasPrice = gasPrice;
            this.Value = value;
            this.Data = data;
            this.Nonce = nonce;
        }

        /// <summary>
        /// Gets or Sets From
        /// </summary>
        [DataMember(Name = "from", IsRequired = true, EmitDefaultValue = true)]
        public string From { get; set; }

        /// <summary>
        /// Gets or Sets To
        /// </summary>
        [DataMember(Name = "to", EmitDefaultValue = true)]
        public string To { get; set; }

        /// <summary>
        /// Gets or Sets Gas
        /// </summary>
        [DataMember(Name = "gas", EmitDefaultValue = true)]
        public string Gas { get; set; }

        /// <summary>
        /// Gets or Sets GasPrice
        /// </summary>
        [DataMember(Name = "gasPrice", EmitDefaultValue = true)]
        public string GasPrice { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name = "value", EmitDefaultValue = true)]
        public string Value { get; set; }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [DataMember(Name = "data", EmitDefaultValue = true)]
        public string Data { get; set; }

        /// <summary>
        /// Gets or Sets Nonce
        /// </summary>
        [DataMember(Name = "nonce", EmitDefaultValue = true)]
        public string Nonce { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WebConnectionTransactionInputInteractionsInner {\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  Gas: ").Append(Gas).Append("\n");
            sb.Append("  GasPrice: ").Append(GasPrice).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  Nonce: ").Append(Nonce).Append("\n");
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
