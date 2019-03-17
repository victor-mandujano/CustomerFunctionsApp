using CustomerFunctionsApp.DTOs;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerFunctionsApp.Models
{
    public class Customer : TableEntity
    {
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int age { get; set; }

        public Customer (CustomerDTO customerDTO)
        {
            name = customerDTO.name;
            address = customerDTO.address;
            phone = customerDTO.phone;
            email = customerDTO.email;
            age = customerDTO.age;
        }
    }
}
