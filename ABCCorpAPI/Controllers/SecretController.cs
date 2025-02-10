using Microsoft.AspNetCore.Mvc;
using ABCCorp.Application;
using ABCCorp.Application.Services;

namespace ABCCorp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretController : Controller
    {
        private readonly KeyVaultService _keyVaultService;

        public SecretController(IConfiguration configuration)
        {
            // Read Key Vault URL from appsettings.json
            string keyVaultUrl = configuration["AzureKeyVault:Url"];

            if (string.IsNullOrEmpty(keyVaultUrl))
            {
                throw new ArgumentNullException(nameof(keyVaultUrl), "Key Vault URL is not configured.");
            }

            // Initialize KeyVaultService with the URL from appsettings.json
            _keyVaultService = new KeyVaultService(keyVaultUrl);
        }
        [HttpGet("{secretName}")]
        public async Task<IActionResult> GetSecret(string secretName)
        {
            try
            {
                var secretValue = await _keyVaultService.GetSecretAsync(secretName);
                return Ok(new { secret = secretValue });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error fetching secret: {ex.Message}");
            }
        }
    }
}
