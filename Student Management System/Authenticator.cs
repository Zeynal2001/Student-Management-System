namespace Student_Management_System
{
    public static class Authenticator
    {
        public static bool AuthenticateSchool()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Xaiş edirik məktəb müdüriyyəti kimi proqrama giriş etmək üçün aşağıda email adresinizi və şifrənizi daxil edin: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n-----------------------------------");

            Console.WriteLine("Emaili daxil edn");
            string mektebEmail = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(mektebEmail))
            {
                Console.WriteLine("Diqqət! dəyər boşdur və ya null-dır.");
            }

            Console.WriteLine("Şifrəni daxil edin");
            string mektebSifre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(mektebSifre))
            {
                Console.WriteLine("Diqqət! dəyər boşdur və ya null-dır.");
            }

            if (mektebEmail == "mekteb@mail.com" && mektebSifre == "mekteb123")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Giriş uğurlu oldu.");
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }

            return false;
        }
        public static Teacher? AuthenticateTeacher()
        {
            School mekteb1 = new School();

            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Xaiş edirik müəllim kimi proqrama giriş etmək üçün aşağıda email adresinizi və şifrənizi daxil edin: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n-----------------------------------");

            Console.WriteLine("Emaili daxil edn");
            string muellimEmail = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(muellimEmail))
            {
                Console.WriteLine("Diqqət! dəyər boşdur və ya null-dır.");
            }

            Console.WriteLine("Şifrəni daxil edin");
            string muellimSifre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(muellimSifre))
            {
                Console.WriteLine("Diqqət! dəyər boşdur və ya null-dır.");
            }

            var muellimler = mekteb1.GetTeachers();

            foreach (var muellim in muellimler)
            {
                if (muellim.TEmail == muellimEmail && muellim.TPassword == muellimSifre)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Giriş uğurlu oldu.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return muellim;
                }
            }
            return null;
        }

        public static Student? AuthenticateStudent()
        {
            School mekteb2 = new School();

            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Xaiş edirik tələbə kimi proqrama giriş etmək üçün aşağıda email adresinizi və şifrənizi daxil edin: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n-----------------------------------");

            Console.WriteLine("Emaili daxil edn");
            string telebeEmail = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(telebeEmail))
            {
                Console.WriteLine("Diqqət! dəyər boşdur və ya null-dır.");
            }

            Console.WriteLine("Şifrəni daxil edin");
            string telebeSifre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(telebeSifre))
            {
                Console.WriteLine("Diqqət! dəyər boşdur və ya null-dır.");
            }

            var telebeler = mekteb2.GetStudents();

            foreach (var telebe in telebeler)
            {
                if (telebe.SEmail == telebeEmail && telebe.SPassword == telebeSifre)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Giriş uğurlu oldu.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return telebe;
                }
            }
            return null;
        }


        public static bool HandleFailedLoginAttempsSch()
        {
            int loginAttemps = 0;

            while (loginAttemps <= 3)
            {
                if (AuthenticateSchool())
                    return true;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email vəya şifrə yanlışdır");
                Thread.Sleep(1800);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                loginAttemps++;
                if (loginAttemps >= 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("3 dəfə yanlış mail və ya şifrə daxil edildiyinə görə proqram bağlandı.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1500);
                    return false;
                }
            }
            return false;
        }


        public static bool HandleFailedLoginAttempsTech()
        {
            int loginAttemps = 0;

            while (loginAttemps <= 3)
            {
                if (AuthenticateTeacher() != null)
                    return true;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email vəya şifrə yanlışdır");
                Thread.Sleep(1800);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                loginAttemps++;
                if (loginAttemps >= 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("3 dəfə yanlış mail və ya şifrə daxil edildiyinə görə proqram bağlandı.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1500);
                    return false;
                }
            }
            return false;
        }

        public static bool HandleFailedLoginAttempsSt()
        {
            int loginAttemps = 0;

            while (loginAttemps <= 3)
            {
                if (AuthenticateStudent() != null)
                    return true;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email vəya şifrə yanlışdır");
                Thread.Sleep(1800);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                loginAttemps++;
                if (loginAttemps >= 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("3 dəfə yanlış mail və ya şifrə daxil edildiyinə görə proqram bağlandı.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1500);
                    return false;
                }
            }
            return false;
        }
    }
}
