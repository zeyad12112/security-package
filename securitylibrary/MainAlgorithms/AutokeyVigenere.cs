using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class AutokeyVigenere : ICryptographicTechnique<string, string>
    {

        public bool Test(string plain, string cipher, string key, int x)
        {
            var part = key.Substring(0, x);
            var enc = Encrypt(plain, part);
            if (enc.Equals(cipher))
                return true;
            return false;
        }

        public string Analyse(string plainText, string cipherText)
        {
            plainText = plainText.ToLower();
            cipherText = cipherText.ToLower();
            var rep = new RepeatingkeyVigenere();
            var init = rep.Analyse(plainText, cipherText);
            int n = init.Length;
            for(int i = 0; i < n; i++)
            {
                if (Test(plainText, cipherText, init, i + 1))
                    return init.Substring(0, i + 1);
            }
            return null;
        }

        public string Decrypt(string cipherText, string key)
        {
            cipherText = cipherText.ToLower();
            key = key.ToLower();
            int n = cipherText.Length;
            int m = key.Length;
            char[] ret = new char[n];
            for(int i = 0; i < m; i++) { 
                int x = cipherText[i] - 'a';
                x -= key[i] - 'a';
                x = (x + 26) % 26;
                ret[i] = (char)(x + 'a');
            }
            for(int i = m; i < n; i++)
            {
                int x = ret[i - m] - 'a';
                x = (cipherText[i] - 'a' - x + 26) % 26;
                ret[i] = (char)('a' +  x);
            }
            return new string(ret);
        }
        public string Encrypt(string plainText, string key)
        {
            plainText = plainText.ToLower();
            key = key.ToLower();
            int n = plainText.Length;
            int m = key.Length;
            char[] ret = new char[n];
            for (int i = 0; i < n; i++)
            {
                int s = 0;
                if (i < m)
                    s = key[i] - 'a';
                else 
                    s = plainText[i - m] - 'a';
                int c = plainText[i] - 'a' + s;
                c %= 26;
                ret[i] = (char)(c + 'a');
            }
            return new string(ret);
        }
    }
}
