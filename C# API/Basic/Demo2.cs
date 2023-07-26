using System;
class Demo2
{ 
    public void Big2Num()
    {
        int num1, num2;

        Console.WriteLine("Enter 2 numbers");
        num1 = Convert.ToInt32(Console.ReadLine());
        num2 = Convert.ToInt32(Console.ReadLine());
        if (num1 == num2)
            Console.WriteLine("Both are equal");
        else if (num2 > num1)
            Console.WriteLine(num2 + " is big");
        else
            Console.WriteLine(num1 + " is big");
    }
    public void Big3Num()
    {
        int num1, num2, num3;

        Console.WriteLine("Enter 3 numbers");
        num1 = Convert.ToInt32(Console.ReadLine());
        num2 = Convert.ToInt32(Console.ReadLine());
        num3 = Convert.ToInt32(Console.ReadLine());
        if ((num1 == num2) && (num2 == num3))
            Console.WriteLine("All are equal");
        else if ((num1 > num2) && (num1 > num3))
            Console.WriteLine(num1 + " is big");
        else if ((num2 > num3) && (num2 > num1))
            Console.WriteLine(num2 + " is big");
        else 
            Console.WriteLine(num3 + " is big");
    }
    public int loopfn(int max)
    {
        int sum = 0;
         for(int cou = 1 ; cou <= max; cou++) 
        {
            sum += Convert.ToInt32(
                Math.Pow(cou, 3));
        }  
        return sum;
    }
    public void foreachfn(string s1)
    {
        foreach ( char s in s1 )
        {
            Console.WriteLine(s);
        }
    }
    public void arrdisp()
    {
        string[] nums = { "Tulu", "Tamil", "Telugu" };

        Array.Sort(nums);
        foreach (string n in nums) 
        {
            Console.WriteLine(n);
        }
    }
}


