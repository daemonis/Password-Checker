namespace PasswordChecker
{
    class PassCheck
    {
        private static string password = "";

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

        static void Main(string[] args)
        {
            Console.Write("Hello. Thank you for using a TechCorps system.\nPlease make a username for use on login: ");
            string username = Console.ReadLine();

            Console.Write($"Please set a password for user {username}: ");

            bool passwordIsLong = false;
            bool passwordIsCaps = false;
            bool passwordHasNum = false;

            do
            {
                GetPassword();

                passwordIsLong = IsPasswordLong();
                passwordIsCaps = IsPasswordCaps();
                passwordHasNum = IsPasswordNum();

                if (!passwordIsLong || !passwordIsCaps || !passwordHasNum)
                {
                    Console.Write($"Your password must contain the following:\n- More than 8 characters.\n- A number.\n- A capital letter.\nPlease try again: ");
                }
            }
            while (!passwordIsLong || !passwordIsCaps || !passwordHasNum);

            Console.WriteLine("Your password meets our system criteria, welcome!.");
        }
    }
}
