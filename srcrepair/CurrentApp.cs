﻿/*
 * Класс CurrentApp SRC Repair.
 * 
 * Copyright 2011 - 2017 EasyCoding Team (ECTeam).
 * Copyright 2005 - 2017 EasyCoding Team.
 * 
 * Лицензия: GPL v3 (см. файл GPL.txt).
 * Лицензия контента: Creative Commons 3.0 BY.
 * 
 * Запрещается использовать этот файл при использовании любой
 * лицензии, отличной от GNU GPL версии 3 и с ней совместимой.
 * 
 * Официальный блог EasyCoding Team: http://www.easycoding.org/
 * Официальная страница проекта: http://www.easycoding.org/projects/srcrepair
 * 
 * Более подробная инфорация о программе в readme.txt,
 * о лицензии - в GPL.txt.
*/
using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;

namespace srcrepair
{
    /// <summary>
    /// Класс работы с рантаймом.
    /// </summary>
    public sealed class CurrentApp
    {
        /// <summary>
        /// Хранит User-Agent, которым представляется удалённым службам...
        /// </summary>
        public string UserAgent { get; private set; }

        /// <summary>
        /// Хранит полный путь к каталогу установленного клиента Steam.
        /// </summary>
        public string FullSteamPath { get; set; }

        /// <summary>
        /// Хранит полный путь к каталогу с утилитой SRCRepair для служебных
        /// целей.
        /// </summary>
        public string FullAppPath { get; private set; }

        /// <summary>
        /// Хранить путь до каталога пользователя программы. Используется
        /// для служебных целей.
        /// </summary>
        public string AppUserDir { get; private set; }

        /// <summary>
        /// Возвращает архитектуру операционной системы.
        /// </summary>
        private string SystemArch { get { return Environment.Is64BitOperatingSystem ? "Amd64" : "x86"; } }

        /// <summary>
        /// Возвращает путь к пользовательскому каталогу программы.
        /// </summary>
        public static string AppUserPath { get { return Properties.Settings.Default.IsPortable ? Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "portable") : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Properties.Resources.AppName); } }
        
        /// <summary>
        /// Возвращает название продукта (из ресурса сборки).
        /// </summary>
        public static string AppProduct { get { object[] Attribs = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false); return Attribs.Length != 0 ? ((AssemblyProductAttribute)Attribs[0]).Product : String.Empty; } }

        /// <summary>
        /// Возвращает версию приложения ((из ресурса сборки).
        /// </summary>
        public static string AppVersion { get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); } }

        /// <summary>
        /// Возвращает название компании-разработчика (из ресурса сборки).
        /// </summary>
        public static string AppCompany { get { object[] Attribs = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false); return Attribs.Length != 0 ? ((AssemblyCompanyAttribute)Attribs[0]).Company : String.Empty; } }

        /// <summary>
        /// Возвращает копирайты приложения (из ресурса сборки).
        /// </summary>
        public static string AppCopyright { get { object[] Attribs = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false); return Attribs.Length != 0 ? ((AssemblyCopyrightAttribute)Attribs[0]).Copyright : String.Empty; } }

        /// <summary>
        /// Возвращает описание переданной в качестве параметра переменной, получая
        /// эту информацию из ресурса CVList с учётом локализации.
        /// </summary>
        /// <param name="CVar">Название переменной</param>
        /// <returns>Описание переменной с учётом локализации</returns>
        public static string GetConVarDescription(string CVar)
        {
            ResourceManager DM = new ResourceManager(Properties.Resources.CE_CVResDf, typeof(FrmMainW).Assembly);
            return DM.GetString(CVar);
        }

        /// <summary>
        /// Конструктор класса. Получает информацию для рантайма.
        /// </summary>
        public CurrentApp()
        {
            // Получаем путь к каталогу приложения...
            FullAppPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            // Укажем путь к пользовательским данным и создадим если не существует...
            AppUserDir = AppUserPath;

            // Проверим существование каталога пользовательских данных и при необходимости создадим...
            if (!(Directory.Exists(AppUserDir)))
            {
                Directory.CreateDirectory(AppUserDir);
            }

            // Генерируем User-Agent для SRC Repair...
            UserAgent = String.Format(Properties.Resources.AppDefUA, Properties.Resources.PlatformFriendlyName, Environment.OSVersion.Version.Major, Environment.OSVersion.Version.Minor, CultureInfo.CurrentCulture.Name, AppVersion, Properties.Resources.AppName, SystemArch);
        }
    }
}
