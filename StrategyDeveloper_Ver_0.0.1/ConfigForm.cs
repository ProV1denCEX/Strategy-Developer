using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StrategyDeveloper_Ver_0._0._1
{
    public partial class ConfigForm : Form
    {
        bool isProEdition;
        public ConfigForm()
        {
            InitializeComponent();
        }

        public ConfigForm(bool isProEdition)
        {
            this.isProEdition = isProEdition;
            InitializeComponent();
            checkBoxBond.Enabled = isProEdition;
            checkBoxFund.Enabled = isProEdition;
            checkBoxFuture.Enabled = isProEdition;
            checkBoxOption.Enabled = isProEdition;

            // 加载策略位置
            // 若有则直接读取文件夹内策略
            // 策略
            // 若无则新建文件夹，不加载策略
            string sStrategyPath = "StrategyPack";
            if (Directory.Exists(sStrategyPath) == true)
            {
                var strategyfile = Directory.GetFiles(sStrategyPath, "*.dll");
                foreach (var file in strategyfile)
                {
                    comboBoxStrategySelect.Items.Add(file);
                }
            }
            else
            {
                Directory.CreateDirectory(sStrategyPath);
            }
        }

        /// <summary>
        /// 选择标的
        /// 免费版：
        ///     只能选择股票类
        ///     最多只能选择一只股票进行回测
        ///     最多只数在后期会做更改
        /// 付费版：
        ///     可以全选
        /// </summary>
        private void SpiecesLimit()
        {
            if (checkBoxStock.Checked ||
                checkBoxFund.Checked ||
                checkBoxBond.Checked ||
                checkBoxFuture.Checked ||
                checkBoxOption.Checked)
            {
                tabControlSpecies.Visible = true;
            }
            else
            {
                tabControlSpecies.Visible = false;
            }
            
            if (!isProEdition && tabControlSpecies.TabPages.Count > 1)
            {
                /// 删去付费版的功能
                /// 效率有待改进
                for (int i = 0; i < 4; i++)
                {
                    tabControlSpecies.TabPages.RemoveAt(1);
                }
            }
        }

        /// <summary>
        /// 退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 选择品种大类时，载入数据库对应的标的名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxStock_CheckedChanged(object sender, EventArgs e)
        {
            /// 进行版本限制
            SpiecesLimit();
            checkedListBoxStock.Items.Clear();
            listBoxSelectedStock.Items.Clear();

            /// 获取代码
            CStock stock = new CStock();
            ArrayList stocklist = stock.GetAllCode();
            foreach (var item in stocklist)
            {
                checkedListBoxStock.Items.Add(item);
            }
                        
        }

        /// <summary>
        /// 写入配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            /// 写入配置文件
            CConfig.isProEdition = this.isProEdition;
            CConfig.sStrategyName = textBoxStrategyName.Text;

            CConfig.nPreLoadDay = (int)numericUpDownPreLoadDate.Value;
            CConfig.nMoneyDelay = (int)numericUpDownMoneyOntheWay.Value;

            CConfig.ImpactCost.nMode = comboBoxImpactMode.SelectedIndex + 1;
            CConfig.ImpactCost.nImpact = (int)numericUpDownImpactValue.Value;

            CConfig.nTradeCost = (int)(numericUpDownTradeCost.Value / 10000);
            CConfig.nTradeCostMin = (int)numericUpDownMinTradeCost.Value;

            CConfig.sStrategy = comboBoxStrategySelect.Text;
            CConfig.sDataBase = comboBoxDataBaseSetting.Text;

            try
            {
                CConfig.nInitEquityMoney = int.Parse(textBoxEquityInitMoney.Text);
                CConfig.nInitDerivativesMoeny = int.Parse(textBoxDerivativeInitMoney.Text);
                CConfig.nInitMoney = CConfig.nInitEquityMoney + CConfig.nInitDerivativesMoeny;
            }
            catch (Exception)
            {
                MessageBox.Show("起始资金不得存在a-z字符！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CConfig.nInitEquityMoney = 0;
                CConfig.nInitDerivativesMoeny = 0;
                CConfig.nInitMoney = 0;
                textBoxEquityInitMoney.Text = "";
                textBoxDerivativeInitMoney.Text = "";
                textBoxTotalInitMoney.Text = "";
            }
            textBoxTotalInitMoney.Text = Convert.ToString(CConfig.nInitMoney);

            try
            {
                CConfig.sStrategyStart = dateTimePickerRetraceStart.Value.Date;
                CConfig.sStrategyEnd = dateTimePickerRetraceEnd.Value.Date;
            }
            catch (Exception)
            {
                MessageBox.Show("回测开始结束日期存在问题！回测区间必须在20120101-今，且须满足预加载天数要求！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerRetraceStart.Value = CConfig.sStrategyStart;
                dateTimePickerRetraceEnd.Value = CConfig.sStrategyStart;
            }

            /// 写入需要回测的代码与品种
            CConfig.nStockSelected = checkBoxStock.Checked;
            if (CConfig.nStockSelected)
            {
                foreach (var item in listBoxSelectedStock.Items)
                {
                    if (!CConfig.dStockCodeList.Contains(item))
                        CConfig.dStockCodeList.Add(item);
                }
            }
            
            CConfig.nFundSelected = checkBoxFund.Checked;
            if (CConfig.nStockSelected)
            {
                foreach (var item in listBoxFund.Items)
                {
                    if (!CConfig.dFundCodeList.Contains(item))
                        CConfig.dFundCodeList.Add(item);
                }
            }

            CConfig.nFutureSelected = checkBoxFuture.Checked;
            if (CConfig.nStockSelected)
            {
                foreach (var item in listBoxFuture.Items)
                {
                    if (!CConfig.dFutureCodeList.Contains(item))
                        CConfig.dFutureCodeList.Add(item);
                }
            }
            
            CConfig.nOptionSelected = checkBoxOption.Checked;
            if (CConfig.nStockSelected)
            {
                foreach (var item in listBoxOption.Items)
                {
                    if (!CConfig.dOptionCodeList.Contains(item))
                        CConfig.dOptionCodeList.Add(item);
                }
            }

            CConfig.nBondSelected = checkBoxBond.Checked;
            if (CConfig.nStockSelected)
            {
                foreach (var item in listBoxBond.Items)
                {
                    if (!CConfig.dBondCodeList.Contains(item))
                        CConfig.dBondCodeList.Add(item);
                }
            }

            /// 开始进行数据载入与回测
            ProcessForm BacktestMain = new ProcessForm();
            BacktestMain.Show();
        }


        /// <summary>
        /// 实现全选
        ///     品种选择模块未来考虑重做
        ///     以VS平台的效果为最终目标
        /// 现阶段功能
        ///     能够通用化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAll()
        {
            foreach (Control item in tabControlSpecies.SelectedTab.Controls)
            {
                if (item is CheckedListBox)
                {
                    CheckedListBox clb = new CheckedListBox();
                    clb = (CheckedListBox)item;
                    for (int i = 0; i < clb.Items.Count; i++)
                    {
                        clb.SetItemChecked(i, true);
                    }
                }    
            }
        }

        /// <summary>
        /// 实现清除
        ///     包括清除checkedlist和listbox
        /// </summary>
        private void ClearAll()
        {
            /// 清除checkedlist
            foreach (Control item in tabControlSpecies.SelectedTab.Controls)
            {
                if (item is CheckedListBox)
                {
                    CheckedListBox clb = new CheckedListBox();
                    clb = (CheckedListBox)item;
                    for (int i = 0; i < clb.Items.Count; i++)
                    {
                        clb.SetItemChecked(i, false);
                    }
                }
            }

            /// 清除listbox
            foreach (Control item in tabControlSpecies.SelectedTab.Controls)
            {
                if (item is ListBox && !(item is CheckedListBox))
                {
                    ListBox lb = new ListBox();
                    lb = (ListBox)item;
                    lb.Items.Clear();
                }
            }
        }

        /// <summary>
        /// 将选中的标的加入listbox
        /// 中间的效率有改进空间
        /// </summary>
        int nLength;
        private void SelectIntoList()
        {
            foreach (Control item in tabControlSpecies.SelectedTab.Controls)
            {
                if (item is CheckedListBox)
                {
                    CheckedListBox clb = new CheckedListBox();
                    clb = (CheckedListBox)item;
                    nLength = clb.CheckedItems.Count;
                }
            }

            string[] items = new string[nLength];
            foreach (Control item in tabControlSpecies.SelectedTab.Controls)
            {
                if (item is CheckedListBox)
                {
                    CheckedListBox clb = new CheckedListBox();
                    clb = (CheckedListBox)item;
                    clb.CheckedItems.CopyTo(items, 0);
                }
            }

            foreach (Control item in tabControlSpecies.SelectedTab.Controls)
            {
                if (item is ListBox && !(item is CheckedListBox))
                {
                    ListBox lb = new ListBox();
                    lb = (ListBox)item;
                    foreach (string s in items)
                    {
                        lb.Items.Add(s);
                    }
                }
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnSelcetAll_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectIntoList();
        }

    }
}
