namespace TCA_VMS.Models
{
    public class Department
    {
        public int Department_Id { get; set; }
        public string Department_Name { get; set; }
        public string User_Logged { get; set; }
        public DateTime Department_Creation_Date { get; set; }
    }

    public class DepartmentUpdate
    {
        public int Department_Id { get; set; }
        public string Department_Name { get; set; }
        public string User_Logged { get; set; }

    }
}
