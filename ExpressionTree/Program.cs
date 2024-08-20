public static class Program {



    public delegate void CallBack(string message);

    public static void DelegateMethod(string message) {
        Console.WriteLine(message);
    }


    public static void MethodWithCallback(int x, int y, CallBack callBack) {
        callBack("The number is: " + (x + y).ToString());
    }


    public static int Sum(int x, int y) => x + y;
    public static int Multiply(int x, int y) => x * y;

    public static int Factorial(int x) {
        if (x <= 1)
            return 1;
        return x * Factorial(x - 1);
    }

    public static void Main(String[] args) {
        CallBack handler = DelegateMethod;
        handler("Hello World");
        MethodWithCallback(1, 2, handler);


        Console.WriteLine(Factorial(9));
    }
}