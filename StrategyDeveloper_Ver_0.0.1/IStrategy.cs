using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDeveloper_Ver_0._0._1
{
    /// <summary>
    /// 提供接口以编写策略
    /// </summary>
    public interface IStrategy
    {
        /// <summary>
        /// 判断是否开仓
        /// </summary>
        /// <returns>
        /// 返回对所有品种的开仓的bool值数组
        /// </returns>
        bool[] isOpen(int iIndexTime);

        /// <summary>
        /// 判断是否平仓
        /// </summary>
        /// <returns>
        /// 返回对所有品种的平仓的bool值数组
        /// </returns>
        bool[] isClose(int iIndexTime);

        /// <summary>
        /// 判断开仓手数
        /// </summary>
        /// <returns></returns>
        double[] OpenAmount(int iIndexTime);

        /// <summary>
        /// 判断平仓手数
        /// </summary>
        /// <returns></returns>
        double[] CloseAmount(int iIndexTime);


    }
}
