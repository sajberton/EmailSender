namespace EmailSender.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using EmailSender.Services.Interfaces;

    public class AdminController : Controller
    {
        private readonly IQueueService _queueService;

        public AdminController(IQueueService queueService)
        {
            _queueService = queueService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UploadXml(IFormFile xmlFile)
        {
            if (xmlFile == null || xmlFile.Length <= 0)
            {
                TempData["Message"] = "Please select a file to upload.";
                return RedirectToAction("Index");
            }

            try
            {
                await _queueService.QueueSendEmailJobXmlFileAsync(xmlFile);

                TempData["Message"] = "Your file is currently processing";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "An error occurred while processing the XML file.";
                // Log the exception
                return RedirectToAction("Index");
            }
        }
    }
}
