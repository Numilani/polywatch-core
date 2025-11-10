using Microsoft.AspNetCore.Mvc;
using polywatchcore.Services;

namespace polywatchcore.Controllers;

[ApiController]
[Route("gdeltevents")]
public class GDELTEventController(GDELTNewsService gdelt) : ControllerBase
{
    [HttpGet("manual/parse")]
    public async Task<IActionResult> FetchAndParse()
    {
      var contents = await gdelt.ParseEventFile(await gdelt.FetchEventFileContents());
      await gdelt.SaveEvents(contents);

      object rv = new{
        Count = contents.Count,
        Sample = contents[0]
      };
      return Ok(rv);
    }
}
