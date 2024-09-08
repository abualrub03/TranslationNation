using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class DocumentTranslationRequestViewModel
    {
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
        public string TaskDescription { get; set; }
        public string DocumentUrl { get; set; }
        public IFormFile UploadedDocument { get; set; } // For handling file uploads
    }
}
