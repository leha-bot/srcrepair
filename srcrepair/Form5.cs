﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace srcrepair
{
    public partial class frmInstaller : Form
    {
        public frmInstaller()
        {
            InitializeComponent();
        }

        private const string PluginName = "Quick Installer";

        private void InstallFileNow(string FileName, string SubDir)
        {
            // Устанавливаем файл...
            File.Copy(FileName, frmMainW.IncludeTrDelim(GV.FullGamePath + SubDir) + Path.GetFileName(FileName), true);
        }

        private void CompileFromVTF(string FileName)
        {
            // Начинаем...
            using (System.IO.StreamWriter CFile = new System.IO.StreamWriter(FileName))
            {
                CFile.WriteLine(@"""UnlitGeneric""");
                CFile.WriteLine("{");
                string AAA = "\t" + @"""$basetexture""	""vgui\logos\" + Path.GetFileNameWithoutExtension(FileName) + @"""";
                CFile.WriteLine("\t" + @"""$basetexture""	""vgui\logos\" + Path.GetFileNameWithoutExtension(FileName) + @"""");
                CFile.WriteLine("\t" + @"""$translucent"" ""1""");
                CFile.WriteLine("\t" + @"""$ignorez"" ""1""");
                CFile.WriteLine("\t" + @"""$vertexcolor"" ""1""");
                CFile.WriteLine("\t" + @"""$vertexalpha"" ""1""");
                CFile.WriteLine("}");
                CFile.Close();
            }
        }

        private void InstallSprayNow(string FileName)
        {
            // Заполняем необходимые переменные...
            string CDir = frmMainW.IncludeTrDelim(Path.GetDirectoryName(FileName)); // Получаем каталог с файлами для копирования...
            string FPath = GV.FullGamePath + @"materials\vgui\logos\"; // Получаем путь к каталогу назначения...
            string FFPath = FPath + Path.GetFileName(FileName); // Получаем полный путь к файлу...
            string VMTFileDest = FPath + Path.GetFileNameWithoutExtension(Path.GetFileName(FileName)) + ".vmt"; // Генерируем путь назначения с именем файла...
            string VMTFile = CDir + Path.GetFileName(VMTFileDest); // Получаем путь до VMT-файла, лежащего в папке с VTF...
            bool UseVMT;

            // Начинаем...
            // Проверим наличие VMT-файла и если его нет, соберём вручную...
            if (File.Exists(VMTFile)) // Проверяем...
            {
                UseVMT = true; // Файл найден, включаем установку и VMT...
            }
            else
            {
                // Файл не найден, спросим нужно ли создать...
                DialogResult UserConfirmation = MessageBox.Show(frmMainW.RM.GetString("QI_GenVMTMsg"), PluginName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (UserConfirmation == DialogResult.Yes)
                {
                    // Да, нужно.
                    UseVMT = true;
                    CompileFromVTF(VMTFile);
                }
                else
                {
                    UseVMT = false; // Отключаем установку VMT-файла...
                }
            }

            // Копируем VTF-файл...
            File.Copy(FileName, FPath + Path.GetFileName(FFPath), true);

            // Копируем VMT-файл если задано...
            if (UseVMT) { File.Copy(VMTFile, VMTFileDest, true); }
        }
        
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Открываем диалоговое окно выбора файла и записываем путь в Edit...
            DialogResult OpenResult = openDialog.ShowDialog();
            if (OpenResult == DialogResult.OK)
            {
                InstallPath.Text = openDialog.FileName;
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            // А здесь собственно установка...
            if (!(String.IsNullOrEmpty(InstallPath.Text)))
            {
                try
                {
                    // У нас два алгоритма, поэтому придётся делать проверки...
                    switch (Path.GetExtension(InstallPath.Text))
                    {
                        case ".dem": InstallFileNow(InstallPath.Text, ""); // Будем устанавливать демку...
                            break;
                        case ".cfg": InstallFileNow(InstallPath.Text, @"cfg\"); // Будем устанавливать конфиг...
                            break;
                        case ".vtf": InstallSprayNow(InstallPath.Text); // Будем устанавливай спрей...
                            break;
                    }

                    // Выведем сообщение...
                    MessageBox.Show(frmMainW.RM.GetString("QI_InstSuccessfull"), PluginName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    // Произошло исключение, выведем сообщение...
                    MessageBox.Show(frmMainW.RM.GetString("QI_Excpt"), PluginName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Пользователь ничего не выбрал для установки, укажем ему на это...
                MessageBox.Show(frmMainW.RM.GetString("QI_InstUnav"), PluginName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
