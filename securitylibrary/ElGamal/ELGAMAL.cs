using SecurityLibrary.DiffieHellman;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary.ElGamal
{
    public class ElGamal
    {
        /// <summary>
        /// Encryption
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="q"></param>
        /// <param name="y"></param>
        /// <param name="k"></param>
        /// <returns>list[0] = C1, List[1] = C2</returns>
        public List<long> Encrypt(int q, int alpha, int y, int k, int m)
        {
            var dh = new DiffieHellman.DiffieHellman();
            int s = dh.FastPower(y, k, q);
            long c1 = dh.FastPower(alpha, k, q);
            long c2 = m * s % q;
            return new List<long>() { c1, c2 };
        }
        public bool IsPrime(int x)
        {
            if (x == 1)
                return false;
            for(int i = 2; i * i <= x; i++)
            {
                if(x%i == 0)
                    return false;
            }
            return true;
        }

        public int Totient(int x)
        {
            for(int i = 2; i <= x; i++)
            {
                if (!IsPrime(i))
                    continue;
                if (x % i == 0)
                    x = x / i * (i - 1);
            }
            return x;
        }
        public int Decrypt(int c1, int c2, int x, int q)
        {
            var dh = new DiffieHellman.DiffieHellman();
            int s = dh.FastPower(c1, x, q);
            int tot = Totient(q);
            int inv = dh.FastPower(s, tot - 1, q);
            int m = (int)(1l * inv * c2 % q);
            return m;
        }
    }
}
