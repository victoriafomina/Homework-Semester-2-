namespace SetGeneric
{
    public class Program
    {
        static void Main(string[] args)
        {
            var set = new Set<int>();
            set.Add(5);
            set.Add(7);
            set.Add(-1);
            set.Add(-3);
            System.Console.WriteLine(set[0]);
            System.Console.WriteLine(set[1]);
            System.Console.WriteLine(set[2]);
            System.Console.WriteLine(set[3]);
        }
    }
}
