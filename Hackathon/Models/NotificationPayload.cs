// <copyright file="NotificationPayload.cs" company="APIMatic">
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
    /// NotificationPayload.
    /// </summary>
    public class NotificationPayload
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationPayload"/> class.
        /// </summary>
        public NotificationPayload()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationPayload"/> class.
        /// </summary>
        /// <param name="mObject">object.</param>
        /// <param name="entry">entry.</param>
        public NotificationPayload(
            string mObject,
            List<Models.Entry> entry)
        {
            this.MObject = mObject;
            this.Entry = entry;
        }

        /// <summary>
        /// Gets or sets MObject.
        /// </summary>
        [JsonProperty("object")]
        public string MObject { get; set; }

        /// <summary>
        /// Gets or sets Entry.
        /// </summary>
        [JsonProperty("entry")]
        public List<Models.Entry> Entry { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"NotificationPayload : ({string.Join(", ", toStringOutput)})";
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

            return obj is NotificationPayload other &&
                ((this.MObject == null && other.MObject == null) || (this.MObject?.Equals(other.MObject) == true)) &&
                ((this.Entry == null && other.Entry == null) || (this.Entry?.Equals(other.Entry) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MObject = {(this.MObject == null ? "null" : this.MObject == string.Empty ? "" : this.MObject)}");
            toStringOutput.Add($"this.Entry = {(this.Entry == null ? "null" : $"[{string.Join(", ", this.Entry)} ]")}");
        }
    }
}