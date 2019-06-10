using Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class EditCategoryViewModel : CreateCategoryViewModel
    {
        [Required]
        public int CategoryID { get; set; }

        [Required]
        public CategoryStatus Status { get; set; }
    }
}
