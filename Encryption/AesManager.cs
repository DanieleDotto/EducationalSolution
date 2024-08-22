using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encryption {
    public static class AesManager {

        public static byte[] EncryptAes(byte[] dataToEncrypt) {
            Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            aes.Key = RandomNumberGenerator.GetBytes(64);
            aes.IV = RandomNumberGenerator.GetBytes(32);

            using (MemoryStream ms = new MemoryStream()) {
                CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                cs.FlushFinalBlock();

                byte[] encryptedBytes = ms.ToArray();

                return encryptedBytes;
            }
        }

        public static byte[] DecryptAes(byte[] dataToDecrypt) {
            Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            aes.Key = RandomNumberGenerator.GetBytes(64);
            aes.IV = RandomNumberGenerator.GetBytes(32);

            using (MemoryStream ms = new MemoryStream()) {
                CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                cs.FlushFinalBlock();

                byte[] decryptedBytes = ms.ToArray();

                return decryptedBytes;
            }
        }
    }
}
