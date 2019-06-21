﻿; 
; This file is a part of SRC Repair project. For more information
; visit official site: https://www.easycoding.org/projects/srcrepair
; 
; Copyright (c) 2011 - 2019 EasyCoding Team (ECTeam).
; Copyright (c) 2005 - 2019 EasyCoding Team.
; 
; This program is free software: you can redistribute it and/or modify
; it under the terms of the GNU General Public License as published by
; the Free Software Foundation, either version 3 of the License, or
; (at your option) any later version.
; 
; This program is distributed in the hope that it will be useful,
; but WITHOUT ANY WARRANTY; without even the implied warranty of
; MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
; GNU General Public License for more details.
; 
; You should have received a copy of the GNU General Public License
; along with this program. If not, see <http://www.gnu.org/licenses/>.
;

; Задаём особые директивы препроцессора...
#define VERSION GetFileVersion("..\..\srcrepair\bin\Release\srcrepair.exe")
#define CI_COMMIT GetEnv('CI_HASH')
#if CI_COMMIT == ''
#define _RELEASE 1
#endif

[Setup]
; Задаём основные параметры...
AppId={{77A71DAB-56AA-4F33-BDE8-F00798468B9D}
AppName=SRC Repair
AppVerName=SRC Repair
AppPublisher=EasyCoding Team
AppPublisherURL=https://www.easycoding.org/
AppVersion={#VERSION}
AppSupportURL=https://github.com/xvitaly/srcrepair/issues
AppUpdatesURL=https://github.com/xvitaly/srcrepair/releases
DefaultDirName={code:GetDefRoot}\SRC Repair
DefaultGroupName=SRC Repair
AllowNoIcons=yes
LicenseFile=..\..\COPYING
#ifdef _RELEASE
OutputBaseFilename=srcrepair_340_final
#else
OutputBaseFilename=snapshot_{#CI_COMMIT}
#endif
SetupIconFile=..\..\srcrepair\srcrepair.ico
UninstallDisplayIcon={app}\srcrepair.exe
Compression=lzma2
SolidCompression=yes
PrivilegesRequired=lowest
ArchitecturesInstallIn64BitMode=x64
MinVersion=6.1.7601

; Здесь указываем данные, которые будут добавлены в свойства установщика...
VersionInfoVersion={#VERSION}
VersionInfoDescription=SRC Repair Setup
VersionInfoCopyright=(c) 2005-2019 EasyCoding Team. All rights reserved.
VersionInfoCompany=EasyCoding Team

[Messages]
BeveledLabel=EasyCoding Team

[CustomMessages]
OptNetStatus=Optimizing MSIL binary...
OptNetUninstallStatus=Removing optimized MSIL binaries...
russian.OptNetStatus=Идёт оптимизация MSIL приложения...
russian.OptNetUninstallStatus=Идёт удаление машинных сборок MSIL...

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"; InfoBeforeFile: "readme_en.rtf"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"; InfoBeforeFile: "readme_ru.rtf"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
; Копируем файл со списком поддерживаемых игр и их параметрами...
Source: "..\..\srcrepair\bin\Release\games.xml"; DestDir: "{app}"; Flags: ignoreversion

; Копируем файл с базой данных HUD...
Source: "..\..\srcrepair\bin\Release\huds.xml"; DestDir: "{app}"; Flags: ignoreversion

; Копируем файл с базой данных FPS-конфигов...
Source: "..\..\srcrepair\bin\Release\configs.xml"; DestDir: "{app}"; Flags: ignoreversion

; Копируем динамические библиотеки сторонних модулей...
Source: "..\..\srcrepair\bin\Release\DotNetZip.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\..\srcrepair\bin\Release\NLog.dll"; DestDir: "{app}"; Flags: ignoreversion

; Устанавливаем бинарники приложения...
Source: "..\..\srcrepair\bin\Release\srcrepair.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\..\srcrepair\bin\Release\srcrepair.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\..\srcrepair\bin\Release\corelib.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\..\srcrepair\bin\Release\corelib.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\..\srcrepair\bin\Release\ru\*"; DestDir: "{app}\ru\"; Flags: ignoreversion recursesubdirs createallsubdirs

; Копируем файлs стандартных настроек программы...
Source: "..\..\srcrepair\bin\Release\srcrepair.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\..\srcrepair\bin\Release\NLog.config"; DestDir: "{app}"; Flags: ignoreversion

; Устанавливаем остальные файлы...
Source: "..\..\srcrepair\bin\Release\cfgs\*"; DestDir: "{app}\cfgs\"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "..\..\srcrepair\bin\Release\help\*"; DestDir: "{app}\help\"; Flags: ignoreversion recursesubdirs createallsubdirs

; Устанавливаем файлы с отсоединёнными подписями для официальных сборок...
#ifdef _RELEASE
Source: "..\..\srcrepair\bin\Release\*.sig"; DestDir: "{app}"; Flags: ignoreversion
#endif

[Icons]
; Создаём ярлык для приложения...
Name: "{group}\SRC Repair"; Filename: "{app}\srcrepair.exe"

; Создаём "ярлык Интернета", указывающий на официальный сайт программы...
Name: "{group}\{cm:ProgramOnTheWeb,SRC Repair}"; Filename: "https://www.easycoding.org/projects/srcrepair"

; Создаём ярлык на рабочем столе (если выбрано)...
Name: "{userdesktop}\SRC Repair"; Filename: "{app}\srcrepair.exe"; Tasks: desktopicon

; Создаём ярлык на панели быстрого запуска (если выбрано)...
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\SRC Repair"; Filename: "{app}\srcrepair.exe"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\srcrepair.exe"; Description: "{cm:LaunchProgram,SRC Repair}"; Flags: nowait postinstall skipifsilent
Filename: "{dotnet40}\ngen.exe"; Parameters: "install ""{app}\srcrepair.exe"""; StatusMsg: {cm:OptNetStatus}; Flags: runhidden; Check: IsAdminLoggedOn()
Filename: "{dotnet40}\ngen.exe"; Parameters: "install ""{app}\corelib.dll"""; StatusMsg: {cm:OptNetStatus}; Flags: runhidden; Check: IsAdminLoggedOn()
Filename: "{dotnet40}\ngen.exe"; Parameters: "install ""{app}\DotNetZip.dll"""; StatusMsg: {cm:OptNetStatus}; Flags: runhidden; Check: IsAdminLoggedOn()
Filename: "{dotnet40}\ngen.exe"; Parameters: "install ""{app}\NLog.dll"""; StatusMsg: {cm:OptNetStatus}; Flags: runhidden; Check: IsAdminLoggedOn()

[UninstallRun]
Filename: "{dotnet40}\ngen.exe"; Parameters: "uninstall ""{app}\srcrepair.exe"""; StatusMsg: {cm:OptNetUninstallStatus}; Flags: runhidden; Check: IsAdminLoggedOn()
Filename: "{dotnet40}\ngen.exe"; Parameters: "uninstall ""{app}\corelib.dll"""; StatusMsg: {cm:OptNetUninstallStatus}; Flags: runhidden; Check: IsAdminLoggedOn()
Filename: "{dotnet40}\ngen.exe"; Parameters: "uninstall ""{app}\DotNetZip.dll"""; StatusMsg: {cm:OptNetUninstallStatus}; Flags: runhidden; Check: IsAdminLoggedOn()
Filename: "{dotnet40}\ngen.exe"; Parameters: "uninstall ""{app}\NLog.dll"""; StatusMsg: {cm:OptNetUninstallStatus}; Flags: runhidden; Check: IsAdminLoggedOn()

[Code]
function GetDefRoot(Param: String): String;
begin
  if not IsAdminLoggedOn then
    Result := ExpandConstant('{localappdata}')
  else
    Result := ExpandConstant('{pf}')
end;
