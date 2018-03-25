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
            this.text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // text
            // 
            this.text.Location = new System.Drawing.Point(12, 9);
            this.text.MaximumSize = new System.Drawing.Size(500, 500);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(460, 465);
            this.text.TabIndex = 0;
            this.text.Text = "label1";
            // 
            // ChatViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(484, 511);
            this.Controls.Add(this.text);
            this.KeyPreview = true;
            this.Name = "ChatViewer";
            this.Text = "ChatViewer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label text;
    }
}

