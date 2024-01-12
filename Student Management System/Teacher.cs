
namespace Student_Management_System
{
    public class Teacher
    {
        public string TFName { get; set; }
        public string TLName { get; set; }
        public string TEmail { get; set; }
        public string TPassword { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }

        public Teacher(string tFName, string tLName, string tEmail, string tPassword, string department, double salary)
        {
            TFName = tFName;
            TLName = tLName;
            TEmail = tEmail;
            TPassword = tPassword;
            Department = department;
            Salary = salary;
        }

        public Teacher(string tFName2, string tLName2, string tEmail2, string tPassword2, string department2)
        {
            TFName = tFName2;
            TLName = tLName2;
            TEmail = tEmail2;
            TPassword = tPassword2;
            Department = department2;
        }


        public Teacher()
        {

        }

        public override string ToString()
        {
            return $" Adi: {TFName} - Soyadı: {TLName} - Emaili: {TEmail} - Şifrəsi: {TPassword} - Departament: {Department} - Maaşı: {Salary}";
        }

        
    }
}
