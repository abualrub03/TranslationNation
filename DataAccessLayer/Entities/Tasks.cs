using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public  class Tasks
    {
        public int TaskId { get; set; }
        public int? TaskServiceCategoryId { get; set; }
        public int? TaskServiceId { get; set; }
        public string? TaskTitle { get; set; }
        public DateTime? TaskDeadlineDateTime { get; set; }
        public string? TaskRequesterDescription { get; set; }
        public string? TaskRequesterAttachmentsUrl { get; set; }
        public string? TaskRequesterAttachmentFilePath { get; set; }
        public string? TaskStatus { get; set; }
        public int? TaskRequesterAccountId { get; set; }
        public int? TaskResponderAccountId { get; set; }
        public string? TaskResponderDescription { get; set; }
        public string? TaskResponderAttachmentsUrl { get; set; }
        public string? TaskResponderAttachmentFileName { get; set; }
        public string? TaskResponderUploadFolderName { get; set; }
        public DateTime? TaskResponseDateTime { get; set; }
    }
}
