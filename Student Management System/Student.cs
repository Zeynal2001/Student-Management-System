namespace Student_Management_System
{
    public class Student
    {
        public string SFName { get; set; }
        public string SLName { get; set; }
        public string SEmail { get; set; }
        public string SPassword { get; set; }
        public double Average { get; set; }

        
        public Student(string sfName, string slName, string sEmail, string sPassword, double average)
        {
            SFName = sfName;
            SLName = slName;
            SEmail = sEmail;
            SPassword = sPassword;
            Average = average;
        }

        public Student(string sfName2, string slName2, string sEmail2, string sPassword)
        {
            SFName = sfName2;
            SLName = slName2;
            SEmail = sEmail2;
            SPassword = sPassword;
        }

        public Student()
        {

        }

        public override string ToString()
        {
            return $"Tələbənin adı: {SFName} - Soyadı: {SLName} - Emaili: {SEmail}" +
                    $" - Şifrəsi: {SPassword} - Qiymət ortalaması: {Average}";
            //return base.ToString();
        }
    }
}
