using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class RepeatingkeyVigenere : ICryptographicTechnique<string, string>
    {

        public bool Test(int x, string rep) {
            int n = rep.Length;
            for(int i = 0; i < n; i++)
                if(i >= x)
                    if (rep[i] != rep[i-x])
                        return false;
            return true;
        }

        public string ExtractKey(string rep)
        {
            int n = rep.Length;
            for(int i = 1; i < n; i++) {
                if (Test(i, rep))
                {
                    var ret = rep.Substring(0,i);
                    return ret;
                }
            }
            return rep;
        }
        public string Analyse(string plainText, string cipherText)
        {
            int n = plainText.Length;
            plainText = plainText.ToLower();
            cipherText = cipherText.ToLower();
            char[] key = new char[n];
            for (int i = 0; i < n; i++)
            {
                int x = cipherText[i] - plainText[i] + 26;
                x %= 26;
                key[i] = (char)(x + 'a');
            }
            var rep = new string(key);
            return ExtractKey(rep);
        }

        public string Decrypt(string cipherText, string key)
        {
            enc = -1;
            var ret = Encrypt(cipherText, key);
            enc = 1;
            return ret;
        }

        int enc = 1;
        public string Encrypt(string plainText, string key)
        {
            plainText = plainText.ToLower();
            key = key.ToLower();
            int n = plainText.Length;
            int m = key.Length;
            char[] ret = new char[n];
            for (int i = 0; i < n; i++)
            {
                int s = key[i % m] - 'a';
                int c = plainText[i] - 'a' + s * enc + 26;
                c %= 26;
                ret[i] = (char)(c + 'a');
            }
            return new string(ret);
        }
    }
}