namespace StrategyDeveloper_Ver_0._0._1
{
    partial class LoginForm
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
            this.tabControlLogin = new System.Windows.Forms.TabControl();
            this.tabPageFreeUser = new System.Windows.Forms.TabPage();
            this.btnPurchaseforProEdition = new System.Windows.Forms.Button();
            this.btnQuitFree = new System.Windows.Forms.Button();
            this.btnLoginFree = new System.Windows.Forms.Button();
            this.textBoxFree2 = new System.Windows.Forms.TextBox();
            this.textBoxFree = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageProUser = new System.Windows.Forms.TabPage();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnLoginPro = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlLogin.SuspendLayout();
            this.tabPageFreeUser.SuspendLayout();
            this.tabPageProUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlLogin
            // 
            this.tabControlLogin.Controls.Add(this.tabPageFreeUser);
            this.tabControlLogin.Controls.Add(this.tabPageProUser);
            this.tabControlLogin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlLogin.Location = new System.Drawing.Point(12, 94);
            this.tabControlLogin.Name = "tabControlLogin";
            this.tabControlLogin.SelectedIndex = 0;
            this.tabControlLogin.Size = new System.Drawing.Size(558, 285);
            this.tabControlLogin.TabIndex = 0;
            // 
            // tabPageFreeUser
            // 
            this.tabPageFreeUser.Controls.Add(this.btnPurchaseforProEdition);
            this.tabPageFreeUser.Controls.Add(this.btnQuitFree);
            this.tabPageFreeUser.Controls.Add(this.btnLoginFree);
            this.tabPageFreeUser.Controls.Add(this.textBoxFree2);
            this.tabPageFreeUser.Controls.Add(this.textBoxFree);
            this.tabPageFreeUser.Controls.Add(this.label3);
            this.tabPageFreeUser.Controls.Add(this.label2);
            this.tabPageFreeUser.Location = new System.Drawing.Point(4, 30);
            this.tabPageFreeUser.Name = "tabPageFreeUser";
            this.tabPageFreeUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFreeUser.Size = new System.Drawing.Size(550, 251);
            this.tabPageFreeUser.TabIndex = 0;
            this.tabPageFreeUser.Text = "试用版用户";
            this.tabPageFreeUser.UseVisualStyleBackColor = true;
            // 
            // btnPurchaseforProEdition
            // 
            this.btnPurchaseforProEdition.Location = new System.Drawing.Point(355, 170);
            this.btnPurchaseforProEdition.Name = "btnPurchaseforProEdition";
            this.btnPurchaseforProEdition.Size = new System.Drawing.Size(121, 29);
            this.btnPurchaseforProEdition.TabIndex = 8;
            this.btnPurchaseforProEdition.Text = "成为专业版！";
            this.btnPurchaseforProEdition.UseVisualStyleBackColor = true;
            this.btnPurchaseforProEdition.Click += new System.EventHandler(this.btnPurchaseforProEdition_Click);
            // 
            // btnQuitFree
            // 
            this.btnQuitFree.Location = new System.Drawing.Point(214, 170);
            this.btnQuitFree.Name = "btnQuitFree";
            this.btnQuitFree.Size = new System.Drawing.Size(121, 29);
            this.btnQuitFree.TabIndex = 7;
            this.btnQuitFree.Text = "退出";
            this.btnQuitFree.UseVisualStyleBackColor = true;
            this.btnQuitFree.Click += new System.EventHandler(this.btnQuitFree_Click);
            // 
            // btnLoginFree
            // 
            this.btnLoginFree.Location = new System.Drawing.Point(73, 170);
            this.btnLoginFree.Name = "btnLoginFree";
            this.btnLoginFree.Size = new System.Drawing.Size(121, 29);
            this.btnLoginFree.TabIndex = 6;
            this.btnLoginFree.Text = "登陆";
            this.btnLoginFree.UseVisualStyleBackColor = true;
            this.btnLoginFree.Click += new System.EventHandler(this.btnLoginFree_Click);
            // 
            // textBoxFree2
            // 
            this.textBoxFree2.Location = new System.Drawing.Point(178, 118);
            this.textBoxFree2.Name = "textBoxFree2";
            this.textBoxFree2.ReadOnly = true;
            this.textBoxFree2.Size = new System.Drawing.Size(241, 29);
            this.textBoxFree2.TabIndex = 5;
            this.textBoxFree2.Text = "******";
            this.textBoxFree2.UseSystemPasswordChar = true;
            // 
            // textBoxFree
            // 
            this.textBoxFree.Location = new System.Drawing.Point(178, 52);
            this.textBoxFree.Name = "textBoxFree";
            this.textBoxFree.ReadOnly = true;
            this.textBoxFree.Size = new System.Drawing.Size(241, 29);
            this.textBoxFree.TabIndex = 4;
            this.textBoxFree.Text = "User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "用户名：";
            // 
            // tabPageProUser
            // 
            this.tabPageProUser.Controls.Add(this.btnAbout);
            this.tabPageProUser.Controls.Add(this.btnQuit);
            this.tabPageProUser.Controls.Add(this.btnLoginPro);
            this.tabPageProUser.Controls.Add(this.textBoxPassword);
            this.tabPageProUser.Controls.Add(this.textBoxUserName);
            this.tabPageProUser.Controls.Add(this.label4);
            this.tabPageProUser.Controls.Add(this.label5);
            this.tabPageProUser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPageProUser.Location = new System.Drawing.Point(4, 30);
            this.tabPageProUser.Name = "tabPageProUser";
            this.tabPageProUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProUser.Size = new System.Drawing.Size(550, 251);
            this.tabPageProUser.TabIndex = 1;
            this.tabPageProUser.Text = "专业版用户";
            this.tabPageProUser.UseVisualStyleBackColor = true;
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(356, 170);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(121, 29);
            this.btnAbout.TabIndex = 15;
            this.btnAbout.Text = "关于我们";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(215, 170);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(121, 29);
            this.btnQuit.TabIndex = 14;
            this.btnQuit.Text = "退出";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuitFree_Click);
            // 
            // btnLoginPro
            // 
            this.btnLoginPro.Location = new System.Drawing.Point(74, 170);
            this.btnLoginPro.Name = "btnLoginPro";
            this.btnLoginPro.Size = new System.Drawing.Size(121, 29);
            this.btnLoginPro.TabIndex = 13;
            this.btnLoginPro.Text = "登陆";
            this.btnLoginPro.UseVisualStyleBackColor = true;
            this.btnLoginPro.Click += new System.EventHandler(this.btnLoginPro_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(179, 118);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(241, 29);
            this.textBoxPassword.TabIndex = 12;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(179, 52);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(241, 29);
            this.textBoxUserName.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(99, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "密码：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "用户名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(217, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "请登录";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 391);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControlLogin);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.tabControlLogin.ResumeLayout(false);
            this.tabPageFreeUser.ResumeLayout(false);
            this.tabPageFreeUser.PerformLayout();
            this.tabPageProUser.ResumeLayout(false);
            this.tabPageProUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlLogin;
        private System.Windows.Forms.TabPage tabPageFreeUser;
        private System.Windows.Forms.TabPage tabPageProUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFree2;
        private System.Windows.Forms.TextBox textBoxFree;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPurchaseforProEdition;
        private System.Windows.Forms.Button btnQuitFree;
        private System.Windows.Forms.Button btnLoginFree;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnLoginPro;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}