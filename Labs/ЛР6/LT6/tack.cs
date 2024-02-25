/*/*
/*
 *
 *
 *1.	Для созданного в предыдущей лабораторной работе контейнерного класса реализовать методы, которые в качестве аргумента принимают делегат:
	метод сортировки;
	метод поиска;
	метод фильтрации.
2.	Для каждого делегата определить один метод и одно лямбда-выражение.
3.	Коллекция изменяется при удалении/добавлении элементов или при изменении одной из входящих в коллекцию ссылок, например, когда одной из ссылок присваивается новое значение. В этом случае в соответствующих методах или свойствах класса бросаются события. 
4.	При изменении данных объектов, ссылки на которые входят в коллекцию, значения самих ссылок не изменяются. Этот тип изменений не порождает событий. Для событий, извещающих об изменениях в коллекции, определяется свой делегат. События регистрируются в специальных классах-слушателях
5.	Для событий предусмотреть возможность подписки и отписки от события.
6.	Для обработки всех ошибочных ситуаций использовать конструкцию try…catch().
7.	В Main создать два экземпляра шаблонного класса-контейнера для разных типов данных. Работа с этими объектами должна демонстрироваться на следующих операциях: добавить – просмотреть – найти – удалить – найти – просмотреть. 
8.	Отладить и выполнить полученную программу. Проверить обработку исключительных ситуаций (например, чтение из пустого стека, дублирование объектов и т.п.).

 *
 *
 * 
 #2#
 using System;
using System.Collections.Generic;

// Класс элемента контейнера
public class ContainerItem<T>
{
    public T Data { get; set; }

    public ContainerItem(T data)
    {
        Data = data;
    }
}

// Контейнерный класс
public class Container<T>
{
    private List<ContainerItem<T>> items = new List<ContainerItem<T>>();

    // Делегат для метода сортировки
    public delegate void SortDelegate(List<ContainerItem<T>> items);

    // Делегат для метода поиска
    public delegate ContainerItem<T> SearchDelegate(T item);

    // Делегат для метода фильтрации
    public delegate List<ContainerItem<T>> FilterDelegate(Func<T, bool> predicate);

    // Событие изменения коллекции
    public event EventHandler CollectionChanged;

    // Метод добавления элемента
    public void Add(T item)
    {
        items.Add(new ContainerItem<T>(item));
        CollectionChanged?.Invoke(this, EventArgs.Empty);
    }

    // Метод просмотра
    public void Display()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item.Data);
        }
    }

    // Метод сортировки
    public void Sort(SortDelegate sortMethod)
    {
        sortMethod(items);
        CollectionChanged?.Invoke(this, EventArgs.Empty);
    }

    // Метод поиска
    public ContainerItem<T> Search(SearchDelegate searchMethod, T item)
    {
        return searchMethod(item);
    }

    // Метод фильтрации
    public List<ContainerItem<T>> Filter(FilterDelegate filterMethod, Func<T, bool> predicate)
    {
        return filterMethod(predicate);
    }
}

class Program1
{
    static void Main1(string[] args)
    {
        // Пример использования
        Container<int> intContainer = new Container<int>();
        intContainer.CollectionChanged += (sender, eventArgs) => Console.WriteLine("Collection changed!");

        // Добавляем элементы
        intContainer.Add(3);
        intContainer.Add(1);
        intContainer.Add(2);

        // Выводим элементы
        intContainer.Display();

        // Сортируем элементы
        intContainer.Sort(items => items.Sort((a, b) => a.Data.CompareTo(b.Data)));

        // Выводим отсортированные элементы
        intContainer.Display();

        // Поиск элемента
        var foundItem = intContainer.Search(item => item.Data == 2, 2);
        Console.WriteLine("Found item: " + foundItem.Data);

        // Фильтрация элементов
        var filteredItems = intContainer.Filter(
            predicate => predicate % 2 == 0,
            predicate => predicate.Data
        );

        Console.WriteLine("Filtered items:");
        foreach (var item in filteredItems)
        {
            Console.WriteLine(item.Data);
        }
    }
}
#1#/*
class Program
{
    public static void Main(String[] args)
    {
        Console.WriteLine(comparator(5, 4));
    }

    public delegate int CompareDelegate<in T>(T right, T left);
    public static int Compare<T>(T left, T right) where T: IComparable<T>
    {
        return left.CompareTo(right);
    }
    
    static CompareDelegate<int> comparator = Compare;
    
    
}
#1#

class Program1
{
    public static void Main1(String[] args)
    {
        
    }
}

class MyClass
{
    public delegate void SortDelegate();
    
    public SortDelegate Sort;

    public MyClass()
    {
        Sort = bubleSort;
    }

    public void bubleSort()
    {
        Console.WriteLine("sorted");
    } 
            
}*/