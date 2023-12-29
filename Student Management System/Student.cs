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
    }
}
