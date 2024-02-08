namespace ASP_University
{
    public class Company
    {
        private string _name;
        private int _employees;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Employees
        {
            get { return _employees; }
            set { _employees = value; }
        }
    }
}
