
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DecryptPGPFunction
{
    public static class Decryption
    {
        [FunctionName("Decryption")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req, ILogger log)
        {
            log.LogInformation($"C# HTTP trigger Decryption function processed a request at: {DateTime.Now}");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
			
			var request = JsonConvert.DeserializeObject<EncryptionDecryptionRequest>(requestBody);

			try
            {
                if(request == null)
                {
                    throw new ArgumentException("Request parameters are missing or not in the correct format.");
                }

                request.validate();

                await new EncryptionDecryptionController(request).DecryptAsync();
            }
            catch (Exception ex)
            {
                log.LogError($"The following execption has occurred: {ex.ToString()}");
                return new BadRequestObjectResult(ex.Message);
            }

            log.LogInformation($"Encription AZ function executed successfully.");

            return new OkResult();
        }
    }
}
