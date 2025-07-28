namespace WeatherStationSimulator
{
    internal class Program
    {
        static int minTemp;
        static int maxTemp;
        static double averageTemp;
        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci il numero di giorni da simulare");
            int days = int.Parse(Console.ReadLine());
            int[] temperature = new int[days];
            string[] conditions = { "Solleggiato", "Piovoso", "Nuvoloso"};
            string[] weekDays = { "Lunedì", "Martedì", "Mercoledì", "Giovedì", "Venerdì", "Sabato", "Domenica" };
            string[] weatherConditions = new string[days];
            Console.WriteLine("Inserisci la temperatura minima possibile");
            minTemp = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci la temperatura massima possibile");
            maxTemp = int.Parse(Console.ReadLine());

            Random random = new Random();
            for (int i = 0; i < days; i++)
            {
                temperature[i] = random.Next(minTemp, maxTemp+1);
                if (temperature[i] <= 0)
                {
                    weatherConditions[i] = "Nevoso";
                }
                else
                {
                    weatherConditions[i] = conditions[random.Next(conditions.Length)];
                }
                Console.WriteLine(temperature[i]+" " + weatherConditions[i]);
            }

            Console.WriteLine("Temperatura Media di tutti i giorni: " + AverageTempCalculator(temperature) + "gradi");

        

            Console.ReadKey();

        }

        static double AverageTempCalculator(int[] temperatures)
        {
            int sum = 0;
            foreach (int temperature in temperatures)
            {
                sum += temperature;
            }
            double average = sum / temperatures.Length;
            
            return Math.Round(average, 2);
        }
    }
}
