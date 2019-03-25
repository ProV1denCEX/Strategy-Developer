namespace StrategyDeveloper_Ver_0._0._1
{
    partial class ProcessForm
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
            this.groupBoxProcess = new System.Windows.Forms.GroupBox();
            this.progressBarBackTest = new System.Windows.Forms.ProgressBar();
            this.textBoxProcess = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnResult = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCheckFile = new System.Windows.Forms.Button();
            this.groupBoxProcess.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxProcess
            // 
            this.groupBoxProcess.Controls.Add(this.progressBarBackTest);
            this.groupBoxProcess.Controls.Add(this.textBoxProcess);
            this.groupBoxProcess.Location = new System.Drawing.Point(12, 95);
            this.groupBoxProcess.Name = "groupBoxProcess";
            this.groupBoxProcess.Size = new System.Drawing.Size(833, 349);
            this.groupBoxProcess.TabIndex = 0;
            this.groupBoxProcess.TabStop = false;
            this.groupBoxProcess.Text = "回测进程";
            // 
            // progressBarBackTest
            // 
            this.progressBarBackTest.Location = new System.Drawing.Point(6, 30);
            this.progressBarBackTest.Name = "progressBarBackTest";
            this.progressBarBackTest.Size = new System.Drawing.Size(821, 33);
            this.progressBarBackTest.Step = 1;
            this.progressBarBackTest.TabIndex = 1;
            // 
            // textBoxProcess
            // 
            this.textBoxProcess.Location = new System.Drawing.Point(6, 79);
            this.textBoxProcess.Multiline = true;
            this.textBoxProcess.Name = "textBoxProcess";
            this.textBoxProcess.ReadOnly = true;
            this.textBoxProcess.Size = new System.Drawing.Size(821, 264);
            this.textBoxProcess.TabIndex = 0;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(18, 491);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(115, 48);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "中止回测";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnResult
            // 
            this.btnResult.Location = new System.Drawing.Point(253, 491);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(115, 48);
            this.btnResult.TabIndex = 2;
            this.btnResult.Text = "查看绩效";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(723, 491);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 48);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存回测结果";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(368, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "回测结果展示";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(359, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "回测中，请耐心等待";
            // 
            // btnCheckFile
            // 
            this.btnCheckFile.Location = new System.Drawing.Point(488, 491);
            this.btnCheckFile.Name = "btnCheckFile";
            this.btnCheckFile.Size = new System.Drawing.Size(115, 48);
            this.btnCheckFile.TabIndex = 6;
            this.btnCheckFile.Text = "查看下单记录";
            this.btnCheckFile.UseVisualStyleBackColor = true;
            this.btnCheckFile.Click += new System.EventHandler(this.btnCheckFile_Click);
            // 
            // ProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 578);
            this.Controls.Add(this.btnCheckFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.groupBoxProcess);
            this.Name = "ProcessForm";
            this.Text = "ProcessForm";
            this.groupBoxProcess.ResumeLayout(false);
            this.groupBoxProcess.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxProcess;
        private System.Windows.Forms.TextBox textBoxProcess;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBarBackTest;
        private System.Windows.Forms.Button btnCheckFile;
    }
}