using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using randominfo.DTO;

namespace randominfo.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class RandomInfoController : ControllerBase
    {
        [HttpGet]
        public IActionResult RandomInfo()
        {
            try
            {
                string ISetPath = Path.Combine(AppContext.BaseDirectory, "util", "InformationSet.json");

                if (!System.IO.File.Exists(ISetPath))
                {
                    return NotFound("El archivo JSON no existe en la ruta especificada.");
                }

                string jsonContent = System.IO.File.ReadAllText(ISetPath);

                List<RandomInfo>? infoList = JsonSerializer.Deserialize<List<RandomInfo>>(jsonContent);

                if (infoList == null || infoList.Count == 0)
                {
                    return NotFound("El archivo JSON está vacío o tiene un formato incorrecto.");
                }

                var random = new Random();
                var randomInfo = infoList[random.Next(infoList.Count)];

                return Ok(randomInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrió un error al procesar la solicitud: {ex.Message}");
            }
        }
    }
}
