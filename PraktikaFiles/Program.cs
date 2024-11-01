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


            customer1.Add();
            customer2.Add();
            customer3.Add();
            Customer.DeleteCustomer(3);
            Customer.Update(1, "John", "Wick", "099666777");
            Customer.GetAll();

        }
    }
}
