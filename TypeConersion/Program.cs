class Program
{
    static void Main(string[] args)
    {
        byte a = 10; //Convert this value into "short" type (assign into another short type of variable)
        int b = 10; //Convert this value into "short" type (assign into another short type of variable)
        string c = "10.34"; //Convert this value into "double" type using Parse  //Also, convert the same value into "decimal" type  using TryParse
        decimal d; //Convert this value into "string" type (assign into another string type of variable)

        short byteToshortValue = a;
        short intToShortValue = (short)b;
        double stringParseToDouble = double.Parse(c);
        bool valid = double.TryParse(c, out double value);

        Console.WriteLine("byte to short: " + byteToshortValue);
        Console.WriteLine("int to short: " + intToShortValue);
        Console.WriteLine("string parse to double: " + stringParseToDouble);

        if (valid)
        {
            Console.WriteLine("string tryParse to double: " + value);
        }
    }
}