using System.ComponentModel;

namespace Tweak
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.DesctopGroupBox = new System.Windows.Forms.GroupBox();
            this.DesktopReadonlyCheckBox = new System.Windows.Forms.CheckBox();
            this.DesktopNothing = new System.Windows.Forms.RadioButton();
            this.DesktopMoveAll = new System.Windows.Forms.RadioButton();
            this.DesktopDeleteOldAndMove = new System.Windows.Forms.RadioButton();
            this.DesktopDeleteOld = new System.Windows.Forms.RadioButton();
            this.DesktopDeleteAll = new System.Windows.Forms.RadioButton();
            this.DownloadsGroupBox = new System.Windows.Forms.GroupBox();
            this.DownloadsReadonlyCheckBox = new System.Windows.Forms.CheckBox();
            this.DownloadsNothing = new System.Windows.Forms.RadioButton();
            this.DownloadsDeleteOld = new System.Windows.Forms.RadioButton();
            this.DownloadsDeleteAll = new System.Windows.Forms.RadioButton();
            this.OthersGroupBox = new System.Windows.Forms.GroupBox();
            this.OthersReadonlyCheckBox = new System.Windows.Forms.CheckBox();
            this.OthersNothing = new System.Windows.Forms.RadioButton();
            this.OthersDeleteOld = new System.Windows.Forms.RadioButton();
            this.OthersDeleteAll = new System.Windows.Forms.RadioButton();
            this.ThemeGroupBox = new System.Windows.Forms.GroupBox();
            this.ThemeLookPictureCheckBox = new System.Windows.Forms.CheckBox();
            this.ThemeLookCheckBox = new System.Windows.Forms.CheckBox();
            this.ThemeNothing = new System.Windows.Forms.RadioButton();
            this.ThemeSetDefault = new System.Windows.Forms.RadioButton();
            this.TempGroupBox = new System.Windows.Forms.GroupBox();
            this.TempDeleteHistoryCheckBox = new System.Windows.Forms.CheckBox();
            this.TempDeleteCheckBox = new System.Windows.Forms.CheckBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.DailyCheckBox = new System.Windows.Forms.CheckBox();
            this.OpenProgramsButton = new System.Windows.Forms.Button();
            this.ProtectCheckBox = new System.Windows.Forms.CheckBox();
            this.DesctopGroupBox.SuspendLayout();
            this.DownloadsGroupBox.SuspendLayout();
            this.OthersGroupBox.SuspendLayout();
            this.ThemeGroupBox.SuspendLayout();
            this.TempGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DesctopGroupBox
            // 
            this.DesctopGroupBox.AutoSize = true;
            this.DesctopGroupBox.Controls.Add(this.DesktopReadonlyCheckBox);
            this.DesctopGroupBox.Controls.Add(this.DesktopNothing);
            this.DesctopGroupBox.Controls.Add(this.DesktopMoveAll);
            this.DesctopGroupBox.Controls.Add(this.DesktopDeleteOldAndMove);
            this.DesctopGroupBox.Controls.Add(this.DesktopDeleteOld);
            this.DesctopGroupBox.Controls.Add(this.DesktopDeleteAll);
            this.DesctopGroupBox.Location = new System.Drawing.Point(12, 12);
            this.DesctopGroupBox.Name = "DesctopGroupBox";
            this.DesctopGroupBox.Size = new System.Drawing.Size(445, 170);
            this.DesctopGroupBox.TabIndex = 0;
            this.DesctopGroupBox.TabStop = false;
            this.DesctopGroupBox.Text = "Рабочий стол";
            // 
            // DesktopReadonlyCheckBox
            // 
            this.DesktopReadonlyCheckBox.AutoSize = true;
            this.DesktopReadonlyCheckBox.Location = new System.Drawing.Point(6, 134);
            this.DesktopReadonlyCheckBox.Name = "DesktopReadonlyCheckBox";
            this.DesktopReadonlyCheckBox.Size = new System.Drawing.Size(264, 17);
            this.DesktopReadonlyCheckBox.TabIndex = 5;
            this.DesktopReadonlyCheckBox.Text = "Запретить создание файлов на рабочем столе";
            this.DesktopReadonlyCheckBox.UseVisualStyleBackColor = true;
            this.DesktopReadonlyCheckBox.CheckedChanged += new System.EventHandler(this.DesktopReadonlyCheckBox_CheckedChanged);
            // 
            // DesktopNothing
            // 
            this.DesktopNothing.AutoSize = true;
            this.DesktopNothing.Location = new System.Drawing.Point(6, 111);
            this.DesktopNothing.Name = "DesktopNothing";
            this.DesktopNothing.Size = new System.Drawing.Size(153, 17);
            this.DesktopNothing.TabIndex = 4;
            this.DesktopNothing.TabStop = true;
            this.DesktopNothing.Tag = "4";
            this.DesktopNothing.Text = "Оставить без изменения";
            this.DesktopNothing.UseVisualStyleBackColor = true;
            this.DesktopNothing.CheckedChanged += new System.EventHandler(this.Desktop_CheckedChanged);
            // 
            // DesktopMoveAll
            // 
            this.DesktopMoveAll.AutoSize = true;
            this.DesktopMoveAll.Location = new System.Drawing.Point(6, 88);
            this.DesktopMoveAll.Name = "DesktopMoveAll";
            this.DesktopMoveAll.Size = new System.Drawing.Size(214, 17);
            this.DesktopMoveAll.TabIndex = 3;
            this.DesktopMoveAll.TabStop = true;
            this.DesktopMoveAll.Tag = "3";
            this.DesktopMoveAll.Text = "Перенести все в папку \"Документы\"";
            this.DesktopMoveAll.UseVisualStyleBackColor = true;
            this.DesktopMoveAll.CheckedChanged += new System.EventHandler(this.Desktop_CheckedChanged);
            // 
            // DesktopDeleteOldAndMove
            // 
            this.DesktopDeleteOldAndMove.AutoSize = true;
            this.DesktopDeleteOldAndMove.Location = new System.Drawing.Point(6, 65);
            this.DesktopDeleteOldAndMove.Name = "DesktopDeleteOldAndMove";
            this.DesktopDeleteOldAndMove.Size = new System.Drawing.Size(433, 17);
            this.DesktopDeleteOldAndMove.TabIndex = 2;
            this.DesktopDeleteOldAndMove.TabStop = true;
            this.DesktopDeleteOldAndMove.Tag = "2";
            this.DesktopDeleteOldAndMove.Text = "Удалить все файлы, старше 7 дней, остальное перенести в папку \"Документы\"";
            this.DesktopDeleteOldAndMove.UseVisualStyleBackColor = true;
            this.DesktopDeleteOldAndMove.CheckedChanged += new System.EventHandler(this.Desktop_CheckedChanged);
            // 
            // DesktopDeleteOld
            // 
            this.DesktopDeleteOld.AutoSize = true;
            this.DesktopDeleteOld.Location = new System.Drawing.Point(6, 42);
            this.DesktopDeleteOld.Name = "DesktopDeleteOld";
            this.DesktopDeleteOld.Size = new System.Drawing.Size(205, 17);
            this.DesktopDeleteOld.TabIndex = 1;
            this.DesktopDeleteOld.TabStop = true;
            this.DesktopDeleteOld.Tag = "1";
            this.DesktopDeleteOld.Text = "Удалить все файлы, старше 7 дней";
            this.DesktopDeleteOld.UseVisualStyleBackColor = true;
            this.DesktopDeleteOld.CheckedChanged += new System.EventHandler(this.Desktop_CheckedChanged);
            // 
            // DesktopDeleteAll
            // 
            this.DesktopDeleteAll.AutoSize = true;
            this.DesktopDeleteAll.Location = new System.Drawing.Point(6, 19);
            this.DesktopDeleteAll.Name = "DesktopDeleteAll";
            this.DesktopDeleteAll.Size = new System.Drawing.Size(126, 17);
            this.DesktopDeleteAll.TabIndex = 0;
            this.DesktopDeleteAll.TabStop = true;
            this.DesktopDeleteAll.Tag = "0";
            this.DesktopDeleteAll.Text = "Удалить все файлы";
            this.DesktopDeleteAll.UseVisualStyleBackColor = true;
            this.DesktopDeleteAll.CheckedChanged += new System.EventHandler(this.Desktop_CheckedChanged);
            // 
            // DownloadsGroupBox
            // 
            this.DownloadsGroupBox.AutoSize = true;
            this.DownloadsGroupBox.Controls.Add(this.DownloadsReadonlyCheckBox);
            this.DownloadsGroupBox.Controls.Add(this.DownloadsNothing);
            this.DownloadsGroupBox.Controls.Add(this.DownloadsDeleteOld);
            this.DownloadsGroupBox.Controls.Add(this.DownloadsDeleteAll);
            this.DownloadsGroupBox.Location = new System.Drawing.Point(12, 188);
            this.DownloadsGroupBox.Name = "DownloadsGroupBox";
            this.DownloadsGroupBox.Size = new System.Drawing.Size(445, 124);
            this.DownloadsGroupBox.TabIndex = 1;
            this.DownloadsGroupBox.TabStop = false;
            this.DownloadsGroupBox.Text = "Загрузки";
            // 
            // DownloadsReadonlyCheckBox
            // 
            this.DownloadsReadonlyCheckBox.AutoSize = true;
            this.DownloadsReadonlyCheckBox.Location = new System.Drawing.Point(6, 88);
            this.DownloadsReadonlyCheckBox.Name = "DownloadsReadonlyCheckBox";
            this.DownloadsReadonlyCheckBox.Size = new System.Drawing.Size(273, 17);
            this.DownloadsReadonlyCheckBox.TabIndex = 3;
            this.DownloadsReadonlyCheckBox.Text = "Запретить создание файлов в папке \"Загрузки\"";
            this.DownloadsReadonlyCheckBox.UseVisualStyleBackColor = true;
            this.DownloadsReadonlyCheckBox.CheckedChanged += new System.EventHandler(this.DownloadsReadonlyCheckBox_CheckedChanged);
            // 
            // DownloadsNothing
            // 
            this.DownloadsNothing.AutoSize = true;
            this.DownloadsNothing.Location = new System.Drawing.Point(6, 65);
            this.DownloadsNothing.Name = "DownloadsNothing";
            this.DownloadsNothing.Size = new System.Drawing.Size(153, 17);
            this.DownloadsNothing.TabIndex = 2;
            this.DownloadsNothing.TabStop = true;
            this.DownloadsNothing.Tag = "2";
            this.DownloadsNothing.Text = "Оставить без изменения";
            this.DownloadsNothing.UseVisualStyleBackColor = true;
            this.DownloadsNothing.CheckedChanged += new System.EventHandler(this.Download_CheckedChanged);
            // 
            // DownloadsDeleteOld
            // 
            this.DownloadsDeleteOld.AutoSize = true;
            this.DownloadsDeleteOld.Location = new System.Drawing.Point(6, 42);
            this.DownloadsDeleteOld.Name = "DownloadsDeleteOld";
            this.DownloadsDeleteOld.Size = new System.Drawing.Size(205, 17);
            this.DownloadsDeleteOld.TabIndex = 1;
            this.DownloadsDeleteOld.TabStop = true;
            this.DownloadsDeleteOld.Tag = "1";
            this.DownloadsDeleteOld.Text = "Удалить все файлы, старше 7 дней";
            this.DownloadsDeleteOld.UseVisualStyleBackColor = true;
            this.DownloadsDeleteOld.CheckedChanged += new System.EventHandler(this.Download_CheckedChanged);
            // 
            // DownloadsDeleteAll
            // 
            this.DownloadsDeleteAll.AutoSize = true;
            this.DownloadsDeleteAll.Location = new System.Drawing.Point(6, 19);
            this.DownloadsDeleteAll.Name = "DownloadsDeleteAll";
            this.DownloadsDeleteAll.Size = new System.Drawing.Size(126, 17);
            this.DownloadsDeleteAll.TabIndex = 0;
            this.DownloadsDeleteAll.TabStop = true;
            this.DownloadsDeleteAll.Tag = "0";
            this.DownloadsDeleteAll.Text = "Удалить все файлы";
            this.DownloadsDeleteAll.UseVisualStyleBackColor = true;
            this.DownloadsDeleteAll.CheckedChanged += new System.EventHandler(this.Download_CheckedChanged);
            // 
            // OthersGroupBox
            // 
            this.OthersGroupBox.AutoSize = true;
            this.OthersGroupBox.Controls.Add(this.OthersReadonlyCheckBox);
            this.OthersGroupBox.Controls.Add(this.OthersNothing);
            this.OthersGroupBox.Controls.Add(this.OthersDeleteOld);
            this.OthersGroupBox.Controls.Add(this.OthersDeleteAll);
            this.OthersGroupBox.Location = new System.Drawing.Point(12, 318);
            this.OthersGroupBox.Name = "OthersGroupBox";
            this.OthersGroupBox.Size = new System.Drawing.Size(445, 124);
            this.OthersGroupBox.TabIndex = 2;
            this.OthersGroupBox.TabStop = false;
            this.OthersGroupBox.Text = "Папки Документы, Изображения, Музыка";
            // 
            // OthersReadonlyCheckBox
            // 
            this.OthersReadonlyCheckBox.AutoSize = true;
            this.OthersReadonlyCheckBox.Location = new System.Drawing.Point(6, 88);
            this.OthersReadonlyCheckBox.Name = "OthersReadonlyCheckBox";
            this.OthersReadonlyCheckBox.Size = new System.Drawing.Size(292, 17);
            this.OthersReadonlyCheckBox.TabIndex = 3;
            this.OthersReadonlyCheckBox.Text = "Запретить создание файлов в папках пользователя";
            this.OthersReadonlyCheckBox.UseVisualStyleBackColor = true;
            this.OthersReadonlyCheckBox.CheckedChanged += new System.EventHandler(this.OthersReadonlyCheckBox_CheckedChanged);
            // 
            // OthersNothing
            // 
            this.OthersNothing.AutoSize = true;
            this.OthersNothing.Location = new System.Drawing.Point(6, 65);
            this.OthersNothing.Name = "OthersNothing";
            this.OthersNothing.Size = new System.Drawing.Size(153, 17);
            this.OthersNothing.TabIndex = 2;
            this.OthersNothing.TabStop = true;
            this.OthersNothing.Tag = "2";
            this.OthersNothing.Text = "Оставить без изменения";
            this.OthersNothing.UseVisualStyleBackColor = true;
            this.OthersNothing.CheckedChanged += new System.EventHandler(this.Others_CheckedChanged);
            // 
            // OthersDeleteOld
            // 
            this.OthersDeleteOld.AutoSize = true;
            this.OthersDeleteOld.Location = new System.Drawing.Point(6, 42);
            this.OthersDeleteOld.Name = "OthersDeleteOld";
            this.OthersDeleteOld.Size = new System.Drawing.Size(211, 17);
            this.OthersDeleteOld.TabIndex = 1;
            this.OthersDeleteOld.TabStop = true;
            this.OthersDeleteOld.Tag = "1";
            this.OthersDeleteOld.Text = "Удалить все файлы, старше 14 дней";
            this.OthersDeleteOld.UseVisualStyleBackColor = true;
            this.OthersDeleteOld.CheckedChanged += new System.EventHandler(this.Others_CheckedChanged);
            // 
            // OthersDeleteAll
            // 
            this.OthersDeleteAll.AutoSize = true;
            this.OthersDeleteAll.Location = new System.Drawing.Point(6, 19);
            this.OthersDeleteAll.Name = "OthersDeleteAll";
            this.OthersDeleteAll.Size = new System.Drawing.Size(126, 17);
            this.OthersDeleteAll.TabIndex = 0;
            this.OthersDeleteAll.TabStop = true;
            this.OthersDeleteAll.Tag = "0";
            this.OthersDeleteAll.Text = "Удалить все файлы";
            this.OthersDeleteAll.UseVisualStyleBackColor = true;
            this.OthersDeleteAll.CheckedChanged += new System.EventHandler(this.Others_CheckedChanged);
            // 
            // ThemeGroupBox
            // 
            this.ThemeGroupBox.AutoSize = true;
            this.ThemeGroupBox.Controls.Add(this.ThemeLookPictureCheckBox);
            this.ThemeGroupBox.Controls.Add(this.ThemeLookCheckBox);
            this.ThemeGroupBox.Controls.Add(this.ThemeNothing);
            this.ThemeGroupBox.Controls.Add(this.ThemeSetDefault);
            this.ThemeGroupBox.Location = new System.Drawing.Point(463, 12);
            this.ThemeGroupBox.Name = "ThemeGroupBox";
            this.ThemeGroupBox.Size = new System.Drawing.Size(295, 124);
            this.ThemeGroupBox.TabIndex = 3;
            this.ThemeGroupBox.TabStop = false;
            this.ThemeGroupBox.Text = "Оформление";
            // 
            // ThemeLookPictureCheckBox
            // 
            this.ThemeLookPictureCheckBox.AutoSize = true;
            this.ThemeLookPictureCheckBox.Location = new System.Drawing.Point(6, 88);
            this.ThemeLookPictureCheckBox.Name = "ThemeLookPictureCheckBox";
            this.ThemeLookPictureCheckBox.Size = new System.Drawing.Size(283, 17);
            this.ThemeLookPictureCheckBox.TabIndex = 3;
            this.ThemeLookPictureCheckBox.Text = "Запретить изменять изображение рабочего стола";
            this.ThemeLookPictureCheckBox.UseVisualStyleBackColor = true;
            this.ThemeLookPictureCheckBox.CheckedChanged += new System.EventHandler(this.ThemeLookPictureCheckBox_CheckedChanged);
            // 
            // ThemeLookCheckBox
            // 
            this.ThemeLookCheckBox.AutoSize = true;
            this.ThemeLookCheckBox.Location = new System.Drawing.Point(6, 65);
            this.ThemeLookCheckBox.Name = "ThemeLookCheckBox";
            this.ThemeLookCheckBox.Size = new System.Drawing.Size(225, 17);
            this.ThemeLookCheckBox.TabIndex = 2;
            this.ThemeLookCheckBox.Text = "Запретить изменять тему оформления";
            this.ThemeLookCheckBox.UseVisualStyleBackColor = true;
            this.ThemeLookCheckBox.CheckedChanged += new System.EventHandler(this.ThemeLookCheckBox_CheckedChanged);
            // 
            // ThemeNothing
            // 
            this.ThemeNothing.AutoSize = true;
            this.ThemeNothing.Location = new System.Drawing.Point(6, 42);
            this.ThemeNothing.Name = "ThemeNothing";
            this.ThemeNothing.Size = new System.Drawing.Size(153, 17);
            this.ThemeNothing.TabIndex = 1;
            this.ThemeNothing.TabStop = true;
            this.ThemeNothing.Tag = "1";
            this.ThemeNothing.Text = "Оставить без изменения";
            this.ThemeNothing.UseVisualStyleBackColor = true;
            this.ThemeNothing.CheckedChanged += new System.EventHandler(this.Theme_CheckedChanged);
            // 
            // ThemeSetDefault
            // 
            this.ThemeSetDefault.AutoSize = true;
            this.ThemeSetDefault.Location = new System.Drawing.Point(6, 19);
            this.ThemeSetDefault.Name = "ThemeSetDefault";
            this.ThemeSetDefault.Size = new System.Drawing.Size(247, 17);
            this.ThemeSetDefault.TabIndex = 0;
            this.ThemeSetDefault.TabStop = true;
            this.ThemeSetDefault.Tag = "0";
            this.ThemeSetDefault.Text = "Установить стандартную тему оформления";
            this.ThemeSetDefault.UseVisualStyleBackColor = true;
            this.ThemeSetDefault.CheckedChanged += new System.EventHandler(this.Theme_CheckedChanged);
            // 
            // TempGroupBox
            // 
            this.TempGroupBox.AutoSize = true;
            this.TempGroupBox.Controls.Add(this.TempDeleteHistoryCheckBox);
            this.TempGroupBox.Controls.Add(this.TempDeleteCheckBox);
            this.TempGroupBox.Location = new System.Drawing.Point(463, 142);
            this.TempGroupBox.Name = "TempGroupBox";
            this.TempGroupBox.Size = new System.Drawing.Size(295, 78);
            this.TempGroupBox.TabIndex = 4;
            this.TempGroupBox.TabStop = false;
            this.TempGroupBox.Text = "Обслуживание, временные файлы";
            // 
            // TempDeleteHistoryCheckBox
            // 
            this.TempDeleteHistoryCheckBox.AutoSize = true;
            this.TempDeleteHistoryCheckBox.Location = new System.Drawing.Point(6, 42);
            this.TempDeleteHistoryCheckBox.Name = "TempDeleteHistoryCheckBox";
            this.TempDeleteHistoryCheckBox.Size = new System.Drawing.Size(207, 17);
            this.TempDeleteHistoryCheckBox.TabIndex = 1;
            this.TempDeleteHistoryCheckBox.Text = "Удалить историю, пароли браузера";
            this.TempDeleteHistoryCheckBox.UseVisualStyleBackColor = true;
            this.TempDeleteHistoryCheckBox.CheckedChanged += new System.EventHandler(this.TempDeleteHistoryCheckBox_CheckedChanged);
            // 
            // TempDeleteCheckBox
            // 
            this.TempDeleteCheckBox.AutoSize = true;
            this.TempDeleteCheckBox.Location = new System.Drawing.Point(6, 19);
            this.TempDeleteCheckBox.Name = "TempDeleteCheckBox";
            this.TempDeleteCheckBox.Size = new System.Drawing.Size(167, 17);
            this.TempDeleteCheckBox.TabIndex = 0;
            this.TempDeleteCheckBox.Text = "Удалить временные файлы";
            this.TempDeleteCheckBox.UseVisualStyleBackColor = true;
            this.TempDeleteCheckBox.CheckedChanged += new System.EventHandler(this.TempDeleteCheckBox_CheckedChanged);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(463, 224);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(295, 46);
            this.ClearButton.TabIndex = 5;
            this.ClearButton.Text = "Выполнить очистку";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // DailyCheckBox
            // 
            this.DailyCheckBox.AutoSize = true;
            this.DailyCheckBox.Location = new System.Drawing.Point(463, 276);
            this.DailyCheckBox.Name = "DailyCheckBox";
            this.DailyCheckBox.Size = new System.Drawing.Size(183, 17);
            this.DailyCheckBox.TabIndex = 6;
            this.DailyCheckBox.Text = "Выполнять очистку ежедневно";
            this.DailyCheckBox.UseVisualStyleBackColor = true;
            this.DailyCheckBox.CheckedChanged += new System.EventHandler(this.DailyCheckBox_CheckedChanged);
            // 
            // OpenProgramsButton
            // 
            this.OpenProgramsButton.Location = new System.Drawing.Point(463, 322);
            this.OpenProgramsButton.Name = "OpenProgramsButton";
            this.OpenProgramsButton.Size = new System.Drawing.Size(295, 23);
            this.OpenProgramsButton.TabIndex = 8;
            this.OpenProgramsButton.Text = "Открыть \"Программы и компоненты\"";
            this.OpenProgramsButton.UseVisualStyleBackColor = true;
            this.OpenProgramsButton.Click += new System.EventHandler(this.OpenProgramsButton_Click);
            // 
            // ProtectCheckBox
            // 
            this.ProtectCheckBox.AutoSize = true;
            this.ProtectCheckBox.Location = new System.Drawing.Point(463, 299);
            this.ProtectCheckBox.Name = "ProtectCheckBox";
            this.ProtectCheckBox.Size = new System.Drawing.Size(123, 17);
            this.ProtectCheckBox.TabIndex = 7;
            this.ProtectCheckBox.Text = "Защитить паролем";
            this.ProtectCheckBox.UseVisualStyleBackColor = true;
            this.ProtectCheckBox.CheckedChanged += new System.EventHandler(this.ProtectCheckBox_CheckedChanged);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 454);
            this.Controls.Add(this.ProtectCheckBox);
            this.Controls.Add(this.OpenProgramsButton);
            this.Controls.Add(this.DailyCheckBox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.TempGroupBox);
            this.Controls.Add(this.ThemeGroupBox);
            this.Controls.Add(this.OthersGroupBox);
            this.Controls.Add(this.DownloadsGroupBox);
            this.Controls.Add(this.DesctopGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Контроль пользовательских данных";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConfigForm_FormClosed);
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.DesctopGroupBox.ResumeLayout(false);
            this.DesctopGroupBox.PerformLayout();
            this.DownloadsGroupBox.ResumeLayout(false);
            this.DownloadsGroupBox.PerformLayout();
            this.OthersGroupBox.ResumeLayout(false);
            this.OthersGroupBox.PerformLayout();
            this.ThemeGroupBox.ResumeLayout(false);
            this.ThemeGroupBox.PerformLayout();
            this.TempGroupBox.ResumeLayout(false);
            this.TempGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.CheckBox DailyCheckBox;
        private System.Windows.Forms.GroupBox DesctopGroupBox;
        private System.Windows.Forms.RadioButton DesktopDeleteAll;
        private System.Windows.Forms.RadioButton DesktopDeleteOld;
        private System.Windows.Forms.RadioButton DesktopDeleteOldAndMove;
        private System.Windows.Forms.RadioButton DesktopMoveAll;
        private System.Windows.Forms.RadioButton DesktopNothing;
        private System.Windows.Forms.CheckBox DesktopReadonlyCheckBox;
        private System.Windows.Forms.RadioButton DownloadsDeleteAll;
        private System.Windows.Forms.RadioButton DownloadsDeleteOld;
        private System.Windows.Forms.GroupBox DownloadsGroupBox;
        private System.Windows.Forms.RadioButton DownloadsNothing;
        private System.Windows.Forms.CheckBox DownloadsReadonlyCheckBox;
        private System.Windows.Forms.Button OpenProgramsButton;
        private System.Windows.Forms.RadioButton OthersDeleteAll;
        private System.Windows.Forms.RadioButton OthersDeleteOld;
        private System.Windows.Forms.GroupBox OthersGroupBox;
        private System.Windows.Forms.RadioButton OthersNothing;
        private System.Windows.Forms.CheckBox OthersReadonlyCheckBox;
        private System.Windows.Forms.CheckBox ProtectCheckBox;
        private System.Windows.Forms.CheckBox TempDeleteCheckBox;
        private System.Windows.Forms.CheckBox TempDeleteHistoryCheckBox;
        private System.Windows.Forms.GroupBox TempGroupBox;
        private System.Windows.Forms.GroupBox ThemeGroupBox;
        private System.Windows.Forms.CheckBox ThemeLookCheckBox;
        private System.Windows.Forms.CheckBox ThemeLookPictureCheckBox;
        private System.Windows.Forms.RadioButton ThemeNothing;
        private System.Windows.Forms.RadioButton ThemeSetDefault;

        #endregion
    }
}