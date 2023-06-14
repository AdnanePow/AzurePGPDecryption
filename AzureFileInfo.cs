using System;
using System.Collections.Generic;
using System.Text;

namespace DecryptPGPFunction
{
    public class AzureFileInfo
    {
        #region Properties
        public string ConnectionString { get; set; }
        public string BlobContainerName { get; set; }
        public string BlobName { get; set; }
        #endregion

        #region Methods
        public void Validate(string _prefix)
        {
            if(string.IsNullOrEmpty(this.ConnectionString))
            {
                throw new ArgumentException($"{_prefix}: Parameter ConnectionString is required");
            }

            if(string.IsNullOrEmpty(this.BlobContainerName))
            {
                throw new ArgumentException($"{_prefix}: Parameter ConnectionString is required");
            }

            if(string.IsNullOrEmpty(this.BlobName))
            {
                throw new ArgumentException($"{_prefix}: Parameter ConnectionString is required");
            }
        }
        #endregion
    }
}
