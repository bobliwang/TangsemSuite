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
    /// This type contains information about a refund issued for an order. This does not include line item level refunds.
    /// </summary>
    [DataContract]
    public partial class OrderRefund :  IEquatable<OrderRefund>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRefund" /> class.
        /// </summary>
        /// <param name="amount">amount.</param>
        /// <param name="refundDate">The date and time that the refund was issued. This timestamp is in ISO 8601 format, which uses the 24-hour Universal Coordinated Time (UTC) clock. This field is not returned until the refund has been issued. Format: YYYY-MM-DDTHH:MM:SS.SSSZ Example: 2015-08-04T19:09:02.768Z.</param>
        /// <param name="refundReferenceId">The eBay-generated unique identifier for the refund. This field is not returned until the refund has been issued..</param>
        /// <param name="refundStatus">This enumeration value indicates the current status of the refund to the buyer. This container is always returned for each refund. For implementation help, refer to &lt;a href&#x3D;&#39;https://developer.ebay.com/devzone/rest/api-ref/fulfillment/types/RefundStatusEnum.html&#39;&gt;eBay API documentation&lt;/a&gt;.</param>
        public OrderRefund(Amount amount = default(Amount), string refundDate = default(string), string refundReferenceId = default(string), string refundStatus = default(string))
        {
            this.Amount = amount;
            this.RefundDate = refundDate;
            this.RefundReferenceId = refundReferenceId;
            this.RefundStatus = refundStatus;
        }
        
        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue=false)]
        public Amount Amount { get; set; }

        /// <summary>
        /// The date and time that the refund was issued. This timestamp is in ISO 8601 format, which uses the 24-hour Universal Coordinated Time (UTC) clock. This field is not returned until the refund has been issued. Format: YYYY-MM-DDTHH:MM:SS.SSSZ Example: 2015-08-04T19:09:02.768Z
        /// </summary>
        /// <value>The date and time that the refund was issued. This timestamp is in ISO 8601 format, which uses the 24-hour Universal Coordinated Time (UTC) clock. This field is not returned until the refund has been issued. Format: YYYY-MM-DDTHH:MM:SS.SSSZ Example: 2015-08-04T19:09:02.768Z</value>
        [DataMember(Name="refundDate", EmitDefaultValue=false)]
        public string RefundDate { get; set; }

        /// <summary>
        /// The eBay-generated unique identifier for the refund. This field is not returned until the refund has been issued.
        /// </summary>
        /// <value>The eBay-generated unique identifier for the refund. This field is not returned until the refund has been issued.</value>
        [DataMember(Name="refundReferenceId", EmitDefaultValue=false)]
        public string RefundReferenceId { get; set; }

        /// <summary>
        /// This enumeration value indicates the current status of the refund to the buyer. This container is always returned for each refund. For implementation help, refer to &lt;a href&#x3D;&#39;https://developer.ebay.com/devzone/rest/api-ref/fulfillment/types/RefundStatusEnum.html&#39;&gt;eBay API documentation&lt;/a&gt;
        /// </summary>
        /// <value>This enumeration value indicates the current status of the refund to the buyer. This container is always returned for each refund. For implementation help, refer to &lt;a href&#x3D;&#39;https://developer.ebay.com/devzone/rest/api-ref/fulfillment/types/RefundStatusEnum.html&#39;&gt;eBay API documentation&lt;/a&gt;</value>
        [DataMember(Name="refundStatus", EmitDefaultValue=false)]
        public string RefundStatus { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderRefund {\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  RefundDate: ").Append(RefundDate).Append("\n");
            sb.Append("  RefundReferenceId: ").Append(RefundReferenceId).Append("\n");
            sb.Append("  RefundStatus: ").Append(RefundStatus).Append("\n");
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
            return this.Equals(input as OrderRefund);
        }

        /// <summary>
        /// Returns true if OrderRefund instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderRefund to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderRefund input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Amount == input.Amount ||
                    (this.Amount != null &&
                    this.Amount.Equals(input.Amount))
                ) && 
                (
                    this.RefundDate == input.RefundDate ||
                    (this.RefundDate != null &&
                    this.RefundDate.Equals(input.RefundDate))
                ) && 
                (
                    this.RefundReferenceId == input.RefundReferenceId ||
                    (this.RefundReferenceId != null &&
                    this.RefundReferenceId.Equals(input.RefundReferenceId))
                ) && 
                (
                    this.RefundStatus == input.RefundStatus ||
                    (this.RefundStatus != null &&
                    this.RefundStatus.Equals(input.RefundStatus))
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
                if (this.Amount != null)
                    hashCode = hashCode * 59 + this.Amount.GetHashCode();
                if (this.RefundDate != null)
                    hashCode = hashCode * 59 + this.RefundDate.GetHashCode();
                if (this.RefundReferenceId != null)
                    hashCode = hashCode * 59 + this.RefundReferenceId.GetHashCode();
                if (this.RefundStatus != null)
                    hashCode = hashCode * 59 + this.RefundStatus.GetHashCode();
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
