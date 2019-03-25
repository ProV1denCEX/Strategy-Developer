using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace StrategyDeveloper_Ver_0._0._1
{
    public partial class ProcessForm : Form
    {
        // 数据区
        private Array cStockMarketData;
        private Array cFundMarketData;
        private Array cFutureMarketData;
        private Array cOptionMarketData;
        private Array cBondMarketData;

        // 输出区
        public string sProcess = "";

        public ProcessForm()
        {
            InitializeComponent();
            progressBarBackTest.Maximum = 60;

            /// 初始化账户
            /// 进度条：日后改进：将进度条的进度细化,嵌入
            CAccount.InitializeAccount();
            progressBarBackTest.Value = 10;
            sProcess += "\n" + "账户初始化完成!" + "\n";
            textBoxProcess.Text = sProcess;

            /// 下载数据
            DownloadData(out cStockMarketData, out cFundMarketData, out cFutureMarketData, out cOptionMarketData, out cBondMarketData);

            /// 确定策略 并 进行回测
            Array dNetValue;
            if (CConfig.sStrategy == "MACD(5,20)")
            {
                CMACDDefault strategy = new CMACDDefault(cStockMarketData);
                /// 进行回测
                dNetValue = BackTest(strategy);
            }
            else
            {
                CStrategy strategy = new CStrategy();
                /// 进行回测
                dNetValue = BackTest();
            }

            /// 绩效评估
            EvaluatePerform(dNetValue);

        }

        private void DownloadData(out Array cStockMarketData, out Array cFundMarketData, out Array cFutureMarketData, out Array cOptionMarketData, out Array cBondMarketData)
        {
            if (CConfig.nStockSelected)
            {
                CStock cStock = new CStock();
                cStockMarketData = cStock.GetSpiecesData();
                sProcess += "\n" + "股票数据下载完成" + "!\n";
                progressBarBackTest.Value += 10;
            }
            else
            {
                cStockMarketData = null;
            }

            if (CConfig.nFundSelected)
            {
                CFund cFund = new CFund();
                cFundMarketData = cFund.GetSpiecesData();
                sProcess += "基金数据下载完成!"+"\n";
                progressBarBackTest.Value += 10;
            }
            else
            {
                cFundMarketData = null;
            }

            if (CConfig.nFutureSelected)
            {
                CFuture cFuture = new CFuture();
                cFutureMarketData = cFuture.GetSpiecesData();
                sProcess += "期货数据下载完成!"+"\n";
                progressBarBackTest.Value += 10;
            }
            else
            {
                cFutureMarketData = null;
            }

            if (CConfig.nOptionSelected)
            {
                COption cOption = new COption();
                cOptionMarketData = cOption.GetSpiecesData();
                sProcess += "期权数据下载完成!"+"\n";
                progressBarBackTest.Value += 10;
            }
            else
            {
                cOptionMarketData = null;
            }

            if (CConfig.nBondSelected)
            {
                CBond cBond = new CBond();
                cBondMarketData = cBond.GetSpiecesData();
                sProcess += "债券数据下载完成!"+"\n";
                progressBarBackTest.Value += 10;
            }
            else
            {
                cBondMarketData = null;
            }
            textBoxProcess.Text = sProcess;
        }



        /// <summary>
        ///  回测流程
        ///     1、进行预计算
        ///     2、进行回测期计算 返回净值序列
        ///     3、进行绩效评估
        /// </summary>
        /// <returns></returns>
        private Array BackTest()
        {
            // 初始化变量
            bool[] isOpen;
            bool[] isClose;
            double[] dOpenAmount;
            double[] dCloseAmount;
            bool[,] CheckResult;
            double[,] FullOrder = null;

            CStrategy strategy = new CStrategy();

            //  获取时间轴：未来版本时间轴应单独列出
            Array iTimeLine = (Array)cStockMarketData.GetValue(0);

            // 进度条安排
            progressBarBackTest.Value = 0;
            progressBarBackTest.Maximum = iTimeLine.Length;
            sProcess += "\n" + "正在进行回测，请稍等!" + " \n";
            textBoxProcess.Text = sProcess;

            // 载入策略
            for (int i = 0; i < iTimeLine.Length; i++)
            {
                if (i <= CConfig.nPreLoadDay)
                {
                    // 策略部分
                    isOpen = strategy.isOpen(i);
                    isClose = strategy.isClose(i);
                    dOpenAmount = strategy.OpenAmount(i);
                    dCloseAmount = strategy.OpenAmount(i);

                    // 输出校验
                    CheckResult = CheckOrder(isOpen, isClose, dOpenAmount, dCloseAmount, out FullOrder);

                    // 进度条+1
                    progressBarBackTest.Value += 1;
                }
                else
                {
                    // 执行下单
                    Order2Market(FullOrder);

                    // 结算净值
                    StrategyAccount();

                    // 策略部分
                    isOpen = strategy.isClose(i);
                    isClose = strategy.isClose(i);
                    dOpenAmount = strategy.OpenAmount(i);
                    dCloseAmount = strategy.OpenAmount(i);

                    // 输出校验
                    CheckResult = CheckOrder(isOpen, isClose, dOpenAmount, dCloseAmount, out FullOrder);

                    // 保存订单
                    SaveOrder(FullOrder, i);

                    // 进度条+1
                    progressBarBackTest.Value += 1;
                }
            }
            return null;
        }

        private Array BackTest(CMACDDefault strategy)
        {
            // 初始化变量
            bool[] isOpen;
            bool[] isClose;
            double[] dOpenAmount;
            double[] dCloseAmount;
            bool[,] CheckResult;
            double[,] FullOrder = null;
            
            //  获取时间轴：未来版本时间轴应单独列出
            Array iTimeLine = (Array)cStockMarketData.GetValue(0);

            // 进度条安排
            progressBarBackTest.Value = 0;
            progressBarBackTest.Maximum = iTimeLine.Length;
            sProcess += "\n" + "正在进行回测，请稍等!" + " \n";
            textBoxProcess.Text = sProcess;

            // 载入策略
            for (int i = 0; i < iTimeLine.Length; i++)
            {
                if (i <= CConfig.nPreLoadDay)
                {
                    // 策略部分
                    isOpen = strategy.isOpen(i);
                    isClose = strategy.isClose(i);
                    dOpenAmount = strategy.OpenAmount(i);
                    dCloseAmount = strategy.OpenAmount(i);

                    // 输出校验
                    CheckResult = CheckOrder(isOpen, isClose, dOpenAmount, dCloseAmount, out FullOrder);

                    // 进度条+1
                    progressBarBackTest.Value += 1;
                }
                else
                {
                    // 执行下单
                    Order2Market(FullOrder);

                    // 结算净值
                    StrategyAccount();

                    // 策略部分
                    isOpen = strategy.isClose(i);
                    isClose = strategy.isClose(i);
                    dOpenAmount = strategy.OpenAmount(i);
                    dCloseAmount = strategy.OpenAmount(i);

                    // 输出校验
                    CheckResult = CheckOrder(isOpen, isClose, dOpenAmount, dCloseAmount, out FullOrder);

                    // 保存订单
                    SaveOrder(FullOrder, i);

                    // 进度条+1
                    progressBarBackTest.Value += 1;
                }
            }
            return null;
        }

        /// <summary>
        /// 评估策略绩效状况
        /// </summary>
        /// <param name="dNetValue"></param>
        private void EvaluatePerform(Array dNetValue)
        {

        }

        /// <summary>
        /// 检查指令单是否符合需要，是否存在冲突等不可能完成下单的情况
        /// </summary>
        /// <param name="isOpen"></param>
        /// <param name="isClose"></param>
        /// <param name="OpenAmount"></param>
        /// <param name="CloseAmount"></param>
        /// <param name="FullOrder"></param>
        /// <returns></returns>
        private bool[,] CheckOrder(bool[] isOpen, bool[] isClose, double[] OpenAmount, double[] CloseAmount, out double[,] FullOrder)
        {
            /// 对于检查结果：
            ///     第一行是开仓检查结果
            ///     第二行是平仓检查结果
            bool[,] CheckResult = new bool[2, isOpen.Length];
            FullOrder = new double[2, isOpen.Length];

            /// 开仓部分检查：
            ///     1、是否有足够的剩余资金
            for (int i = 0; i < isOpen.Length; i++)
            {
                if (isOpen[i])
                {
                    /// 检查是否有足够资金
                    if (OpenAmount[i] * 10 <= CAccount.nEquityAsset)
                    {
                        CheckResult[0, i] = true;
                        FullOrder[0, i] = OpenAmount[i];
                    }
                    else
                    {
                        CheckResult[0, i] = false;
                    }
                }
                else
                {
                    CheckResult[0, i] = false;
                }
            }

            /// 平仓部分检查：
            ///     1、是否有足够的持仓
            for (int i = 0; i < isClose.Length; i++)
            {
                if (isClose[i])
                {
                    /// 检查是否有足够的持仓
                    if (CAccount.dHolding[i] >= CloseAmount[i])
                    {
                        CheckResult[1, i] = true;
                        FullOrder[2, i] = -CloseAmount[i];
                    }
                    else
                    {
                        CheckResult[1, i] = false;
                    }
                }
                else
                {
                    CheckResult[1, i] = false;
                }
            }
            return CheckResult;
        }

        /// <summary>
        /// 保存经过检验和矫正的指令单到指定的txt文件中以备查询
        /// </summary>
        /// <param name="FullOrder"></param>
        private void SaveOrder(double[,] FullOrder, int iDate)
        {
            /// 记录交易语句
            /// 此处需要复杂化，而且只遍历了一边
            string sTrade = "";
            for (int i = 0; i < FullOrder.GetLength(0); i++)
            {
                if (FullOrder[1,i] > 0)
                {
                    sTrade += string.Format("\n" + "第{0}标的，仓位变动：{1}；时间：{2}" + "\n", i,FullOrder[1, i], iDate);
                }
            }

            /// 进行文件记录
            /// 后期再补充
            


        }

        /// <summary>
        /// 计算策略的净值与剩余资金情况
        /// </summary>
        private void StrategyAccount()
        {

        }


        /// <summary>
        /// 执行下单动作
        /// </summary>
        /// <param name="FullOrder"></param>
        private void Order2Market(Array FullOrder)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        /// <summary>
        /// 展示交易流程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckFile_Click(object sender, EventArgs e)
        {
            TradeListForm TradeList = new TradeListForm();
            TradeList.Show();
        }

        /// <summary>
        /// 展示绩效评估
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResult_Click(object sender, EventArgs e)
        {
            PerformForm perform = new PerformForm();
            perform.Show();
        }

        /// <summary>
        /// 保存回测结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private string SName;
        public string sName
        {
            get
            {
                return SName;
            }
            set
            {
                SName = CConfig.sStrategy;
            }
        }
    }
}
