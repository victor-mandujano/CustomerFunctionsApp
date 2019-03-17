using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerFunctionsApp.DTOs
{
    public class CustomerDTO
    {
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int age { get; set; }

        public override string ToString()
        {
            return new StringBuilder().Append(" Name: ").Append(name)
                .Append(" Address: ").Append(address)
                .Append(" Phone: ").Append(phone)
                .Append(" Email: ").Append(email)
                .Append(" Age: ").Append(age)
                .ToString();
        }
    }
}
