using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDeveloper_Ver_0._0._1
{
    class CAccount
    {
        /// <summary>
        /// 字段需要改进
        /// </summary>
        public static int nTotalAsset;
        public static int nEquityAsset;
        public static int nEquityCash;
        public static int nDerivativesAsset;
        public static int nDerivativesMoney;
        public static int nMoneyOntheWay;
        public static int nMargin;
        public static int nMarginOccupied;

        /// <summary>
        /// 持仓字段,同样需要改进
        /// </summary>
        public static double[] dHolding = new double[CConfig.dStockCodeList.Count];


        public static void InitializeAccount()
        {
            nTotalAsset = CConfig.nInitMoney;
            nEquityCash = CConfig.nInitEquityMoney;
            nDerivativesMoney = CConfig.nInitDerivativesMoeny;
        }

        public static void ClearAccount()
        {
            nTotalAsset = 0;
            nEquityCash = 0;
            nDerivativesMoney = 0;
            nMoneyOntheWay = 0;
            nMargin = 0;
            nMarginOccupied = 0;
        }
    }
}
