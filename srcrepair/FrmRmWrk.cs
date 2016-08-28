﻿/*
 * Модуль быстрой очистки SRC Repair.
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
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace srcrepair
{
    /// <summary>
    /// Класс формы модуля быстрой очистки.
    /// </summary>
    public partial class FrmRmWrk : Form
    {
        private bool IsRunning = true;
        private List<String> RemDirs;

        public FrmRmWrk(List<String> SL)
        {
            InitializeComponent();
            RemDirs = SL;
        }

        private List<String> DetectFilesForCleanup(List<String> CleanDirs)
        {
            // Создаём массив, в котором будем хранить имена файлов...
            List<String> Result = new List<String>();

            // Заполняем наш массив...
            foreach (string CleanCnd in CleanDirs)
            {
                // Проверяем существование каталога...
                if (Directory.Exists(CleanCnd))
                {
                    // Получаем содержимое каталога и добавляем их в очередь для удаления...
                    DirectoryInfo DInfo = new DirectoryInfo(CleanCnd);
                    FileInfo[] DirList = DInfo.GetFiles("*.*");
                    foreach (FileInfo DItem in DirList)
                    {
                        Result.Add(DItem.FullName);
                    }

                    // Получаем список вложенных каталогов...
                    List<String> SubDirs = new List<string>();
                    foreach (DirectoryInfo Dir in DInfo.GetDirectories())
                    {
                        SubDirs.Add(Path.Combine(Dir.FullName));
                    }

                    // Обходим полученные подкаталоги рекурсивно...
                    if (SubDirs.Count > 0)
                    {
                        Result.AddRange(DetectFilesForCleanup(SubDirs));
                    }
                }
                else
                {
                    // Если это не каталог, значит может быть обычным файлом. Проверим...
                    if (File.Exists(CleanCnd))
                    {
                        Result.Add(CleanCnd);
                    }
                }
            }

            // Выводим результат...
            return Result;
        }

        private void FrmRmWrk_Load(object sender, EventArgs e)
        {
            // Запускаем удаление асинхронно...
            if (!RW_Wrk.IsBusy) { RW_Wrk.RunWorkerAsync(); }
        }

        private void RW_Wrk_DoWork(object sender, DoWorkEventArgs e)
        {
            // Создаём список файлов для удаления...
            List<string> DeleteQueue = DetectFilesForCleanup(RemDirs);

            // Формируем счётчики...
            int TotalFiles = DeleteQueue.Count;
            int i = 1, j = 0;

            // Удаляем файлы из очереди очистки...
            foreach (string Fl in DeleteQueue)
            {
                try { j = (int)Math.Round(((double)i / (double)TotalFiles * (double)100.00), 0); i++; if ((j >= 0) && (j <= 100)) { RW_Wrk.ReportProgress(j); } } catch (Exception Ex) { CoreLib.WriteStringToLog(Ex.Message); }
                try { if (File.Exists(Fl)) { File.SetAttributes(Fl, FileAttributes.Normal); File.Delete(Fl); } } catch (Exception Ex) { CoreLib.WriteStringToLog(Ex.Message); }
            }

            // Удаляем пустые каталоги...
            foreach (string Dir in RemDirs) { CoreLib.RemoveEmptyDirectories(Path.GetDirectoryName(Dir)); }

        }

        private void RW_Wrk_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Отображаем прогресс удаления файлов...
            RW_PrgBr.Value = e.ProgressPercentage;
        }

        private void RW_Wrk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Удаление завершено. Закроем форму...
            IsRunning = false;
            if (e.Error != null) { CoreLib.HandleExceptionEx(AppStrings.RW_RmException, Properties.Resources.AppName, e.Error.Message, e.Error.Source, MessageBoxIcon.Warning); }
            Close();
        }

        private void FrmRmWrk_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Блокируем возможность закрытия формы при работающем процессе...
            e.Cancel = IsRunning;
        }
    }
}
