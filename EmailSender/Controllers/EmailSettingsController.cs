using EmailSender.Data.Entities;
using EmailSender.Models;
using EmailSender.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmailSender.Controllers
{
    public class EmailSettingsController : Controller
    {
        private readonly IClientServices _clientServices;

        public EmailSettingsController(IClientServices clientServices)
        {
            _clientServices = clientServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveSettings(CreateClientModel createClient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _clientServices.CreateClientAsync(createClient);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //Logger
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            return View("Index", createClient);
        }
    }
}
