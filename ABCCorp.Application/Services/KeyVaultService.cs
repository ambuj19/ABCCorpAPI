using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.Application.Services
{
    public class KeyVaultService
    {
        private readonly SecretClient _secretClient;

        public KeyVaultService(string keyVaultUrl)
        {
            var credential = new DefaultAzureCredential(); // Using Managed Identity or Azure AD credentials
            _secretClient = new SecretClient(new Uri(keyVaultUrl), credential);
        }

        // Fetch the secret from Azure Key Vault
        public async Task<string> GetSecretAsync(string secretName)
        {
            var secret = await _secretClient.GetSecretAsync(secretName);
            return secret.Value.Value;
        }
    }
}
