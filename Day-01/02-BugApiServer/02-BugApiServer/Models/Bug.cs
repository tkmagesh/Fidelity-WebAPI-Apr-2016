using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _02_BugApiServer.Models
{
    public class Bug
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage ="IsClosed is required")]
        public bool IsClosed { get; set; }

        [Required(ErrorMessage ="CreatedAt is mandatory")]
        public DateTime createdAt { get; set; }
    }
}