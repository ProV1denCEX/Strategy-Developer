using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDeveloper_Ver_0._0._1
{
    class CMACDDefault : IStrategy
    {
        private Array cData;
        private int iIndexTime;
        private double[,] cCalendar;
        public CMACDDefault(Array cStockMarketData)
        {
            cData = cStockMarketData;
            cCalendar = (double[,])cStockMarketData.GetValue(0);
        }

        public bool[] isOpen(int iDate)
        {
            bool[] dResult = new bool[cData.GetLength(0) - 2];
            // 获取当前日期（回测）
            iIndexTime = iDate;

            // 遍历所有候选品种，寻找可开仓的标的
            for (int i = 3; i < cData.GetLength(0); i++)
            {
                // 获取品种数据
                double[,] dTemp = (double[,])cData.GetValue(i);

                // 策略判断开始，以下由研究人员自行完成
                for (int iDay = 0; iDay < dTemp.GetLength(0); iDay++)
                {
                    if (dTemp[iDay,0] == cCalendar[iIndexTime, 0])
                    {

                        // 策略部分



                        dResult[i - 3] = true;
                        
                    }

                }
            }
            return dResult;
        }

        public bool[] isClose(int iDate)
        {
            bool[] dResult = new bool[cData.GetLength(0) - 2];
            return dResult;
        }

        public double[] OpenAmount(int iDate)
        {
            bool[] dOpen = isOpen(iDate);
            double[] Amount = new double[cData.GetLength(0) - 2];
            return Amount;
        }

        public double[] CloseAmount(int iDate)
        {
            bool[] dOpen = isOpen(iDate);
            double[] Amount = new double[cData.GetLength(0) - 2];
            return Amount; ;
        }
    }
}
