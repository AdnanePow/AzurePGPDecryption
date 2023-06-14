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
