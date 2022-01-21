using System.Collections.Generic;
using System.Globalization;

namespace Bonfire
{
    public static class PreferenceHelper
    {
        public static CultureInfo LoadedLanguage;

        private static List<(ServerEntryInfo, string)> serverEntries;

        private static void ClearThenStoreServerEntries()
        {
            Properties.Settings.Default.Servers.Clear();

            foreach ((ServerEntryInfo, string) entry in serverEntries)
            {
                string serializedEntry = entry.Item1.ToString() + ":" + entry.Item2;
                Properties.Settings.Default.Servers.Add(serializedEntry);
            }

            Properties.Settings.Default.Save();
        }

        public static void StoreServerEntry(ServerEntryInfo entryInfo, string name)
        {
            RemoveServerEntry(name, false);
            serverEntries.Add((entryInfo, name));

            ClearThenStoreServerEntries();
        }

        public static void RemoveServerEntry(string name, bool updateSettings = true)
        {
            bool found = false;
            int index = -1;
            foreach (var item in serverEntries)
            {
                index++;

                if (item.Item2 == name)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                return;
            }

            serverEntries.RemoveAt(index);

            if (updateSettings)
            {
                ClearThenStoreServerEntries();
            }
        }

        public static List<(ServerEntryInfo, string)> GetServerEntries()
        {
            if (serverEntries is null)
            {
                serverEntries = new List<(ServerEntryInfo, string)>();

                int index = -1;
                Stack<int> brokenIndices = new Stack<int>();
                // Load server entries from preferences.
                foreach (var serializedEntry in Properties.Settings.Default.Servers)
                {
                    index++;

                    ServerEntryInfo entryInfo = new ServerEntryInfo();
                    string servername;
                    string[] parameters = serializedEntry.Split(':');

                    if (parameters.Length < 2)
                    {
                        // Isn't formatted correctly, too few parameters.
                        brokenIndices.Push(index);
                        continue;
                    }

                    entryInfo.ip = parameters[0];

                    if (!short.TryParse(parameters[1], out short parsedPort))
                    {
                        // Invalid port number.
                        brokenIndices.Push(index);
                        continue;
                    }

                    entryInfo.port = parsedPort;

                    if (parameters.Length >= 3)
                    {
                        servername = parameters[2];
                    }
                    else
                    {
                        // No specified servername.
                        servername = entryInfo.ToString();
                    }

                    serverEntries.Add((entryInfo, servername));
                }

                // Remove broken entries, if any.
                while (brokenIndices.Count != 0)
                {
                    Properties.Settings.Default.Servers.RemoveAt(brokenIndices.Pop());
                }
            }

            return serverEntries;
        }
    }
}
