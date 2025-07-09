using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Reflection;
using Contact_Manager;

namespace Contact_Manager
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ContactListData UsersContactList = new ContactListData();
            UsersContactList.AddContact("Sankar2", "san@gmail.com", "8220709131", "Nothing much");
            UsersContactList.AddContact("Sankar4", "san@gmail.com", "8220709131", "Nothing much");
            UsersContactList.AddContact("Guru", "san@gmail.com", "8220709131", "Nothing much");
            UsersContactList.AddContact("Uttand", "san@gmail.com", "8220709131", "Nothing much");
            UsersContactList.AddContact("Sankar1", "san@gmail.com", "8220709131", "Nothing much");
            string choice;
            do
            {
                Console.WriteLine("1. Add  2. Show  3. Edit  4. Delete  5. Sort  6. Search  7.Exit");
                choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        Services.ManageAddContact(UsersContactList);
                        break;
                    case "2":
                        Services.ManageShowContact(UsersContactList);
                        break;
                    case "3":
                        Services.ManageEditContact(UsersContactList);
                        break;
                    case "4":
                        Services.ManageDeleteContact(UsersContactList);
                        break;
                    case "5":
                        Services.ManageSortContact(UsersContactList);
                        break;
                    case "6":
                        Services.ManageSearchContact(UsersContactList);
                        break;
                    case "7":
                        return;
                    default:
                        break;
                }
            } while (true);
        }
    }


}
