namespace Chatrum
{
    public class ServerEntryInfo
    {
        public int port;
        public string ip;

        public override string ToString()
        {
            return $"{ip}:{port}";
        }

        public override bool Equals(object obj)
        {
            return ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
