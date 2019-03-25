using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StrategyDeveloper_Ver_0._0._1
{
    public partial class PurchaseForProEditionForm : Form
    {
        public PurchaseForProEditionForm()
        {
            InitializeComponent();
        }

        private string initPassword = "123456";
        private int userID;

        /// <summary>
        /// 初始密码统一为123456
        /// ID为从10001开始的顺延
        /// 不输入则直接退出
        ///     存在改进空间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK9_Click(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "")
            {
                this.Close();
            }
            else
            {
                UserManageDataContext user = new UserManageDataContext();
                var fetch = from field in user.User select field;
                if (fetch.Count() > 0)
                {
                    userID = fetch.Max(x => x.UserID) + 1;
                }
                else
                {
                    userID = 10001;
                }

                User newUser = new User();
                newUser.UserID = userID;
                newUser.UserName = textBoxEmail.Text;
                newUser.Password = initPassword;
                user.User.InsertOnSubmit(newUser);
                user.SubmitChanges();

                this.Close();
            }
        }
    }
}
