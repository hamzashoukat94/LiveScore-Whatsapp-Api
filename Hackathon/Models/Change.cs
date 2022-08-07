// <copyright file="Change.cs" company="APIMatic">
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
    /// Change.
    /// </summary>
    public class Change
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Change"/> class.
        /// </summary>
        public Change()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Change"/> class.
        /// </summary>
        /// <param name="mValue">value.</param>
        /// <param name="field">field.</param>
        public Change(
            Models.MValue mValue,
            string field)
        {
            this.MValue = mValue;
            this.Field = field;
        }

        /// <summary>
        /// Gets or sets MValue.
        /// </summary>
        [JsonProperty("value")]
        public Models.MValue MValue { get; set; }

        /// <summary>
        /// Gets or sets Field.
        /// </summary>
        [JsonProperty("field")]
        public string Field { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Change : ({string.Join(", ", toStringOutput)})";
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

            return obj is Change other &&
                ((this.MValue == null && other.MValue == null) || (this.MValue?.Equals(other.MValue) == true)) &&
                ((this.Field == null && other.Field == null) || (this.Field?.Equals(other.Field) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MValue = {(this.MValue == null ? "null" : this.MValue.ToString())}");
            toStringOutput.Add($"this.Field = {(this.Field == null ? "null" : this.Field == string.Empty ? "" : this.Field)}");
        }
    }
}