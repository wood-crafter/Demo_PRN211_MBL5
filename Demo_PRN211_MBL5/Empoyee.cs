namespace Demo_PRN211_MBL5
{
    // We can call this class by 'model'
    internal class Empoyee
    {
        public string Code { get; set; }
        private string _name;
        public string _gender;
        private string _role;
        private long _salary;

        public Empoyee(string code, string name, bool isMale, string role, long salary)
        {
            Code = code;
            Name = name;
            Gender = isMale ? "Male" : "Female";
            Role = role;
            Salary = salary;
        }

        public string Name
        {
            get
            {
                return _name.ToUpper();
            }

            set { _name = value; }
        }

        public string Gender
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
            set { 
                _salary = Gender == "Female" ? value + 100000 : value; 
            }
        }


        public void Employee()
        {

        }

        public override string ToString()
        {
            return Code + "\t" + Name + "\t" + Gender + "\t" + Role + "\t" + Salary;
        }
    }
}