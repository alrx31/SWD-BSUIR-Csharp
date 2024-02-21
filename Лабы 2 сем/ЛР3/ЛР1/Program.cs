using System.ComponentModel;

namespace ЛР1 { 
public class Program
    {
        public static void Main(String[] arg)
        {
            MushroomContainer container = new MushroomContainer();
            while (true) {
                Console.WriteLine("Choose action:");
                Console.WriteLine("1. Create array of objects");
                Console.WriteLine("2. Fill array of objects");
                Console.WriteLine("3. Print array of objects");
                Console.WriteLine("4. Delete object from array");
                Console.WriteLine("5. Add object to array");
                Console.WriteLine("6. Exit");
                int action = Convert.ToInt32(Console.ReadLine());
                switch (action){
                    case 1:
                        Console.WriteLine("Enter size of array: ");
                        int size = Convert.ToInt32(Console.ReadLine());
                        container = new MushroomContainer(size);
                        break;
                    case 2:
                        Console.WriteLine("Enter size of array: ");
                        size = Convert.ToInt32(Console.ReadLine());
                        container.FillArray(size);
                        break;
                    case 3:
                        container.Print();
                        break;
                    case 4:
                        Console.WriteLine("By name or by id ? (name/id)");
                        string action1 = Console.ReadLine();
                        if (action1 == "name")
                        {
                            Console.WriteLine("Enter name: ");
                            string name = Console.ReadLine();
                            container.DeleteByName(name);
                        }
                        else
                        {
                            Console.WriteLine("Enter id: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            container.deleteByIndex(id);
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter name: ");
                        string name1 = Console.ReadLine();
                        Console.WriteLine("Enter size: ");
                        int size1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter class: ");
                        ClassMush classMush = (ClassMush)Enum.Parse(typeof(ClassMush), Console.ReadLine());
                        container.AddMushroom(new Mushroom(name1, size1, classMush));
                        break;
                    case 6:
                        Console.WriteLine("Goodbye!");
                        return;   
                }
            }
        }
        enum ClassMush
        {
            Poisonous,
            Edible,
            Inedible
        }

        class Mushroom {
            
            public string Name { get; set; }
            public int Size { get; set; }
            [DisplayName("Class")]
            public ClassMush ClassMush { get; set; }

            public Mushroom() { }
            public Mushroom(string name, int size, ClassMush classMush) => (Name, Size, ClassMush) = (name, size, classMush);
            public void Print() => Console.WriteLine($"Name: {Name}, Size: {Size}, Class: {ClassMush};");
        }

        class MushroomContainer
        {
            public Mushroom[] Mushrooms { get; set; }
            public MushroomContainer() { }
            public MushroomContainer(int size) => Mushrooms = new Mushroom[size];
            public MushroomContainer(Mushroom[] mushrooms) => Mushrooms = mushrooms;


            public void AddMushroom(Mushroom obj)
            {
                Mushrooms[Mushrooms.Length] = obj;
            }

            public void Print()
            {
                if(Mushrooms.Length != 0)
                {
                    foreach (var item in Mushrooms)
                    {
                        item.Print();
                    }
                }
            }

            public void deleteByIndex(int index)
            {
                for (int i = index; i < Mushrooms.Length - 1; i++)
                {
                    Mushrooms[i] = Mushrooms[i + 1];
                }
                Mushrooms[Mushrooms.Length - 1] = null;
                
            }

            public void DeleteByName(string name)
            {
                for (int i = 0; i < Mushrooms.Length; i++)
                {
                    if (Mushrooms[i].Name == name)
                    {
                        deleteByIndex(i);
                    }
                }
            }

            public void FillArray(int size)
            {
                Mushrooms = new Mushroom[size];
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine("Enter name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter size: ");
                    int size1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter class: ");
                    ClassMush classMush = (ClassMush)Enum.Parse(typeof(ClassMush), Console.ReadLine());
                    Mushrooms[i] = new Mushroom(name, size1, classMush);
                }
            }
        }
    }
}