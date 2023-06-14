using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using PgpCore;

namespace DecryptPGPFunction
{
    public class EncryptionDecryptionController
    {
        public EncryptionDecryptionRequest Request { get; set; }

        public EncryptionDecryptionController(EncryptionDecryptionRequest _request)
        {
            this.Request = _request;
        }

        public async Task EncryptAsync()
        {
            var inputStream = new MemoryStream();
            await DownloadFileFromBlobAsync(Request.InputFile, inputStream);

            var outputStream = new MemoryStream();

            var encryptionKeyStream = new MemoryStream();
            await DownloadFileFromBlobAsync(Request.EncryptionDecryptionKeyFile, encryptionKeyStream);

            await new PGP().EncryptStreamAsync(inputStream, outputStream, encryptionKeyStream, Request.Armor);

            await UploadStreamToBlobAsync(Request.OutputFile, outputStream);
        }

        public async Task DecryptAsync()
        {
            var inputStream = new MemoryStream();
            await DownloadFileFromBlobAsync(Request.InputFile, inputStream);

            var outputStream = new MemoryStream();

            var encryptionKeyStream = new MemoryStream();
            await DownloadFileFromBlobAsync(Request.EncryptionDecryptionKeyFile, encryptionKeyStream);

            await new PGP().DecryptStreamAsync(inputStream, outputStream, encryptionKeyStream, Request.passPhrase);

            await UploadStreamToBlobAsync(Request.OutputFile, outputStream);
        }

        public async Task DownloadFileFromBlobAsync(AzureFileInfo _azureFileInfo, MemoryStream _toStream)
        {
            try
            {
                var blobClient = new BlockBlobClient(_azureFileInfo.ConnectionString, _azureFileInfo.BlobContainerName, _azureFileInfo.BlobName);
                await blobClient.DownloadToAsync(_toStream);
                _toStream.Position = 0;
            }
            catch (Exception ex)
            {
                throw new Azure.RequestFailedException(
                    $"Unable to download file."
                    + $" ConnectionString: {_azureFileInfo.ConnectionString},"
                    + $" BlobContainerName: {_azureFileInfo.BlobContainerName},"
                    + $" BlobName: {_azureFileInfo.BlobName}."
                    + $" Exception message: {ex.Message}");
            }
        }

        public async Task UploadStreamToBlobAsync(AzureFileInfo _azureFileInfo, MemoryStream _stream)
        {
            try
            {
                _stream.Position = 0;
                var blobClient = new BlockBlobClient(_azureFileInfo.ConnectionString, _azureFileInfo.BlobContainerName, _azureFileInfo.BlobName);
                await blobClient.UploadAsync(_stream);
            }
            catch (Exception ex)
            {
                throw new Azure.RequestFailedException(
                    $"Unable to upload file."
                    + $" ConnectionString: {_azureFileInfo.ConnectionString},"
                    + $" BlobContainerName: {_azureFileInfo.BlobContainerName},"
                    + $" BlobName: {_azureFileInfo.BlobName}."
                    + $" Exception message: {ex.Message}");
            }
        }


    }
}
