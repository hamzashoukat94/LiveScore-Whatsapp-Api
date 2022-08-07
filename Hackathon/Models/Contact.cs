// <copyright file="Contact.cs" company="APIMatic">
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
    /// Contact.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        public Contact()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        /// <param name="profile">profile.</param>
        /// <param name="waId">wa_id.</param>
        public Contact(
            Models.Profile profile,
            string waId)
        {
            this.Profile = profile;
            this.WaId = waId;
        }

        /// <summary>
        /// Gets or sets Profile.
        /// </summary>
        [JsonProperty("profile")]
        public Models.Profile Profile { get; set; }

        /// <summary>
        /// Gets or sets WaId.
        /// </summary>
        [JsonProperty("wa_id")]
        public string WaId { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Contact : ({string.Join(", ", toStringOutput)})";
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

            return obj is Contact other &&
                ((this.Profile == null && other.Profile == null) || (this.Profile?.Equals(other.Profile) == true)) &&
                ((this.WaId == null && other.WaId == null) || (this.WaId?.Equals(other.WaId) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Profile = {(this.Profile == null ? "null" : this.Profile.ToString())}");
            toStringOutput.Add($"this.WaId = {(this.WaId == null ? "null" : this.WaId == string.Empty ? "" : this.WaId)}");
        }
    }
}