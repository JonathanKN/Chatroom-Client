using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatrum
{
    public class ServerListController
    {
        private readonly Dictionary<string, ServerEntryInfo> servers = new Dictionary<string, ServerEntryInfo>();
        private readonly FlowLayoutPanel listPanel;
        private readonly Action<string> serverEntryClicked;

        public ServerListController(FlowLayoutPanel serverListPanel, Action<ServerEntryInfo, string> serverEntryClicked)
        {
            listPanel = serverListPanel;
            this.serverEntryClicked = (servername) => serverEntryClicked(servers[servername], servername);
        }

        public string[] GetServerNames() => servers.Keys.ToArray();

        public bool TryGetServer(string servername, out ServerEntryInfo server)
        {
            return servers.TryGetValue(servername, out server);
        }

        public void AddServer(int port, string ip, string servername)
        {
            ServerListEntry listEntry = new ServerListEntry(
                listPanel.Width - 17,
                servername,
                listPanel);
            listPanel.Controls.Add(listEntry);

            listEntry.RemoveServer += () => RemoveServer(listEntry, servername);
            listEntry.SwitchToServer += () => serverEntryClicked(servername);
            listEntry.CopyServer += () =>
            {
                Clipboard.SetText($"{ip}:{port}");
            };

            ServerEntryInfo s = new ServerEntryInfo
            {
                port = port,
                ip = ip
            };
            servers.Add(servername, s);
        }

        private void RemoveServer(ServerListEntry serverEntry, string server)
        {
            servers.Remove(server);
            listPanel.Controls.Remove(serverEntry);
        }
    }
}
