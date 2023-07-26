using GenDel;

public delegate int MyDelegate();


class Program
{
    /*
    static void InvokeDelegate(MyDelegate del)
    {
        del("Hello World");
    }*/
    public static void Main(string[] args)
    {
        /* MyDelegate delobj1, delobj2;


         delobj1= DelUse1.Method1;
         //delobj1.Invoke("hello");

         delobj2 = DelUse2.Method2;
         //delobj1.Invoke("hi");

         InvokeDelegate(delobj1);

         InvokeDelegate(delobj2);
        */

        MyDelegate del1 = DelUse1.Method1;
        MyDelegate del2 = DelUse2.Method2;

       MyDelegate del = del1 + del2;
       // Console.WriteLine("after del1+del2");


       Console.WriteLine( del());
       // Console.WriteLine(del2());




        /*
        GenUse<int> intarr = new GenUse<int>(5);
        for (int i = 0;i<5;i++)
        {
            intarr.setarr(i,(i+1)*10);
        }
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(intarr.getarr(i));
        }

        GenUse<char> chararr = new GenUse<char>(5);

        
        for (int i = 0; i < 5; i++)
        {
            chararr.setarr(i, Convert.ToChar(i+ 65));
        }
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(chararr.getarr(i));
        }*/
        /*
        GenUse<int> guint = new GenUse<int>(10);

        GenUse<double> gudbl = new GenUse<double>(32.8776655);

        GenUse<string> gustr = new GenUse<string>("hello");

        Console.WriteLine(gudbl.Number);
        Console.WriteLine(gustr.Number);
        Console.WriteLine(guint.Number);
        */
    }
}