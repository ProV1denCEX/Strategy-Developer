using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDeveloper_Ver_0._0._1
{
    class CConfig
    {
        public static int nInitMoney;
        public static int nPreLoadDay;
        public static int nMoneyDelay;
        public static string sDataBase;
        public static string sStrategy;
        public static bool isProEdition;
        public static int nTradeCost;
        public static int nTradeCostMin;
        public static bool nStockSelected;
        public static bool nFundSelected;
        public static bool nFutureSelected;
        public static bool nOptionSelected;
        public static bool nBondSelected;
        public static ArrayList dStockCodeList = new ArrayList();
        public static ArrayList dFundCodeList = new ArrayList();
        public static ArrayList dOptionCodeList = new ArrayList();
        public static ArrayList dFutureCodeList = new ArrayList();
        public static ArrayList dBondCodeList = new ArrayList();
        public static CImpactCost ImpactCost = new CImpactCost();

        /// <summary>
        /// 设定类
        /// 将以下字段设定为静态
        /// 供全局使用
        /// </summary>
        private static string _sStrategyName;
        public static string sStrategyName
        {
            get
            {
                return _sStrategyName;
            }
            set
            {
                if (value != "")
                {
                    _sStrategyName = value;
                }
                else
                {
                    throw new Exception("策略名不得为空！");
                }
            }
        }

        /// <summary>
        /// 初始资金的对应判断
        /// </summary>
        private static int _nInitEquityMoney;
        public static int nInitEquityMoney
        {
            get
            {
                return _nInitEquityMoney;
            }
            set
            {
                if (value % 100 == 0)
                {
                    _nInitEquityMoney = value;
                }
                else
                {
                    throw new Exception("初始资金须为100的整数倍！");
                }
            }
        }

        private static int _nInitDerivativesMoeny;
        public static int nInitDerivativesMoeny
        {
            get
            {
                return _nInitDerivativesMoeny;
            }
            set
            {
                if (value % 100 == 0)
                {
                    _nInitDerivativesMoeny = value;
                }
                else
                {
                    throw new Exception("初始资金须为100的整数倍！");
                }
            }
        }



        private static DateTime _sStrategyStart;
        private static DateTime _sStrategyEnd;

        /// <summary>
        /// 最大准许回测日期区间：
        ///     20120101 - now
        /// </summary>
        public static DateTime sStrategyStart
        {
            get
            {
                return _sStrategyStart;
            }
            set
            {
                if (value >= Convert.ToDateTime("2012.01.01") && value <= DateTime.Now.AddDays(-nPreLoadDay))
                {
                    _sStrategyStart = value;
                }
                else
                {
                    _sStrategyStart = Convert.ToDateTime("2012.01.01");
                    throw new Exception("错误的开始时间！开始时间必须在20120101至今之间的时间段内！");
                }
            }
        }

        public static DateTime sStrategyEnd
        {
            get
            {
                return _sStrategyEnd;
            }
            set
            {
                if (value >= sStrategyStart.AddDays(nPreLoadDay))
                {
                    _sStrategyEnd = value;
                }
                else
                {
                    /// 过远时，默认设置到现在的前一个月
                    _sStrategyEnd = DateTime.Now.AddMonths(-1);
                    throw new Exception("错误的结束回测时间！结束时间必须在20120101至今之间的时间段内！且必须满足预载入日期的要求！");
                }
            }
        }
    }
}
