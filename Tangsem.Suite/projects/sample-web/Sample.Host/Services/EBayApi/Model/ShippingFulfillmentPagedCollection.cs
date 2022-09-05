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
    /// This type contains the specifications for the entire collection of shipping fulfillments that are associated with the order specified by a &lt;b&gt;getShippingFulfillments&lt;/b&gt; call. The &lt;b&gt;fulfillments&lt;/b&gt; container returns an array of all the fulfillments in the collection.
    /// </summary>
    [DataContract]
    public partial class ShippingFulfillmentPagedCollection :  IEquatable<ShippingFulfillmentPagedCollection>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShippingFulfillmentPagedCollection" /> class.
        /// </summary>
        /// <param name="fulfillments">This array contains one or more fulfillments required for the order that was specified in method endpoint..</param>
        /// <param name="total">The total number of fulfillments in the specified order. Note: If no fulfillments are found for the order, this field is returned with a value of 0..</param>
        /// <param name="warnings">This array is only returned if one or more errors or warnings occur with the call request..</param>
        public ShippingFulfillmentPagedCollection(List<ShippingFulfillment> fulfillments = default(List<ShippingFulfillment>), int? total = default(int?), List<Error> warnings = default(List<Error>))
        {
            this.Fulfillments = fulfillments;
            this.Total = total;
            this.Warnings = warnings;
        }
        
        /// <summary>
        /// This array contains one or more fulfillments required for the order that was specified in method endpoint.
        /// </summary>
        /// <value>This array contains one or more fulfillments required for the order that was specified in method endpoint.</value>
        [DataMember(Name="fulfillments", EmitDefaultValue=false)]
        public List<ShippingFulfillment> Fulfillments { get; set; }

        /// <summary>
        /// The total number of fulfillments in the specified order. Note: If no fulfillments are found for the order, this field is returned with a value of 0.
        /// </summary>
        /// <value>The total number of fulfillments in the specified order. Note: If no fulfillments are found for the order, this field is returned with a value of 0.</value>
        [DataMember(Name="total", EmitDefaultValue=false)]
        public int? Total { get; set; }

        /// <summary>
        /// This array is only returned if one or more errors or warnings occur with the call request.
        /// </summary>
        /// <value>This array is only returned if one or more errors or warnings occur with the call request.</value>
        [DataMember(Name="warnings", EmitDefaultValue=false)]
        public List<Error> Warnings { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ShippingFulfillmentPagedCollection {\n");
            sb.Append("  Fulfillments: ").Append(Fulfillments).Append("\n");
            sb.Append("  Total: ").Append(Total).Append("\n");
            sb.Append("  Warnings: ").Append(Warnings).Append("\n");
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
            return this.Equals(input as ShippingFulfillmentPagedCollection);
        }

        /// <summary>
        /// Returns true if ShippingFulfillmentPagedCollection instances are equal
        /// </summary>
        /// <param name="input">Instance of ShippingFulfillmentPagedCollection to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ShippingFulfillmentPagedCollection input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Fulfillments == input.Fulfillments ||
                    this.Fulfillments != null &&
                    this.Fulfillments.SequenceEqual(input.Fulfillments)
                ) && 
                (
                    this.Total == input.Total ||
                    (this.Total != null &&
                    this.Total.Equals(input.Total))
                ) && 
                (
                    this.Warnings == input.Warnings ||
                    this.Warnings != null &&
                    this.Warnings.SequenceEqual(input.Warnings)
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
                if (this.Fulfillments != null)
                    hashCode = hashCode * 59 + this.Fulfillments.GetHashCode();
                if (this.Total != null)
                    hashCode = hashCode * 59 + this.Total.GetHashCode();
                if (this.Warnings != null)
                    hashCode = hashCode * 59 + this.Warnings.GetHashCode();
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
