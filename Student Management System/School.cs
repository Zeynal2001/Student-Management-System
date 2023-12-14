namespace Student_Management_System
{
    public class School
    {
        public string SMail { get; set; }
        public string SPassword { get; set;}

        public List<Teacher> muellimler = new List<Teacher>();
        public List<Student> telebeler = new();


        public School()
        {
            
        }
        public School(string mektebMail, string mektebSifre)
        {
            SMail = mektebMail;
            SPassword = mektebSifre;
        }
    }
}
