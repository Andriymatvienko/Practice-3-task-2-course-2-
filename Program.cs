using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Person> person = new List<Person>()
        {
            new Person { Name = "Ihor", Age = 0 },
            new Person { Name = "Andr", Age = 1 }
         };


        void Serialize()
        {
            FileStream stream = new FileStream("Person.xml", FileMode.OpenOrCreate);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            serializer.Serialize(stream, person);
            Console.WriteLine("Object Serialized");
            stream.Close();
        }

        void Deserialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            FileStream stream = new FileStream("Person.xml", FileMode.OpenOrCreate);
            List<Person> newPersons = serializer.Deserialize(stream) as List<Person>;

            foreach (Person p in newPersons)
            {
                Console.WriteLine("Person");
                Console.WriteLine(p.Name);
                Console.WriteLine(p.Age);
            }
        }
        Console.WriteLine("Оберiть Дiю(1-Серiалiзацiя, 2-Десереалiзаця");
        int choice =Int32.Parse(Console.ReadLine());
        
        switch (choice)
        {
            case 1: Serialize();break;
            case 2: Deserialize(); break;
        }
     }
}