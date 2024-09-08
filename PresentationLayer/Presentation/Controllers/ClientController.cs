using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using TranslationNation.Controllers;
using Microsoft.Data.SqlClient;
using System.Data;
using Entities;

namespace TranslationNation.Web.Controllers
{
    
    public class ClientController : AuthorizedController
    {
        public IActionResult ClientIndex()
        {
           
            return View("ClientIndex", GetCurrentUser());
        } 
        public IActionResult CurrentTasks()
        {
           
            return View("CurrentTasks", GetCurrentUser());
        }
        public IActionResult NewServiceRequest_Document()
        {

            return View("NewServiceRequest_Document", GetCurrentUser());
        }
        public IActionResult NewServiceRequest_Video()
        {

            return View("NewServiceRequest_Video", GetCurrentUser());
        }

        public  async Task<IActionResult> signOutFromAuthorized()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Customer");
        }
        [HttpPost]
        public async Task<IActionResult> NewServiceRequest_Document(ViewModel.DocumentTranslationRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Generate a unique filename for the uploaded document
                string uniqueFileName = null;
                if (model.UploadedDocument != null)
                {
                    string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/Documents");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.UploadedDocument.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.UploadedDocument.CopyToAsync(stream);
                    }
                }
                Entities.Tasks task = new Entities.Tasks();
                task.TaskTitle= model.Title;
                task.TaskRequesterDescription= model.TaskDescription;
                task.TaskDeadlineDateTime= model.Deadline;
                task.TaskRequesterAttachmentFilePath= uniqueFileName;
                task.TaskRequesterAccountId= GetCurrentUser().AccountId;
                task.TaskRequesterAttachmentsUrl= model.DocumentUrl;
                var a = new RacoonProvider.TN_DB_Tasks().new_WrittenTranslation_DocumentTask(task);


                return RedirectToAction("Success");
            }

            return View("NewServiceRequest_Document", GetCurrentUser());
        }

        [HttpPost]
        public async Task<IActionResult> NewServiceRequest_Video(ViewModel.DocumentTranslationRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Generate a unique filename for the uploaded document
                string uniqueFileName = null;
                if (model.UploadedDocument != null)
                {
                    string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/Videos");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.UploadedDocument.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.UploadedDocument.CopyToAsync(stream);
                    }
                }
                Entities.Tasks task = new Entities.Tasks();
                task.TaskTitle= model.Title;
                task.TaskRequesterDescription= model.TaskDescription;
                task.TaskDeadlineDateTime= model.Deadline;
                task.TaskRequesterAttachmentFilePath= uniqueFileName;
                task.TaskRequesterAccountId= GetCurrentUser().AccountId;
                task.TaskRequesterAttachmentsUrl= model.DocumentUrl;
                var a = new RacoonProvider.TN_DB_Tasks().new_WrittenTranslation_VideoTask(task);


                return RedirectToAction("Success");
            }

            return View("NewServiceRequest_Document", GetCurrentUser());
        }


    }
}
