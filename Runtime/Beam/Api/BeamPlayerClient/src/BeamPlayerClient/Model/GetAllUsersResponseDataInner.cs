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
    /// GetAllUsersResponseDataInner
    /// </summary>
    [DataContract(Name = "GetAllUsersResponse_data_inner")]
    [UnityEngine.Scripting.Preserve]
    public partial class GetAllUsersResponseDataInner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllUsersResponseDataInner" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        [UnityEngine.Scripting.Preserve]
        protected GetAllUsersResponseDataInner() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllUsersResponseDataInner" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="wallets">wallets (required).</param>
        /// <param name="entities">entities (required).</param>
        [UnityEngine.Scripting.Preserve]
        public GetAllUsersResponseDataInner(string id = default(string), List<GetAllUsersResponseDataInnerWalletsInner> wallets = default(List<GetAllUsersResponseDataInnerWalletsInner>), List<GetTransactionResponseUserEntitiesInner> entities = default(List<GetTransactionResponseUserEntitiesInner>))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for GetAllUsersResponseDataInner and cannot be null");
            }
            this.Id = id;
            // to ensure "wallets" is required (not null)
            if (wallets == null)
            {
                throw new ArgumentNullException("wallets is a required property for GetAllUsersResponseDataInner and cannot be null");
            }
            this.Wallets = wallets;
            // to ensure "entities" is required (not null)
            if (entities == null)
            {
                throw new ArgumentNullException("entities is a required property for GetAllUsersResponseDataInner and cannot be null");
            }
            this.Entities = entities;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Wallets
        /// </summary>
        [DataMember(Name = "wallets", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public List<GetAllUsersResponseDataInnerWalletsInner> Wallets { get; set; }

        /// <summary>
        /// Gets or Sets Entities
        /// </summary>
        [DataMember(Name = "entities", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public List<GetTransactionResponseUserEntitiesInner> Entities { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        [UnityEngine.Scripting.Preserve]
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GetAllUsersResponseDataInner {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Wallets: ").Append(Wallets).Append("\n");
            sb.Append("  Entities: ").Append(Entities).Append("\n");
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
