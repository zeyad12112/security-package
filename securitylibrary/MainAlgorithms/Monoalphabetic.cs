using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class Monoalphabetic : ICryptographicTechnique<string, string>
    {
        public string Analyse(string plainText, string cipherText)
        {
            int n = plainText.Length;
            plainText = plainText.ToLower();
            cipherText = cipherText.ToLower();
            char[] key = new char[26];
            for(int i = 0; i < n; i++)
            {
                int pos = plainText[i] - 'a';
                char val = cipherText[i];
                key[pos] = val;
            }
            for(int i = 0; i < 26; i++)
            {
                if (key[i] == '\0')
                    for(char c = 'a'; c <= 'z'; c++)
                    {
                        if (key.Contains(c))
                            continue;
                        key[i] = c;
                        break;
                    }
            }
            return new string(key);
        }

        public string Decrypt(string cipherText, string key)
        {
            char[] revKey = new char[26];
            for(int i = 0; i < 26; i++)
                revKey[key[i] - 'a'] = (char)(i + 'a');
            return Encrypt(cipherText, new string(revKey));
        }

        public string Encrypt(string plainText, string key)
        {
            plainText = plainText.ToLower();
            int n = plainText.Length;
            char[] cipher = new char[n];
            for(int i = 0; i < n; i++)
            {
                int c = plainText[i] - 'a';
                cipher[i] = key[c];
            }
            return new string(cipher);
        }

        /// <summary>
        /// Frequency Information:
        /// E   12.51%
        /// T	9.25
        /// A	8.04
        /// O	7.60
        /// I	7.26
        /// N	7.09
        /// S	6.54
        /// R	6.12
        /// H	5.49
        /// L	4.14
        /// D	3.99
        /// C	3.06
        /// U	2.71
        /// M	2.53
        /// F	2.30
        /// P	2.00
        /// G	1.96
        /// W	1.92
        /// Y	1.73
        /// B	1.54
        /// V	0.99
        /// K	0.67
        /// X	0.19
        /// J	0.16
        /// Q	0.11
        /// Z	0.09
        /// </summary>
        /// <param name="cipher"></param>
        /// <returns>Plain text</returns>
        public string AnalyseUsingCharFrequency(string cipher)
        {
            string plain = "ETAOINSRHLDCUMFPGWYBVKXJQZ";
            var freq = new Dictionary<char, int>();
            foreach(var c in cipher)
            {
                if (!freq.ContainsKey(c))
                    freq.Add(c, 0);
                freq[c]++;
            }
            List<(char, int)> vals = new List<(char, int)>();
            foreach(var kv in freq)
            {
                vals.Add((kv.Key, kv.Value));
            }
            var ct = new string(vals.OrderByDescending(v => v.Item2)
                .Select(v=>v.Item1).ToArray());
            string key =  Analyse(plain, ct);
            return Decrypt(cipher, key);
        }
    }
}
