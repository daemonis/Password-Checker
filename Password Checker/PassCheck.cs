namespace PasswordChecker
{
    class PassCheck
    {
        private static string? password;
        private static string? username;

        static void GetPassword()
        {
            ConsoleColor origForeground = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            password = Console.ReadLine();
            Console.ForegroundColor = origForeground;
        }

        static bool IsPasswordCaps()
        {
            int i = 0;
            int passwordLength = password.Length - 1;
            do
            {
                if (Char.IsUpper(password, i))
                {
                    return true;
                }
                i++;
            }
            while (passwordLength >= i);
            return false;
        }

        static bool IsPasswordNum()
        {
            int i = 0;
            int passwordLength = password.Length - 1;
            do
            {
                if (Char.IsNumber(password, i))
                {
                    return true;
                }
                i++;
            }
            while (passwordLength >= i);
            return false;
        }

        static bool IsPasswordLong()
        {
            if (password.Length < 8)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool IsPasswordThere()
        {
            if (password == null || password.Length <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool IsUsernameThere()
        {
            if (username == null || username.Length <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool IsUsernameLong()
        {
            if (username.Length > 20 || username.Length < 8)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static void GetUsername()
        {
            username = Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Console.Write("Hello. Thank you for using a TechCorps system.\nPlease make a username for use on login: ");

            do
            {
                GetUsername();
                if (!IsUsernameThere())
                {
                    Console.Write("You must enter a username.\nPlease enter a username: ");
                }
                else if (!IsUsernameLong())
                {
                    Console.Write("Your username must contain the following:\n- Between 8 and 20 characters.\nPlease try again: ");
                }
            }
            while (!IsUsernameThere() || !IsUsernameLong());

            Console.Write($"Please set a password for user {username}: ");

            do
            {
                GetPassword();

                if (!IsPasswordThere())
                {
                    Console.Write("You must enter a password.\nPlease enter a password: ");
                    continue;
                }
                else if (!IsPasswordLong() || !IsPasswordCaps() || !IsPasswordNum())
                {
                    Console.Write($"Your password must contain the following:\n- More than 8 characters.\n- A number.\n- A capital letter.\nPlease try again: ");
                }
            }
            while (!IsPasswordLong() || !IsPasswordCaps() || !IsPasswordNum());

            Console.WriteLine("Your password meets our system criteria, welcome!.");
        }
    }
}
