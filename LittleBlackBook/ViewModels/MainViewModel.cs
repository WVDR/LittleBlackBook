using System;
using System.Collections.Generic;
using IreneAdler.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Data;

namespace LittleBlackBook.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        HttpClient client;
        string url; 
        public MainViewModel()
        {
            //Initialize HTTP Client
            client = new HttpClient();
            url = IreneAdlerAddress + @"/api/ContactApi";
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Contacts = GetContacts().Result;            
        }

        private List<CONTACT> contacts;

        public List<CONTACT> Contacts
        {
            get
            {
                return contacts;
            }
            set
            {
                if(contacts != value)
                {
                    contacts = value;
                    NotifyPropertyChanged("Contacts");
                }
            }
        }

        private CONTACT currentContact;

        public CONTACT CurrentContact
        {
            get
            {
                return currentContact;
            }
            set
            {
                currentContact = value;
                NotifyPropertyChanged("CurrentContact");
            }
        }

        /// <summary>
        /// This is a method purly becuase the view should not be aware of the models.
        /// </summary>
        /// <param name="contact"></param>
        public void SetCurrentContact(object contact)
        {
            //Check if selection is valid.
            if (contact == null || contact.ToString().Contains("NewItemPlaceholder"))
            {
                return;
            }
            CurrentContact = (CONTACT)contact;
        }


        /// <summary>
        /// GET: from api
        /// </summary>
        /// <returns>List of contacts</returns>
        async private Task<List<CONTACT>> GetContacts()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            if (!responseMessage.IsSuccessStatusCode)
            {
                //Do not leave the app in an incorrect state, that can not be recovered from.
                throw new DataException("Could not GET from web api");
            }

            string responseData = responseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<CONTACT>>(responseData);
        }

        public void AddContact()
        {            
            CONTACT contact = new CONTACT
            {                
                Date_Added = DateTime.Now,
                Name = "Enter Name",
                Surname = "Enter Surname",
                Cell = "000 000 0000",
                Land_Line = "000 000 0000",
                Email = "Email needed"
            };                       
            
            CurrentContact = contact;            
            CreateContact(contact);
            Contacts = GetContacts().Result;
        }

        public void SaveCurrentContact()
        {
            SaveContact(CurrentContact.Contact_ID, CurrentContact);
            Contacts = GetContacts().Result;
        }

        public void DeleteCurrentContact()
        {
            DeleteContact(CurrentContact.Contact_ID, CurrentContact);
            Contacts = GetContacts().Result;
        }

        /// <summary>
        /// POST: to api
        /// </summary>
        /// <param name="contact"></param>
        async private void CreateContact(CONTACT contact)
        {
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, contact);
            if (!responseMessage.IsSuccessStatusCode)
            {
                //Do not leave the app in an incorrect state, that can not be recovered from.
                throw new DataException("Could not POST to web api");
            }
        }

        /// <summary>
        /// PUT: to api
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contact"></param>
        async private void SaveContact(long id, CONTACT contact)
        {
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, contact);
            if (!responseMessage.IsSuccessStatusCode)
            {
                //Do not leave the app in an incorrect state, that can not be recovered from.
                throw new DataException("Could not PUT to web api");
            }
        }

        /// <summary>
        /// DELET: from api
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contact"></param>
        async private void DeleteContact(long id, CONTACT contact)
        {
            HttpResponseMessage responseMessage = await client.DeleteAsync(url + "/" + id);
            if (!responseMessage.IsSuccessStatusCode)
            {
                //Do not leave the app in an incorrect state, that can not be recovered from.
                throw new DataException("Could not DELETE from web api");
            }
        }
    }   
}
