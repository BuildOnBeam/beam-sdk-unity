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
    /// CancelAssetOfferRequestInput
    /// </summary>
    [DataContract(Name = "CancelAssetOfferRequestInput")]
    [UnityEngine.Scripting.Preserve]
    public partial class CancelAssetOfferRequestInput
    {
        /// <summary>
        /// Operation processing type. If Execute is used, Operation will be executed automatically right after User signs it. If you prefer to have more control, use SignOnly then Process it using ProcessOperation.
        /// </summary>
        /// <value>Operation processing type. If Execute is used, Operation will be executed automatically right after User signs it. If you prefer to have more control, use SignOnly then Process it using ProcessOperation.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OperationProcessingEnum
        {
            /// <summary>
            /// Enum SignOnly for value: SignOnly
            /// </summary>
            [EnumMember(Value = "SignOnly")]
            SignOnly = 1,

            /// <summary>
            /// Enum Execute for value: Execute
            /// </summary>
            [EnumMember(Value = "Execute")]
            Execute = 2
        }


        /// <summary>
        /// Operation processing type. If Execute is used, Operation will be executed automatically right after User signs it. If you prefer to have more control, use SignOnly then Process it using ProcessOperation.
        /// </summary>
        /// <value>Operation processing type. If Execute is used, Operation will be executed automatically right after User signs it. If you prefer to have more control, use SignOnly then Process it using ProcessOperation.</value>
        [DataMember(Name = "operationProcessing", EmitDefaultValue = false)]
        [UnityEngine.Scripting.Preserve]
        public OperationProcessingEnum? OperationProcessing { get; set; }
        /// <summary>
        /// Auth Provider for the user to use. If it&#39;s Any, user will be able to choose his preferred login method. Useful when you want to present social login choice in your UI.
        /// </summary>
        /// <value>Auth Provider for the user to use. If it&#39;s Any, user will be able to choose his preferred login method. Useful when you want to present social login choice in your UI.</value>
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
        /// Auth Provider for the user to use. If it&#39;s Any, user will be able to choose his preferred login method. Useful when you want to present social login choice in your UI.
        /// </summary>
        /// <value>Auth Provider for the user to use. If it&#39;s Any, user will be able to choose his preferred login method. Useful when you want to present social login choice in your UI.</value>
        [DataMember(Name = "authProvider", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public AuthProviderEnum? AuthProvider { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CancelAssetOfferRequestInput" /> class.
        /// </summary>
        /// <param name="optimistic">optimistic (default to false).</param>
        /// <param name="sponsor">sponsor (default to true).</param>
        /// <param name="policyId">policyId.</param>
        /// <param name="operationProcessing">Operation processing type. If Execute is used, Operation will be executed automatically right after User signs it. If you prefer to have more control, use SignOnly then Process it using ProcessOperation. (default to OperationProcessingEnum.Execute).</param>
        /// <param name="authProvider">Auth Provider for the user to use. If it&#39;s Any, user will be able to choose his preferred login method. Useful when you want to present social login choice in your UI. (default to AuthProviderEnum.Any).</param>
        /// <param name="chainId">chainId (default to 13337).</param>
        [UnityEngine.Scripting.Preserve]
        public CancelAssetOfferRequestInput(bool optimistic = false, bool sponsor = true, string policyId = default(string), OperationProcessingEnum? operationProcessing = OperationProcessingEnum.Execute, AuthProviderEnum? authProvider = AuthProviderEnum.Any, long chainId = 13337)
        {
            this.Optimistic = optimistic;
            this.Sponsor = sponsor;
            this.PolicyId = policyId;
            this.OperationProcessing = operationProcessing;
            this.AuthProvider = authProvider;
            this.ChainId = chainId;
        }

        /// <summary>
        /// Gets or Sets Optimistic
        /// </summary>
        [DataMember(Name = "optimistic", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public bool Optimistic { get; set; }

        /// <summary>
        /// Gets or Sets Sponsor
        /// </summary>
        [DataMember(Name = "sponsor", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public bool Sponsor { get; set; }

        /// <summary>
        /// Gets or Sets PolicyId
        /// </summary>
        [DataMember(Name = "policyId", EmitDefaultValue = true)]
        [UnityEngine.Scripting.Preserve]
        public string PolicyId { get; set; }

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
            sb.Append("class CancelAssetOfferRequestInput {\n");
            sb.Append("  Optimistic: ").Append(Optimistic).Append("\n");
            sb.Append("  Sponsor: ").Append(Sponsor).Append("\n");
            sb.Append("  PolicyId: ").Append(PolicyId).Append("\n");
            sb.Append("  OperationProcessing: ").Append(OperationProcessing).Append("\n");
            sb.Append("  AuthProvider: ").Append(AuthProvider).Append("\n");
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
