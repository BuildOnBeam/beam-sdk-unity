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
    /// GetConnectionRequestResponse
    /// </summary>
    [DataContract(Name = "GetConnectionRequestResponse")]
    [UnityEngine.Scripting.Preserve]
    public partial class GetConnectionRequestResponse
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
            /// Enum Connected for value: Connected
            /// </summary>
            [EnumMember(Value = "Connected")]
            Connected = 2,

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
        [UnityEngine.Scripting.Preserve]
        public StatusEnum Status { get; set; }
        /// <summary>
        /// Defines AuthProvider
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AuthProviderEnum
        {
            /// <summary>
            /// Enum Any for value: Any
            /// </summary>
            [EnumMember(Value = "Any")]
            Any = 1,

            /// <summary>
            /// Enum Google for value: Google
            /// </summary>
            [EnumMember(Value = "Google")]
            Google = 2,

            /// <summary>
            /// Enum Discord for value: Discord
            /// </summary>
            [EnumMember(Value = "Discord")]
            Discord = 3,

            /// <summary>
            /// Enum Apple for value: Apple
            /// </summary>
            [EnumMember(Value = "Apple")]
            Apple = 4
        }


        /// <summary>
        /// Gets or Sets AuthProvider
        /// </summary>
        [DataMember(Name = "authProvider", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public AuthProviderEnum AuthProvider { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetConnectionRequestResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetConnectionRequestResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetConnectionRequestResponse" /> class.
        /// </summary>
        /// <param name="status">status (required).</param>
        /// <param name="authProvider">authProvider (required).</param>
        /// <param name="id">id (required).</param>
        /// <param name="createdAt">createdAt (required).</param>
        /// <param name="updatedAt">updatedAt (required).</param>
        /// <param name="entityId">entityId (required).</param>
        [UnityEngine.Scripting.Preserve]
        public GetConnectionRequestResponse(StatusEnum status = default(StatusEnum), AuthProviderEnum authProvider = default(AuthProviderEnum), string id = default(string), DateTime createdAt = default(DateTime), DateTime? updatedAt = default(DateTime?), string entityId = default(string))
        {
            this.Status = status;
            this.AuthProvider = authProvider;
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for GetConnectionRequestResponse and cannot be null");
            }
            this.Id = id;
            this.CreatedAt = createdAt;
            // to ensure "updatedAt" is required (not null)
            if (updatedAt == null)
            {
                throw new ArgumentNullException("updatedAt is a required property for GetConnectionRequestResponse and cannot be null");
            }
            this.UpdatedAt = updatedAt;
            // to ensure "entityId" is required (not null)
            if (entityId == null)
            {
                throw new ArgumentNullException("entityId is a required property for GetConnectionRequestResponse and cannot be null");
            }
            this.EntityId = entityId;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [DataMember(Name = "createdAt", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedAt
        /// </summary>
        [DataMember(Name = "updatedAt", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or Sets EntityId
        /// </summary>
        [DataMember(Name = "entityId", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string EntityId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        [UnityEngine.Scripting.Preserve]
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GetConnectionRequestResponse {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  AuthProvider: ").Append(AuthProvider).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  EntityId: ").Append(EntityId).Append("\n");
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
