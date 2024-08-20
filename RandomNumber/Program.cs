using RandomNumber;

public class Program {
    public static void Main(string[] args) {
        
        for (int i=0; i<10; i++) {
            //Console.WriteLine(RandomLib.GenerateRandomBytes(32));
            Console.WriteLine($"Random number {i}: {Convert.ToBase64String(RandomLib.GenerateRandomBytes(32))}");
        }
    }
}