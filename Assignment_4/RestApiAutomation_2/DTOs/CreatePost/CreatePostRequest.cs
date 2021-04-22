using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiAutomation_2.DTOs.CreatePost
{
    public class CreatePostRequest
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
    }


}
