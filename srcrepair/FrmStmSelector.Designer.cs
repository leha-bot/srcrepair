﻿namespace srcrepair
{
    partial class FrmStmSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStmSelector));
            this.SD_WMsg = new System.Windows.Forms.Label();
            this.SD_SteamSel = new System.Windows.Forms.ComboBox();
            this.ST_OK = new System.Windows.Forms.Button();
            this.ST_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SD_WMsg
            // 
            resources.ApplyResources(this.SD_WMsg, "SD_WMsg");
            this.SD_WMsg.Name = "SD_WMsg";
            // 
            // SD_SteamSel
            // 
            this.SD_SteamSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SD_SteamSel.FormattingEnabled = true;
            resources.ApplyResources(this.SD_SteamSel, "SD_SteamSel");
            this.SD_SteamSel.Name = "SD_SteamSel";
            // 
            // ST_OK
            // 
            resources.ApplyResources(this.ST_OK, "ST_OK");
            this.ST_OK.Name = "ST_OK";
            this.ST_OK.UseVisualStyleBackColor = true;
            // 
            // ST_Cancel
            // 
            resources.ApplyResources(this.ST_Cancel, "ST_Cancel");
            this.ST_Cancel.Name = "ST_Cancel";
            this.ST_Cancel.UseVisualStyleBackColor = true;
            // 
            // FrmStmSelector
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ST_Cancel);
            this.Controls.Add(this.ST_OK);
            this.Controls.Add(this.SD_SteamSel);
            this.Controls.Add(this.SD_WMsg);
            this.Name = "FrmStmSelector";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label SD_WMsg;
        private System.Windows.Forms.ComboBox SD_SteamSel;
        private System.Windows.Forms.Button ST_OK;
        private System.Windows.Forms.Button ST_Cancel;
    }
}