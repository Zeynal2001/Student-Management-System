using Student_Management_System;

Console.OutputEncoding = System.Text.Encoding.UTF8;

//Teacher t = new();
//t.TEmail = "dsasa";
//t.Salary = 2312;

//Console.WriteLine(t);

School mekteb = new School();
Teacher muellim = new Teacher();
Student telebe = new Student();
Menu.MainMenu();

int secim1 = 0;
if (int.TryParse(Console.ReadLine(), out secim1))
{
    //Əsas giriş 
    switch (secim1)
	{
        // Məktəb kimi giriş etmək.
		case 1:
            bool authed1 = Authenticator.AuthenticateSchool();
            if (!authed1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email vəya şifrə yanlışdır");
                Console.ForegroundColor = ConsoleColor.White;
                authed1 = Authenticator.HandleFailedLoginAttempsSch();
            }

            while (true && authed1)
            {
                Menu.SchoolMenu();
                try
                {
                    int secim = int.Parse(Console.ReadLine());
                    switch (secim)
                    {
                        case 1:
                            // Programın bağlanması.
                            Console.WriteLine("Proqram bağlandı.");
                            return;
                        case 2:
                            // Yeni müəllim əlavə etmək.
                            Console.WriteLine("Müəllimin adını daxil edin:");
                            string muellimAdi = Console.ReadLine();
                            Console.WriteLine("Müəllimin soyadını daxil edin: ");
                            string muellimSoyadi = Console.ReadLine();
                            Console.WriteLine("Müəllimin email adresini daxil edin:");
                            string muellimEmail = Console.ReadLine();
                            Console.WriteLine("Müəllimin şifrəsini daxil edin:");
                            string muellimSifresi = Console.ReadLine();
                            Console.WriteLine("Müəllimin işlədiyi departamenti daxil edin:");
                            string muellimDepartament = Console.ReadLine();
                            Console.WriteLine("Müəllimin maaşını qeyd edin:");
                            double muellimMaas = double.Parse(Console.ReadLine());

                            Teacher muellim2 = new Teacher(muellimAdi, muellimSoyadi, muellimEmail, muellimSifresi, muellimDepartament, muellimMaas);
                            mekteb.AddTeacher(muellim2);
                            break;
                        case 3:
                            // Müəllim siyahısının göstərilməsi.
                            mekteb.DisplayTeacher();
                            break;
                        case 4:
                            // Müəllim hesabının axtarılması.
                            Console.WriteLine("Tapmaq istədiyiniz müəllimin adını daxil edin:");
                            string muellimAd = Console.ReadLine();
                            Console.WriteLine("Tapmaq istədiyiniz müəllimin soyadını daxil edin:");
                            string muellimSoyad = Console.ReadLine();

                            var tapilacaqMuellim = mekteb.SearchTeacher(muellimAd, muellimSoyad);
                            if (tapilacaqMuellim == null)
                            {
                                Console.WriteLine("Müəllim tapılmadı");
                                return;
                            }
                            break;
                        case 5:
                            // Müəllim məlumanlarının yenilənməsi.
                            mekteb.DisplayTeacher();

                            Console.WriteLine("Məlumatlarını dəyişmək istədiyniz müəllimin sıra sayını girin: ");
                            int secim_muellim = int.Parse(Console.ReadLine());

                            Console.WriteLine("Müəllimin adını daxil edin:");
                            string yeniMAdi = Console.ReadLine();
                            Console.WriteLine("Müəllimin soyadını daxil edin: ");
                            string yeniMSoyadi = Console.ReadLine();
                            Console.WriteLine("Müəllimin email adresini daxil edin:");
                            string yeniMEmail = Console.ReadLine();
                            Console.WriteLine("Müəllimin şifrəsini daxil edin:");
                            string yeniMSifresi = Console.ReadLine();
                            Console.WriteLine("Müəllimin işlədiyi departamenti daxil edin:");
                            string yeniMDepartament = Console.ReadLine();
                            Console.WriteLine("Müəllimin maaşını qeyd edin:");
                            double yeniMMaas = double.Parse(Console.ReadLine());

                            Teacher yeniMuellim = new Teacher(yeniMAdi, yeniMSoyadi, yeniMEmail, yeniMSifresi, yeniMDepartament, yeniMMaas);

                            bool detisildimiMu = mekteb.TeacherUpdate(secim_muellim, yeniMuellim);
                            if (detisildimiMu)
                            {
                                Console.WriteLine("Məlumatlar uğurla dəyişildi");
                            }
                            else
                            {
                                Console.WriteLine("Daxil edilen sıra sayına uyğun müəllim tapılmadı");
                            }
                            break;
                        case 6:
                            // Mövcud olan Müəllim hesabının bazadan silinməsi
                            mekteb.DisplayTeacher();

                            Console.WriteLine("\nSilinəcək işçinin sıra sayını girin: ");
                            int silinecekMu = int.Parse(Console.ReadLine());

                            bool silindimiMu = mekteb.RemoveTeacher(silinecekMu);
                            if (silindimiMu)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Müəllim uğurla bazadan silindi");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Daxil edilen sıra sayına uyğun müəllim tapılmadı");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;
                        case 7:
                            // Tələbə əlavə etmək.
                            mekteb.AddStudent();
                            break;
                        case 8:
                            // Tələbə siyahısının göstərilməsi.
                            mekteb.DisplayStudent();
                            break;
                        case 9:
                            // Tələbə hesabının axtarılması.
                            Console.WriteLine("Tapmaq istədiyiniz tələbənin adını daxil edin:");
                            string telebeAd = Console.ReadLine();
                            Console.WriteLine("Tapmaq istədiyiniz tələbənin soyadını daxil edin:");
                            string telebeSoyad = Console.ReadLine();

                            var tapilacaqTel = mekteb.SearchStudent(telebeAd, telebeSoyad);
                            if (tapilacaqTel == null)
                            {
                                Console.WriteLine("Müştəri tapılmadı");
                                return;
                            }
                            break;

                        case 10:
                            // Tələbə məlumanlarının yenilənməsi.
                            mekteb.DisplayStudent();

                            Console.WriteLine("Məlumatlarını dəyişmək istədiyniz tələbənin sıra sayını girin: ");
                            int secim_telebe = int.Parse(Console.ReadLine());

                            Console.WriteLine("Tələbənin yeni adını daxil edin: ");
                            string yeniTad = Console.ReadLine();
                            Console.WriteLine("Tələbənin yeni soyadını daxil edin: ");
                            string yeniTsoyad = Console.ReadLine();
                            Console.WriteLine("Tələbənin yeni email adresini daxil edin: ");
                            string yeniTemail = Console.ReadLine();
                            Console.WriteLine("Tələbənin yeni şifrəsini daxil edin: ");
                            string yeniTsifre = Console.ReadLine();
                            Console.WriteLine("Tələbənin yeni qiymət ortalamasınə daxil edin: ");
                            double yeniTortalama = double.Parse(Console.ReadLine());


                            Student student2 = new Student(sfName: yeniTad, slName: yeniTsoyad, sEmail: yeniTemail, sPassword: yeniTsifre, average: yeniTortalama);

                            bool deyisildimiSt = mekteb.StudentUpdate(secim_telebe, student2);
                            if (deyisildimiSt)
                            {
                                Console.WriteLine("Məlumatlar uğurla dəyişildi");
                            }
                            else
                            {
                                Console.WriteLine("Daxil edilen sıra sayına uyğun tələbə tapılmadı");
                            }
                            break;

                        case 11:
                            // Mövcud olan tələbənin bazadan silinməsi
                            mekteb.DisplayStudent();

                            Console.WriteLine("\nSilinəcək tələbənin sıra sayını girin: ");
                            int silinecekT = int.Parse(Console.ReadLine());

                            bool silindimiT = mekteb.RemoveStudent(silinecekT);
                            if (silindimiT)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Tələbə uğurla bazadan silindi");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Daxil edilen sıra sayına uyğun tələbə tapılmadı");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;
                        default:
                            //Yanlış seçim
                            Console.WriteLine("Yanlış seçim etmisiniz 😕.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Əgər proqramın işlənməsi zamanı bir xəta baş verərsə istifadəçiyə bildiriş göstərilir.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Xəta baş verdi: {ex.Message}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                finally
                {
                    // Bura əlavə təmizləmə və ya başqa tədbirlər əlavə edilə bilər.
                    Thread.Sleep(5000);
                    Console.Clear();
                }
            }
            break;
        case 2:
            //Müəllim kimi giriş etmək.
            var teacher = Authenticator.AuthenticateTeacher();
            bool authed2 = teacher != null;
            if (!authed2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email vəya şifrə yanlışdır");
                Console.ForegroundColor = ConsoleColor.White;
                authed2 = Authenticator.HandleFailedLoginAttempsTech();
            }

            while (true && authed2)
            {
                Menu.TeacherMenu();

                try
                {
                    int secim = int.Parse(Console.ReadLine());
                    switch (secim)
                    {
                        case 1:
                            //Öz məlumatlarına baxmaq
                            Console.WriteLine(teacher);

                            break;
                        case 2:
                            // Öz məlumatlarını yeniləmək/dəyişmək.
                            Console.WriteLine(teacher);

                            Console.WriteLine("Dəyişmək istədiyiniz məlumatları sırasıyla daxil edin:");

                            Console.WriteLine("\nYeni adınızı daxil edin:");
                            string yeniMAdi = Console.ReadLine();
                            Console.WriteLine("Yeni soyadınızı daxil edin: ");
                            string yeniMSoyadi = Console.ReadLine();
                            Console.WriteLine("Yeni email adresinizi daxil edin:");
                            string yeniMEmail = Console.ReadLine();
                            Console.WriteLine("Yeni şifrənizi daxil edin:");
                            string yeniMSifresi = Console.ReadLine();
                            Console.WriteLine("Yeni işlədiyiniz departamenti daxil edin:");
                            string yeniMDepartament = Console.ReadLine();
                            

                            Teacher yeniMuellim = new Teacher(yeniMAdi, yeniMSoyadi, yeniMEmail, yeniMSifresi, yeniMDepartament);

                            bool deyisildimiM = mekteb.OzMelumatlariniDeyismekM(teacher, yeniMuellim);
                            if (deyisildimiM)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Məlumatlar uğurla dəyişildi.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Xəta baş verdi.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;
                        case 3:
                            //Tələbələrin siyahısına baxmaq.
                            mekteb.DisplayStudent();
                            break;
                        case 4:
                            //Proqramdan çıxış etmək.
                            Console.WriteLine("Proqram bağlandı.");
                            return;
                        default:
                            Console.WriteLine("Yanlış seçim etmisiniz 😕.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Əgər proqramın işlənməsi zamanı bir xəta baş verərsə istifadəçiyə bildiriş göstərilir.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Xəta baş verdi: {ex.Message}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                finally
                {
                    // Bura əlavə təmizləmə və ya başqa tədbirlər əlavə edilə bilər.
                    Thread.Sleep(5000);
                    Console.Clear();
                }
            }
            break;
        case 3:
            //Tələbə kimi giriş etmək.
            var student = Authenticator.AuthenticateStudent();
            bool authed3 = student != null;
            if (!authed3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email vəya şifrə yanlışdır");
                Console.ForegroundColor = ConsoleColor.White;
                authed3 = Authenticator.HandleFailedLoginAttempsSt();
            }

            while (true && authed3)
            {
                Menu.StudentMenu();

                try
                {
                    int secim = int.Parse(Console.ReadLine());
                    switch (secim)
                    {
                        case 1:
                            //Öz məlumatlarına baxmaq
                            Console.WriteLine(student);
                            break;
                        case 2:
                            //Öz məlumatlarını dəyişmək.
                            Console.WriteLine(student);

                            Console.WriteLine("Dəyişmək istədiyiniz məlumatları sırasıyla daxil edin:");

                            Console.WriteLine("\nYeni adınızı daxil edin:");
                            string yeniSAdi = Console.ReadLine();
                            Console.WriteLine("Yeni soyadınızı daxil edin: ");
                            string yeniSSoyadi = Console.ReadLine();
                            Console.WriteLine("Yeni email adresinizi daxil edin:");
                            string yeniSEmail = Console.ReadLine();
                            Console.WriteLine("Yeni şifrənizi daxil edin:");
                            string yeniSSifresi = Console.ReadLine();


                            Student yeniTelebe = new Student(yeniSAdi, yeniSSoyadi, yeniSEmail, yeniSSifresi);

                            bool deyisildimiS = mekteb.OzMelumatlariniDeyismekS(student, yeniTelebe);
                            if (deyisildimiS)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Məlumatlar uğurla dəyişildi.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Xəta baş verdi.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;
                        case 3:
                            // Müəllimlərin siyahısına baxmaq.
                            mekteb.DisplayTeacher();
                            break;
                        case 4:
                            //Proqramdan çıxış etmək.
                            Console.WriteLine("Proqram bağlandı.");
                            return;
                        default:
                            Console.WriteLine("Yanlış seçim etmisiniz 😕.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Əgər proqramın işlənməsi zamanı bir xəta baş verərsə istifadəçiyə bildiriş göstərilir.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Xəta baş verdi: {ex.Message}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                finally
                {
                    // Bura əlavə təmizləmə və ya başqa tədbirlər əlavə edilə bilər.
                    Thread.Sleep(5000);
                    Console.Clear();
                }
            }
            break;
        case 4:
            //Proqramdan çıxış etmək.
            Console.WriteLine("Proqram bağlandı.");
            return;
		default:
            //Yanlış seçim
            Console.WriteLine("Yanlış seçim etmisiniz 😕.");
            break;
	}
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Xəta: Daxil etdiyiniz dəyər doğru formatda deyil!");
    Console.ForegroundColor = ConsoleColor.White;
}