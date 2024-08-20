using EducationalSolution.Crypto;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
public class Program {
    public static void ListAllDirectories(string path) {
        IEnumerable<string> listOfDirectories = Directory.EnumerateDirectories(path);
        foreach (string dir in listOfDirectories) {
            Console.WriteLine(dir);
        }
    }

    public static void ListAllFiles(string path) {
        IEnumerable<string> files = Directory.EnumerateFiles(path);
        foreach (string file in files) {
            Console.WriteLine(file);
        }
    }

    public static void ListAllFilesRec(string path) {
        IEnumerable<string> files = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories);
        foreach (string file in files) {
            Console.WriteLine(file);
        }
    }

    public static void Main(string[] args) {

        CryptoAES cryptoAES = new CryptoAES();
        byte[] encryptedText = cryptoAES.Encrypt("Encrypt me!");
        Console.WriteLine("Testo crittografato (base64): " + Convert.ToBase64String(encryptedText));
        string decryptedText = cryptoAES.Decrypt(encryptedText);
        Console.WriteLine("Testo decrittografato: " + decryptedText);
    }
}