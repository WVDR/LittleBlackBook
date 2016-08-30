using System;
using System.Collections.Generic;
using IreneAdler.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace LittleBlackBook.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        HttpClient client;
        string url; 
        public MainViewModel()
        {
            client = new HttpClient();
            url = IreneAdlerAddress + @"/api/ContactApi";
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            GetContacts();
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


        
        async private void GetContacts()
        {
            //Initialize HTTP Client 

            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                string responseData = responseMessage.Content.ReadAsStringAsync().Result;
                Contacts = JsonConvert.DeserializeObject<List<CONTACT>>(responseData);               
            }            
        }        
    }   
}
