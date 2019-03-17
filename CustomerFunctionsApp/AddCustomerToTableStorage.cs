using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using CustomerFunctionsApp.DTOs;
using CustomerFunctionsApp.Models;
using System.Threading.Tasks;

namespace CustomerFunctionsApp
{
   
    public static class AddCustomerToTableStorage
    {
        [FunctionName("Extractor")]
        
        public static void Run([QueueTrigger("customersToAddQueue", Connection = "AzureWebJobsStorage")] CustomerDTO customerDTO,
           [Table("Customers", Connection = "AzureWebJobsStorage")] ICollector<Customer> outputTable, ILogger log)
        {
            try
            {
                log.LogInformation($"CustomerFunctionsApp.AddCustomerToTableStorage Received customer data: {customerDTO}");

                var customer = new Customer(customerDTO) {
                    PartitionKey = "Customers",
                    RowKey = Guid.NewGuid().ToString()
                };
 
                outputTable.Add(customer);
            }
            catch (Exception ex)
            {
                log.LogError("CustomerFunctionsApp.AddCustomerToTableStorage: " + ex.ToString());
            }
        }
    }
}
