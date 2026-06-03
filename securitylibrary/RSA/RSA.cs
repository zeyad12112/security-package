using SecurityLibrary.AES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary.RSA
{
    public class RSA
    {
        private int exp(int b, int p, int M)
        {
            int cur = 1;
            int ret = 1;
            while (p != 0)
            {
                if ((p & cur) != 0)
                {
                    ret = (int)(1l * ret * b % M);
                    p -= cur;
                }
                b = (int)(1l * b * b % M);
                cur = cur + cur;
            }
            return ret;
        }
        public int Encrypt(int p, int q, int M, int e)
        {
            int n = p * q;
            return exp(M, e, n);
        }
        public int Decrypt(int p, int q, int C, int e)
        {
            var euclid = new ExtendedEuclid();
            int totient = (p - 1) * (q - 1);
            int n = p * q;
            int d = euclid.GetMultiplicativeInverse(e, totient);
            return exp(C, d, n);

        }
    }
}
