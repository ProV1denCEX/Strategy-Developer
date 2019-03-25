using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StrategyDeveloper_Ver_0._0._1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private bool isProEdition;

        private void btnPurchaseforProEdition_Click(object sender, EventArgs e)
        {
            PurchaseForProEditionForm Purchase = new PurchaseForProEditionForm();
            Purchase.Show();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.Show();
        }

        private void btnQuitFree_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 免费版登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoginFree_Click(object sender, EventArgs e)
        {
            this.isProEdition = false;
            this.Hide();
            ConfigForm config = new ConfigForm(isProEdition);
            config.Show();
        }

        /// <summary>
        /// 专业版登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoginPro_Click(object sender, EventArgs e)
        {
            this.isProEdition = true;
            if (textBoxUserName.Text != "" && textBoxPassword.Text != "")
            {
                UserManageDataContext user = new UserManageDataContext();
                var temp = from field in user.User
                           where field.UserName == textBoxUserName.Text && field.Password == textBoxPassword.Text
                           select field;
                if (temp.Count() != 0)
                {
                    this.Hide();
                    ConfigForm config = new ConfigForm(isProEdition);
                    config.Show();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！", "登陆失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("请输入账号或密码！", "登陆失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
