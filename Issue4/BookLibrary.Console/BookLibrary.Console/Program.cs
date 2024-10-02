namespace proj
{
    public class User
    {
        public string FirstName { get; set; } = " ";
        public string LastName { get; set; } = " ";
        public int Age { get; set; }
        public string Email { get; set; }

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
        static void Main (string[] args)
        {
            User user = new User();
            Console.WriteLine("what's your age ? ");
            user.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("what's your name ? ");
            user.FirstName = Console.ReadLine();
            Console.WriteLine("what's your Last name ? ");
            user.LastName = Console.ReadLine();
            Console.WriteLine("what's your Email ? ");
            user.Email = Console.ReadLine();
            validateMethod(user);

            Console.WriteLine(user.FirstName + "  " + user.LastName+" " + user.Age +   "  " + user.Email);
        }

      
    }

}