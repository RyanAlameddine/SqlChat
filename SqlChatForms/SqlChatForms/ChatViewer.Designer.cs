namespace SqlChatForms
{
    partial class ChatViewer
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
            this.TextBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextBox
            // 
            this.TextBox.AutoSize = true;
            this.TextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.TextBox.Location = new System.Drawing.Point(12, 9);
            this.TextBox.MaximumSize = new System.Drawing.Size(500, 500);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(0, 15);
            this.TextBox.TabIndex = 0;
            this.TextBox.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // ChatViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(484, 511);
            this.Controls.Add(this.TextBox);
            this.KeyPreview = true;
            this.Name = "ChatViewer";
            this.Text = "ChatViewer";
            this.Load += new System.EventHandler(this.ChatViewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TextBox;
    }
}

