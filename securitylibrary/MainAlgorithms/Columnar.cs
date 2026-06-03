using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class Columnar : ICryptographicTechnique<string, List<int>>
    {
        List<string> ToColumns(string plain, int x)
        {
            var cols = new string[x];
            for (int i = 0; i < plain.Length; i++)
                cols[i % x] += plain[i];
            return cols.ToList();
        }
        bool Check(string plain, string cipher, int x)
        {
            var cols = ToColumns(plain, x).OrderBy(c=>c).ToList();
            for (int i = 0; i < cols.Count; i++)
                if (!cipher.Contains(cols[i]))
                    return false;
            return true;
        }
        List<string> FindCols(string plain, string cipher)
        {
            for (int i = 1; i <= plain.Length; i++)
                if (Check(plain, cipher, i))
                        return ToColumns(plain, i);
            return null;
        }
        public List<int> Analyse(string plainText, string cipherText)
        {
            List<int> Key = new List<int>();
            plainText = plainText.ToLower();
            cipherText = cipherText.ToLower();
            var cols = FindCols(plainText, cipherText);
            int h = plainText.Length / cols.Count;
            foreach (var col in cols)
            {
                int res = -1;
                for (int i = 0; i < cipherText.Length; i++)
                    if (cipherText.Substring(i, col.Length).Equals(col))
                    {
                        res = i / h + 1;
                        break;
                    }

                if (res == -1)
                    return null;
                Key.Add(res);
            }
            return Key;
        }

        public string Decrypt(string cipherText, List<int> key)
        {
            var cipher = cipherText.ToLower();
            int n = cipher.Length;
            int m = key.Count;
            int h = n / m;
            int l = n % m;
            var cols = new string[m];
            int x = 1;
            while(cipher.Length != 0)
            {
                int col = -1;
                for (int i = 0; i < m; i++)
                    if (key[i] == x)
                        col = i;
                int size = h;
                if (l > col)
                    size++;
                cols[col] = cipher.Substring(0, size);
                x++;
                cipher = cipher.Substring(size);
            }
            var ret = "";
            for (int i = 0; i < n; i++)
                ret += cols[i % m][i/m];
            return ret;
        }
 
        public string Encrypt(string plainText, List<int> key)
        {
            plainText = plainText.ToLower();
            int n = plainText.Length;
            int m = key.Count();
            List<List<char>> cols = new List<List<char>>();
            for(int i = 0; i < m; i++)
                cols.Add(new List<char>());
            for(int i = 0; i < n; i++) {  
                int c = i % m;
                cols[key[c] - 1].Add(plainText[i]);
            }
            string ret = "";
            foreach(var s in cols)
            {
                foreach(var c in s)
                {
                    ret += c;
                }
            }
            return ret;
        }
    }
}
