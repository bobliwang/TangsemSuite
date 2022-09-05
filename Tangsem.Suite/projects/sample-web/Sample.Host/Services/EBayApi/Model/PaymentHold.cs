/* 
 * Fulfillment API
 *
 * Use the Fulfillment API to complete the process of packaging, addressing, handling, and shipping each order on behalf of the seller, in accordance with the payment method and timing specified at checkout.
 *
 * OpenAPI spec version: v1.8.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// This type contains information about a hold placed on a payment to a seller for an order, including the reason why the buyer&#39;s payment for the order is being held, the expected release date of the funds into the seller&#39;s account, the current state of the hold, and the actual release date if the payment has been released, and possible actions the seller can take to expedite the payout of funds into their account.
    /// </summary>
    [DataContract]
    public partial class PaymentHold :  IEquatable<PaymentHold>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentHold" /> class.
        /// </summary>
        /// <param name="expectedReleaseDate">The date and time that the payment being held is expected to be released to the seller. This timestamp is in ISO 8601 format, which uses the 24-hour Universal Coordinated Time (UTC) clock. This field will be returned if known by eBay. Format: YYYY-MM-DDTHH:MM:SS.SSSZ Example: 2015-08-04T19:09:02.768Z.</param>
        /// <param name="holdAmount">holdAmount.</param>
        /// <param name="holdReason">The reason that the payment is being held. A seller&#39;s payment may be helf for a number of reasons, including when the seller is new, the seller&#39;s level is below standard, or if a return case or &#39;Significantly not as described&#39; case is pending against the seller. This field is always returned with the paymentHolds array..</param>
        /// <param name="holdState">The current stage or condition of the hold. This field is always returned with the paymentHolds array. Applicable values: HELD HELD_PENDING NOT_HELD RELEASE_CONFIRMED RELEASE_FAILED RELEASE_PENDING RELEASED.</param>
        /// <param name="releaseDate">The date and time that the payment being held was actually released to the seller. This timestamp is in ISO 8601 format, which uses the 24-hour Universal Coordinated Time (UTC) clock. This field is not returned until the seller&#39;s payment is actually released into the seller&#39;s account. Format: YYYY-MM-DDTHH:MM:SS.SSSZ Example: 2015-08-04T19:09:02.768Z.</param>
        /// <param name="sellerActionsToRelease">A list of one or more possible actions that the seller can take to release the hold on the payment..</param>
        public PaymentHold(string expectedReleaseDate = default(string), Amount holdAmount = default(Amount), string holdReason = default(string), string holdState = default(string), string releaseDate = default(string), List<SellerActionsToRelease> sellerActionsToRelease = default(List<SellerActionsToRelease>))
        {
            this.ExpectedReleaseDate = expectedReleaseDate;
            this.HoldAmount = holdAmount;
            this.HoldReason = holdReason;
            this.HoldState = holdState;
            this.ReleaseDate = releaseDate;
            this.SellerActionsToRelease = sellerActionsToRelease;
        }
        
        /// <summary>
        /// The date and time that the payment being held is expected to be released to the seller. This timestamp is in ISO 8601 format, which uses the 24-hour Universal Coordinated Time (UTC) clock. This field will be returned if known by eBay. Format: YYYY-MM-DDTHH:MM:SS.SSSZ Example: 2015-08-04T19:09:02.768Z
        /// </summary>
        /// <value>The date and time that the payment being held is expected to be released to the seller. This timestamp is in ISO 8601 format, which uses the 24-hour Universal Coordinated Time (UTC) clock. This field will be returned if known by eBay. Format: YYYY-MM-DDTHH:MM:SS.SSSZ Example: 2015-08-04T19:09:02.768Z</value>
        [DataMember(Name="expectedReleaseDate", EmitDefaultValue=false)]
        public string ExpectedReleaseDate { get; set; }

        /// <summary>
        /// Gets or Sets HoldAmount
        /// </summary>
        [DataMember(Name="holdAmount", EmitDefaultValue=false)]
        public Amount HoldAmount { get; set; }

        /// <summary>
        /// The reason that the payment is being held. A seller&#39;s payment may be helf for a number of reasons, including when the seller is new, the seller&#39;s level is below standard, or if a return case or &#39;Significantly not as described&#39; case is pending against the seller. This field is always returned with the paymentHolds array.
        /// </summary>
        /// <value>The reason that the payment is being held. A seller&#39;s payment may be helf for a number of reasons, including when the seller is new, the seller&#39;s level is below standard, or if a return case or &#39;Significantly not as described&#39; case is pending against the seller. This field is always returned with the paymentHolds array.</value>
        [DataMember(Name="holdReason", EmitDefaultValue=false)]
        public string HoldReason { get; set; }

        /// <summary>
        /// The current stage or condition of the hold. This field is always returned with the paymentHolds array. Applicable values: HELD HELD_PENDING NOT_HELD RELEASE_CONFIRMED RELEASE_FAILED RELEASE_PENDING RELEASED
        /// </summary>
        /// <value>The current stage or condition of the hold. This field is always returned with the paymentHolds array. Applicable values: HELD HELD_PENDING NOT_HELD RELEASE_CONFIRMED RELEASE_FAILED RELEASE_PENDING RELEASED</value>
        [DataMember(Name="holdState", EmitDefaultValue=false)]
        public string HoldState { get; set; }

        /// <summary>
        /// The date and time that the payment being held was actually released to the seller. This timestamp is in ISO 8601 format, which uses the 24-hour Universal Coordinated Time (UTC) clock. This field is not returned until the seller&#39;s payment is actually released into the seller&#39;s account. Format: YYYY-MM-DDTHH:MM:SS.SSSZ Example: 2015-08-04T19:09:02.768Z
        /// </summary>
        /// <value>The date and time that the payment being held was actually released to the seller. This timestamp is in ISO 8601 format, which uses the 24-hour Universal Coordinated Time (UTC) clock. This field is not returned until the seller&#39;s payment is actually released into the seller&#39;s account. Format: YYYY-MM-DDTHH:MM:SS.SSSZ Example: 2015-08-04T19:09:02.768Z</value>
        [DataMember(Name="releaseDate", EmitDefaultValue=false)]
        public string ReleaseDate { get; set; }

        /// <summary>
        /// A list of one or more possible actions that the seller can take to release the hold on the payment.
        /// </summary>
        /// <value>A list of one or more possible actions that the seller can take to release the hold on the payment.</value>
        [DataMember(Name="sellerActionsToRelease", EmitDefaultValue=false)]
        public List<SellerActionsToRelease> SellerActionsToRelease { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PaymentHold {\n");
            sb.Append("  ExpectedReleaseDate: ").Append(ExpectedReleaseDate).Append("\n");
            sb.Append("  HoldAmount: ").Append(HoldAmount).Append("\n");
            sb.Append("  HoldReason: ").Append(HoldReason).Append("\n");
            sb.Append("  HoldState: ").Append(HoldState).Append("\n");
            sb.Append("  ReleaseDate: ").Append(ReleaseDate).Append("\n");
            sb.Append("  SellerActionsToRelease: ").Append(SellerActionsToRelease).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as PaymentHold);
        }

        /// <summary>
        /// Returns true if PaymentHold instances are equal
        /// </summary>
        /// <param name="input">Instance of PaymentHold to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PaymentHold input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ExpectedReleaseDate == input.ExpectedReleaseDate ||
                    (this.ExpectedReleaseDate != null &&
                    this.ExpectedReleaseDate.Equals(input.ExpectedReleaseDate))
                ) && 
                (
                    this.HoldAmount == input.HoldAmount ||
                    (this.HoldAmount != null &&
                    this.HoldAmount.Equals(input.HoldAmount))
                ) && 
                (
                    this.HoldReason == input.HoldReason ||
                    (this.HoldReason != null &&
                    this.HoldReason.Equals(input.HoldReason))
                ) && 
                (
                    this.HoldState == input.HoldState ||
                    (this.HoldState != null &&
                    this.HoldState.Equals(input.HoldState))
                ) && 
                (
                    this.ReleaseDate == input.ReleaseDate ||
                    (this.ReleaseDate != null &&
                    this.ReleaseDate.Equals(input.ReleaseDate))
                ) && 
                (
                    this.SellerActionsToRelease == input.SellerActionsToRelease ||
                    this.SellerActionsToRelease != null &&
                    this.SellerActionsToRelease.SequenceEqual(input.SellerActionsToRelease)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.ExpectedReleaseDate != null)
                    hashCode = hashCode * 59 + this.ExpectedReleaseDate.GetHashCode();
                if (this.HoldAmount != null)
                    hashCode = hashCode * 59 + this.HoldAmount.GetHashCode();
                if (this.HoldReason != null)
                    hashCode = hashCode * 59 + this.HoldReason.GetHashCode();
                if (this.HoldState != null)
                    hashCode = hashCode * 59 + this.HoldState.GetHashCode();
                if (this.ReleaseDate != null)
                    hashCode = hashCode * 59 + this.ReleaseDate.GetHashCode();
                if (this.SellerActionsToRelease != null)
                    hashCode = hashCode * 59 + this.SellerActionsToRelease.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
