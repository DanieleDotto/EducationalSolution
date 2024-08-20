using Hashing;
using System.Text;

public class Program {
    public static void Main(string[] args) {
        string s = "Hello world!";
        byte[] b = Encoding.UTF8.GetBytes(s);
        byte[] digest = HashingLib.ComputeHashSHA512(b);

        string digestString = Convert.ToBase64String(digest);
        Console.WriteLine(digestString);
        Console.WriteLine(digest.Length);
    }
}