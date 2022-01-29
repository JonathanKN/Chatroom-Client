namespace Bonfire
{
    /// <summary>
    /// Class for storing serverentry information,
    /// primarily used for saving and loading preferences.
    /// </summary>
    public class ServerEntryInfo
    {
        /// <summary>
        /// Gets or sets the serverentry port.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the IP/hostname of the serverentry.
        /// </summary>
        public string IP { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{IP}:{Port}";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return ToString() == obj.ToString();
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
