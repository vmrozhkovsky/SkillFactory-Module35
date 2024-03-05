using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Controllers;

public class LogController : Controller
{
    private readonly IRequestRepository _repo;

    public LogController(IRequestRepository repo)
    {
        _repo = repo;
    }
    
    public async Task <IActionResult> Index()
    {
        var requests = await _repo.GetRequests();
        return View(requests);
    }
}