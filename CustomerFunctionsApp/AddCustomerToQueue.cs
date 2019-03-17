using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CustomerFunctionsApp.DTOs;

namespace CustomerFunctionsApp
{
    public static class AddCustomerToQueue
    {
        // TODO: Implement proper Authorization for the Azure function.
        [FunctionName("Saver")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] CustomerDTO customer,
            [Queue("customersToAddQueue", Connection = "AzureWebJobsStorage")] IAsyncCollector<CustomerDTO> outputQueue,
            ILogger log)
        {
            try
            {
                log.LogInformation("CustomerFunctionsApp.AddCustomerToQueue - Recevied customer data: " +
                    customer);

                // TODO: Some defensive programming should be implemented at this point 
                // in case some argument is invalid or null and return 400 Bad Request if it does.

                await outputQueue.AddAsync(customer);

                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            catch(Exception ex)
            {
                // TODO: Implement a decoupled logging layer.
                log.LogError("CustomerFunctionsApp.AddCustomerToQueue: " + ex.ToString());
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
