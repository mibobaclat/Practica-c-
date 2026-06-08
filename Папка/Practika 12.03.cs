namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pablo a = new Cartel(1);
            Cartel c = new Cartel(2);

            a.Scream();
            c.Scream();

            a.Print();
            c.Print();
        }
    }
    public abstract class Pablo
    {
        private int _id;

        public abstract string Type { get; }
        
        public Pablo(int id) 
        {
            _id = id;
        }
        public abstract void Scream();
        public virtual void Print()
        {
            Console.WriteLine($"I knew you're here{_id}");
        }

    }
    public class Cartel : Pablo
    {
        public Cartel(int id) : base(id) { }
        public override string Type { get { return "Papa"; } }
        public override void Scream()
        {
            Console.WriteLine("TACO TACO");
        }
        public override void Print()
        {
            Console.WriteLine("ALO ALO");
        }
    }
        
}
