using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace vabalas_api.Controllers;

[Route("api/users")]
[ApiController]
[Authorize]
public class UserControler : ControllerBase
{
}