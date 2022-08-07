// <copyright file="MValue.cs" company="APIMatic">
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
    /// MValue.
    /// </summary>
    public class MValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MValue"/> class.
        /// </summary>
        public MValue()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MValue"/> class.
        /// </summary>
        /// <param name="messagingProduct">messaging_product.</param>
        /// <param name="metadata">metadata.</param>
        /// <param name="contacts">contacts.</param>
        /// <param name="messages">messages.</param>
        public MValue(
            string messagingProduct,
            Models.Metadata metadata,
            List<Models.Contact> contacts,
            List<Models.Message> messages)
        {
            this.MessagingProduct = messagingProduct;
            this.Metadata = metadata;
            this.Contacts = contacts;
            this.Messages = messages;
        }

        /// <summary>
        /// Gets or sets MessagingProduct.
        /// </summary>
        [JsonProperty("messaging_product")]
        public string MessagingProduct { get; set; }

        /// <summary>
        /// Gets or sets Metadata.
        /// </summary>
        [JsonProperty("metadata")]
        public Models.Metadata Metadata { get; set; }

        /// <summary>
        /// Gets or sets Contacts.
        /// </summary>
        [JsonProperty("contacts")]
        public List<Models.Contact> Contacts { get; set; }

        /// <summary>
        /// Gets or sets Messages.
        /// </summary>
        [JsonProperty("messages")]
        public List<Models.Message> Messages { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"MValue : ({string.Join(", ", toStringOutput)})";
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

            return obj is MValue other &&
                ((this.MessagingProduct == null && other.MessagingProduct == null) || (this.MessagingProduct?.Equals(other.MessagingProduct) == true)) &&
                ((this.Metadata == null && other.Metadata == null) || (this.Metadata?.Equals(other.Metadata) == true)) &&
                ((this.Contacts == null && other.Contacts == null) || (this.Contacts?.Equals(other.Contacts) == true)) &&
                ((this.Messages == null && other.Messages == null) || (this.Messages?.Equals(other.Messages) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MessagingProduct = {(this.MessagingProduct == null ? "null" : this.MessagingProduct == string.Empty ? "" : this.MessagingProduct)}");
            toStringOutput.Add($"this.Metadata = {(this.Metadata == null ? "null" : this.Metadata.ToString())}");
            toStringOutput.Add($"this.Contacts = {(this.Contacts == null ? "null" : $"[{string.Join(", ", this.Contacts)} ]")}");
            toStringOutput.Add($"this.Messages = {(this.Messages == null ? "null" : $"[{string.Join(", ", this.Messages)} ]")}");
        }
    }
}