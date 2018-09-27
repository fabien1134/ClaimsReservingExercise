namespace ClaimsReservingExercise.Forms
{
    partial class InputContentModifier
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
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.btnUpdateContent = new System.Windows.Forms.Button();
            this.rtInputContent = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlFooter.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(441, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.statusStrip1);
            this.pnlFooter.Controls.Add(this.btnUpdateContent);
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 374);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(800, 76);
            this.pnlFooter.TabIndex = 1;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.rtInputContent);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(800, 374);
            this.pnlBody.TabIndex = 2;
            // 
            // btnUpdateContent
            // 
            this.btnUpdateContent.Location = new System.Drawing.Point(315, 6);
            this.btnUpdateContent.Name = "btnUpdateContent";
            this.btnUpdateContent.Size = new System.Drawing.Size(90, 23);
            this.btnUpdateContent.TabIndex = 1;
            this.btnUpdateContent.Text = "Update Content";
            this.btnUpdateContent.UseVisualStyleBackColor = true;
            this.btnUpdateContent.Click += new System.EventHandler(this.btnUpdateContent_Click);
            // 
            // rtInputContent
            // 
            this.rtInputContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtInputContent.Location = new System.Drawing.Point(0, 0);
            this.rtInputContent.Name = "rtInputContent";
            this.rtInputContent.Size = new System.Drawing.Size(800, 374);
            this.rtInputContent.TabIndex = 0;
            this.rtInputContent.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 54);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslMessage
            // 
            this.tsslMessage.Name = "tsslMessage";
            this.tsslMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // InputContentModifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Name = "InputContentModifier";
            this.Text = "InputContentModifier";
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnUpdateContent;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.RichTextBox rtInputContent;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslMessage;
    }
}