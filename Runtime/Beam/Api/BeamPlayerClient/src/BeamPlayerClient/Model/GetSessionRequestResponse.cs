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
    /// GetSessionRequestResponse
    /// </summary>
    [DataContract(Name = "GetSessionRequestResponse")]
    public partial class GetSessionRequestResponse
    {
        /// <summary>
        /// Defines Status
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Pending for value: Pending
            /// </summary>
            [EnumMember(Value = "Pending")]
            Pending = 1,

            /// <summary>
            /// Enum Accepted for value: Accepted
            /// </summary>
            [EnumMember(Value = "Accepted")]
            Accepted = 2,

            /// <summary>
            /// Enum Error for value: Error
            /// </summary>
            [EnumMember(Value = "Error")]
            Error = 3
        }


        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSessionRequestResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetSessionRequestResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSessionRequestResponse" /> class.
        /// </summary>
        /// <param name="status">status (required).</param>
        /// <param name="id">id (required).</param>
        /// <param name="createdAt">createdAt (required).</param>
        /// <param name="updatedAt">updatedAt (required).</param>
        /// <param name="chainId">chainId (required).</param>
        /// <param name="openfortId">openfortId (required).</param>
        public GetSessionRequestResponse(StatusEnum status = default(StatusEnum), string id = default(string), DateTime createdAt = default(DateTime), DateTime? updatedAt = default(DateTime?), int chainId = default(int), string openfortId = default(string))
        {
            this.Status = status;
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for GetSessionRequestResponse and cannot be null");
            }
            this.Id = id;
            this.CreatedAt = createdAt;
            // to ensure "updatedAt" is required (not null)
            if (updatedAt == null)
            {
                throw new ArgumentNullException("updatedAt is a required property for GetSessionRequestResponse and cannot be null");
            }
            this.UpdatedAt = updatedAt;
            this.ChainId = chainId;
            // to ensure "openfortId" is required (not null)
            if (openfortId == null)
            {
                throw new ArgumentNullException("openfortId is a required property for GetSessionRequestResponse and cannot be null");
            }
            this.OpenfortId = openfortId;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name = "createdAt", IsRequired = true, EmitDefaultValue = true)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedAt
        /// </summary>
        [DataMember(Name = "updatedAt", IsRequired = true, EmitDefaultValue = true)]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or Sets ChainId
        /// </summary>
        [DataMember(Name = "chainId", IsRequired = true, EmitDefaultValue = true)]
        public int ChainId { get; set; }

        /// <summary>
        /// Gets or Sets OpenfortId
        /// </summary>
        [DataMember(Name = "openfortId", IsRequired = true, EmitDefaultValue = true)]
        public string OpenfortId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GetSessionRequestResponse {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
            sb.Append("  OpenfortId: ").Append(OpenfortId).Append("\n");
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