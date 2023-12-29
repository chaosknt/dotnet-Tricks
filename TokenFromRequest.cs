[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TuControlador : ControllerBase
{
    [HttpGet("ejemplo")]
    public IActionResult Ejemplo()
    {
        
        var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        return Ok("Ejemplo completado");
    }
}
