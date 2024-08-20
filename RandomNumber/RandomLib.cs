using System.Security.Cryptography;

namespace RandomNumber {
    public static class RandomLib {
        
        public static byte[] GenerateRandomBytes(int length) {
            return RandomNumberGenerator.GetBytes(length);
        }

        public static int GenerateRandomNumber(int length) {
            return RandomNumberGenerator.GetInt32(length);
        }
    }
}
