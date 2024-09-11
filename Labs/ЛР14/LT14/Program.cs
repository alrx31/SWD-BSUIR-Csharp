using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        var lines = File.ReadAllLines("..\\..\\..\\input.txt");

        var average = 0.0;
        var count = 0;

        foreach (var line in lines)
        {
            var parts = line.Split(' ');
            Console.WriteLine($"{parts[0]} {parts[1]} {parts[2]}");
            foreach (var part in parts)
            {
                if (int.TryParse(part, out var num))
                {
                    average += num;
                    count++;
                }
            }
        }
        average /= count;

        Console.WriteLine(average);
        Console.WriteLine(count);

        Console.ReadKey();

        Console.WriteLine("Enter data to write to file");
        while (true)
        {
            var data = Console.ReadLine();
            
            if(string.IsNullOrEmpty(data)) break;
            
            File.AppendAllText("..\\..\\..\\output.txt", data + Environment.NewLine);
        }
        Console.ReadKey();
    
        
        var dataRead = File.ReadAllLines("..\\..\\..\\output.txt");

        Console.WriteLine($"lines: {dataRead.Length}");
        Console.WriteLine("Words and letters in lines");

        for(int i = 0; i < dataRead.Length; i++)
        {
            var words = dataRead[i].Split(' ');
            Console.WriteLine($"Line {i + 1}: words: {words.Length}, letters: {dataRead[i].Length}");
        }

        Console.ReadKey();

        for(int i = 1; i <= 500; i++)
        {
            File.AppendAllText("..\\..\\..\\numbers.txt", dataRead + Environment.NewLine);
        }

        Console.ReadKey();


        Console.WriteLine("Enter number to save in file");
        var number = Console.ReadLine();
        File.WriteAllText("..\\..\\..\\s1.txt", number);
        Console.ReadKey();


        var numberRead = File.ReadAllText("..\\..\\..\\s1.txt");

        if(int.TryParse(numberRead, out var numberInt))
        {
            numberInt += 3;
            File.WriteAllText("..\\..\\..\\s2.txt", numberInt.ToString());
        }

        Console.ReadKey();


        // work with json
        string jsonFile = File.ReadAllText("..\\..\\..\\json.json");
        var dataJson = JsonSerializer.Deserialize<TestData>(jsonFile);
        Console.WriteLine(dataJson.name);
        Console.WriteLine(dataJson.age);
        Console.WriteLine(dataJson.weight);

        Console.ReadKey();

        var dataJsonNew = new TestData("new Alex", 19, 75.5f);
        var jsonNew = JsonSerializer.Serialize(dataJsonNew);
        File.WriteAllText("..\\..\\..\\jsonNew.json", jsonNew);
    }



    public record TestData(string name, int age, float weight);


}