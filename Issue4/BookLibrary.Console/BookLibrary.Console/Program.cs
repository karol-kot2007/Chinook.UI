namespace proj
{
    public class User
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public int Age { get; set; }
        public string Email { get; set; }

        public static List<User> Users = new List<User>();
        private static void validateMethod(User user)
        {
           while (user.FirstName.Length < 3 || user.LastName.Length < 3 || user.Email.Length < 3 || user.Age < 10)
            {
                Console.WriteLine("what's your name ? ");
                user.FirstName = Console.ReadLine();
                Console.WriteLine("what's your Last name ? ");
                user.LastName = Console.ReadLine();
                Console.WriteLine("what's your Email ? ");
                user.Email = Console.ReadLine();
              
            }
            }

        private static void InitializeEmployees(List<User> users)
        {
            Users.Add(new User
            {
                Email = "tuba@gmail.com",
                FirstName = "Tuba",
                Age = 35,
                LastName = "ojciechowski"
            });

            Users.Add(new User
            {
                Email = "atul@gmail.com",
                FirstName = "Tul",
                Age = 24,
                LastName = "krol"
            });
            var querySyntax1 = from user in Users
                               where user.FirstName.StartsWith("T")                 
                               select user.FirstName;
                               


            Console.WriteLine("Where in querySyntax------");
            foreach (var item in querySyntax1)
            {
                Console.WriteLine(item);
            }
        }
        static void Main (string[] args)
        {
            User user = new User();
            //  Console.WriteLine("what's your age ? ");
            // user.Age = int.Parse(Console.ReadLine());
            //Console.WriteLine("what's your name ? ");
            //user.FirstName = Console.ReadLine();
            //Console.WriteLine("what's your Last name ? ");
            //user.LastName = Console.ReadLine();
            //Console.WriteLine("what's your Email ? ");
            //user.Email = Console.ReadLine();
           // validateMethod(user);
            InitializeEmployees(Users);
           // Console.WriteLine(user.FirstName + "  " + user.LastName+" " + user.Age +   "  " + user.Email);
        }

      
    }

}