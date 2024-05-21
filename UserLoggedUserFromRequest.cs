namespace wos_auditoria_api_canastos.Controllers
{
    public static class HttpContextExtension
    {
        public static string ToCurrentUser(this HttpContext HttpContext)
        {
            return HttpContext.User.FindFirst(ClaimTypes.Email)?.Value ?? throw new ArgumentNullException("current user", "Por favor inicie sesión");
        }
    }
}


[Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = WebHostConstants.AzureAdB2cAuthenticationScheme)]
    [ApiController]
    [ApiVersion("2.0")]
    public class LecturaArticuloUbicacionController : ApiControllerBase
    {
        [HttpGet("TraerUbicacionSobrantes")]
        [ProducesResponseType(typeof(List<AuditoriaCanastosResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllUbicacionesSobrantes([FromQuery] AuditoriaCanastosRequest request)
        {
            return Result(await Mediator.Send(new GetAuditoriadeCanastos { Data = request, Tabla = TableNames.Sobrantes, User = HttpContext.ToCurrentUser() })); 
        }
}
