namespace WeatherStationSimulator
{
    internal class Program
    {
        static int minTemp;
        static int maxTemp;
        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci il numero di giorni da simulare");
            int days = int.Parse(Console.ReadLine());
            int[] temperature = new int[days];
            string[] conditions = { "Solleggiato", "Piovoso", "Nuvoloso", "Nevoso" };
            string[] weatherConditions = new string[days];
            Console.WriteLine("Inserisci la temperatura minima possibile");
            minTemp = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci la temperatura massima possibile");
            maxTemp = int.Parse(Console.ReadLine());

            Random random = new Random();
            for (int i = 0; i < days; i++)
            {
                temperature[i] = random.Next(minTemp, maxTemp+1);
                weatherConditions[i] = conditions[random.Next(conditions.Length)];
                Console.WriteLine(temperature[i]);
            }

            

            Console.ReadKey();

        }
    }
}
