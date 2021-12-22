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
        private Dictionary<string, Server> servers = new Dictionary<string, Server>();
        private FlowLayoutPanel listPanel;

        public ServerListController(FlowLayoutPanel serverListPanel)
        {
            listPanel = serverListPanel;
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
                ServerListEntry_Clicked,
                listPanel);

            listPanel.Controls.Add(listEntry);

            Server s = new Server
            {
                port = port,
                ip = ip
            };
            servers.Add(servername, s);
        }

        private void ServerListEntry_Clicked(string servername)
        {
            ConnectToServer(servername);
        }
    }
}
