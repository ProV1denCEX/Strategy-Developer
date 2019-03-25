using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace StrategyDeveloper_Ver_0._0._1
{
    class CSpieces
    {
        /// <summary>
        /// 定义所有金融交易品种必须具备的属性：
        /// 开高低收 成交量 交易状态
        /// 品种代码
        /// </summary>
        private int _nOpen;
        public int nOpen
        {
            get
            {
                return _nOpen;
            }
            set
            {
                _nOpen = value;
            }

        }

        private int _nHigh;
        public int nHigh
        {
            get
            {
                return _nHigh;
            }
            set
            {
                _nHigh = value;
            }
        }

        private int _nLow;
        public int nLow
        {
            get
            {
                return _nLow;
            }
            set
            {
                _nLow = value;
            }

        }

        private int _nClose;
        public int nClose
        {
            get
            {
                return _nClose;
            }
            set
            {
                _nClose = value;
            }

        }

        private int _nVol;
        public int nVol
        {
            get
            {
                return _nVol;
            }
            set
            {
                _nVol = value;
            }
        }

        private bool _nStatus;
        public bool nStatus
        {
            get
            {
                return _nStatus;
            }
            set
            {
                _nStatus = value;
            }
        }

        private int _nCode;
        public int nCode
        {
            get
            {
                return _nCode;
            }
            set
            {
                _nCode = value;
            }
        }

        /// <summary>
        /// 获取用户选择的品种，虚函数
        /// </summary>
        public virtual void GetSelectSpieces() { }

        /// <summary>
        /// 获取对应品种的数据
        /// 虚函数:
        ///     下载交易日历 股票型：适用于股票 债券 基金
        /// </summary>
        private DataTable tCalender = new DataTable();
        public virtual Array GetSpiecesData()
        {
            string sStart = (CConfig.sStrategyStart.Year * 10000 + CConfig.sStrategyStart.Month * 100 + CConfig.sStrategyStart.Day * 1).ToString();
            string sEnd = (CConfig.sStrategyEnd.Year * 10000 + CConfig.sStrategyEnd.Month * 100 + CConfig.sStrategyEnd.Day * 1).ToString();
            string sconn = "Data Source = FullFrontal;Initial Catalog = Alpha; Integrated Security = true";
            string sGetCalender = string.Format("Select [TRADINGDAY] from [dbo].[CALENDAR] where [TRADINGDAY] >= {0} and [TRADINGDAY] <= {1} order by [TRADINGDAY]", sStart, sEnd);
            using (SqlConnection conn = new SqlConnection(sconn))
            {
                conn.Open();
                tCalender = getTable(sGetCalender, conn);
            }
            double[,] dCalendar = new double[tCalender.Rows.Count, tCalender.Columns.Count];
            dCalendar = Table2Array(tCalender);
            return dCalendar;
        }

        /// <summary>
        /// 获取该品种的所有候选代码
        /// </summary>
        public virtual ArrayList GetAllCode()
        {
            return null;
        }

        /// <summary>
        /// 获取内存中的数据表
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static DataTable getTable(string strSql, SqlConnection conn)
        {
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(strSql, conn);
                DataSet ds = new DataSet();
                sda.Fill(ds, "table");
                sda.Dispose();
                return ds.Tables["table"];
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// 工具函数 将数据表转化为数组
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static double[,] Table2Array(DataTable dt)
        {
            string[] colname = null;
            double[,] arrayA = new double[dt.Rows.Count, dt.Columns.Count];

            if (dt.Columns.Count > 0)
            {
                colname = new string[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                {

                    colname[i] = dt.Columns[i].ColumnName;
                    for (int n = 0; n < dt.Rows.Count; n++)
                    {
                        DataRow dr2 = dt.Rows[n];
                        var sType = dr2[colname[i]].GetType();
                        switch (sType.Name)
                        {
                            case "double":
                                if (!dr2[colname[i]].Equals(""))
                                    arrayA[n, i] = Convert.ToDouble(dr2[colname[i]]);
                                break;
                            case "DateTime":
                                //double nTime = dDate.Date.ToBinary();
                                //后期考虑用ToBinay实现
                                if (!dr2[colname[i]].Equals(""))
                                {
                                    DateTime dDate = Convert.ToDateTime(dr2[colname[i]]);
                                    int nDate = dDate.Year * 10000 + dDate.Month * 100 + dDate.Day;
                                    arrayA[n, i] = nDate;
                                }
                                else
                                    arrayA[n, i] = 0;
                                break;
                            default:
                                if (dr2[colname[i]].ToString() != "")
                                    arrayA[n, i] = Convert.ToDouble(dr2[colname[i]]);
                                break;
                        }
                    }
                }
            }
            return arrayA;
        }
    }
}
