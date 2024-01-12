using System.Text.Json;

namespace Student_Management_System
{
    public class School
    {
        public string SName { get; set; }
        public string SEmail { get; set; }
        public string SPassword { get; set;}

        public School(string sName, string sMail, string sPassword) //List<Teacher> teachers, List<Student> students
        {
            SName = sName;
            SEmail = sMail;
            SPassword = sPassword;
        }

        string studentPath = "telebeler.json";
        string teacherPath = "muellimler.json";

        private List<Student> _telebeler;
        public List<Student> listTelebeler
        {
            get
            {
                if (File.Exists(studentPath))
                {
                    return GetStudents();
                }
                else
                {
                    return new List<Student>();
                }
            }
            set
            {
                _telebeler = value;
            }
        }

        private List<Teacher> _muellimler;
        public List<Teacher> listMuellimler
        {
            get
            {
                if (File.Exists(teacherPath))
                {
                    return GetTeachers();
                }
                else
                {
                    return new List<Teacher>();
                }
            }
            set
            {
                _muellimler = value;
            }
        }

        public School()
        {
            listTelebeler = GetStudents();
            listMuellimler = GetTeachers();
        }

        #region Muellim

        public void AddTeacher(Teacher teacher)
        {
            var hazirki = listMuellimler;
            hazirki.Add(teacher);
            SaveTeachers(hazirki);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Yeni müəllim əlavə edildi.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void SaveTeachers(List<Teacher>? teachers = null)
        {
            if (teachers != null)
            {
                var file = File.Open(teacherPath, FileMode.Create);
                JsonSerializer.Serialize<List<Teacher>>(file, teachers);
                file.Close();
            }
            else
            {
                var file = File.Open(teacherPath, FileMode.Create);
                JsonSerializer.Serialize<List<Teacher>>(file, listMuellimler);
                file.Close();
            }
        }

        public List<Teacher> GetTeachers()
        {
            if (!File.Exists(teacherPath))
            {
                return new();
            }
            var file = File.OpenRead(teacherPath);
            var listim = JsonSerializer.Deserialize<List<Teacher>>(file);
            file.Close();
            if (listim == null)
            {
                return new List<Teacher>();
            }
            else
            {
                return listim;
            }
        }


        public void DisplayTeacher()
        {
            var count = 1;
            Console.WriteLine("\nMüəllimlər: ");
            foreach (var muellim in listMuellimler)
            {
                Console.WriteLine($"======Müəllim {count}======");
                Console.WriteLine($"Müəllimin adı: {muellim.TFName} - Soyadı: {muellim.TLName} - Emaili: {muellim.TEmail}" +
                    $" - Şifrəsi: {muellim.TPassword} - Departament: {muellim.Department} - Maaşı: {muellim.Salary}");
                count++;
            }
        }


        public Teacher? SearchTeacher(string ad, string soyad)
        {
            foreach (var muellim in listMuellimler)
            {
                if (muellim.TFName.ToLower() == ad.ToLower() && muellim.TLName.ToLower() == soyad.ToLower())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Tapıldı adı: {muellim.TFName} - Soyadı: {muellim.TLName} - Emaili: {muellim.TEmail}" +
                    $" - Şifrəsi: {muellim.TPassword} - Departament: {muellim.Department} - Maaşı: {muellim.Salary}");
                    Console.ForegroundColor = ConsoleColor.White;
                    return muellim;
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Axtarışa uyğun müəllim tapılmadı.");
            Console.ForegroundColor = ConsoleColor.White;
            return null;
        }



        public bool OzMelumatlariniDeyismekM(Teacher ozu, Teacher deyisdirilmisi)
        {
            var deyisilecek = listMuellimler;

            for (int i = 0; i <= deyisilecek.Count; i++)
            {
                  var muellim = deyisilecek[i];

                  if (muellim.TFName.ToLower() == ozu.TFName.ToLower() && muellim.TLName.ToLower() == ozu.TLName.ToLower())
                  {
                        var kohnemuellim = deyisilecek[i];
                        deyisdirilmisi.TFName = string.IsNullOrWhiteSpace(deyisdirilmisi.TFName) ? kohnemuellim.TFName : deyisdirilmisi.TFName;
                        deyisdirilmisi.TLName = string.IsNullOrWhiteSpace(deyisdirilmisi.TLName) ? kohnemuellim.TLName : deyisdirilmisi.TLName;
                        deyisdirilmisi.TEmail = string.IsNullOrWhiteSpace(deyisdirilmisi.TEmail) ? kohnemuellim.TEmail : deyisdirilmisi.TEmail;
                        deyisdirilmisi.TPassword = string.IsNullOrWhiteSpace(deyisdirilmisi.TPassword) ? kohnemuellim.TPassword : deyisdirilmisi.TPassword;
                        deyisdirilmisi.Department = string.IsNullOrWhiteSpace(deyisdirilmisi.Department) ? kohnemuellim.Department : deyisdirilmisi.Department;
                        deyisilecek[i] = deyisdirilmisi;
                        SaveTeachers(deyisilecek);

                        return true;
                  }
            }    

            return false;
        }


        public bool TeacherUpdate(int muellimnum, Teacher deyisdirilmisi)
        {
            var deyisilecek = listMuellimler;

            for (int i = 0; i <= deyisilecek.Count; i++)
            {
                if (muellimnum == (i + 1))
                {
                    var kohnemuellim = deyisilecek[i];
                    deyisdirilmisi.TFName = string.IsNullOrWhiteSpace(deyisdirilmisi.TFName) ? kohnemuellim.TFName : deyisdirilmisi.TFName;
                    deyisdirilmisi.TLName = string.IsNullOrWhiteSpace(deyisdirilmisi.TLName) ? kohnemuellim.TLName : deyisdirilmisi.TLName;
                    deyisdirilmisi.TEmail = string.IsNullOrWhiteSpace(deyisdirilmisi.TEmail) ? kohnemuellim.TEmail : deyisdirilmisi.TEmail;
                    deyisdirilmisi.TPassword = string.IsNullOrWhiteSpace(deyisdirilmisi.TPassword) ? kohnemuellim.TPassword : deyisdirilmisi.TPassword;
                    deyisdirilmisi.Department = string.IsNullOrWhiteSpace(deyisdirilmisi.Department) ? kohnemuellim.Department : deyisdirilmisi.Department;
                    deyisdirilmisi.Salary = deyisdirilmisi.Salary == 0 ? kohnemuellim.Salary : deyisdirilmisi.Salary;
                    deyisilecek[i] = deyisdirilmisi;
                    SaveTeachers(deyisilecek);

                    return true;
                }
            }
            return false;
        }


       


        public bool RemoveTeacher(int silineceknum)
        {
            var silinecekMuellimler = listMuellimler;

            for (int i = 0; i < silinecekMuellimler.Count; i++)
            {
                if (silineceknum == (i + 1))
                {
                    silinecekMuellimler.RemoveAt(i);
                    SaveTeachers(silinecekMuellimler);
                    return true;
                }
            }
            return false;
        }

        #endregion


        #region Telebe

        public void AddStudent()
        {
            Console.WriteLine("Tələbənin adını daxil edin:");
            string telebeAdi = Console.ReadLine();
            Console.WriteLine("Tələbənin soyadını daxil edin: ");
            string telebeSoyadi = Console.ReadLine();
            Console.WriteLine("Tələbənin email adresini daxil edin:");
            string telebeEmail = Console.ReadLine();
            Console.WriteLine("Tələbənin şifrəsini daxil edin:");
            string telebeSifresi = Console.ReadLine();
            Console.WriteLine("Müştərinin ortalamasını daxil edin:");
            double telebeOrtalamsi = double.Parse(Console.ReadLine());

            Student studentobj = new Student(telebeAdi, telebeSoyadi, telebeEmail, telebeSifresi, telebeOrtalamsi);

            var indiki = listTelebeler;
            indiki.Add(studentobj);
            SaveStudent(indiki);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Yeni tələbə əlavə edildi.");
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public void SaveStudent(List<Student>? students = null)
        {
            if (students != null)
            {
                var file = File.Open(studentPath, FileMode.Create);
                JsonSerializer.Serialize<List<Student>>(file, students);
                file.Close();
            }
            else
            {
                var file = File.Open(studentPath, FileMode.Create);
                JsonSerializer.Serialize<List<Student>>(file, listTelebeler);
                file.Close();
            }
        }

        public List<Student> GetStudents()
        {
            if (!File.Exists(studentPath))
            {
                return new();
            }
            var file = File.OpenRead(studentPath);
            var listim = JsonSerializer.Deserialize<List<Student>>(file);
            file.Close();
            if (listim == null)
            {
                return new List<Student>();
            }
            else
            {
                return listim;
            }
        }

        public void DisplayStudent()
        {
            var count = 1;

            Console.WriteLine("\nTələbələr: ");
            foreach (var telebe in listTelebeler)
            {
                Console.WriteLine($"======Tələbə {count}======");
                Console.WriteLine($"Tələbənin adı: {telebe.SFName} - Soyadı: {telebe.SLName} - Emaili: {telebe.SEmail}" +
                    $" - Şifrəsi: {telebe.SPassword} - Ortalaması: {telebe.Average}");
                count++;
            }
        }


        public Student? SearchStudent(string ad, string soyad)
        {
            foreach (var telebem in listTelebeler)
            {
                if (telebem.SFName.ToLower() == ad.ToLower() && telebem.SLName.ToLower() == soyad.ToLower())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Tapıldı. Tələbənin adı: {telebem.SFName} - Soyadı: {telebem.SLName} - Emaili: {telebem.SEmail} - Şifrəsi: {telebem.SPassword} - Qiymət ortalaması: {telebem.Average}");
                    Console.ForegroundColor = ConsoleColor.White;
                    return telebem;
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Axtarışa uyğun tələbə tapılmadı.");
            Console.ForegroundColor = ConsoleColor.White;
            return null;
        }


        public bool OzMelumatlariniDeyismekS(Student ozu, Student deyisdirilmisi)
        {
            var deyisilecek = listTelebeler;

            for (int i = 0; i < deyisilecek.Count; i++)
            {
                var telebe = deyisilecek[i];

                if (telebe.SFName.ToLower() == ozu.SFName.ToLower() && telebe.SLName.ToLower() == ozu.SLName.ToLower())
                {
                    var  kohnestudent= deyisilecek[i];
                    deyisdirilmisi.SFName = string.IsNullOrWhiteSpace(deyisdirilmisi.SFName) ? kohnestudent.SFName : deyisdirilmisi.SFName;
                    deyisdirilmisi.SLName = string.IsNullOrWhiteSpace(deyisdirilmisi.SLName) ? kohnestudent.SLName : deyisdirilmisi.SLName;
                    deyisdirilmisi.SEmail = string.IsNullOrWhiteSpace(deyisdirilmisi.SEmail) ? kohnestudent.SEmail : deyisdirilmisi.SEmail;
                    deyisdirilmisi.SPassword = string.IsNullOrWhiteSpace(deyisdirilmisi.SPassword) ? kohnestudent.SPassword : deyisdirilmisi.SPassword;
                    deyisilecek[i] = deyisdirilmisi;
                    SaveStudent(deyisilecek);

                    return true;
                }
            }

            return false;
        }


        public bool StudentUpdate(int telebenum, Student deyisdirilmisS)
        {
            var deyiselecek = listTelebeler;

            for (int i = 0; i <= deyiselecek.Count; i++)
            {
                if (telebenum == (i + 1))
                {
                    
                    var kohnetelebe = deyiselecek[i];
                    deyisdirilmisS.SFName = string.IsNullOrWhiteSpace(deyisdirilmisS.SFName) ? kohnetelebe.SFName : deyisdirilmisS.SFName;
                    deyisdirilmisS.SLName = string.IsNullOrWhiteSpace(deyisdirilmisS.SLName) ? kohnetelebe.SLName : deyisdirilmisS.SLName;
                    deyisdirilmisS.SEmail = string.IsNullOrWhiteSpace(deyisdirilmisS.SEmail) ? kohnetelebe.SEmail : deyisdirilmisS.SEmail;
                    deyisdirilmisS.SPassword = string.IsNullOrWhiteSpace(deyisdirilmisS.SPassword) ? kohnetelebe.SPassword : deyisdirilmisS.SPassword;
                    deyisdirilmisS.Average = deyisdirilmisS.Average == 0 ? kohnetelebe.Average : deyisdirilmisS.Average;
                    deyiselecek[i] = deyisdirilmisS;
                    SaveStudent(deyiselecek);

                    return true;
                }
            }
            return false;
        }


        public bool RemoveStudent(int silineceknum)
        {
            var silinecekTelebeler = listTelebeler;

            for (int i = 0; i < silinecekTelebeler.Count; i++)
            {
                if (silineceknum == (i + 1))
                {
                    silinecekTelebeler.RemoveAt(i);
                    SaveStudent(silinecekTelebeler);
                    return true;
                }
            }
            return false;
        }



        #endregion
    }
}
