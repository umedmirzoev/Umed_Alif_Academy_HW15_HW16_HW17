var turnOn = true;
#region Homework 15
/*
 * ДЗ (практика):
 - Разработайте примеры по каждому принципу ООП, и опишите в комментариях каждый принцип, своими словами.
 - Разработайте пример по использованию исключений, создание своих исключений, 
   обработка исключений в try...catch...finally блоке.
 */

// ------------------- Инкапсуляция -----------------------
public class Person
{
    private string name;

    public void SetName(string newName)
    {
        name = newName;
    }

    public string GetName()
    {
        return name;
    }
}

// Наследование
public class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal is making a sound");
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Dog is barking");
    }
}

// ------------------- Полиморфизм --------------------------
public class Shape
{
    public virtual void Draw()
    {
        Console.WriteLine("Drawing a shape");
    }
}

public class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a circle");
    }
}

public class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a rectangle");
    }
}

// ------------------- Исключение ----------------------------
public class CustomException : Exception
{
    public CustomException(string message) : base(message)
    {
    }
}

public class Calculator
{
    public int Divide(int dividend, int divisor)
    {
        try
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }
            if (divisor == 1)
            {
                throw new CustomException("Dividing by 1 is not allowed");
            }

            return dividend / divisor;
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (CustomException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Division operation completed");
        }

        return 0;
    }
}
#endregion

#region Homework 16
/*
 * ДЗ (практика):
 - Создайте консольный проект.
 - Разработайте пример для каждого принципа SOLID, как отдельный пример.
 - Опишите приципы SOLID своими словами.
 */

// ------------------ Single Responsibility Principle (SRP) -------------------
public class Customer
{
    public void AddCustomer()
    {
        // Логика добавления нового клиента в базу данных
    }

    public void UpdateCustomer()
    {
        // Логика обновления информации о клиенте в базе данных
    }

    public void DeleteCustomer()
    {
        // Логика удаления клиента из базы данных
    }
}

// ------------------ Open/Closed Principle (OCP) -----------------------------
public interface IShape
{
    double CalculateArea();
}

public class RectangleShape : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public double CalculateArea()
    {
        return Width * Height;
    }
}

public class CircleShape : IShape
{
    public double Radius { get; set; }

    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

// ------------------ Liskov Substitution Principle (LSP) ----------------------

public class Vehicle
{
    public virtual void StartEngine()
    {
        Console.WriteLine("Engine started");
    }
}

public class Car : Vehicle
{
    public override void StartEngine()
    {
        Console.WriteLine("Car engine started");
    }
}

public class Motorcycle : Vehicle
{
    public override void StartEngine()
    {
        Console.WriteLine("Motorcycle engine started");
    }
}

// ------------------ Interface Segregation Principle (ISP) ----------------------
public interface ICar
{
    void Start();
    void Stop();
    void Accelerate();
    void Brake();
}

public interface IAirplane
{
    void TakeOff();
    void Land();
    void Fly();
}

public class Car1 : ICar
{
    public void Start()
    {
        Console.WriteLine("Car started");
    }

    public void Stop()
    {
        Console.WriteLine("Car stopped");
    }

    public void Accelerate()
    {
        Console.WriteLine("Car accelerated");
    }

    public void Brake()
    {
        Console.WriteLine("Car braked");
    }
}

public class Airplane : IAirplane
{
    public void TakeOff()
    {
        Console.WriteLine("Airplane took off");
    }

    public void Land()
    {
        Console.WriteLine("Airplane landed");
    }

    public void Fly()
    {
        Console.WriteLine("Airplane flying");
    }
}

// ------------------ Dependency Inversion Principle (DIP) ------------------------

interface ISwitchable
{
    void TurnOn();
    void TurnOff();
    bool IsOn();
}

class LightBulb : ISwitchable
{
    private bool isOn;
    public void TurnOn()
    {
        isOn = true;
        // Turn on the light bulb
    }

    public void TurnOff()
    {
        isOn = false;
        // Turn off the light bulb
    }

    public bool IsOn()
    {
        return isOn;
    }
}

class Switch
{
    private ISwitchable device;

    public Switch(ISwitchable device)
    {
        this.device = device;
    }

    public void Toggle()
    {
        if(!device.IsOn())
        {
            device.TurnOn();
        }
        else
        {
            device.TurnOff();
        }
    }
}
#endregion

#region Homework 18 Part 1
/*
 - Разработайте пример использования обобщенных типов в методах.
 - Разработайте пример использования обобщенных типов в классах.
 - Разработайте пример использования ограничений new(), struct, class, Интерфейс, Классы и абстрактные классы.
 */

// --------------------------- Использования обобщенных типов в методах.
class GenericMethodsExample
{
    public T FindMax<T>(T[] array) where T : IComparable<T>
    {
        if (array.Length == 0)
        {
            throw new InvalidOperationException("Array is empty.");
        }

        T max = array[0];
        foreach (T item in array)
        {
            if (item.CompareTo(max) > 0)
            {
                max = item;
            }
        }

        return max;
    }
}

class Program1
{
    static void Main(string[] args)
    {
        int[] intArray = { 3, 7, 1, 9, 4 };
        GenericMethodsExample example = new GenericMethodsExample();
        int maxInt = example.FindMax(intArray);
        Console.WriteLine("Maximum integer: " + maxInt);

        string[] stringArray = { "apple", "banana", "cherry" };
        string maxString = example.FindMax(stringArray);
        Console.WriteLine("Maximum string: " + maxString);
    }
}

// --------------------------- Использования обобщенных типов в классах.
class GenericClassExample<T>
{
    private T value;

    public GenericClassExample(T initialValue)
    {
        value = initialValue;
    }

    public void DisplayValue()
    {
        Console.WriteLine("Value: " + value);
    }
}

class Program2
{
    static void Main(string[] args)
    {
        GenericClassExample<int> intInstance = new GenericClassExample<int>(42);
        intInstance.DisplayValue();

        GenericClassExample<string> stringInstance = new GenericClassExample<string>("Hello, Generics!");
        stringInstance.DisplayValue();
    }
}

// --------------------------- Использования ограничений new(), struct, class, Интерфейс, Классы и абстрактные классы.
interface IDisplayable
{
    void Display();
}

public class AnimalA
{
    public string Name { get; set; }
}

class Cat : AnimalA, IDisplayable
{
    public void Display()
    {
        Console.WriteLine("Cat: " + Name);
    }
}

class DisplayService<T> where T : AnimalA, IDisplayable, new()
{
    public void DisplayItem()
    {
        T item = new T();
        item.Name = "Fluffy";
        item.Display();
    }
}

public struct MyStruct
{
    public int Value { get; set; }
}

class MyGenericClass<T> where T : class
{
    public void Process(T data)
    {
        // Process the data
    }
}

abstract class MyBaseClass
{
    public abstract void Print();
}

class MyDerivedClass : MyBaseClass
{
    public override void Print()
    {
        Console.WriteLine("Derived class implementation.");
    }
}

class Program3
{
    static void Main(string[] args)
    {
        DisplayService<Cat> displayService = new DisplayService<Cat>();
        displayService.DisplayItem();

        MyStruct myStruct = new MyStruct { Value = 42 };
        MyGenericClass<MyStruct> structProcessor = new();
        structProcessor.Process(myStruct);

        MyDerivedClass derived = new MyDerivedClass();
        derived.Print();
    }
}

#endregion