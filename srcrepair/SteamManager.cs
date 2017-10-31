﻿/*
 * This file is a part of SRC Repair project. For more information
 * visit official site: https://www.easycoding.org/projects/srcrepair
 * 
 * Copyright (c) 2011 - 2017 EasyCoding Team (ECTeam).
 * Copyright (c) 2005 - 2017 EasyCoding Team.
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
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Win32;

namespace srcrepair
{
    /// <summary>
    /// Класс для взаимодействия с клиентом Steam.
    /// </summary>
    public static class SteamManager
    {
        /// <summary>
        /// Получает из реестра и возвращает путь к установленному клиенту Steam.
        /// </summary>
        /// <returns>Путь к клиенту Steam</returns>
        public static string GetSteamPath()
        {
            // Подключаем реестр и открываем ключ только для чтения...
            RegistryKey ResKey = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam", false);

            // Создаём строку для хранения результатов...
            string ResString = String.Empty;

            // Проверяем чтобы ключ реестр существовал и был доступен...
            if (ResKey != null)
            {
                // Получаем значение открытого ключа...
                object ResObj = ResKey.GetValue("SteamPath");

                // Проверяем чтобы значение существовало...
                if (ResObj != null)
                {
                    // Существует, возвращаем...
                    ResString = Path.GetFullPath(Convert.ToString(ResObj));
                }
                else
                {
                    // Значение не существует, поэтому сгенерируем исключение для обработки в основном коде...
                    throw new NullReferenceException("Exception: No InstallPath value detected! Please run Steam.");
                }
            }

            // Закрываем открытый ранее ключ реестра...
            ResKey.Close();

            // Возвращаем результат...
            return ResString;
        }

        /// <summary>
        /// Получает из реестра и возвращает текущий язык клиента Steam.
        /// </summary>
        /// <returns>Язык клиента Steam</returns>
        public static string GetSteamLanguage()
        {
            using (RegistryKey ResKey = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam", false))
            {
                string Result = String.Empty;
                if (ResKey != null) { object ResObj = ResKey.GetValue("Language"); if (ResObj != null) { Result = Convert.ToString(ResObj); } else { throw new NullReferenceException("Exception: No Language value detected! Please run Steam."); } }
                return Result;
            }
        }

        /// <summary>
        /// Тестирует переданный каталог в качестве пути установки Steam.
        /// </summary>
        /// <param name="SteamPath">Каталог установки Steam</param>
        /// <returns>Каталог установки Steam</returns>
        public static string TrySteamPath(string SteamPath)
        {
            if (Directory.Exists(SteamPath)) { return SteamPath; } else { throw new DirectoryNotFoundException(); }
        }

        /// <summary>
        /// Возвращает путь к главному VDF конфигу Steam.
        /// </summary>
        /// <param name="SteamPath">Каталог установки Steam</param>
        /// <returns>Путь к VDF конфигу</returns>
        public static string GetSteamConfig(string SteamPath)
        {
            return Path.Combine(SteamPath, "config", "config.vdf");
        }

        /// <summary>
        /// Возвращает путь к локально хранящемуся VDF конфигу Steam.
        /// </summary>
        /// <param name="SteamPath">Каталог установки Steam</param>
        /// <returns>Путь к локальному VDF конфигу</returns>
        public static List<String> GetSteamLocalConfig(string SteamPath)
        {
            List<String> Result = new List<String>();
            foreach (string ID in GetUserIDs(SteamPath))
            {
                Result.AddRange(FileManager.FindFiles(Path.Combine(SteamPath, "userdata", ID, "config"), "localconfig.vdf"));
            }
            return Result;
        }

        /// <summary>
        /// Возвращает список используемых на данном компьютере SteamID.
        /// </summary>
        /// <param name="SteamPath">Каталог установки Steam</param>
        /// <returns>Список Steam user ID</returns>
        public static List<String> GetUserIDs(string SteamPath)
        {
            // Создаём новый список...
            List<String> Result = new List<String>();

            // Получаем список каталогов...
            string DDir = Path.Combine(SteamPath, "userdata");
            if (Directory.Exists(DDir))
            {
                DirectoryInfo DInfo = new DirectoryInfo(DDir);
                foreach (DirectoryInfo SubDir in DInfo.GetDirectories())
                {
                    Result.Add(SubDir.Name);
                }
            }

            // Возвращаем результат...
            return Result;
        }

        /// <summary>
        /// Получает и возвращает параметры запуска указанного приложения.
        /// </summary>
        /// <param name="SteamPath">Каталог установки Steam</param>
        /// <param name="GameID">ID приложения, параметры запуска которого нужно определить</param>
        /// <returns>Параметры запуска приложения</returns>
        public static string GetLaunchOptions(string SteamPath, string GameID)
        {
            // Возвращаем результат...
            return String.Empty;
        }

        /// <summary>
        /// Очищает блобы (файлы с расширением *.blob) из каталога Steam.
        /// </summary>
        /// <param name="SteamPath">Полный путь к каталогу Steam</param>
        public static void CleanBlobsNow(string SteamPath)
        {
            // Инициализируем буферную переменную, в которой будем хранить имя файла...
            string FileName;

            // Генерируем имя первого кандидата на удаление с полным путём до него...
            FileName = Path.Combine(SteamPath, "AppUpdateStats.blob");

            // Проверяем существует ли данный файл...
            if (File.Exists(FileName))
            {
                // Удаляем...
                File.Delete(FileName);
            }

            // Аналогично генерируем имя второго кандидата...
            FileName = Path.Combine(SteamPath, "ClientRegistry.blob");

            // Проверяем, существует ли файл...
            if (File.Exists(FileName))
            {
                // Удаляем...
                File.Delete(FileName);
            }
        }

        /// <summary>
        /// Удаляет значения реестра, отвечающие за настройки клиента Steam,
        /// а также записывает значение языка.
        /// </summary>
        /// <param name="LangCode">ID языка Steam</param>
        public static void CleanRegistryNow(int LangCode)
        {
            // Удаляем ключ HKEY_LOCAL_MACHINE\Software\Valve рекурсивно (если есть права администратора)...
            if (ProcessManager.IsCurrentUserAdmin()) { Registry.LocalMachine.DeleteSubKeyTree(Path.Combine("Software", "Valve"), false); }

            // Удаляем ключ HKEY_CURRENT_USER\Software\Valve рекурсивно...
            Registry.CurrentUser.DeleteSubKeyTree(Path.Combine("Software", "Valve"), false);

            // Начинаем вставлять значение языка клиента Steam...
            // Инициализируем буферную переменную для хранения названия языка...
            string XLang;

            // Генерируем...
            switch (LangCode)
            {
                case 0:
                    XLang = "english";
                    break;
                case 1:
                    XLang = "russian";
                    break;
                default:
                    XLang = "english";
                    break;
            }

            // Подключаем реестр и создаём ключ HKEY_CURRENT_USER\Software\Valve\Steam...
            RegistryKey RegLangKey = Registry.CurrentUser.CreateSubKey(Path.Combine("Software", "Valve", "Steam"));

            // Если не было ошибок, записываем значение...
            if (RegLangKey != null)
            {
                // Записываем значение в реестр...
                RegLangKey.SetValue("language", XLang);
            }

            // Закрываем ключ...
            RegLangKey.Close();
        }

        /// <summary>
        /// Считывает из главного файла конфигурации Steam пути к дополнительным точкам монтирования.
        /// </summary>
        /// <param name="SteamPath">Путь к клиенту Steam</param>
        public static List<String> GetSteamMountPoints(string SteamPath)
        {
            // Создаём массив, в который будем помещать найденные пути...
            List<String> Result = new List<String> { SteamPath };

            // Начинаем чтение главного файла конфигурации...
            try
            {
                // Открываем файл как поток...
                using (StreamReader SteamConfig = new StreamReader(Path.Combine(SteamPath, "config", "config.vdf"), Encoding.Default))
                {
                    // Инициализируем буферную переменную...
                    string RdStr;

                    // Читаем поток построчно...
                    while (SteamConfig.Peek() >= 0)
                    {
                        // Считываем строку и сразу очищаем от лишнего...
                        RdStr = SteamConfig.ReadLine().Trim();

                        // Проверяем наличие данных в строке...
                        if (!(String.IsNullOrWhiteSpace(RdStr)))
                        {
                            // Ищем в строке путь установки...
                            if (RdStr.IndexOf("BaseInstallFolder", StringComparison.CurrentCultureIgnoreCase) != -1)
                            {
                                RdStr = CoreLib.CleanStrWx(RdStr, true, true);
                                RdStr = RdStr.Remove(0, RdStr.IndexOf(" ") + 1);
                                if (!(String.IsNullOrWhiteSpace(RdStr))) { Result.Add(RdStr); }
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                CoreLib.WriteStringToLog(Ex.Message);
            }

            // Возвращаем сформированный массив...
            return Result;
        }

        /// <summary>
        /// Формирует полные пути к библиотекам с установленными играми.
        /// </summary>
        /// <param name="SteamPath">Путь установки Steam</param>
        /// <param name="SteamAppsFolderName">Платформо-зависимое название каталога SteamApps</param>
        public static List<String> FormatInstallDirs(string SteamPath, string SteamAppsFolderName)
        {
            // Создаём массив, в который будем помещать найденные пути...
            List<String> Result = new List<String>();

            // Считываем все возможные расположения локальных библиотек игр...
            List<String> MntPnts = GetSteamMountPoints(SteamPath);

            // Начинаем обход каталога и получение поддиректорий...
            foreach (string MntPnt in MntPnts)
            {
                Result.Add(Path.Combine(MntPnt, SteamAppsFolderName, "common"));
            }

            // Возвращаем сформированный массив...
            return Result;
        }
    }
}
