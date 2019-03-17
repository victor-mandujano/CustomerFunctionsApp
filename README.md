# Customer Functions App

The Customer Functions App contains:
* AddCustomerToQueue (Saver): HTTP-triggered Azure function to add a new customer to Azure Storage Queue.
* AddCustomerToTableStorage (Extractor): Queue-triggered Azure function to retrieve the Customer message from the Storage Queue and insert it to Azure Table Storage.


