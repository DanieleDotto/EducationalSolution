using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hashing {
    public static class HashingLib {
        public static byte[] ComputeHashSHA512(byte[] toBeHashed) {
            return SHA512.HashData(toBeHashed);
        }


        public static byte[] ComputeHmacSha256(byte[] toBeHashed, byte[] key) {
            return HMACSHA256.HashData(key, toBeHashed);
        }

        public static byte[] HashPassword(byte[] password) {
            int saltLength = 32;
            byte[] salt = RandomNumberGenerator.GetBytes(saltLength);
            int numberOfRounds = 100000;
            HashAlgorithmName hashAlgorithmName = HashAlgorithmName.SHA256;
            int outputLength = 32;
            return Rfc2898DeriveBytes.Pbkdf2(password, salt, numberOfRounds, hashAlgorithmName, outputLength);
        }




        
    }
}
