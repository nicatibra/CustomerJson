using Newtonsoft.Json;

namespace PraktikaFiles
{
    internal class Program
    {
        //Folder ve Customer.json run edende yaranir
        static string Path = @"C:\Users\nicha\OneDrive\Desktop\CodeAcademy\C#\Praktika\PraktikaFiles\PraktikaFiles\Data";
        static string FileName = @"C:\Users\nicha\OneDrive\Desktop\CodeAcademy\C#\Praktika\PraktikaFiles\PraktikaFiles\Data\Customers.json";

        static void Main(string[] args)
        {
            Customer customer1 = new Customer(1, "Nicat", "Ibrahimli", "0515262466");
            Customer customer2 = new Customer(2, "Azad", "Ashurov", "0552262466");
            Customer customer3 = new Customer(3, "Tony", "Stark", "0101001010");

            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }

            if (!File.Exists(FileName))
            {
                using (StreamWriter sw = File.CreateText(FileName)) ;
            }

            Add(customer1);
            Add(customer2);
            Add(customer3);
            DeleteCustomer(3);
            Update(1, "John", "Wick", "099666777");
            GetAll();
        }

        static void Add(Customer customer)
        {
            List<Customer> customers = new List<Customer>();

            using (StreamReader sr = new StreamReader(FileName))
            {
                string json = sr.ReadToEnd();
                customers = JsonConvert.DeserializeObject<List<Customer>>(json);

                if (customers == null)
                {
                    customers = new List<Customer>();
                }
            }

            if (customers.Any(c => c.Id == customer.Id))
            {
                Console.WriteLine($"A customer with ID {customer.Id} already exists. Cannot add duplicate ID.");
                return;
            }

            customers.Add(customer);

            using (StreamWriter sw = new StreamWriter(FileName))
            {
                string updatedJson = JsonConvert.SerializeObject(customers);
                sw.Write(updatedJson);
            }
        }


        static void DeleteCustomer(int id)
        {
            List<Customer> customers = new List<Customer>();

            using (StreamReader sr = new StreamReader(FileName))
            {
                string json = sr.ReadToEnd();
                customers = JsonConvert.DeserializeObject<List<Customer>>(json);
            }

            customers.RemoveAll(c => c.Id == id);

            using (StreamWriter sw = new StreamWriter(FileName))
            {
                string updatedJson = JsonConvert.SerializeObject(customers);
                sw.Write(updatedJson);
            }
        }

        static void GetAll()
        {
            List<Customer> customers = new List<Customer>();

            using (StreamReader sr = new StreamReader(FileName))
            {
                string json = sr.ReadToEnd();
                customers = JsonConvert.DeserializeObject<List<Customer>>(json);
            }

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ToString());
            }
        }

        static void Update(int id, string newFirstName, string newLastName, string newPhoneNumber)
        {
            List<Customer> customers = new List<Customer>();

            using (StreamReader sr = new StreamReader(FileName))
            {
                string json = sr.ReadToEnd();
                customers = JsonConvert.DeserializeObject<List<Customer>>(json);
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
                string updatedJson = JsonConvert.SerializeObject(customers);
                sw.Write(updatedJson);
            }
        }
    }
}
