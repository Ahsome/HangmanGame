using System;
using System.Collections.Generic;
public class Class1
{
    public static void Test()
    {
        int numberOfRepeats = 0;
        int repeats = int.Parse(Console.ReadLine());
        double T;
        double F = 0;
        double S = 1;
        double numberToCheck = double.Parse(Console.ReadLine());
        while (repeats > 0)
        {
            T = S;
            S += F;
            F = T;
            numberOfRepeats++;
            if (S == numberToCheck)
            {
                Console.WriteLine(numberOfRepeats+1);
                numberToCheck = double.Parse(Console.ReadLine());
                numberOfRepeats = 0;
                repeats--;
                T = 0;
                F = 0;
                S = 1;
            }
        }
    }
}
