// Quiz2Joe
// Alias
using con = System.Console;

namespace Quiz2Joe
{
    class Quiz2Joe
    {
        static void Main(string[] args)
        {
            Greeting myGenericGreeting = new Greeting();

            Greeting myCustomGreeting = new Greeting("Joe Sedutto");
        }
    }

    class Greeting
    {
        public Greeting()
        {
            con.WriteLine("Hello, this is a generic greeting message.");
        }

        public Greeting(string name)
        {
            con
                .WriteLine($"Hello {
                    name}, this is a customized greeting message.");
        }
    }
}
