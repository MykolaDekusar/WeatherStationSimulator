namespace WeatherStationSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci il numero di giorni da simulare");
            int days = int.Parse(Console.ReadLine());
            int[] temperature = new int[days];
            string[] conditions = { "Solleggiato", "Piovoso", "Nuvoloso", "Nevoso" };
            string[] weatherConditions = new string[days];


            Console.ReadKey();

        }
    }
}
