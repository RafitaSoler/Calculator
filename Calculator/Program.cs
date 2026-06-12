using CalculatorLibrary;

class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");

        Calculator calculator = new Calculator();
        while (!endApp)
        {
            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\t0 - Addition");
            Console.WriteLine("\t1 - Substraction");
            Console.WriteLine("\t2 - Multiplication");
            Console.WriteLine("\t3 - Division");
            Console.WriteLine("\t4 - Exponentiation");
            Console.WriteLine("\t5 - SquareRoot");
            Console.WriteLine("\t6 - 10x");
            Console.WriteLine("\t7 - Sin");
            Console.WriteLine("\t8 - Cos");
            Console.WriteLine("\t9 - Tan");
            Console.Write("Your option? ");

            string? op = Console.ReadLine();

            int cleanOp = -1;
            while (!int.TryParse(op, out cleanOp) || cleanOp < 0 || cleanOp > 9)
            {
                Console.Write("This is not valid input. Please enter a numeric value between 0 and 9: ");
                op = Console.ReadLine();
            }

            string? numInput1 = "";
            string? numInput2 = "";
            double result = 0;

            Console.Write("Type a number, and then press Enter: ");
            numInput1 = Console.ReadLine();

            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                numInput1 = Console.ReadLine();
            }

            double cleanNum2 = double.NaN;
            // Operators 0 to 4 are binary so they need a second number. 5 to 9 are unary
            if (cleanOp < 5)
            {
                Console.Write("Type another number, and then press Enter: ");
                numInput2 = Console.ReadLine();

                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not valid input. Please enter a numeric value: ");
                    numInput2 = Console.ReadLine();
                }
            }

            try
            {
                result = calculator.DoOperation(cleanNum1, cleanNum2, cleanOp);

                if (double.IsNaN(result))
                {
                    Console.WriteLine("This operation will result in a mathematical error.\n");
                }
                else
                {
                    Console.WriteLine("Your result: {0:0.##}\n", result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
            }
            Console.WriteLine("------------------------\n");

            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("\n");
        }

        calculator.Finish();
        return;
    }
}