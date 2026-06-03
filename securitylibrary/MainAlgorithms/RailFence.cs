using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class RailFence : ICryptographicTechnique<string, int>
    {
        public int Analyse(string plainText, string cipherText)
        {
            int n = plainText.Length;
            plainText = plainText.ToLower();
            cipherText = cipherText.ToLower();
            for(int i = 0; i < n; i++)
            {
                int key = i + 1;
                if (Encrypt(plainText, key).Equals(cipherText))
                    return key;
            }
            return 0;
        }

        string Merge(Dictionary<int, List<char>> fence) {
            var segments = fence.Values.Select(v => new string(v.ToArray())).ToList();
            return string.Concat(segments);
        }

        public string Decrypt(string cipherText, int key)
        {
            int n = cipherText.Length;
            Dictionary<int, List<int>> fence = new Dictionary<int, List<int>>();
            int x = 0;
            int delta = 1;
            for (int i = 0; i < n; i++)
            {
                if (!fence.ContainsKey(x))
                    fence.Add(x, new List<int>());
                fence[x].Add(i);
                x += delta;
                x %= key;
            }
            var order = fence.Values.SelectMany(v => v).ToList();
            var ret = new char[n];
            for(int i = 0; i < n; i++)
            {
                int pos = order[i];
                ret[pos] = cipherText[i];
            }
            return new string(ret);
        }

        public string Encrypt(string plainText, int key)
        {
            Dictionary<int, List<char>> fence = new Dictionary<int, List<char>>();
            int x = 0;
            int delta = 1;
            for(int i = 0; i < plainText.Length; i++)
            {
                if(!fence.ContainsKey(x))
                    fence.Add(x, new List<char>());
                fence[x].Add(plainText[i]);
                x += delta;
                x %= key;
            }
            return Merge(fence);
        }
    }
}
