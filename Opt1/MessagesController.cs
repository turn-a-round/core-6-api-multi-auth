[Authorize(Policy = "read:messages")]
public class MessagesController : ControllerBase
{
    // ...
}
