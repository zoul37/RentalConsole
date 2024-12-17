using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;
using System.Xml.Schema;


// Define a class named Car
public class Car
{
    // Properties of the Car class, using auto-implemented properties
    //intoducing arguments 
    //public string? Model { get; set; } // Model of the car (e.g., Skyline, Supra)
    private string Model;//field
    public string? Brand { get; set; } // Brand of the car (e.g., Nissan, Toyota)
    public int Year { get; set; } // Year the car was manufactured
    public double PricePerDay { get; set; } // Rental price per day for the car
    public bool IsAvailable { get; set; } // Indicates if the car is available for rent or not

    //Creating an array to declare models and brand names
    public static string[] Models = new string[5];
    public static string[] Brands = new string[5];
    //Key property to access the private field model
    public string MModel
    {
        get { return Model; }
        set { Model = value; }
    }
    

    // Constructor to initialize the Car object with specific values
    public Car(string? model, string brand, int year, double priceperday, bool isavailable)
    {
        //car class parameters
        MModel = model; // Assign the passed 'model' to the 'Model' property
        Brand = brand; // Assign the passed 'brand' to the 'Brand' property
        Year = year; // Assign the passed 'year' to the 'Year' property
        PricePerDay = priceperday; // Assign the passed 'priceperday' to the 'PricePerDay' property
        IsAvailable = isavailable; // Assign the passed 'isavailable' to the 'IsAvailable' property

        Models[0] = "Supra";
        Models[1] = "Skyine";
        Models[2] = "Evo";
        Models[3] = "Civic";
        Models[4] = "Rx7";

        Brands[0] = "Toyota";
        Brands[1] = "Nissan";
        Brands[2] = "Mistubushi";
        Brands[3] = "Honda";
        Brands[4] = "Mazda";
    }

    // Method representing an action that can be performed on a Car object
    public void Buy()
    {
        Console.WriteLine($"{Model} car is bought"); // Display a message indicating the car was bought
    }

    //static polymorphism method 
    public void start()
    {
        Console.WriteLine($"Lets start our new {Model}.....");
    }
    //overloaded method
    public void start(string? model)
    {
        Console.WriteLine($"starting {model}");
    }

    // Dynamic polymorphic method
    public virtual void stop() 
        { 
            Console.WriteLine($"Stopping our {Model}"); 
        }
}
//New class SUV that inherits from car 

public class SUV : Car
{
    //property argument of SUV class
    public int SeatingCapacity { get; set; }

    //Constructor 

    public SUV(string? model, string brand, int year, int seatingcapacity, double priceperday, bool isavailable) : base(model, brand, year, priceperday, isavailable)
    {
        SeatingCapacity = seatingcapacity;

    }

    //Copy Constructor

    public SUV(SUV Cross) : base(Cross.MModel, Cross.Brand, Cross.Year, Cross.PricePerDay, Cross.IsAvailable)
    { 
        SeatingCapacity = Cross.SeatingCapacity;
       
    }

    //Dynamic method overriding
    public override void stop()
    {
        Console.WriteLine($"Stopiing our SUV {MModel}");
    }
}

//abstract class
public abstract class Sedan : Car
{ 
    public int TrunkCapacity { get; set; }

    public Sedan(string? model, string brand, int year, int TrunkCapacity, double priceperday, bool isavailable) : base(model, brand, year, priceperday, isavailable) 
    {
        TrunkCapacity = TrunkCapacity;
    }
}

//concrete class of sedan 
public class LuxurySedan : Sedan
{
    public LuxurySedan(string? model, string brand, int year, int TrunkCapacity, double priceperday, bool isavailable) : base(model, brand, year, TrunkCapacity, priceperday, isavailable) { }
}

    // Define a class containing the Main method to execute the program
    class Program
    {
    // Entry point of the program
    public static void Main()
    {
        List<Car> Carlist = new List<Car>(); 
        int i = 0;
        for (i = 0; i < Car.Brands.Length; i++)
        {
            Console.WriteLine($"{Car.Brands[i]} {Car.Models[i]}");
            Car arrcar = new Car(Car.Models[i], Car.Brands[i], 1999, 15000, true);
            Carlist.Add(arrcar);
        }

        // Create an object (instance) of the Car class with specified details
        Car mycar = new Car("Skyline", "Nissan", 1999, 15000, false);

        

        



        //child class
        SUV mycar3 = new SUV("Carnival", "KIA", 2023, 5, 5000, true); // instatiating the SUV class

        //copy constructor object

        SUV mycar4 = new SUV(mycar3);

        ////concrete class object
        //LuxurySedan mylux = new LuxurySedan(); ;

        //abstract class object

        LuxurySedan mycar5 = new LuxurySedan("Cruze", "Chevorlet", 2012, 40, 8000, true);



        // Create another Car object with different details
        Car mycar2 = new Car("Supra", "Toyota", 2001, 15000, false);

        // Display the details of the first car in a formatted string
        Console.WriteLine($"{mycar.Brand}'s {mycar.MModel} of {mycar.Year} costs {mycar.PricePerDay} and is {(mycar.IsAvailable ? "Available" : "Not available")}");
        Console.WriteLine($"{mycar3.Brand}'s {mycar3.MModel} of {mycar3.Year} costs {mycar3.PricePerDay} and is {(mycar3.IsAvailable ? "Available" : "Not available")}");
        Console.WriteLine($"{mycar4.Brand}'s {mycar4.MModel} of {mycar4.Year} costs {mycar4.PricePerDay} and is {(mycar4.IsAvailable ? "Available" : "Not available")}");
        Console.WriteLine($"{mycar5.Brand}'s {mycar5.MModel} of {mycar5.Year} costs {mycar5.PricePerDay} and is {(mycar5.IsAvailable ? "Available" : "Not available")}");
        //Console.WriteLine($"{arrcar.Brand}'s {arrcar.MModel} of {arrcar.Year} costs {arrcar.PricePerDay} and is {(arrcar.IsAvailable ? "Available" : "Not available")}");
        
        

        // Call the Buy method on the first car object
        mycar.Buy();
        //static method usaage
        mycar3.start();

        //Dynamic polyphorphic method call
        mycar4.stop();
        //Dynamic method use
        mycar.stop();

        //use of abstract object
        mycar5.start();
        mycar5.stop();

       

        //// Print the Models array elements individually
        //Console.WriteLine("Models:");
        //foreach (var model in mycar.Models)
        //{
        //    Console.WriteLine(model);
        //}

        //// Print the Brands array elements individually
        //Console.WriteLine("\nBrands:");
        //foreach (var brand in mycar.Brands)
        //{
        //    Console.WriteLine(brand);
        //}

        
        GC.Collect();
    }

    
    }
    
