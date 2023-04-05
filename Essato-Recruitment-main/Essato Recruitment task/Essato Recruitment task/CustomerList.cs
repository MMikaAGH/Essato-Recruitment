using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Essato_Recruitment_task
{
    [Serializable]
    public class CustomerList : IList, ICloneable
    {
        private List<Customer> list = new List<Customer>();

        public void AddCustomer(Customer c)
        {
            List.Add(c);
        }
        public void RemoveCustomer(Customer c)
        {
            list.Remove(c);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Customer item in List)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
        public static void SaveXML(string nazwa, CustomerList z)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CustomerList));
            TextWriter writer = new StreamWriter($"{nazwa}.xml");
            serializer.Serialize(writer, z);
            writer.Close();
        }
        public static CustomerList OpenXML(string nazwa)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CustomerList));
            FileStream fs = new FileStream($"{nazwa}.xml", FileMode.Open);
            return (CustomerList)serializer.Deserialize(fs);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }


        public object DeepClone()
        {
            CustomerList customers = new CustomerList();
            customers= (CustomerList)this.MemberwiseClone();
            customers.List = new List<Customer>();
            foreach (Customer cus in this.List)
                customers.AddCustomer((Customer)cus.Clone());
            return customers;
        }

        public List<Customer> List { get => list; set => list = value; }


    }
}
