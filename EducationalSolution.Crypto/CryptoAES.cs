using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace EducationalSolution.Crypto {
    public class CryptoAES {
        private Aes _aes;
        public byte[] Key => _aes.Key;
        public byte[] IV => _aes.IV;
        
        public CryptoAES() {
            _aes = Aes.Create();
            _aes.GenerateKey();
            _aes.GenerateIV();
        }

        public byte[] Encrypt(string s) {
            ICryptoTransform cryptoTransform = _aes.CreateEncryptor(_aes.Key, _aes.IV);
            byte[] encryptedResult;

            using (MemoryStream ms = new MemoryStream()) {
                using (CryptoStream cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write)) {
                    using (StreamWriter sw = new StreamWriter(cs)) {
                        sw.Write(s);
                    }
                }
                encryptedResult = ms.ToArray();
            }
            return encryptedResult;
        }

        public string Decrypt(byte[] cipherText) {
            ICryptoTransform decryptoTransform = _aes.CreateDecryptor(_aes.Key, _aes.IV);
            string decryptedResult;

            using (MemoryStream ms = new MemoryStream(cipherText)) {
                using (CryptoStream cs = new CryptoStream(ms, decryptoTransform, CryptoStreamMode.Read)) {
                    using (StreamReader sr = new StreamReader(cs)) {
                        decryptedResult = sr.ReadToEnd();
                    }
                }
            }
            return decryptedResult;
        }
    }
}
