using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Essato_Recruitment_task
{
    [Serializable]
    public enum enumContinent { North_America, South_America, Africa, Europe, Asia, Australia}
    public class Customer : ICloneable
    {
        private string name;
        private string surname;
        private string vat;
        private DateTime creation_date;
        private string post_code;
        private enumContinent continent;
        private string city;
        private string country;
        private string street;
        private string house_numb;
        private string apartament_numb;

        public Customer()
        {
        }

        public Customer(string name, string surname, string vat, string creation_date, enumContinent continent, string country, string post_code, string city, string street, string house_numb) :this()
        {
            this.Name = name;
            this.Surname = surname;
            this.Vat = vat;
            DateTime date;
            DateTime.TryParseExact(creation_date, new[] { "yyyy-MMM-dd", "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy", "dd-MM-yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out date);
            this.Creation_date = date;
            this.Continent = continent;
            this.Country = country;
            this.Post_code = post_code;
            this.City = city;
            this.Street = street;
            this.House_numb = house_numb;
        }

        public Customer(string name, string surname, string vat, string creation_date, enumContinent continent, string country, string post_code, string city, string street, string house_numb, string apartament_numb)
           : this(name, surname, vat, creation_date, continent, country, post_code, city, street, house_numb)
        { 
            this.Apartament_numb =apartament_numb;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Apartament_numb))
                return $"Name: {Name}\nSurname: {Surname}\nVat: {Vat}\nCreation date: {Creation_date.ToString("yyyy-MM-dd")}\nAdress: {Continent} {Country}, {Post_code} {City} {Street} {House_numb}\n";
            else
                return $"Name: {Name}\nSurname: {Surname}\nVat: {Vat}\nCreation date: {Creation_date.ToString("yyyy-MM-dd")}\nAdress: {Continent} {Country}, {Post_code} {City} {Street} {House_numb}/{Apartament_numb}\n";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public string Name
        {
            get => name;
            set
            {
                if (Regex.IsMatch(value, @"\p{Lu}"))
                    name = value;
                else
                    throw new LetterException("Have to start with big letter");
            }
        }
        public string Surname { get => surname; set => surname = value; }
        public string Vat
        {
            get => vat;
            set
            {
                if (value.ToString().Length <10 || value.ToString().Length > 20)
                    throw new VatException("VAT have between 10 and 20 signs");
                vat = value;
            }
        }
        public DateTime Creation_date { get => creation_date; set => creation_date = value; }
        public string Country { get => country; set => country = value; }
        public string Post_code { get => post_code; set => post_code = value; }
        public enumContinent Continent { get => continent; set => continent = value; }
        public string City { get => city; set => city = value; }
        public string Street { get => street; set => street = value; }
        public string House_numb { get => house_numb; set => house_numb = value; }
        public string Apartament_numb { get => apartament_numb; set => apartament_numb = value; }
    }
}
