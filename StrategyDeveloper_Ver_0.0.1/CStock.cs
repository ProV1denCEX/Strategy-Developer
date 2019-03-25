using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace StrategyDeveloper_Ver_0._0._1
{
    class CStock : CSpieces
    {
        /// <summary>
        /// 下载：
        ///     1、交易日历数据
        ///     2、对应股票数据
        ///     3、指数数据
        /// </summary>
        
        private DataTable tTemp = new DataTable();
        public override Array GetSpiecesData()
        {
            int nTotalSpieces = CConfig.dStockCodeList.Count + 2;
            Array[] cStockMarketData = new Array[nTotalSpieces];
            cStockMarketData[0] = base.GetSpiecesData();

            for (int i = 0; i < CConfig.dStockCodeList.Count; i++)
            {
                object sCode = CConfig.dStockCodeList[i];
                string sconn = "Data Source = FullFrontal;Initial Catalog = Alpha; Integrated Security = true";
                string sGetStockMarketData = string.Format("Select [Date], [Oppr], [Hipr], [Lopr], [Clpr], [Trdvol] from [dbo].[{0}] where [Date] >= '{1}' and [Date] <= '{2}' order by [Date]",
                    sCode, CConfig.sStrategyStart, CConfig.sStrategyEnd);
                using (SqlConnection conn = new SqlConnection(sconn))
                {
                    conn.Open();
                    tTemp = getTable(sGetStockMarketData, conn);
                }
                double[,] dTemp = new double[tTemp.Rows.Count, tTemp.Columns.Count];
                dTemp = Table2Array(tTemp);
                cStockMarketData[i + 2] = dTemp;
                
            }
            return cStockMarketData;
        }


        /// <summary>
        /// 获取对应的股票代码
        /// </summary>
        /// <returns></returns>
        public override ArrayList GetAllCode()
        {
            /// 获取所有数据表名
            /// 后期需要更改，用总股票表替代
            StockDataDataContext stocklinq = new StockDataDataContext();
            var table = from t in stocklinq.Mapping.GetTables()
                        orderby t.TableName
                        select t;
            ArrayList stocktable = new ArrayList();
            
            /// 将对应代码录入
            foreach (var x in table)
            {
                string sCode = "";
                foreach (char i in x.TableName)
                {
                    if (Char.IsNumber(i))
                    {
                        sCode += i;
                    }
                }
                stocktable.Add(sCode);
            }
            return stocktable;
        }
    }
}
