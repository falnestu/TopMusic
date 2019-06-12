using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }

        public string Status
        {
            get
            {
                var status = (Common.Entities.CategoryStatus)Category.Statut;
                switch (status)
                {
                    case Common.Entities.CategoryStatus.Invisible:
                        return "Invisible";
                    case Common.Entities.CategoryStatus.Closed:
                        return "Fermé aux votes";
                    case Common.Entities.CategoryStatus.Opened:
                        return "Ouvert aux votes";
                    default:
                        return null;
                }
            }
        }
    }
}
