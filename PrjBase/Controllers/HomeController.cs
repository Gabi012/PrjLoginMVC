using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PrjBase.Controllers;

[Authorize] // Requer apenas estar autenticado, qualquer role
public class HomeController : Controller
{
    public IActionResult Index() => View();
}
