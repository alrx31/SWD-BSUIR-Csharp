class Prigram
{
    public static void Main(string[] args)
    {
        //Написать метод, который на вход принимает строку,
        //состоящую из букв. Вернуть данный метод должен строку, в которой каждая буква заменена ее позицией в алфавите.



        string ChangeString(string str)
        {
            str = str.ToLower();
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string result = "";
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (str[i] == alphabet[j])
                    {
                        result += j + 1;
                    }
                }
            }

            return result;
        }

        Console.WriteLine("Enter a string");
        string input = Console.ReadLine();
        Console.WriteLine(ChangeString(input));




    }




}