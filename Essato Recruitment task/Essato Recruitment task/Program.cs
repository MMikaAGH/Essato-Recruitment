using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essato_Recruitment_task
{
    [Serializable]
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer("Marcin", "Mika","PL1234567890","20-03-2023",enumContinent.Europe, "Poland","33-100", "Tarnów", "Mazowiecka", "40A");
            Customer customer2 = new Customer("Thomas", "Muller", "DE987654321", "11-02-2022", enumContinent.Europe, "Germany", "22098", "Dortmund", "Gewur", "51", "6");
            Console.WriteLine(customer1.ToString());
            CustomerList list = new CustomerList();
            //-----Adding to list:--------
            list.AddCustomer(customer1);
            list.AddCustomer(customer2);
            Console.Write(list.ToString());
            Console.WriteLine();
            //-----Editing:----------------
            customer2.City = "Munchen";
            Console.WriteLine("\n");
            Console.Write(list.ToString());
            Console.WriteLine();
            //-----Removing:---------------
            list.RemoveCustomer(customer2);
            Console.WriteLine(list.ToString());
            list.AddCustomer(customer2);
            //-----XML save---------------
            CustomerList.SaveXML("plik", list);
            //-------Clone----------------
            CustomerList list2 = (CustomerList)list.DeepClone();
            Console.WriteLine(list2.ToString());
            Console.ReadKey();
        }
    }
}
