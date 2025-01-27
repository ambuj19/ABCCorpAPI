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

        public SecretController()
        {
            string keyVaultUrl = "https://text-to-stats-abc.vault.azure.net/"; // Key Vault URL
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
