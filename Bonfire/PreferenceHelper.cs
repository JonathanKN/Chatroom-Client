using System.Collections.Generic;
using System.Globalization;

namespace Bonfire
{
    public static class PreferenceHelper
    {
        /// <summary>
        /// Gets or sets the currently selected language, since application startup.
        /// </summary>
        public static CultureInfo LoadedLanguage { get; set; }

        private static IList<(ServerEntryInfo, string)> ServerEntries { get; set; }

        /// <summary>
        /// Stores a particular server entry.
        /// </summary>
        /// <param name="entryInfo"></param>
        /// <param name="name"></param>
        public static void StoreServerEntry(ServerEntryInfo entryInfo, string name)
        {
            RemoveServerEntry(name, false);
            ServerEntries.Add((entryInfo, name));

            ClearThenStoreServerEntries();
        }

        /// <summary>
        /// Removes a particular server entry.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="updateSettings"></param>
        public static void RemoveServerEntry(string name, bool updateSettings = true)
        {
            bool found = false;
            int index = -1;
            foreach (var item in ServerEntries)
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

            ServerEntries.RemoveAt(index);

            if (updateSettings)
            {
                ClearThenStoreServerEntries();
            }
        }

        /// <summary>
        /// Returns the list of server entries.
        /// </summary>
        /// <returns>Returns a list containing the server entries.</returns>
        public static IList<(ServerEntryInfo, string)> GetServerEntries()
        {
            if (!(ServerEntries is null))
            {
                return ServerEntries;
            }

            ServerEntries = new List<(ServerEntryInfo, string)>();

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

                entryInfo.IP = parameters[0];

                if (!short.TryParse(parameters[1], out short parsedPort))
                {
                    // Invalid port number.
                    brokenIndices.Push(index);
                    continue;
                }

                entryInfo.Port = parsedPort;

                if (parameters.Length >= 3)
                {
                    servername = parameters[2];
                }
                else
                {
                    // No specified servername.
                    servername = entryInfo.ToString();
                }

                ServerEntries.Add((entryInfo, servername));
            }

            // Remove broken entries, if any.
            while (brokenIndices.Count != 0)
            {
                Properties.Settings.Default.Servers.RemoveAt(brokenIndices.Pop());
            }

            return ServerEntries;
        }

        private static void ClearThenStoreServerEntries()
        {
            Properties.Settings.Default.Servers.Clear();

            foreach ((ServerEntryInfo, string) entry in ServerEntries)
            {
                string serializedEntry = entry.Item1.ToString() + ":" + entry.Item2;
                Properties.Settings.Default.Servers.Add(serializedEntry);
            }

            Properties.Settings.Default.Save();
        }
    }
}
