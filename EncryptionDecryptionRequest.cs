using System;
using System.Collections.Generic;
using System.Text;

namespace DecryptPGPFunction
{
    public class EncryptionDecryptionRequest
    {
        #region Properties
        public AzureFileInfo InputFile { get; set; }
        public AzureFileInfo OutputFile { get; set; }
        public AzureFileInfo EncryptionDecryptionKeyFile { get; set; }

        public string passPhrase {get;set;}
        public bool Armor { get; set; } = true;
        #endregion

        #region Methods
        public void validate()
        {
            InputFile.Validate(nameof(InputFile));
            OutputFile.Validate(nameof(OutputFile));
            EncryptionDecryptionKeyFile.Validate(nameof(EncryptionDecryptionKeyFile));
        }
        #endregion
    }
}
