using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPlanning_V2.Models
{
    public class ToastModel
    {
        public string? messang {get;set;}
        public string? action {get; set;} = "success";
        public bool autohide {get; set;} =true;
        public int delay {get; set;} = 3000;
    }
}