﻿/*
 * Класс, предназначенный для работы с графическими настройками NCF игр.
 * 
 * Copyright 2011 - 2016 EasyCoding Team (ECTeam).
 * Copyright 2005 - 2016 EasyCoding Team.
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
using System.Collections.Generic;
using System.IO;

namespace srcrepair
{
    /// <summary>
    /// Управляет графическими настройками NCF приложений.
    /// </summary>
    public class NCFVideo : VideoSettings
    {
        /// <summary>
        /// Хранит путь к актуальному файлу с графическими настройками игры.
        /// </summary>
        private string VideoFileName;

        /// <summary>
        /// Хранит путь к файлу со стандартными настройками для текущего ПК.
        /// </summary>
        private string DefaultsFileName;

        /// <summary>
        /// Хранит содержиме файла с графическими настройками игры.
        /// </summary>
        private List<String> VideoFile;

        /// <summary>
        /// Хранит содержиме файла со стандартными настройками игры для текущего ПК.
        /// </summary>
        private List<String> DefaultsFile;

        /// <summary>
        /// Хранит настройки соотношения сторон NCF-игры на движке Source 1: setting.aspectratiomode.
        /// </summary>
        private int ScreenRatio;

        /// <summary>
        /// Хранит настройки контрастности и цветовой гаммы NCF-игры на движке Source 1: setting.mat_monitorgamma.
        /// </summary>
        private int Brightness;

        /// <summary>
        /// Хранит настройки качества теней NCF-игры на движке Source 1: setting.csm_quality_level.
        /// </summary>
        private int ShadowQuality;

        /// <summary>
        /// Хранит настройки размытия движений NCF-игры на движке Source 1: setting.mat_motion_blur_enabled.
        /// </summary>
        private int MotionBlur;

        /// <summary>
        /// Хранит настройки графического режима NCF-игры на движке Source 1: setting.fullscreen.
        /// </summary>
        private int DisplayMode;

        /// <summary>
        /// Хранит настройки графического режима NCF-игры на движке Source 1: setting.nowindowborder.
        /// </summary>
        private int DisplayBorderless;

        /// <summary>
        /// Хранит настройки полноэкранного сглаживания NCF-игры на движке Source 1: setting.mat_antialias.
        /// </summary>
        private int AntiAliasing;

        /// <summary>
        /// Хранит значение глубины полноэкранного сглаживания NCF-игры на движке Source 1: setting.mat_aaquality.
        /// </summary>
        private int AntiAliasQuality;

        /// <summary>
        /// Хранит настройки качества фильтрации текстур NCF-игры на движке Source 1: setting.mat_forceaniso.
        /// </summary>
        private int FilteringMode;

        /// <summary>
        /// Хранит настройки вертикальной синхронизации NCF-игры на движке Source 1: setting.mat_vsync.
        /// </summary>
        private int VSync;

        /// <summary>
        /// Хранит настройки качества вертикальной синхронизации NCF-игры на движке Source 1: setting.mat_triplebuffered.
        /// </summary>
        private int VSyncMode;

        /// <summary>
        /// Хранит настройки многоядерного рендеринга NCF-игры на движке Source 1: setting.mat_queue_mode.
        /// </summary>
        private int MCRendering;

        /// <summary>
        /// Хранит настройки качества шейдерных эффектов NCF-игры на движке Source 1: setting.gpu_level.
        /// </summary>
        private int ShaderEffects;

        /// <summary>
        /// Хранит настройки качества обычных эффектов NCF-игры на движке Source 1: setting.cpu_level.
        /// </summary>
        private int EffectDetails;

        /// <summary>
        /// Хранит настройки выделенного игре пула памяти NCF-игры на движке Source 1: setting.mem_level.
        /// </summary>
        private int MemoryPoolType;

        /// <summary>
        /// Хранит настройки качества детализации моделей и текстур NCF-игры на движке Source 1: setting.gpu_mem_level.
        /// </summary>
        private int TextureModelQuality;

        /// <summary>
        /// Возвращает настройки соотношения сторон NCF-игры на движке Source 1.
        /// </summary>
        public int GetScreenRatio()
        {
            int res = -1;

            switch (ScreenRatio)
            {
                case 0: res = 0;
                    break;
                case 1: res = 1;
                    break;
                case 2: res = 2;
                    break;
            }

            return res;
        }

        /// <summary>
        /// Задаёт настройки соотношения сторон NCF-игры на движке Source 1.
        /// </summary>
        /// <param name="Value">Текущий индекс контрола</param>
        public void SetScreenRatio(int Value)
        {
            switch (Value)
            {
                case 0: ScreenRatio = 0;
                    break;
                case 1: ScreenRatio = 1;
                    break;
                case 2: ScreenRatio = 2;
                    break;
            }
        }

        /// <summary>
        /// Считывает графические настройки игры из файла.
        /// </summary>
        private void ReadSettings()
        {
            //
        }

        /// <summary>
        /// Сохраняет графические настройки игры в файл.
        /// </summary>
        public void WriteSettings()
        {
            //
        }

        /// <summary>
        /// Базовый конструктор класса.
        /// </summary>
        /// <param name="VFile">Путь к файлу с настройками графики</param>
        /// <param name="ReadNow">Включает автоматическое считывание настроек из файла</param>
        public NCFVideo(string VFile, bool ReadNow = true)
        {
            // Сохраним путь к файлу с графическими настройками...
            VideoFileName = VFile;

            // Сгенерируем путь к файлу со стандартными настройками графики текущей системы...
            DefaultsFileName = Path.Combine(Path.GetDirectoryName(VideoFileName), "videodefaults.txt");

            // Считываем настройки из файла если зто разрешено...
            if (ReadNow)
            {
                // Получаем содержимое файла графических настроек...
                VideoFile = new List<String>(File.ReadAllLines(VideoFileName));

                // Получаем содержимое файла стандартных настроек (если он существует)...
                DefaultsFile = new List<String>();
                if (File.Exists(DefaultsFileName)) { DefaultsFile.AddRange(File.ReadAllLines(DefaultsFileName)); }

                // Запускаем непосредственно процесс...
                ReadSettings();
            }
        }
    }
}
