using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDeveloper_Ver_0._0._1
{
    class CImpactCost
    {
        private int NMode;
        private int NImpact;
        /// <summary>
        /// 冲击成本模式 
        ///     1：滑点
        ///     2：飘移
        /// 默认：
        ///     滑点模式 无滑点
        /// </summary>
        public int nMode
        {
            get
            {
                return NMode;
            }
            set
            {
                switch(value)
                {
                    case 1:
                        NMode = 1;
                        break;
                    case 2:
                        NMode = 2;
                        break;
                    default:
                        NMode = 1;
                        break;
                }
            }
        }

        public int nImpact
        {
            get
            {
                return NImpact;
            }
            set
            {
                NImpact = value;
            }
        }
    }
}
