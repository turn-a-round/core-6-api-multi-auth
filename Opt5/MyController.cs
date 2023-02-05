[Authorize(AuthenticationSchemes = "JwtBearer, OAuth")]
[Route("api/[controller]")]
[ApiController]
public class MyController : ControllerBase
{
   [HttpGet]
   public ActionResult<IEnumerable<string>> Get()
   {
      return new string[] { "value1", "value2" };
   }
}
