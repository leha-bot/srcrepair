﻿/*
 * This file is a part of SRC Repair project. For more information
 * visit official site: https://www.easycoding.org/projects/srcrepair
 *
 * Copyright (c) 2011 - 2020 EasyCoding Team (ECTeam).
 * Copyright (c) 2005 - 2020 EasyCoding Team.
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using NLog;

namespace srcrepair.core
{
    /// <summary>
    /// Class for working with collection of HUDs.
    /// </summary>
    public sealed class HUDManager
    {
        /// <summary>
        /// Logger instance for HUDManager class.
        /// </summary>
        private readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Store full list of available HUDs.
        /// </summary>
        private readonly Dictionary<string, HUDSingle> HUDsAvailable;

        /// <summary>
        /// Overloaded inxeding operator, returning HUD by specified name.
        /// </summary>
        public HUDSingle this[string key] => HUDsAvailable[key];

        /// <summary>
        /// Gets list of all available HUDs.
        /// </summary>
        public List<String> AvailableHUDNames
        {
            get
            {
                List<String> Result = new List<String>();
                foreach (string Hud in HUDsAvailable.Keys) { Result.Add(Hud); }
                return Result;
            }
        }

        /// <summary>
        /// Checks if specified HUD installed.
        /// </summary>
        /// <param name="CustomInstallDir">Full path to custom game stuff directory.</param>
        /// <param name="HUDDir">HUD installation directory name.</param>
        /// <returns>Return True if specified config is installed.</returns>
        public static bool CheckInstalledHUD(string CustomInstallDir, string HUDDir)
        {
            // Creating some local variables...
            bool Result = false;
            string HUDPath = Path.Combine(CustomInstallDir, HUDDir);

            // Checks if directory exists...
            if (Directory.Exists(HUDPath))
            {
                // Checks if any files exists in this directory...
                using (IEnumerator<String> StrEn = Directory.EnumerateFileSystemEntries(HUDPath).GetEnumerator())
                {
                    Result = StrEn.MoveNext();
                }
            }

            // Returning result...
            return Result;
        }

        /// <summary>
        /// Formats path with platform-dependent trailing path separator.
        /// </summary>
        /// <param name="IntDir">Source string with full path.</param>
        /// <returns>Formatted string.</returns>
        public static string FormatIntDir(string IntDir)
        {
            return IntDir.Replace('/', Path.DirectorySeparatorChar);
        }

        /// <summary>
        /// Checks if HUD database need to be updated.
        /// </summary>
        /// <param name="LastHUDUpdate">Date of the last HUD database update.</param>
        /// <returns>Returns True if database need to be updated.</returns>
        public static bool CheckHUDDatabase(DateTime LastHUDUpdate)
        {
            return (DateTime.Now - LastHUDUpdate).Days >= 7;
        }

        /// <summary>
        /// ConfigManager class constructor.
        /// </summary>
        /// <param name="GameID">Game ID.</param>
        /// <param name="FullAppPath">Full path to application's directory</param>
        /// <param name="AppHUDDir">Full HUD directory installation path</param>
        /// <param name="HideOutdated">Enable hiding of outdated HUDs.</param>
        public HUDManager(string GameID, string FullAppPath, string AppHUDDir, bool HideOutdated = true)
        {
            // Initializing empty dictionary...
            HUDsAvailable = new Dictionary<string, HUDSingle>();

            // Fetching list of available HUDs from XML database file...
            using (FileStream XMLFS = new FileStream(Path.Combine(FullAppPath, StringsManager.HudDatabaseName), FileMode.Open, FileAccess.Read))
            {
                // Loading XML file from file stream...
                XmlDocument XMLD = new XmlDocument();
                XMLD.Load(XMLFS);

                // Parsing XML and filling our structures...
                foreach (XmlNode XmlItem in XMLD.SelectNodes("HUDs/HUD"))
                {
                    try
                    {
                        if ((!HideOutdated || XmlItem.SelectSingleNode("IsUpdated").InnerText == "1") && (XmlItem.SelectSingleNode("Game").InnerText == GameID))
                        {
                            HUDsAvailable.Add(XmlItem.SelectSingleNode("Name").InnerText, new HUDSingle(XmlItem.SelectSingleNode("Name").InnerText, XmlItem.SelectSingleNode("Game").InnerText, XmlItem.SelectSingleNode("URI").InnerText, XmlItem.SelectSingleNode("UpURI").InnerText, XmlItem.SelectSingleNode("IsUpdated").InnerText == "1", XmlItem.SelectSingleNode("Preview").InnerText, XmlItem.SelectSingleNode("LastUpdate").InnerText, XmlItem.SelectSingleNode("Site").InnerText, XmlItem.SelectSingleNode("ArchiveDir").InnerText, XmlItem.SelectSingleNode("InstallDir").InnerText, XmlItem.SelectSingleNode("Hash2").InnerText, Path.Combine(AppHUDDir, Path.ChangeExtension(Path.GetFileName(XmlItem.SelectSingleNode("Name").InnerText), ".zip"))));
                        }
                    }
                    catch (Exception Ex)
                    {
                        Logger.Warn(Ex, DebugStrings.AppDbgExCoreHudManConstructor);
                    }
                }
            }
        }
    }
}
