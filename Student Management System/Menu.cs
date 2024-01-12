namespace Student_Management_System
{
    public static class Menu
    {
        public static void MainMenu()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Xoş gəlmisiniz 😊. Girişi seçin: (1/4)");
            Console.WriteLine("1. Məktəb kimi.");
            Console.WriteLine("2. Müəllim kimi. ");
            Console.WriteLine("3. Tələbə kimi. ");
            Console.WriteLine("4. Proqramdan çıxış etmək.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------");
        }

        public static void SchoolMenu()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nXoş gəlmisiniz hörmətli müdür 😊. Aşağıda etmək istədiyiniz əməliyyatı seçin:(1/11)");
            Console.WriteLine("1. Proqramdan çıxış etmək.");
            Console.WriteLine("2. Müəllim əlavə etmək.");
            Console.WriteLine("3. Müəllim siyahısına baxmaq.");
            Console.WriteLine("4. Müəllim hesabını axtarmaq.");
            Console.WriteLine("5. Müəllimin məlumatlarını yeniləmək.");
            Console.WriteLine("6. Mövcud müəllimin hesabını silmək.");
            Console.WriteLine("7. Tələbə əlavə etmək.");
            Console.WriteLine("8. Tələbə siyahısına baxmaq.");
            Console.WriteLine("9. Tələbə hesabını axtarmaq.");
            Console.WriteLine("10. Tələbənin məlumatlarını yeniləmək.");
            Console.WriteLine("11. Mövcud tələbənin hesabını silmək.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------");
        }

        public static void TeacherMenu()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Xoş gəlmisiniz 😊. Etmək istədiyiniz əməliyyatı seçin: (1/4)");
            Console.WriteLine("1. Öz məlumatlarına baxmaq.");
            Console.WriteLine("2. Öz məlumatlarını dəyişmək.");
            Console.WriteLine("3. Tələbələrin siyahısına baxmaq.");
            Console.WriteLine("4. Proqramdan çıxış etmək.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------");
        }

        public static void StudentMenu()
        {
            Console.WriteLine("\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Xoş gəlmisiniz 😊. Etmək istədiyiniz əməliyyatı seçin: (1/5)");
            Console.WriteLine("1. Öz məlumatlarına baxmaq.");
            Console.WriteLine("2. Öz məlumatlarını dəyişmək.");
            Console.WriteLine("3. Müəllimlərin siyahısına baxmaq.");
            Console.WriteLine("4. Proqramdan çıxış etmək.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------------------------------");
        }



    }
}
