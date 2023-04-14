using RSGymPT_DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_DAL.Interface
{
    public interface IPersonalTrainer
    {
        #region Scalar Properties

        int PersonalTrainerID { get; set; }


        int LocationID { get; set; }

        string Code { get; set; }


        string Nif { get; set; }


        string Phone { get; set; }

        string Email { get; set; }

        #endregion

        #region Navigation Properties

        Location Location { get; set; }

        ICollection<Request> Request { get; set; }

        #endregion
    }
}
