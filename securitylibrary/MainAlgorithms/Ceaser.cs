using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class Ceaser : ICryptographicTechnique<string, int>
    {
        char Add(char x, int v)
        {
            char a = 'A';
            if (x >= 'a' && x <= 'z')
                a = 'a';
            return (char)((x - a + v + 26) % 26 + a);
            
        }
        public string Encrypt(string plainText, int key)
        {
            int n = plainText.Length;
            string encryptedText = string.Concat(plainText.Select(c => Add(c, key)));
            return encryptedText;
        }

        public string Decrypt(string cipherText, int key)
        {
            return Encrypt(cipherText, -key);
        }

        public int Analyse(string plainText, string cipherText)
        {
            plainText = plainText.ToLower();
            cipherText = cipherText.ToLower();
            return (cipherText.FirstOrDefault(c => c >= 'a' && c <='z') - plainText.FirstOrDefault(c => c >= 'a' && c <= 'z') + 26) % 26;
        }
    }
}
