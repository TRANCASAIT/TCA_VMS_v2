namespace TCA_VMS.Models
{
    public class Staff
    {
        public int Staff_Id { get; set; }
        public string Staff_Name { get; set; }
        public string Staff_LastName { get; set; }
        public string Staff_Number { get; set; }
        public string Staff_PhoneNumber { get; set; }
        public string Staff_Email { get; set; }
        public string Base_Name { get; set; }
        public string Department_Name { get; set; }
        public bool Staff_Status { get; set; }
        public int Base_Id { get; set; }
        public int Department_Id { get; set; }
        public string Staff_Creation_Date { get; set; }
    }

    public class StaffPost
    {
        public string Staff_Name { get; set; }
        public string Staff_LastName { get; set; }
        public string Staff_Number { get; set; }
        public string Staff_PhoneNumber { get; set; }
        public string Staff_Email { get; set; }
        public int Base_Id { get; set; }
        public int Department_Id { get; set; }
        public string User_Logged { get; set; }
    }

    public class StaffPut
    {
        public int Staff_Id { get; set; }
        public string Staff_Name { get; set; }
        public string Staff_LastName { get; set; }
        public string Staff_Number { get; set; }
        public string Staff_PhoneNumber { get; set; }
        public string Staff_Email { get; set; }
        public int Base_Id { get; set; }
        public int Department_Id { get; set; }
        public string User_Logged { get; set; }
    }

    public class StaffStatus
    {
        public int Staff_Id { get; set; }
        public bool Staff_Status { get; set; }
        public string User_Logged { get; set; }

    }
}
