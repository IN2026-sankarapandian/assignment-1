using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager
{
    internal class Services
    {
        /// <summary>
        /// Manages all the console inputs and outputs to add a contact
        /// Get name, email, phone and notes
        /// create a new contact and print it
        /// return to home at end
        /// </summary>
        /// <param name="userContactList">
        /// Gives access to users contact list
        /// </param>
        public static void ManageAddContact(ContactListData userContactList)
        {
            string name, email, phone, notes;
            Console.Clear();
            Console.WriteLine("Add a contact\n");
            Console.WriteLine("You have to enter the name*, email*, phone*, additional notes ");
            name = Utilities.GetName(userContactList);

            phone = Utilities.GetPhone();
            email = Utilities.GetEmail();
            notes = Utilities.GetNotes();
            Console.WriteLine("");
            ContactData newContact = userContactList.AddContact(name, email, phone, notes);
            userContactList.ShowContact(newContact);
            Console.WriteLine("Contact added successsfully !");
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
            Console.Clear();
        }
        /// <summary>
        /// Manages all the console inputs and outputs to show all the contact list
        /// return to home at end 
        /// </summary>
        /// <param name="userContactList">
        /// Gives access to users contact list
        /// </param>
        public static void ManageShowContact(ContactListData userContactList)
        {
            Console.Clear();
            Console.WriteLine("Show mode\n");
            List<ContactData> ContactList = userContactList.GetContacts();
            userContactList.ShowContacts(ContactList);
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
            Console.Clear();
        }
        /// <summary>
        /// Manages all the console inputs and outputs to edit the contact
        /// Shows the entire data with index
        /// get the index of contact to edited and shows it
        /// ask the field to edit
        /// Apply edits
        /// return to home at end
        /// </summary>
        /// <param name="userContactList">
        /// Gives access to users contact list
        /// </param>
        public static void ManageEditContact(ContactListData userContactList)
        {
            Console.Clear();
            Console.WriteLine("Edit mode\n");
            List<ContactData> ContactList = userContactList.GetContacts();
            userContactList.ShowContacts(ContactList);
            string key = null, optionName;
            int index;
            index = Utilities.GetIndex(userContactList);
            Console.Clear();
            Console.WriteLine("Edit mode\n");
            userContactList.ShowContactByIndex(index-1);
            Console.Write("\nEdit ");
            optionName = Utilities.GetField();
            Console.Write("New ");
            switch (optionName)
            {
                case "name":
                    key = Utilities.GetName(userContactList);
                    break;
                case "email":
                    key = Utilities.GetEmail();
                    break;
                case "phone":
                    key = Utilities.GetPhone();
                    break;
                case "notes":
                    key = Utilities.GetNotes();
                    break;
            }
            userContactList.EditContact(index - 1, key, optionName);
            Console.WriteLine("Edited successsfully !");
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
            Console.Clear();
        }
        /// <summary>
        /// Manages all the console inputs and outputs to delete the contact
        /// Show all the contact list index
        /// get the index to delete
        /// delete the contact at that index
        /// return to home at end
        /// </summary>
        /// <param name="userContactList">
        /// Gives access to users contact list
        /// </param>
        public static void ManageDeleteContact(ContactListData userContactList)
        {
            Console.Clear();
            Console.WriteLine("Delete mode\n");
            List<ContactData> ContactList = userContactList.GetContacts();
            userContactList.ShowContacts(ContactList);
            int index = Utilities.GetIndex(userContactList);
            userContactList.DeleteContacts(index - 1);
            Console.WriteLine("Contact deleted successsfully !");
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
            Console.Clear();
        }
        /// <summary>
        /// Manages all the console inputs and outputs to sort contacts
        /// get the sort mode
        /// display the sorted list
        /// return to home at end
        /// </summary>
        /// <param name="userContactList">
        /// Gives access to users contact list
        /// </param>
        public static void ManageSortContact(ContactListData userContactList)
        {
            Console.Clear();
            Console.WriteLine("Sort mode\n");
            userContactList.ShowContacts(userContactList.GetContacts());
            string optionName = Utilities.GetSortOption();
            if (optionName == "exit")
            {
                Console.Clear();
                return;
            }
            userContactList.SortContacts(optionName);
            Console.Clear();
            userContactList.ShowContacts(userContactList.GetContacts());
            Console.WriteLine("Sorted by " + optionName);
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
            Console.Clear();
        }
        /// <summary>
        /// Manages all the console inputs and outputs to search with keyword
        /// get the field to search by
        /// get the key word
        /// display the filtered list
        /// return to home at end
        /// </summary>
        /// <param name="userContactList">
        /// Gives access to users contact list
        /// </param>
        public static void ManageSearchContact(ContactListData userContactList)
        {
            Console.Clear();
            Console.WriteLine("Search mode\n");
            string key = null, fieldName;
            fieldName = Utilities.GetField();
            switch (fieldName)
            {
                case "name":
                    key = Utilities.GetName(userContactList);
                    break;
                case "email":
                    key = Utilities.GetEmail();
                    break;
                case "phone":
                    key = Utilities.GetPhone();
                    break;
                case "notes":
                    key = Utilities.GetNotes();
                    break;
            }
            List<ContactData> filtered = userContactList.Search(key,  fieldName);
            Console.Clear();
            Console.WriteLine("Search mode\n");
            if (filtered.Count <= 0)
            {
                Console.WriteLine("No matches found");
            }
            else
            {
                Console.WriteLine("Matched results : ");
                userContactList.ShowContacts(filtered);
            }
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
