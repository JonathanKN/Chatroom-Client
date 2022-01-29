using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Bonfire.LogicControllers
{
    public class ServerListController
    {
        private readonly Dictionary<string, ServerEntryInfo> servers = new Dictionary<string, ServerEntryInfo>();
        private readonly Dictionary<ServerEntryInfo, ServerListEntry> serverEntryUI = new Dictionary<ServerEntryInfo, ServerListEntry>();
        private readonly FlowLayoutPanel listPanel;
        private readonly Action<string> serverEntryClicked;
        private readonly Action disconnect;
        private readonly ToolTip serverEntryTooltip;

        public ServerListController(bool populateWithPreferences, FlowLayoutPanel serverListPanel, Action<ServerEntryInfo, string> serverEntryClicked, Action disconnect, ToolTip serverEntryTooltip)
        {
            listPanel = serverListPanel;
            this.serverEntryClicked = (servername) => serverEntryClicked(servers[servername], servername);
            this.serverEntryTooltip = serverEntryTooltip;
            this.disconnect = disconnect;

            if (populateWithPreferences)
            {
                // Populate with cloned list.
                PopulateWithPreferences(new List<(ServerEntryInfo, string)>(PreferenceHelper.GetServerEntries()));
            }
        }

        public void PopulateWithPreferences(List<(ServerEntryInfo, string)> entries)
        {
            foreach (var item in entries)
            {
                AddServer(item.Item1.Port, item.Item1.IP, item.Item2);
            }
        }

        public string[] GetServerNames() => servers.Keys.ToArray();

        public bool TryGetServer(string servername, out ServerEntryInfo server)
        {
            return servers.TryGetValue(servername, out server);
        }

        public void UpdateServerConnectedStatus(ServerEntryInfo serverInfo, bool connected)
        {
            UpdateStatusDisconnectAll();
            if (!serverEntryUI.TryGetValue(serverInfo, out ServerListEntry value))
            {
                // 🤷‍
                return;
            }

            value.UpdateConnectedState(connected);
        }

        public void UpdateStatusDisconnectAll()
        {
            foreach (var item in serverEntryUI)
            {
                item.Value.UpdateConnectedState(false);
            }
        }

        public void AddServer(int port, string ip, string servername)
        {
            ServerListEntry listEntry = new ServerListEntry(
                listPanel.Width - 17,
                servername,
                listPanel);
            listPanel.Controls.Add(listEntry);

            serverEntryTooltip.SetToolTip(listEntry.ServernameLabel, $"Server information: {ip}:{port}");

            ServerEntryInfo info = new ServerEntryInfo
            {
                Port = port,
                IP = ip,
            };
            servers.Add(servername, info);

            listEntry.RemoveServer += () => RemoveServer(info, servername);
            listEntry.SwitchToServer += () => serverEntryClicked(servername);
            listEntry.CopyServer += () =>
            {
                Clipboard.SetText($"{ip}:{port}");
            };
            listEntry.Disconnect += () =>
            {
                disconnect?.Invoke();
            };

            serverEntryUI[info] = listEntry;

            PreferenceHelper.StoreServerEntry(info, servername);
        }

        private void RemoveServer(ServerEntryInfo serverEntry, string servername)
        {
            PreferenceHelper.RemoveServerEntry(servername);
            servers.Remove(servername);
            listPanel.Controls.Remove(serverEntryUI[serverEntry]);
            serverEntryUI.Remove(serverEntry);
        }
    }
}
