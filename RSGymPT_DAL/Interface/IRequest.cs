using RSGymPT_DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_DAL.Interface
{
    public interface IRequest
    {
        #region Scalar Properties

        int RequestID { get; set; }

        int ClientID { get; set; }

        int PersonalTrainerID { get; set; }

        DateTime Schedule { get; set; }

        string Status { get; set; }

        string Observations { get; set; }

        #endregion

        #region Navigation Properties

        Client Client { get; set; }

        PersonalTrainer PersonalTrainer { get; set; }

        #endregion
    }
}
