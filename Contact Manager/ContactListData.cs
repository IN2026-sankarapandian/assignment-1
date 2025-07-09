using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager
{
    internal class ContactListData
    {
        List<ContactData> totalContacts = new List<ContactData>();

        public ContactData AddContact(string name, string email, string phone, string notes)
        {
            ContactData newContact = new ContactData(name, email, phone, notes);
            totalContacts.Add(newContact);
            return newContact;
        }
        public List<ContactData> GetContacts()
        {
            return totalContacts;
        }
        public void ShowContacts(List<ContactData> ListToShow)
        {
            Console.WriteLine(String.Format("|{0,-5}|{1,-15}|{2,-15}|{3,-15}|{4,-20}|", "S. no", "Name", "Email ID", "Phone", "Additional Notes"));
            Console.WriteLine(new string('-', 76));
            for (int i = 0; i < ListToShow.Count; i++)
            {
                Console.WriteLine(String.Format("|{0,-5}|{1,-15}|{2,-15}|{3,-15}|{4,-20}|", i + 1, ListToShow[i].Name, ListToShow[i].Email, ListToShow[i].Phone, ListToShow[i].Notes));
            }
        }
        public void ShowContact(ContactData ContactToShow)
        {
            Console.WriteLine(String.Format("|{0,-15}|{1,-15}|{2,-15}|{3,-20}|", "Name", "Email ID", "Phone", "Additional Notes"));
            Console.WriteLine(String.Format("|{0,-15}|{1,-15}|{2,-15}|{3,-20}|", ContactToShow.Name, ContactToShow.Email, ContactToShow.Phone, ContactToShow.Notes));
        }
        public bool ShowContactByIndex(int index)
        {
            if (index < 0 || index >= totalContacts.Count)
            {
                return false;
            }
            ShowContact(totalContacts[index]);
            return true;

        }
        public bool EditContact(int index, string key, string option)
        {
            if (index >= totalContacts.Count || index < 0) return false;
            switch (option)
            {
                case "name":
                    totalContacts[index].Name = key;
                    return true;
                case "email":
                    totalContacts[index].Email = key;
                    return true;
                case "phone":
                    totalContacts[index].Phone = key;
                    return true;
                case "notes":
                    totalContacts[index].Notes = key;
                    return true;
                default:
                    return false;
            }
        }
        public bool DeleteContacts(int index)
        {
            if (index >= totalContacts.Count || index < 0) return false;
            totalContacts.RemoveAt(index);
            return true;
        }
        public List<ContactData> Search(string keyword, string option)
        {
            Console.WriteLine();
            List<ContactData> filtered;
            switch (option)
            {
                case "name":
                    filtered = totalContacts.FindAll(a => a.Name.ToUpper().Contains(keyword.ToUpper()));
                    break;
                case "email":
                    filtered = totalContacts.FindAll(a => a.Email.ToUpper().Contains(keyword.ToUpper()));
                    break;
                case "phone":
                    filtered = totalContacts.FindAll(a => a.Phone.ToUpper().Contains(keyword.ToUpper()));
                    break;
                case "notes":
                    filtered = totalContacts.FindAll(a => a.Phone.ToUpper().Contains(keyword.ToUpper()));
                    break;
                default:
                    filtered = totalContacts.FindAll(a => a.Name.ToUpper().Contains(keyword.ToUpper()));
                    break;
            }
            return filtered;
        }
        public void SortContacts(string option)
        {
            switch (option)
            {
                case "name":
                    totalContacts.Sort((a, b) => a.Name.CompareTo(b.Name));
                    break;
                case "time":
                    Console.WriteLine("yoyo");
                    totalContacts.Sort((a, b) => a.CreatedAt.CompareTo(b.CreatedAt));
                    break;
            }
        }
        public bool existWithName(string name)
        {
            if (totalContacts.Exists(a => a.Name == name))
            {
                return true;
            }
            return false;
        }

        public bool isValidIndex(int index)
        {
            if(index >= 0 && index <= totalContacts.Count)
            {
                return true;
            }
            return false;
        }
        
        
        
        
        
        
        
    }
}
