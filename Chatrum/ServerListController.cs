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
        private readonly Dictionary<string, Server> servers = new Dictionary<string, Server>();
        private readonly FlowLayoutPanel listPanel;
        private readonly Action<string> serverEntryClicked;

        public ServerListController(FlowLayoutPanel serverListPanel, Action<Server, string> serverEntryClicked)
        {
            listPanel = serverListPanel;
            this.serverEntryClicked = (servername) => serverEntryClicked(servers[servername], servername);
        }

        public bool TryGetServer(string servername, out Server server)
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

            Server s = new Server
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
