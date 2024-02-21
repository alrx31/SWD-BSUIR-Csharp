using System.ComponentModel;

namespace ЛР4
{
    public class Program
    {
        public static void Main(String[] arg)
        {
            
            MushroomContainer container = new MushroomContainer();
            container.FillArray(3);
            container.Print();
            container.DeleteByName("Name");
            container.Print();

            Poganka poganka = new Poganka("Poganka", 5, ClassMush.Poisonous, 100);
            poganka.Print();
            redMush redMush = new redMush("redMush", 5, ClassMush.Inedible, "poison", "no");
            redMush.Print();
            WhiteMush whiteMush = new WhiteMush("whiteMush", 5, ClassMush.Edible, "good", "good");
            whiteMush.Print();

            InedibleMushroom inedibleMushroom = new InedibleMushroom("inedibleMushroom", 5, ClassMush.Inedible, "poison");
            inedibleMushroom.Print();
            EdibleMushroom edibleMushroom = new EdibleMushroom("edibleMushroom", 5, ClassMush.Edible, "good");
            edibleMushroom.Print();

        }
        enum ClassMush
        {
            Poisonous,
            Edible,
            Inedible
        }

        class Mushroom
        {
            public string Name { get; set; }
            public int Size { get; set; }
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
                foreach (var item in Mushrooms)
                {
                    item.Print();
                }
            }

            public void deleteByIndex(int index)
            {
                for (int i = index; i < Mushrooms.Length - 1; i++)
                {
                    Mushrooms[i] = Mushrooms[i + 1];
                }
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
            class PoisenousMushroom : Mushroom{
                public string PoisonousSubstance { get; set; }
                public int dangerLevel { get; set; }
                public PoisenousMushroom() { }
                 public PoisenousMushroom(string name, int size, ClassMush classMush) : base(name, size, classMush)
                {
                }
            }

            class Poganka : PoisenousMushroom
            {
                public int Population { get; set; }
                public Poganka() { }
                public Poganka(string name, int size, ClassMush classMush, int population) : base(name, size, classMush)
                {
                    PoisonousSubstance = "Amanitin";
                    dangerLevel = 5;
                    Population = population;
                }
            }

            class InedibleMushroom : Mushroom
            {
                public string Reason { get; set; }
                public InedibleMushroom() { }
                public InedibleMushroom(string name, int size, ClassMush classMush, string reason) : base(name, size, classMush)
                {
                    Reason = reason;
                }
            }
            class redMush : InedibleMushroom
            {
                public string howUtilyze { get; set; }
                public redMush() { }
                public redMush(string name, int size, ClassMush classMush, string reason, string howUtilyze) : base(name, size, classMush, reason)
                {
                    this.howUtilyze = howUtilyze;
                }
                
            }

            class EdibleMushroom : Mushroom
            {
                public string callorize { get; set; }
                public EdibleMushroom() { }
                public EdibleMushroom(string name, int size, ClassMush classMush, string recipe) : base(name, size, classMush)
                {
                    callorize = recipe;
                }
            }


            class  WhiteMush : EdibleMushroom
            {
                public string reciept { get; set; }
                public WhiteMush() { }
                public WhiteMush(string name, int size, ClassMush classMush, string recipe, string reciept) : base(name, size, classMush, recipe)
                {
                    this.reciept = reciept;
                }
            } 

    }
}