using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary.AES
{
    public class ExtendedEuclid 
    {

        Dictionary<int, (int, int)> Expression = new Dictionary<int, (int, int)>();
        internal void ExtendedEuclidean(int x, int y)
        {
            //y = ax + m
            int a = y / x;
            int m = y % x;
            if (m == 0)
                return;
            //m = y - ax
            (int, int) repM = (Expression[y].Item1 - a * Expression[x].Item1,
                Expression[y].Item2 - a * Expression[x].Item2);
            Expression.Add(m, repM);
            ExtendedEuclidean(m, x);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="baseN"></param>
        /// <returns>Mul inverse, -1 if no inv</returns>
        public int GetMultiplicativeInverse(int number, int baseN)
        {
            number %= baseN;
            Expression.Add(number, (1, 0));
            Expression.Add(baseN, (0, 1));
            ExtendedEuclidean(number, baseN);
            int ret = -1;
            if (Expression.ContainsKey(1))
                ret = (Expression[1].Item1 + baseN)%baseN;
            Expression.Clear();
            return ret;
        }
    }
}
