using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Xml.Linq;

namespace VideoTheque.ViewModels.Emprunts
{
    public class EmpruntViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Owner")]
        public string IdOwner { get; set; }


    }
}