using System.ComponentModel;

namespace Tweak
{
    partial class PromptForm
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Button buttonOk;
            System.Windows.Forms.Button buttonAbort;
            this.textBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            buttonOk = new System.Windows.Forms.Button();
            buttonAbort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(48, 13);
            label1.TabIndex = 1;
            label1.Text = "Пароль:";
            // 
            // buttonOk
            // 
            buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            buttonOk.Location = new System.Drawing.Point(269, 38);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new System.Drawing.Size(75, 23);
            buttonOk.TabIndex = 1;
            buttonOk.Text = "Ок";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonAbort
            // 
            buttonAbort.DialogResult = System.Windows.Forms.DialogResult.Abort;
            buttonAbort.Location = new System.Drawing.Point(188, 38);
            buttonAbort.Name = "buttonAbort";
            buttonAbort.Size = new System.Drawing.Size(75, 23);
            buttonAbort.TabIndex = 2;
            buttonAbort.Text = "Отмена";
            buttonAbort.UseVisualStyleBackColor = true;
            buttonAbort.Click += new System.EventHandler(this.buttonAbort_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(67, 12);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(277, 20);
            this.textBox.TabIndex = 0;
            // 
            // PromptForm
            // 
            this.AcceptButton = buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = buttonAbort;
            this.ClientSize = new System.Drawing.Size(356, 73);
            this.ControlBox = false;
            this.Controls.Add(buttonAbort);
            this.Controls.Add(buttonOk);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PromptForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Введите пароль";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox textBox;

        #endregion
    }
}