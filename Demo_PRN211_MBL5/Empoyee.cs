namespace Demo_PRN211_MBL5
{
    // We can call this class by 'model'
    internal class Empoyee
    {
        public string Code { get; set; }
        private string _name;
        public bool _gender;
        private string _role;
        private long _salary;

        public string Name
        {
            get => _name;
            set { _name = value; }
        }

        public bool Gender
        {
            get => _gender;
            set { _gender = value; }
        }

        public string Role
        {
            get => _role;
            set { _role = value; }
        }
        public long Salary
        {
            get => _salary;
            set { _salary = value; }
        }


        public void Employee()
        {

        }

        public void Employee(string code, string name, bool gender, string role, long salary)
        {
            Code = code;
            Name = name;
            Gender = gender;
            Role = role;
            Salary = salary;
        }
    }
}