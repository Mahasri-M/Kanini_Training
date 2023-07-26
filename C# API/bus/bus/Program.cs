using bus;
class Program
{
    public static void Main(string[] args)
    {
        buses bus = new buses();
        bus.Openconn();
        //bus.createtable();
        //bus.insertable();
        bus.busmain();
    }
}