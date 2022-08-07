// <copyright file="Metadata.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace Hackathon.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Metadata.
    /// </summary>
    public class Metadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Metadata"/> class.
        /// </summary>
        public Metadata()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Metadata"/> class.
        /// </summary>
        /// <param name="displayPhoneNumber">display_phone_number.</param>
        /// <param name="phoneNumberId">phone_number_id.</param>
        public Metadata(
            string displayPhoneNumber,
            string phoneNumberId)
        {
            this.DisplayPhoneNumber = displayPhoneNumber;
            this.PhoneNumberId = phoneNumberId;
        }

        /// <summary>
        /// Gets or sets DisplayPhoneNumber.
        /// </summary>
        [JsonProperty("display_phone_number")]
        public string DisplayPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets PhoneNumberId.
        /// </summary>
        [JsonProperty("phone_number_id")]
        public string PhoneNumberId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Metadata : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is Metadata other &&
                ((this.DisplayPhoneNumber == null && other.DisplayPhoneNumber == null) || (this.DisplayPhoneNumber?.Equals(other.DisplayPhoneNumber) == true)) &&
                ((this.PhoneNumberId == null && other.PhoneNumberId == null) || (this.PhoneNumberId?.Equals(other.PhoneNumberId) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DisplayPhoneNumber = {(this.DisplayPhoneNumber == null ? "null" : this.DisplayPhoneNumber == string.Empty ? "" : this.DisplayPhoneNumber)}");
            toStringOutput.Add($"this.PhoneNumberId = {(this.PhoneNumberId == null ? "null" : this.PhoneNumberId == string.Empty ? "" : this.PhoneNumberId)}");
        }
    }
}