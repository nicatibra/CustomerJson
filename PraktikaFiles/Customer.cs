using Newtonsoft.Json;

namespace PraktikaFiles
{
    internal class Customer
    {
        public int Id;
        public string FirsName;
        public string LastName;

        public string PhoneNumber;

        private static string FileName = @"C:\Users\nicha\OneDrive\Desktop\CodeAcademy\C#\Praktika\PraktikaFiles\PraktikaFiles\Data\Customers.json";

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

        public void Add()
        {
            List<Customer> customers;

            using (StreamReader sr = new StreamReader(FileName))
            {
                string json = sr.ReadToEnd();
                customers = JsonConvert.DeserializeObject<List<Customer>>(json) ?? new List<Customer>();
            }

            if (customers.Any(c => c.Id == this.Id))
            {
                Console.WriteLine($"A customer with ID {this.Id} already exists. Cannot add duplicate ID.");
                return;
            }

            customers.Add(this);

            using (StreamWriter sw = new StreamWriter(FileName))
            {
                string updatedJson = JsonConvert.SerializeObject(customers, Formatting.Indented);
                sw.Write(updatedJson);
            }
        }

        public static void DeleteCustomer(int id)
        {
            List<Customer> customers;

            using (StreamReader sr = new StreamReader(FileName))
            {
                string json = sr.ReadToEnd();
                customers = JsonConvert.DeserializeObject<List<Customer>>(json) ?? new List<Customer>();
            }

            customers.RemoveAll(c => c.Id == id);

            using (StreamWriter sw = new StreamWriter(FileName))
            {
                string updatedJson = JsonConvert.SerializeObject(customers, Formatting.Indented);
                sw.Write(updatedJson);
            }
        }

        public static void GetAll()
        {
            List<Customer> customers;

            using (StreamReader sr = new StreamReader(FileName))
            {
                string json = sr.ReadToEnd();
                customers = JsonConvert.DeserializeObject<List<Customer>>(json) ?? new List<Customer>();
            }

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ToString());
            }
        }

        public static void Update(int id, string newFirstName, string newLastName, string newPhoneNumber)
        {
            List<Customer> customers;

            using (StreamReader sr = new StreamReader(FileName))
            {
                string json = sr.ReadToEnd();
                customers = JsonConvert.DeserializeObject<List<Customer>>(json) ?? new List<Customer>();
            }

            foreach (var customer in customers)
            {
                if (customer.Id == id)
                {
                    customer.FirsName = newFirstName;
                    customer.LastName = newLastName;
                    customer.PhoneNumber = newPhoneNumber;
                }
            }

            using (StreamWriter sw = new StreamWriter(FileName))
            {
                string updatedJson = JsonConvert.SerializeObject(customers, Formatting.Indented);
                sw.Write(updatedJson);
            }
        }
    }
}
