using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class PlayFair : ICryptographic_Technique<string, string>
    {
        public string Decrypt(string cipherText, string key)
        {
            delta = -1;
            var dec = Encrypt(cipherText, key);
            delta = 1;
            string ret = "";
            for(int i = 0; i < dec.Length; i++)
            {
                if(i % 2 ==  0 || dec[i] != 'x')
                {
                    ret += dec[i];
                    continue;
                }
                if (i + 1 == dec.Length || dec[i - 1] == dec[i + 1])
                    continue;
                ret += dec[i];
            }
            return ret;
        }
        (int, int) Find(char[,] matrix, char c)
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (matrix[i, j] == c)
                        return (i, j);
            return (-1, - 1);
        }
        int delta = 1;
        public string Encrypt(string plainText, string key)
        {
            int n = plainText.Length;
            key = key.ToLower();
            plainText = plainText.ToLower();
            key.Replace('j', 'i');
            key = new string(key.Distinct().ToArray());
            char[,] matrix = new char[5, 5];
            for (int i = 0; i < 26; i++)
            {
                char c = (char)('a' + i);
                if (c == 'j')
                    continue;
                if (!key.Contains(c))
                    key += c;
            }
            for (int i = 0; i < key.Length; i++)
            {
                int x = i / 5;
                int y = i % 5;
                matrix[x,y] = key[i];
            }
            List<char> moddedPlain= new List<char>();
            moddedPlain.Add(plainText[0]);
            for(int i = 1; i < n; i++)
            {
                char c = plainText[i];
                if (c == plainText[i - 1] && moddedPlain.Count() % 2 == 1)
                    moddedPlain.Add('x');
                moddedPlain.Add(c);
            }
            if (moddedPlain.Count % 2 == 1)
                moddedPlain.Add('x');
            int m = moddedPlain.Count;
            char[] ret = new char[m];
            for(int i = 0; i < m; i += 2)
            {
                char a = moddedPlain[i];
                char b = moddedPlain[i + 1];
                int i1, j1, i2, j2;
                (i1, j1) = Find(matrix, a);
                (i2, j2) = Find(matrix, b);
                if (i1 == i2) {
                    j1 = (j1 + delta + 5) %5;
                    j2 = (j2 + delta + 5) % 5;
                }
                else if (j1 == j2)
                {
                    i1 = (i1 + delta + 5) %5;
                    i2 = (i2 + delta + 5) % 5;
                }
                else
                {
                    (j1, j2) = (j2, j1);
                }
                a = matrix[i1, j1];
                b = matrix[i2, j2];
                ret[i] = a;
                ret[i + 1] = b;
            }
            return new string(ret);
        }
    }
}
