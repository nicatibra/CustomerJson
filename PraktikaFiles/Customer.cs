namespace PraktikaFiles
{
    internal class Customer
    {
        public int Id;
        public string FirsName;
        public string LastName;

        public string PhoneNumber;

        public Customer(int id, string firstname, string lastname, string number)
        {
            Id = id;
            FirsName = firstname;
            LastName = lastname;
            PhoneNumber = number;
        }

        public override string ToString()
        {
            return $"Name: {FirsName}, Surname: {LastName}, Phone number: {PhoneNumber}";
        }
    }
}
