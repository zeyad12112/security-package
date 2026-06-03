using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary.DiffieHellman
{
    public class DiffieHellman 
    {

        public int FastPower(int b, int p, int m)
        {
            int res = 1;
            int cur = 1;
            while (p != 0)
            {
                if((p & cur) != 0)
                {
                    res = (int)(1l * res * b % m);
                    p -= cur;
                }
                cur += cur;
                b = (int)(1l * b * b % m);
            }
            return res;
        }
        int GetKey(int q, int alpha, int xa, int xb) {
            int k1 = FastPower(alpha, xa, q);
            int key = FastPower(k1, xb, q);
            return key;
        }
        public List<int> GetKeys(int q, int alpha, int xa, int xb)
        {
            return new List<int>() {
                GetKey(q, alpha, xa, xb),
                GetKey(q, alpha, xb, xa)
            };
        }
    }
}
