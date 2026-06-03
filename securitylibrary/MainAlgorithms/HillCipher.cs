using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    /// <summary>
    /// The List<int> is row based. Which means that the key is given in row based manner.
    /// </summary>
    public class HillCipher :  ICryptographicTechnique<List<int>, List<int>>
    {
        public List<int> Analyse(List<int> plainText, List<int> cipherText)
        {
            throw new NotImplementedException();
        }


        public List<int> Decrypt(List<int> cipherText, List<int> key)
        {
            throw new NotImplementedException();
        }


        public List<int> Encrypt(List<int> plainText, List<int> key)
        {
            int len;
            if (key.Count == 9)
                len = 3;
            else len = 2;
            List<int> ret = new List<int>();
            List<int>[] parts = new List<int>[plainText.Count / len];
            List<int>[] vecs = new List<int>[len];
            for(int i = 0; i < len; i++)
            {
                vecs[i] = new List<int>();
                for (int j = len * i; j < len * i + len; j++)
                    vecs[i].Add(key[j]);
            }
            for (int i = 0; i < plainText.Count; i += len) {
                parts[i / len] = new List<int>();
                for (int j = i; j < i + len; j++)
                    parts[i / len].Add(plainText[j]);
            }

            foreach(var part in parts)
            {
                for(int i = 0; i < len; i++)
                {
                    int r = 0;
                    for (int j = 0; j < len; j++)
                        r += part[j] * vecs[i][j];
                    ret.Add(r % 26);
                }
            }
            return ret;
        }


        public List<int> Analyse3By3Key(List<int> plainText, List<int> cipherText)
        {
            throw new NotImplementedException();
        }

    }
}
