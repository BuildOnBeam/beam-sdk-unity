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
    /// GetAssetResponse
    /// </summary>
    [DataContract(Name = "GetAssetResponse")]
    [UnityEngine.Scripting.Preserve]
    public partial class GetAssetResponse
    {
        /// <summary>
        /// Defines Rarity
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RarityEnum
        {
            /// <summary>
            /// Enum Common for value: Common
            /// </summary>
            [EnumMember(Value = "Common")]
            Common = 1,

            /// <summary>
            /// Enum Uncommon for value: Uncommon
            /// </summary>
            [EnumMember(Value = "Uncommon")]
            Uncommon = 2,

            /// <summary>
            /// Enum Rare for value: Rare
            /// </summary>
            [EnumMember(Value = "Rare")]
            Rare = 3,

            /// <summary>
            /// Enum VeryRare for value: VeryRare
            /// </summary>
            [EnumMember(Value = "VeryRare")]
            VeryRare = 4,

            /// <summary>
            /// Enum ExtremelyRare for value: ExtremelyRare
            /// </summary>
            [EnumMember(Value = "ExtremelyRare")]
            ExtremelyRare = 5
        }


        /// <summary>
        /// Gets or Sets Rarity
        /// </summary>
        [DataMember(Name = "rarity", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public RarityEnum? Rarity { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAssetResponse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GetAssetResponse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAssetResponse" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        /// <param name="imageUrl">imageUrl (required).</param>
        /// <param name="assetType">assetType (required).</param>
        /// <param name="assetAddress">assetAddress (required).</param>
        /// <param name="assetId">assetId (required).</param>
        /// <param name="supply">supply (required).</param>
        /// <param name="owners">owners (required).</param>
        /// <param name="rarity">rarity.</param>
        /// <param name="rarityScore">rarityScore.</param>
        /// <param name="attributes">attributes.</param>
        /// <param name="chainId">chainId (default to 13337).</param>
        [UnityEngine.Scripting.Preserve]
        public GetAssetResponse(string name = default(string), string imageUrl = default(string), string assetType = default(string), string assetAddress = default(string), string assetId = default(string), decimal supply = default(decimal), List<GetAssetResponseOwnersInner> owners = default(List<GetAssetResponseOwnersInner>), RarityEnum? rarity = default(RarityEnum?), decimal? rarityScore = default(decimal?), List<GetAssetsForUserResponseDataInnerAttributesInner> attributes = default(List<GetAssetsForUserResponseDataInnerAttributesInner>), long chainId = 13337)
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for GetAssetResponse and cannot be null");
            }
            this.Name = name;
            // to ensure "imageUrl" is required (not null)
            if (imageUrl == null)
            {
                throw new ArgumentNullException("imageUrl is a required property for GetAssetResponse and cannot be null");
            }
            this.ImageUrl = imageUrl;
            // to ensure "assetType" is required (not null)
            if (assetType == null)
            {
                throw new ArgumentNullException("assetType is a required property for GetAssetResponse and cannot be null");
            }
            this.AssetType = assetType;
            // to ensure "assetAddress" is required (not null)
            if (assetAddress == null)
            {
                throw new ArgumentNullException("assetAddress is a required property for GetAssetResponse and cannot be null");
            }
            this.AssetAddress = assetAddress;
            // to ensure "assetId" is required (not null)
            if (assetId == null)
            {
                throw new ArgumentNullException("assetId is a required property for GetAssetResponse and cannot be null");
            }
            this.AssetId = assetId;
            this.Supply = supply;
            // to ensure "owners" is required (not null)
            if (owners == null)
            {
                throw new ArgumentNullException("owners is a required property for GetAssetResponse and cannot be null");
            }
            this.Owners = owners;
            this.Rarity = rarity;
            this.RarityScore = rarityScore;
            this.Attributes = attributes;
            this.ChainId = chainId;
        }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets ImageUrl
        /// </summary>
        [DataMember(Name = "imageUrl", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or Sets AssetType
        /// </summary>
        [DataMember(Name = "assetType", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string AssetType { get; set; }

        /// <summary>
        /// Gets or Sets AssetAddress
        /// </summary>
        [DataMember(Name = "assetAddress", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string AssetAddress { get; set; }

        /// <summary>
        /// Gets or Sets AssetId
        /// </summary>
        [DataMember(Name = "assetId", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string AssetId { get; set; }

        /// <summary>
        /// Gets or Sets Supply
        /// </summary>
        [DataMember(Name = "supply", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public decimal Supply { get; set; }

        /// <summary>
        /// Gets or Sets Owners
        /// </summary>
        [DataMember(Name = "owners", IsRequired = true, EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public List<GetAssetResponseOwnersInner> Owners { get; set; }

        /// <summary>
        /// Gets or Sets RarityScore
        /// </summary>
        [DataMember(Name = "rarityScore", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public decimal? RarityScore { get; set; }

        /// <summary>
        /// Gets or Sets Attributes
        /// </summary>
        [DataMember(Name = "attributes", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public List<GetAssetsForUserResponseDataInnerAttributesInner> Attributes { get; set; }

        /// <summary>
        /// Gets or Sets ChainId
        /// </summary>
        [DataMember(Name = "chainId", EmitDefaultValue = false)]
        [UnityEngine.Scripting.Preserve]
        public long ChainId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        [UnityEngine.Scripting.Preserve]
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GetAssetResponse {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ImageUrl: ").Append(ImageUrl).Append("\n");
            sb.Append("  AssetType: ").Append(AssetType).Append("\n");
            sb.Append("  AssetAddress: ").Append(AssetAddress).Append("\n");
            sb.Append("  AssetId: ").Append(AssetId).Append("\n");
            sb.Append("  Supply: ").Append(Supply).Append("\n");
            sb.Append("  Owners: ").Append(Owners).Append("\n");
            sb.Append("  Rarity: ").Append(Rarity).Append("\n");
            sb.Append("  RarityScore: ").Append(RarityScore).Append("\n");
            sb.Append("  Attributes: ").Append(Attributes).Append("\n");
            sb.Append("  ChainId: ").Append(ChainId).Append("\n");
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
