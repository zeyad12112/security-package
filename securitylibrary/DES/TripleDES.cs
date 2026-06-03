using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary.DES
{
    /// <summary>
    /// If the string starts with 0x.... then it's Hexadecimal not string
    /// </summary>
    public class TripleDES : ICryptographicTechnique<string, List<string>>
    {

        public string Decrypt(string cipherText, List<string> key)
        {
            var des = new DES();
            cipherText = des.Decrypt(cipherText, key[0]);
            cipherText = des.Encrypt(cipherText, key[1]);
            if(key.Count == 3)
                cipherText = des.Decrypt(cipherText, key[2]);
            else
                cipherText = des.Decrypt(cipherText, key[0]);
            return cipherText;
        }

        public string Encrypt(string plainText, List<string> key)
        {
            var des = new DES();
            plainText = des.Encrypt(plainText, key[0]);
            plainText = des.Decrypt(plainText, key[1]);
            if (key.Count == 2)
                plainText = des.Encrypt(plainText, key[0]);
            else
                plainText = des.Encrypt(plainText, key[2]);
            return plainText;
        }

        public List<string> Analyse(string plainText,string cipherText)
        {
            throw new NotSupportedException();
        }

    }
}
