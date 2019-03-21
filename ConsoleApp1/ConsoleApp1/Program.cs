using System;
using System.Collections.Generic;
using ConsoleApp1.Classes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>()
            {
                new Person("Nathanael", "Holt", 20, Job.Choreographer),
                new Person("Jabari", "Chapman", 35, Job.Dentist),
                new Person("Oswaldo", "Wilson", 19, Job.Developer),
                new Person("Kody", "Walton", 43, Job.Sculptor),
                new Person("Andreas", "Weeks", 17, Job.Developer),
                new Person("Kayla", "Douglas", 28, Job.Developer),
                new Person("Xander", "Campbell", 19, Job.Waiter),
                new Person("Soren", "Velasquez", 33, Job.Interpreter),
                new Person("August", "Rubio", 21, Job.Developer),
                new Person("Malakai", "Mcgee", 57, Job.Barber),
                new Person("Emerson", "Rollins", 42, Job.Choreographer),
                new Person("Everett", "Parks", 39, Job.Sculptor),
                new Person("Amelia", "Moody", 24, Job.Waiter),
                new Person("Emilie", "Horn", 16, Job.Waiter),
                new Person("Leroy", "Baker", 44, Job.Interpreter),
                new Person("Nathen", "Higgins", 60, Job.Archivist),
                new Person("Erin", "Rocha", 37, Job.Developer),
                new Person("Freddy", "Gordon", 26, Job.Sculptor),
                new Person("Valeria", "Reynolds", 26, Job.Dentist),
                new Person("Cristofer", "Stanley", 28, Job.Dentist)
            };

            var dogs = new List<Dog>()
            {
                new Dog("Charlie", "Black", 3, Race.Collie),
                new Dog("Buddy", "Brown", 1, Race.Doberman),
                new Dog("Max", "Olive", 1, Race.Plott),
                new Dog("Archie", "Black", 2, Race.Mutt),
                new Dog("Oscar", "White", 1, Race.Mudi),
                new Dog("Toby", "Maroon", 3, Race.Bulldog),
                new Dog("Ollie", "Silver", 4, Race.Dalmatian),
                new Dog("Bailey", "White", 4, Race.Pointer),
                new Dog("Frankie", "Gray", 2, Race.Pug),
                new Dog("Jack", "Black", 5, Race.Dalmatian),
                new Dog("Chanel", "Black", 1, Race.Pug),
                new Dog("Henry", "White", 7, Race.Plott),
                new Dog("Bo", "Maroon", 1, Race.Boxer),
                new Dog("Scout", "Olive", 2, Race.Boxer),
                new Dog("Ellie", "Brown", 6, Race.Doberman),
                new Dog("Hank", "Silver", 2, Race.Collie),
                new Dog("Shadow", "Silver", 3, Race.Mudi),
                new Dog("Diesel", "Brown", 1, Race.Bulldog),
                new Dog("Abby", "Black", 1, Race.Dalmatian),
                new Dog("Trixie", "White", 8, Race.Pointer),
            };



            // 1. Take person Cristofer and add Jack, Ellie and Hank as his dogs.

            var Cristofer = people.Where(p => p.FirstName == "Cristofer").FirstOrDefault();

            var JackDog = dogs.Where(d => d.Name == "Jack").FirstOrDefault();
            var EllieDog = dogs.Where(d => d.Name == "Ellie").FirstOrDefault();
            var HankDog = dogs.Where(d => d.Name == "Hank").FirstOrDefault();

            Cristofer.Dogs = new List<Dog>();

            Cristofer.Dogs.Add(JackDog);
            Cristofer.Dogs.Add(EllieDog);
            Cristofer.Dogs.Add(HankDog);

            foreach (var dog in Cristofer.Dogs)
            {
                Console.WriteLine($" {dog.Name} !");
            }


            //2.Take person Freddy and add Oscar, Toby, Chanel, Bo and Scout as his dogs.

            var Freddy = people.Where(p => p.FirstName == "Freddy").FirstOrDefault();

            var OscarDog = dogs.Where(d => d.Name == "Oscar").FirstOrDefault();
            var TobyDog = dogs.Where(d => d.Name == "Toby").FirstOrDefault();
            var ChanelDog = dogs.Where(d => d.Name == "Chanel").FirstOrDefault();
            var BoDog = dogs.Where(d => d.Name == "Bo").FirstOrDefault();
            var ScoutDog = dogs.Where(d => d.Name == "Scout").FirstOrDefault();

            Freddy.Dogs = new List<Dog>();

            Freddy.Dogs.Add(OscarDog);
            Freddy.Dogs.Add(TobyDog);
            Freddy.Dogs.Add(ChanelDog);
            Freddy.Dogs.Add(BoDog);
            Freddy.Dogs.Add(ScoutDog);


            //3.Add Trixie, Archie and Max as dogs from Erin

            var Erin = people.Where(p => p.FirstName == "Erin").FirstOrDefault();

            var TrixieDog = dogs.Where(d => d.Name == "Trixie").FirstOrDefault();
            var ArchieDog = dogs.Where(d => d.Name == "Archie").FirstOrDefault();
            var MaxDog = dogs.Where(d => d.Name == "Max").FirstOrDefault(); 

            Erin.Dogs = new List<Dog>();

            Erin.Dogs.Add(TrixieDog);
            Erin.Dogs.Add(ArchieDog);
            Erin.Dogs.Add(MaxDog);


            // 4. Give Abby and Shadow to Amelia

            var Amelia = people.Where(p => p.FirstName == "Amelia").FirstOrDefault();

            var AbbyDog = dogs.Where(d => d.Name == "Abby").FirstOrDefault();
            var ShadowDog = dogs.Where(d => d.Name == "Shadow").FirstOrDefault();

            Amelia.Dogs = new List<Dog>();

            Amelia.Dogs.Add(AbbyDog);
            Amelia.Dogs.Add(ShadowDog);


            //PART 3 - LINQ
            // 1. Find and print all persons firstnames starting with 'R', ordered by Age - DESCENDING ORDER

            var personsFirstNameR = people.Where(p => p.FirstName.StartsWith("R")).OrderByDescending(p => p.Age)
                                         .Select(p => p.FirstName).ToList();

            // 2. Find and print all brown dogs names and ages older than 3 years, ordered by Age - ASCENDING ORDER

            var brownDogs = dogs.Where(d => d.Color == "Brown" && d.Age > 3).OrderBy(d => d.Age)
                                .Select(d => d.Name).ToList();

            if (brownDogs.Count == 0)
            {
                Console.WriteLine("There aren't that kind of dogs!");
            }
            else
            {
                Console.WriteLine("Brown dogs that have more than 3 years are:");
                foreach (var names in brownDogs)
                {
                    Console.WriteLine(names);
                }
            }

            // 3. Find and print all persons with more than 2 dogs, ordered by Name - DESCENDING ORDER

            var personsWithDogs = people.Where(p => p.Dogs.Count > 2).OrderByDescending(p => p.FirstName).ToList();

            Console.WriteLine("Person with more than 2 dogs:");
            foreach (var personWithDog in personsWithDogs)
            {
                Console.WriteLine(personWithDog.FirstName);
            }


            // 4. Find and print all Freddy`s dogs names older than 1 year
            var freddyDogs = Freddy.Dogs.Where(d => d.Age > 1).Select(d => d.Name).ToList();

            Console.WriteLine("Freddy`s dogs orlder than 1 year old:");

            foreach (var dog in freddyDogs)
            {
                Console.WriteLine(dog);
            }

            //5.Find and print Nathen`s first dog

            var NathensDog = people.Where(p => p.FirstName == "Nathen").FirstOrDefault();

            var nathenDogs = NathensDog.Dogs.FirstOrDefault();

            if (nathenDogs == null)
            {
                Console.WriteLine("She doesn't have dogs!");
            }
            else
            {
                Console.WriteLine("Nathen`s first dog is " + nathenDogs.Name);
            }


            // 6. Find and print all white dogs names from Cristofer, Freddy, Erin and Amelia, ordered by Name - ASCENDING ORDER

            var whiteDogsCristofer = Cristofer.Dogs.Where(d => d.Color == "White").ToList();
            var whiteDogsFreddy = Freddy.Dogs.Where(d => d.Color == "White").ToList();
            var whiteDogsErin = Erin.Dogs.Where(d => d.Color == "White").ToList();
            var whiteDogsAmelia = Amelia.Dogs.Where(d => d.Color == "White").ToList();

            var whiteDogs = new List<string>();

            Console.WriteLine("White dogs names:");
            foreach (var dog in whiteDogsCristofer)
            {
                whiteDogs.Add(dog.Name);
            }

            foreach (var dog in whiteDogsFreddy)
            {
                whiteDogs.Add(dog.Name);
            }

            foreach (var dog in whiteDogsErin)
            {
                whiteDogs.Add(dog.Name);
            }

            foreach (var dog in whiteDogsAmelia)
            {
                whiteDogs.Add(dog.Name);
            }

            var orderedByName = whiteDogs.OrderBy(d => d).ToList();

            foreach (var dog in orderedByName)
            {
                Console.WriteLine(dog);
            }



        }
    }
}
