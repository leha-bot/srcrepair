﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace srcrepair {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class AppStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AppStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("srcrepair.AppStrings", typeof(AppStrings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to en.
        /// </summary>
        internal static string AppLangPrefix {
            get {
                return ResourceManager.GetString("AppLangPrefix", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attention! The program is not started from an account with administrator privileges, so some features are disabled. To access them, then restart it as root!.
        /// </summary>
        internal static string AppLaunchedNotAdmin {
            get {
                return ResourceManager.GetString("AppLaunchedNotAdmin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occurred while creating the backup. Backup has been created!.
        /// </summary>
        internal static string BackUpCreationFailed {
            get {
                return ResourceManager.GetString("BackUpCreationFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Save the configuration file?.
        /// </summary>
        internal static string CE_CfgSV {
            get {
                return ResourceManager.GetString("CE_CfgSV", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attention! When saving a file error occurred. File was not saved!.
        /// </summary>
        internal static string CE_CfgSVVEx {
            get {
                return ResourceManager.GetString("CE_CfgSVVEx", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create a backup file.
        /// </summary>
        internal static string CE_CreateBackUp {
            get {
                return ResourceManager.GetString("CE_CreateBackUp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attention! When you try to open the file the error occurred. The file may open correctly. Please report it to our bugtracker (Help - Report an error in the program)..
        /// </summary>
        internal static string CE_ExceptionDetected {
            get {
                return ResourceManager.GetString("CE_ExceptionDetected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can not read the contents of the config, as file not found!.
        /// </summary>
        internal static string CE_OpenFailed {
            get {
                return ResourceManager.GetString("CE_OpenFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attention! It is not recommended to edit this file, because this may lead to unpredictable consequences. Edit it at your own risk..
        /// </summary>
        internal static string CE_RestConfigOpenWarn {
            get {
                return ResourceManager.GetString("CE_RestConfigOpenWarn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A critical error: can not install the selected config!.
        /// </summary>
        internal static string FP_InstallFailed {
            get {
                return ResourceManager.GetString("FP_InstallFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attention! Setting FPS-config reduce all graphics settings to the absolute minimum that will lead to significant deterioration of the quality of game graphics and game performance increase. Are you sure you want to set the FPS-config?.
        /// </summary>
        internal static string FP_InstallQuestion {
            get {
                return ResourceManager.GetString("FP_InstallQuestion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Config has been successfully installed!.
        /// </summary>
        internal static string FP_InstallSuccessful {
            get {
                return ResourceManager.GetString("FP_InstallSuccessful", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attention! For the selected game we do not have FPS-config, so this page will be disabled!.
        /// </summary>
        internal static string FP_NoCfgGame {
            get {
                return ResourceManager.GetString("FP_NoCfgGame", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unfortunately, the description of the chosen config is not available. We apologize for any inconvenience..
        /// </summary>
        internal static string FP_NoDescr {
            get {
                return ResourceManager.GetString("FP_NoDescr", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Вы не выбрали FPS-конфиг из списка. Выберите конфиг и повторите попытку!.
        /// </summary>
        internal static string FP_NothingSelected {
            get {
                return ResourceManager.GetString("FP_NothingSelected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occurred while removing the installed config!.
        /// </summary>
        internal static string FP_RemoveFailed {
            get {
                return ResourceManager.GetString("FP_RemoveFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Needless to delete: FPS-config for the current game is not installed!.
        /// </summary>
        internal static string FP_RemoveNotExists {
            get {
                return ResourceManager.GetString("FP_RemoveNotExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to delete installed config?.
        /// </summary>
        internal static string FP_RemoveQuestion {
            get {
                return ResourceManager.GetString("FP_RemoveQuestion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Installed FPS-config has been successfully deleted!.
        /// </summary>
        internal static string FP_RemoveSuccessful {
            get {
                return ResourceManager.GetString("FP_RemoveSuccessful", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select the config file from the list above!.
        /// </summary>
        internal static string FP_SelectFromList {
            get {
                return ResourceManager.GetString("FP_SelectFromList", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Close application? Any unsaved changes will be lost!.
        /// </summary>
        internal static string FrmCloseQuery {
            get {
                return ResourceManager.GetString("FrmCloseQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Found an unhandled exception. Please inform the developers email: vitaly@easycoding.org..
        /// </summary>
        internal static string GeneralErrorDetected {
            get {
                return ResourceManager.GetString("GeneralErrorDetected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enable DirectX 8 mode rendering? This will significantly increase the performance of the game..
        /// </summary>
        internal static string GT_DxLevelMsg {
            get {
                return ResourceManager.GetString("GT_DxLevelMsg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attention! An installed FPS-config detected, so the settings from this page except the DirectX mode will be ignored by the game until you remove this config..
        /// </summary>
        internal static string GT_FPSCfgDetected {
            get {
                return ResourceManager.GetString("GT_FPSCfgDetected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do you really want to set the graphics settings to the recommended maximum? This will require a powerful computer!.
        /// </summary>
        internal static string GT_MaxPerfMsg {
            get {
                return ResourceManager.GetString("GT_MaxPerfMsg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do you really want to install all the video settings to minimum? This will increase the FPS, but worsen the graphics in the game..
        /// </summary>
        internal static string GT_MinPerfMsg {
            get {
                return ResourceManager.GetString("GT_MinPerfMsg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Done. Do not forget to adjust and save the changes in the settings!.
        /// </summary>
        internal static string GT_PerfSet {
            get {
                return ResourceManager.GetString("GT_PerfSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Save your changes?.
        /// </summary>
        internal static string GT_SaveMsg {
            get {
                return ResourceManager.GetString("GT_SaveMsg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Changes have been successfully saved!.
        /// </summary>
        internal static string GT_SaveSuccess {
            get {
                return ResourceManager.GetString("GT_SaveSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cancel.
        /// </summary>
        internal static string InputBoxCancelBtnName {
            get {
                return ResourceManager.GetString("InputBoxCancelBtnName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sorry, but this feature is not yet implemented!.
        /// </summary>
        internal static string NotImplementedYet {
            get {
                return ResourceManager.GetString("NotImplementedYet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Discovered the command line parameter, but not found its value, so ignore this option!.
        /// </summary>
        internal static string ParamError {
            get {
                return ResourceManager.GetString("ParamError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error occured while deleting files. Some files were not deleted!.
        /// </summary>
        internal static string PS_CleanupErr {
            get {
                return ResourceManager.GetString("PS_CleanupErr", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Clean {0}?.
        /// </summary>
        internal static string PS_CleanupExecuteQ {
            get {
                return ResourceManager.GetString("PS_CleanupExecuteQ", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cleanup was successfully completed!.
        /// </summary>
        internal static string PS_CleanupSuccess {
            get {
                return ResourceManager.GetString("PS_CleanupSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Perform the cleanup?.
        /// </summary>
        internal static string PS_ExecuteMSG {
            get {
                return ResourceManager.GetString("PS_ExecuteMSG", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You chose the wrong language Steam from the dropdown list, so we will use English!.
        /// </summary>
        internal static string PS_NoLangSelected {
            get {
                return ResourceManager.GetString("PS_NoLangSelected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You do not choose! Please select at least one of the options of cleaning and run the cleanup again!.
        /// </summary>
        internal static string PS_NothingSelected {
            get {
                return ResourceManager.GetString("PS_NothingSelected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Steam has been successfully terminated..
        /// </summary>
        internal static string PS_ProcessTerminated {
            get {
                return ResourceManager.GetString("PS_ProcessTerminated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cleanup completed successfully! Thank you for using the program. Now you can run Steam!.
        /// </summary>
        internal static string PS_SeqCompleted {
            get {
                return ResourceManager.GetString("PS_SeqCompleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to To work correctly, this programm needs {0} to be shut down. Proceed?.
        /// </summary>
        internal static string ST_KillMessage {
            get {
                return ResourceManager.GetString("ST_KillMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Steam login was successfully changed. Let&apos;s continue to work with the new one....
        /// </summary>
        internal static string StatusLoginChanged {
            get {
                return ResourceManager.GetString("StatusLoginChanged", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to All systems are working normally..
        /// </summary>
        internal static string StatusNormal {
            get {
                return ResourceManager.GetString("StatusNormal", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Opened file in Config Editor:.
        /// </summary>
        internal static string StatusOpenedFile {
            get {
                return ResourceManager.GetString("StatusOpenedFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please select game from the list!.
        /// </summary>
        internal static string StatusSApp {
            get {
                return ResourceManager.GetString("StatusSApp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please select your Steam login from the list!.
        /// </summary>
        internal static string StatusSLogin {
            get {
                return ResourceManager.GetString("StatusSLogin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You refused to enter your login Steam, so the work program is impossible. Restart this application later and enter the correct login!.
        /// </summary>
        internal static string SteamLoginCancel {
            get {
                return ResourceManager.GetString("SteamLoginCancel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please enter your Steam login:.
        /// </summary>
        internal static string SteamLoginEnterText {
            get {
                return ResourceManager.GetString("SteamLoginEnterText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter Steam login.
        /// </summary>
        internal static string SteamLoginEnterTitle {
            get {
                return ResourceManager.GetString("SteamLoginEnterTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attention! Source Repair was unable to get a list of active logins Steam, so you have to enter it manually..
        /// </summary>
        internal static string SteamLoginsNotDetected {
            get {
                return ResourceManager.GetString("SteamLoginsNotDetected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attention! On the way to Steam detected invalid characters: Russian, German, etc. letters, or Unicode characters. Steam and the games will not work correctly. Reinstall Steam folder, the path to which will contain only latin symbols..
        /// </summary>
        internal static string SteamNonASCIIDetected {
            get {
                return ResourceManager.GetString("SteamNonASCIIDetected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attention! On the way to Steam detected invalid characters. Steam and the games will not work correctly. Reinstall Steam to folder, the path to which will contain only latin symbols..
        /// </summary>
        internal static string SteamNonASCIISmall {
            get {
                return ResourceManager.GetString("SteamNonASCIISmall", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Disallowed characters detected!.
        /// </summary>
        internal static string SteamNonASCIITitle {
            get {
                return ResourceManager.GetString("SteamNonASCIITitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Registry keys related to Steam is not found. You do not need their cleaning. Click OK to exit the program!.
        /// </summary>
        internal static string SteamNotDetected {
            get {
                return ResourceManager.GetString("SteamNotDetected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You refused to enter the path to Steam, so the program will be terminated!.
        /// </summary>
        internal static string SteamPathCancel {
            get {
                return ResourceManager.GetString("SteamPathCancel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have entered the wrong path! The program will be terminated..
        /// </summary>
        internal static string SteamPathEnterErr {
            get {
                return ResourceManager.GetString("SteamPathEnterErr", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Specify the path to Steam:.
        /// </summary>
        internal static string SteamPathEnterText {
            get {
                return ResourceManager.GetString("SteamPathEnterText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Specify the path to Steam.
        /// </summary>
        internal static string SteamPathEnterTitle {
            get {
                return ResourceManager.GetString("SteamPathEnterTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Warning! Critical error occured: can not get the path to the Steam from the registry, so you&apos;ll have to manually specify the correct path!.
        /// </summary>
        internal static string SteamPathNotDetected {
            get {
                return ResourceManager.GetString("SteamPathNotDetected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unnamed.cfg.
        /// </summary>
        internal static string UnnamedFileName {
            get {
                return ResourceManager.GetString("UnnamedFileName", resourceCulture);
            }
        }
    }
}
