using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PrjBase.Controllers;

// Apenas usuários com a role "Admin" conseguem acessar
[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    public IActionResult Index() => View();
}
