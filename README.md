# PGP File Decryption Azure Function
This repository hosts a .NET Azure Function that enables the decryption of PGP (Pretty Good Privacy) files stored in Azure Blob Storage. The function accepts three parameters to perform the decryption:

**1. PGP Private Key: The private key used for decrypting the PGP file.**

**2. Encrypted File: The path to the encrypted PGP file stored in Azure Blob Storage.**

**3. Output File: The file path where the decrypted content will be saved.**

Using the power of Azure Functions and the security of PGP encryption, this function allows you to easily decrypt PGP files and retrieve the original content from your Azure Blob Storage. Simply provide the necessary parameters and let the function handle the decryption process.

Feel free to explore and utilize this Azure Function to streamline your PGP file decryption workflows and enhance the security of your data stored in Azure Blob Storage.


# Decryption Class
This repository contains a C# class named "Decryption" that represents an Azure Function for decrypting PGP files. The function is triggered via an HTTP request and performs the decryption process using the provided parameters.

## Functionality
The Decryption Azure Function offers the following features:

**1. HTTP Trigger: The function is triggered by an HTTP request and uses the "post" method.**

**2. Request Validation: It validates the incoming request to ensure all necessary parameters are present and in the correct format.**

**3. Decryption: The function utilizes the EncryptionDecryptionController class to perform the actual decryption process asynchronously.**

**4. Logging: It logs relevant information and any errors that occur during the decryption process.**

## Usage
To use the Decryption Azure Function, follow these steps:

**1. Deploy the Azure Function to your desired Azure environment.**

**2. Trigger an HTTP POST request to the function endpoint with the necessary parameters.**

**3. The function will validate the request, decrypt the PGP file, and log the execution status.**

## Class Details

The Decryption class includes the following methods and components:

**1. Run:** The Run method is the entry point for the Azure Function and handles the HTTP trigger. It receives the HttpRequest object and ILogger instance as parameters. It reads the request body, deserializes it into an EncryptionDecryptionRequest object, validates the request, and initiates the decryption process.

**2. Logging:** The ILogger instance is used to log information and errors during the execution of the function.

**3. Exception Handling:** Any exceptions that occur during the decryption process are caught and logged, and a BadRequestObjectResult is returned with the corresponding error message.

#  Azure File Information Class
This repository includes a C# class named "AzureFileInfo" that represents the file information required for accessing and processing files stored in Azure Blob Storage. The class provides properties for the Azure Blob Storage connection string, blob container name, and blob name.

## Properties
The AzureFileInfo class includes the following properties:

**1. ConnectionString: Represents the connection string for accessing the Azure Blob Storage account.**

**2. BlobContainerName: Specifies the name of the blob container where the file is stored.**

**3. BlobName: Represents the name of the specific blob/file within the container.**

## Methods
The AzureFileInfo class includes the following method:

**- Validate: This method validates the AzureFileInfo object by ensuring that the required properties (ConnectionString, BlobContainerName, and BlobName) are not null or empty. It takes a prefix parameter (_prefix) that can be used to provide additional context or details in the error message if any of the properties are missing.**

## Usage
To use the AzureFileInfo class, follow these steps:

**1. Instantiate an AzureFileInfo object.**

**2. Set the ConnectionString, BlobContainerName, and BlobName properties with the relevant values.**

**3. Call the Validate method to ensure that the required properties are provided.**

# Encryption/Decryption Controller Class

This repository includes a C# class named "EncryptionDecryptionController" that serves as the controller for handling encryption and decryption operations on PGP files. The class utilizes the PgpCore library and Azure.Storage.Blobs.Specialized namespace for file processing and Azure Blob Storage integration.

## Properties
The EncryptionDecryptionController class includes the following property:

**- Request: Represents an instance of the EncryptionDecryptionRequest class, which contains the parameters required for encryption or decryption.**

## Methods
The EncryptionDecryptionController class includes the following methods:

**1. EncryptAsync(): This method performs the encryption process. It downloads the input file from Azure Blob Storage, encrypts the stream using the specified encryption key file, and uploads the resulting encrypted content to Azure Blob Storage as the output file.**

**2. DecryptAsync(): This method performs the decryption process. It downloads the input file from Azure Blob Storage, decrypts the stream using the specified encryption key file and passphrase, and uploads the decrypted content to Azure Blob Storage as the output file.**

**3. DownloadFileFromBlobAsync(AzureFileInfo, MemoryStream): This method downloads a file from Azure Blob Storage. It takes an AzureFileInfo object that contains the connection string, blob container name, and blob name, as well as a MemoryStream to store the downloaded file content.**

**4. UploadStreamToBlobAsync(AzureFileInfo, MemoryStream): This method uploads a stream to Azure Blob Storage. It takes an AzureFileInfo object representing the destination blob, as well as a MemoryStream containing the content to be uploaded.**

## Usage
To use the EncryptionDecryptionController class, follow these steps:

**1. Instantiate an EncryptionDecryptionController object and provide an instance of the EncryptionDecryptionRequest class containing the necessary parameters.**

**2. Call the EncryptAsync() method to perform the encryption process or the DecryptAsync() method to perform the decryption process.**

**3. The class will handle downloading the input file, performing the encryption or decryption, and uploading the result to Azure Blob Storage.**
