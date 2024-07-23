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
    /// CommonActivityRequestInput
    /// </summary>
    [DataContract(Name = "CommonActivityRequestInput")]
    public partial class CommonActivityRequestInput
    {
        /// <summary>
        /// Defines Types
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypesEnum
        {
            /// <summary>
            /// Enum Ask for value: ask
            /// </summary>
            [EnumMember(Value = "ask")]
            Ask = 1,

            /// <summary>
            /// Enum AskCancel for value: ask_cancel
            /// </summary>
            [EnumMember(Value = "ask_cancel")]
            AskCancel = 2,

            /// <summary>
            /// Enum Bid for value: bid
            /// </summary>
            [EnumMember(Value = "bid")]
            Bid = 3,

            /// <summary>
            /// Enum BidCancel for value: bid_cancel
            /// </summary>
            [EnumMember(Value = "bid_cancel")]
            BidCancel = 4,

            /// <summary>
            /// Enum Sale for value: sale
            /// </summary>
            [EnumMember(Value = "sale")]
            Sale = 5,

            /// <summary>
            /// Enum Mint for value: mint
            /// </summary>
            [EnumMember(Value = "mint")]
            Mint = 6,

            /// <summary>
            /// Enum Transfer for value: transfer
            /// </summary>
            [EnumMember(Value = "transfer")]
            Transfer = 7
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonActivityRequestInput" /> class.
        /// </summary>
        /// <param name="limit">limit (default to 20M).</param>
        /// <param name="types">types.</param>
        /// <param name="chainId">chainId (default to 13337M).</param>
        public CommonActivityRequestInput(decimal limit = 20M, List<TypesEnum> types = default(List<TypesEnum>), decimal chainId = 13337M)
        {
            this.Limit = limit;
            this.Types = types;
            this.ChainId = chainId;
        }

        /// <summary>
        /// Gets or Sets Limit
        /// </summary>
        [DataMember(Name = "limit", EmitDefaultValue = false)]
        public decimal Limit { get; set; }

        /// <summary>
        /// Gets or Sets Types
        /// </summary>
        [DataMember(Name = "types", EmitDefaultValue = true)]
        public List<CommonActivityRequestInput.TypesEnum> Types { get; set; }

        /// <summary>
        /// Gets or Sets ChainId
        /// </summary>
        [DataMember(Name = "chainId", EmitDefaultValue = false)]
        public decimal ChainId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CommonActivityRequestInput {\n");
            sb.Append("  Limit: ").Append(Limit).Append("\n");
            sb.Append("  Types: ").Append(Types).Append("\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
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
