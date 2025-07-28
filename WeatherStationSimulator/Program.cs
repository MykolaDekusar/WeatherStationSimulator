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
            string[] conditions = { "Solleggiato", "Piovoso", "Nuvoloso" };
            string[] weekDays = { "lunedì", "martedì", "mercoledì", "giovedì", "venerdì", "sabato", "domenica" };
            string[] weatherConditions = new string[days];
            Console.WriteLine("Inserisci il giorno corrente");
            string currentDay = Console.ReadLine().ToLower();



            Console.WriteLine("Inserisci la temperatura minima possibile");
            minTemp = int.Parse(Console.ReadLine());


            Console.WriteLine("Inserisci la temperatura massima possibile");
            maxTemp = int.Parse(Console.ReadLine());

            Random random = new Random();
            for (int i = 0; i < days; i++)
            {
                temperature[i] = random.Next(minTemp, maxTemp + 1);
                if (temperature[i] <= 0)
                {
                    weatherConditions[i] = "Nevoso";
                }
                else
                {
                    weatherConditions[i] = conditions[random.Next(conditions.Length)];
                }

                Console.WriteLine($"{CurrentDayCalculator(days, i, currentDay, weekDays)}: {temperature[i]} gradi ed è {weatherConditions[i]}\n");
            }

            Console.WriteLine($"\n\nTemperatura Media di tutti i giorni: {AverageTempCalculator(temperature)} gradi\n" +
                $"Temperatura minima: {MinTempCalculator(temperature)} gradi\n" +
                $"Temperatura massima: {MaxTempCalcualtor(temperature)} gradi\n" +
                $"La condizione più comune: {MostCommonWeatherCondition(weatherConditions)}");

            Console.ReadKey();
        }

        static double AverageTempCalculator(int[] temperatures)
        {
            double sum = 0;
            foreach (int temperature in temperatures)
            {
                sum += temperature;
            }
            double average = sum / temperatures.Length;

            return Math.Round(average, 2);
        }
        static string CurrentDayCalculator(int days, int i, string currentDay, string[] weekDays)
        {
            int currentDayIndex = 0;
            for (int j = 0; j < weekDays.Length; j++)
            {
                if (currentDay == weekDays[j])
                {
                    currentDayIndex = j;
                    break;
                }
            }
            int cycleIndex = (currentDayIndex + i) % weekDays.Length;
            return weekDays[cycleIndex];
        }

        static int MinTempCalculator(int[] temperatures)
        {
            int min = temperatures[0];
            foreach (int temperature in temperatures)
            {
                if (temperature < min)
                {
                    min = temperature;
                }
            }
            return min;
        }
        static int MaxTempCalcualtor(int[] temperatures)
        {
            int max = temperatures[0];
            foreach (int temperature in temperatures)
            {
                if (temperature > max)
                {
                    max = temperature;
                }
            }
            return max;
        }

        static string MostCommonWeatherCondition(string[] condition)
        {
            int counter = 0;
            string mostCommon = condition[0];
            for (int i = 0; i < condition.Length; i++)
            {
                int tempCounter = 0;
                for (int j = 0; j < condition.Length; j++)
                {
                    //Verifico quante altre condizioni uguali ci sono
                    if(condition[j] == condition[i])
                    {
                        tempCounter++;
                    }
                }
                if(counter < tempCounter)
                {
                    counter = tempCounter;
                    mostCommon = condition[i];
                }
            }

            return mostCommon;
        }
    }
}
