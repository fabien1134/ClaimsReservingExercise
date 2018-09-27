namespace ClaimsReservingExercise
{
    partial class frmClaimsReservingTool
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
            this.lblInputSelectionPrompt = new System.Windows.Forms.Label();
            this.btnLoadInputFile = new System.Windows.Forms.Button();
            this.btnViewEdit = new System.Windows.Forms.Button();
            this.gbInputOptions = new System.Windows.Forms.GroupBox();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tspbAppExecutionStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.tspbExecutionProgressStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnStopTest = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.gbResult = new System.Windows.Forms.GroupBox();
            this.rtResult = new System.Windows.Forms.RichTextBox();
            this.gbInputOptions.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.gbResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInputSelectionPrompt
            // 
            this.lblInputSelectionPrompt.AutoSize = true;
            this.lblInputSelectionPrompt.Location = new System.Drawing.Point(219, 16);
            this.lblInputSelectionPrompt.Name = "lblInputSelectionPrompt";
            this.lblInputSelectionPrompt.Size = new System.Drawing.Size(64, 13);
            this.lblInputSelectionPrompt.TabIndex = 0;
            this.lblInputSelectionPrompt.Text = "Select Input";
            // 
            // btnLoadInputFile
            // 
            this.btnLoadInputFile.Location = new System.Drawing.Point(182, 100);
            this.btnLoadInputFile.Name = "btnLoadInputFile";
            this.btnLoadInputFile.Size = new System.Drawing.Size(75, 23);
            this.btnLoadInputFile.TabIndex = 1;
            this.btnLoadInputFile.Text = "Load Input File";
            this.btnLoadInputFile.UseVisualStyleBackColor = true;
            this.btnLoadInputFile.Click += new System.EventHandler(this.btnLoadInputFile_Click);
            // 
            // btnViewEdit
            // 
            this.btnViewEdit.Location = new System.Drawing.Point(284, 100);
            this.btnViewEdit.Name = "btnViewEdit";
            this.btnViewEdit.Size = new System.Drawing.Size(75, 23);
            this.btnViewEdit.TabIndex = 2;
            this.btnViewEdit.Text = "View/Edit";
            this.btnViewEdit.UseVisualStyleBackColor = true;
            this.btnViewEdit.Click += new System.EventHandler(this.btnViewEdit_Click);
            // 
            // gbInputOptions
            // 
            this.gbInputOptions.Controls.Add(this.lblFilePath);
            this.gbInputOptions.Controls.Add(this.lblInputSelectionPrompt);
            this.gbInputOptions.Controls.Add(this.btnViewEdit);
            this.gbInputOptions.Controls.Add(this.btnLoadInputFile);
            this.gbInputOptions.Location = new System.Drawing.Point(12, 43);
            this.gbInputOptions.Name = "gbInputOptions";
            this.gbInputOptions.Size = new System.Drawing.Size(539, 128);
            this.gbInputOptions.TabIndex = 3;
            this.gbInputOptions.TabStop = false;
            this.gbInputOptions.Text = "Input Options";
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(6, 67);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(32, 13);
            this.lblFilePath.TabIndex = 3;
            this.lblFilePath.Text = "Path:";
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.statusStrip1);
            this.pnlFooter.Controls.Add(this.btnStopTest);
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Controls.Add(this.btnExecute);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 363);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(563, 100);
            this.pnlFooter.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspbAppExecutionStatus,
            this.tspbExecutionProgressStatus,
            this.tsslMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 78);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(563, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tspbAppExecutionStatus
            // 
            this.tspbAppExecutionStatus.Name = "tspbAppExecutionStatus";
            this.tspbAppExecutionStatus.Size = new System.Drawing.Size(100, 16);
            // 
            // tspbExecutionProgressStatus
            // 
            this.tspbExecutionProgressStatus.Name = "tspbExecutionProgressStatus";
            this.tspbExecutionProgressStatus.Size = new System.Drawing.Size(100, 16);
            // 
            // tsslMessage
            // 
            this.tsslMessage.Name = "tsslMessage";
            this.tsslMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // btnStopTest
            // 
            this.btnStopTest.Location = new System.Drawing.Point(296, 6);
            this.btnStopTest.Name = "btnStopTest";
            this.btnStopTest.Size = new System.Drawing.Size(75, 23);
            this.btnStopTest.TabIndex = 2;
            this.btnStopTest.Text = "Stop Test";
            this.btnStopTest.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(476, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(220, 6);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 0;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.gbResult);
            this.pnlBody.Controls.Add(this.gbInputOptions);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(563, 363);
            this.pnlBody.TabIndex = 5;
            // 
            // gbResult
            // 
            this.gbResult.Controls.Add(this.rtResult);
            this.gbResult.Location = new System.Drawing.Point(12, 177);
            this.gbResult.Name = "gbResult";
            this.gbResult.Size = new System.Drawing.Size(539, 173);
            this.gbResult.TabIndex = 4;
            this.gbResult.TabStop = false;
            this.gbResult.Text = "Result";
            // 
            // rtResult
            // 
            this.rtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtResult.Location = new System.Drawing.Point(3, 16);
            this.rtResult.Name = "rtResult";
            this.rtResult.Size = new System.Drawing.Size(533, 154);
            this.rtResult.TabIndex = 0;
            this.rtResult.Text = "";
            // 
            // frmClaimsReservingTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 463);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Name = "frmClaimsReservingTool";
            this.Text = "Claims Reserving Tool";
            this.Load += new System.EventHandler(this.frmClaimsReservingTool_Load);
            this.gbInputOptions.ResumeLayout(false);
            this.gbInputOptions.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.gbResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInputSelectionPrompt;
        private System.Windows.Forms.Button btnLoadInputFile;
        private System.Windows.Forms.Button btnViewEdit;
        private System.Windows.Forms.GroupBox gbInputOptions;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnStopTest;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar tspbAppExecutionStatus;
        private System.Windows.Forms.ToolStripProgressBar tspbExecutionProgressStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsslMessage;
        private System.Windows.Forms.GroupBox gbResult;
        private System.Windows.Forms.RichTextBox rtResult;
    }
}

