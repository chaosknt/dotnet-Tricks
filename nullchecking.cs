using System;

namespace NullChecking
{
    public class NullChecking
    {
        public User User { get; set; }

        public NullChecking()
        {
            var rnd = new Random(69);
            this.User = rnd.Next(1, 10) < 3 ? new User("chaosknt") : null;

            if (this.User == null)
            {
                Console.WriteLine("User was null");
            }
            else
            {
                Console.WriteLine("User was not null");
            }

            //using referenceEquals

            if (ReferenceEquals(this.User, null)) //the same behavior => if(this.User is null)
            {
                Console.WriteLine("check with ReferenceEquals: User was null");
            }
            else // the opposite if(this.User is not null)
            {
                Console.WriteLine("check with ReferenceEquals: User was not null");
            }


            //check for null on nested props
            Console.WriteLine("checking properties of null user");

            //old way
            if (User?.Child?.Name is not null)
            {
                Console.WriteLine("Name is not null");
            }
            else
            {
                Console.WriteLine("Name is null");
            }


            if (User is not { Child.Name: null }) //.net core >=6
            {
                Console.WriteLine("New way: Name null");
            }
            else
            {
                Console.WriteLine("New way: Name not is null");

            }
        }
    }

    public class User
    {
        public User(string name) 
        {
            this.Name = name;   
            this.Child = new User(name);
        }

        public string Name { get; set; }

        public User Child { get; set; }

        //The equals operator can be overloaded
        public static bool operator ==(User left, User right)
        {
            return false;
        }

        public static bool operator !=(User left, User right)
        {
            return false;
        }
    }
}
