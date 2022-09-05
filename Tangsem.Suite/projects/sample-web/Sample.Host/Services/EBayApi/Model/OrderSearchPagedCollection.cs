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
    /// This type contains the specifications for the collection of orders that match the search or filter criteria of a &lt;b&gt;getOrders&lt;/b&gt; call. The collection is grouped into a result set, and based on the query parameters that are set (including the &lt;strong&gt;limit&lt;/strong&gt; and &lt;strong&gt;offset&lt;/strong&gt; parameters), the result set may included multiple pages, but only one page of the result set can be viewed at a time.
    /// </summary>
    [DataContract]
    public partial class OrderSearchPagedCollection :  IEquatable<OrderSearchPagedCollection>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderSearchPagedCollection" /> class.
        /// </summary>
        /// <param name="href">The URI of the getOrders call request that produced the current page of the result set..</param>
        /// <param name="limit">The maximum number of orders returned per page of the result set. The limit value can be passed in as a query parameter, or if omitted, its value defaults to 50. Note: If this is the last or only page of the result set, the page may contain fewer orders than the limit value. To determine the number of pages in a result set, divide the total value (total number of orders matching input criteria) by this limit value, and then round up to the next integer. For example, if the total value was 120 (120 total orders) and the limit value was 50 (show 50 orders per page), the total number of pages in the result set is three, so the seller would have to make three separate getOrders calls to view all orders matching the input criteria. Default: 50.</param>
        /// <param name="next">The getOrders call URI to use if you wish to view the next page of the result set. For example, the following URI returns records 41 thru 50 from the collection of orders: path/order?limit&#x3D;10&amp;amp;offset&#x3D;40 This field is only returned if there is a next page of results to view based on the current input criteria..</param>
        /// <param name="offset">This integer value indicates the actual position that the first order returned on the current page has in the results set. So, if you wanted to view 11th order of the result set, you would set the offset value in the request to 10. In the request, you can use the offset parameter in conjunction with the limit parameter to control the pagination of the output. For example, if offset is set to 30 and limit is set to 10, the call retrieves orders 31 thru 40 from the resulting collection of orders. Note: This feature employs a zero-based list, where the first item in the list has an offset of 0.Default: 0 (zero).</param>
        /// <param name="orders">This array contains one or more orders that are part of the current result set, that is controlled by the input criteria. The details of each order include information about the buyer, order history, shipping fulfillments, line items, costs, payments, and order fulfillment status. By default, orders are returned according to creation date (oldest to newest), but the order will vary according to any filter that is set in request..</param>
        /// <param name="prev">The getOrders call URI for the previous result set. For example, the following URI returns orders 21 thru 30 from the collection of orders: path/order?limit&#x3D;10&amp;amp;offset&#x3D;20 This field is only returned if there is a previous page of results to view based on the current input criteria..</param>
        /// <param name="total">The total number of orders in the results set based on the current input criteria. Note: If no orders are found, this field is returned with a value of 0..</param>
        /// <param name="warnings">This array is returned if one or more errors or warnings occur with the call request..</param>
        public OrderSearchPagedCollection(string href = default(string), int? limit = default(int?), string next = default(string), int? offset = default(int?), List<Order> orders = default(List<Order>), string prev = default(string), int? total = default(int?), List<Error> warnings = default(List<Error>))
        {
            this.Href = href;
            this.Limit = limit;
            this.Next = next;
            this.Offset = offset;
            this.Orders = orders;
            this.Prev = prev;
            this.Total = total;
            this.Warnings = warnings;
        }
        
        /// <summary>
        /// The URI of the getOrders call request that produced the current page of the result set.
        /// </summary>
        /// <value>The URI of the getOrders call request that produced the current page of the result set.</value>
        [DataMember(Name="href", EmitDefaultValue=false)]
        public string Href { get; set; }

        /// <summary>
        /// The maximum number of orders returned per page of the result set. The limit value can be passed in as a query parameter, or if omitted, its value defaults to 50. Note: If this is the last or only page of the result set, the page may contain fewer orders than the limit value. To determine the number of pages in a result set, divide the total value (total number of orders matching input criteria) by this limit value, and then round up to the next integer. For example, if the total value was 120 (120 total orders) and the limit value was 50 (show 50 orders per page), the total number of pages in the result set is three, so the seller would have to make three separate getOrders calls to view all orders matching the input criteria. Default: 50
        /// </summary>
        /// <value>The maximum number of orders returned per page of the result set. The limit value can be passed in as a query parameter, or if omitted, its value defaults to 50. Note: If this is the last or only page of the result set, the page may contain fewer orders than the limit value. To determine the number of pages in a result set, divide the total value (total number of orders matching input criteria) by this limit value, and then round up to the next integer. For example, if the total value was 120 (120 total orders) and the limit value was 50 (show 50 orders per page), the total number of pages in the result set is three, so the seller would have to make three separate getOrders calls to view all orders matching the input criteria. Default: 50</value>
        [DataMember(Name="limit", EmitDefaultValue=false)]
        public int? Limit { get; set; }

        /// <summary>
        /// The getOrders call URI to use if you wish to view the next page of the result set. For example, the following URI returns records 41 thru 50 from the collection of orders: path/order?limit&#x3D;10&amp;amp;offset&#x3D;40 This field is only returned if there is a next page of results to view based on the current input criteria.
        /// </summary>
        /// <value>The getOrders call URI to use if you wish to view the next page of the result set. For example, the following URI returns records 41 thru 50 from the collection of orders: path/order?limit&#x3D;10&amp;amp;offset&#x3D;40 This field is only returned if there is a next page of results to view based on the current input criteria.</value>
        [DataMember(Name="next", EmitDefaultValue=false)]
        public string Next { get; set; }

        /// <summary>
        /// This integer value indicates the actual position that the first order returned on the current page has in the results set. So, if you wanted to view 11th order of the result set, you would set the offset value in the request to 10. In the request, you can use the offset parameter in conjunction with the limit parameter to control the pagination of the output. For example, if offset is set to 30 and limit is set to 10, the call retrieves orders 31 thru 40 from the resulting collection of orders. Note: This feature employs a zero-based list, where the first item in the list has an offset of 0.Default: 0 (zero)
        /// </summary>
        /// <value>This integer value indicates the actual position that the first order returned on the current page has in the results set. So, if you wanted to view 11th order of the result set, you would set the offset value in the request to 10. In the request, you can use the offset parameter in conjunction with the limit parameter to control the pagination of the output. For example, if offset is set to 30 and limit is set to 10, the call retrieves orders 31 thru 40 from the resulting collection of orders. Note: This feature employs a zero-based list, where the first item in the list has an offset of 0.Default: 0 (zero)</value>
        [DataMember(Name="offset", EmitDefaultValue=false)]
        public int? Offset { get; set; }

        /// <summary>
        /// This array contains one or more orders that are part of the current result set, that is controlled by the input criteria. The details of each order include information about the buyer, order history, shipping fulfillments, line items, costs, payments, and order fulfillment status. By default, orders are returned according to creation date (oldest to newest), but the order will vary according to any filter that is set in request.
        /// </summary>
        /// <value>This array contains one or more orders that are part of the current result set, that is controlled by the input criteria. The details of each order include information about the buyer, order history, shipping fulfillments, line items, costs, payments, and order fulfillment status. By default, orders are returned according to creation date (oldest to newest), but the order will vary according to any filter that is set in request.</value>
        [DataMember(Name="orders", EmitDefaultValue=false)]
        public List<Order> Orders { get; set; }

        /// <summary>
        /// The getOrders call URI for the previous result set. For example, the following URI returns orders 21 thru 30 from the collection of orders: path/order?limit&#x3D;10&amp;amp;offset&#x3D;20 This field is only returned if there is a previous page of results to view based on the current input criteria.
        /// </summary>
        /// <value>The getOrders call URI for the previous result set. For example, the following URI returns orders 21 thru 30 from the collection of orders: path/order?limit&#x3D;10&amp;amp;offset&#x3D;20 This field is only returned if there is a previous page of results to view based on the current input criteria.</value>
        [DataMember(Name="prev", EmitDefaultValue=false)]
        public string Prev { get; set; }

        /// <summary>
        /// The total number of orders in the results set based on the current input criteria. Note: If no orders are found, this field is returned with a value of 0.
        /// </summary>
        /// <value>The total number of orders in the results set based on the current input criteria. Note: If no orders are found, this field is returned with a value of 0.</value>
        [DataMember(Name="total", EmitDefaultValue=false)]
        public int? Total { get; set; }

        /// <summary>
        /// This array is returned if one or more errors or warnings occur with the call request.
        /// </summary>
        /// <value>This array is returned if one or more errors or warnings occur with the call request.</value>
        [DataMember(Name="warnings", EmitDefaultValue=false)]
        public List<Error> Warnings { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderSearchPagedCollection {\n");
            sb.Append("  Href: ").Append(Href).Append("\n");
            sb.Append("  Limit: ").Append(Limit).Append("\n");
            sb.Append("  Next: ").Append(Next).Append("\n");
            sb.Append("  Offset: ").Append(Offset).Append("\n");
            sb.Append("  Orders: ").Append(Orders).Append("\n");
            sb.Append("  Prev: ").Append(Prev).Append("\n");
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
            return this.Equals(input as OrderSearchPagedCollection);
        }

        /// <summary>
        /// Returns true if OrderSearchPagedCollection instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderSearchPagedCollection to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderSearchPagedCollection input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Href == input.Href ||
                    (this.Href != null &&
                    this.Href.Equals(input.Href))
                ) && 
                (
                    this.Limit == input.Limit ||
                    (this.Limit != null &&
                    this.Limit.Equals(input.Limit))
                ) && 
                (
                    this.Next == input.Next ||
                    (this.Next != null &&
                    this.Next.Equals(input.Next))
                ) && 
                (
                    this.Offset == input.Offset ||
                    (this.Offset != null &&
                    this.Offset.Equals(input.Offset))
                ) && 
                (
                    this.Orders == input.Orders ||
                    this.Orders != null &&
                    this.Orders.SequenceEqual(input.Orders)
                ) && 
                (
                    this.Prev == input.Prev ||
                    (this.Prev != null &&
                    this.Prev.Equals(input.Prev))
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
                if (this.Href != null)
                    hashCode = hashCode * 59 + this.Href.GetHashCode();
                if (this.Limit != null)
                    hashCode = hashCode * 59 + this.Limit.GetHashCode();
                if (this.Next != null)
                    hashCode = hashCode * 59 + this.Next.GetHashCode();
                if (this.Offset != null)
                    hashCode = hashCode * 59 + this.Offset.GetHashCode();
                if (this.Orders != null)
                    hashCode = hashCode * 59 + this.Orders.GetHashCode();
                if (this.Prev != null)
                    hashCode = hashCode * 59 + this.Prev.GetHashCode();
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
