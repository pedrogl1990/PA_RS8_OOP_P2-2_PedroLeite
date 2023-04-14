using RSGymPT_DAL.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_DAL.Model
{
    public class Request : IRequest
    {
        #region Scalar Properties

        [Key]
        public int RequestID { get; set; }

        [Required(ErrorMessage = "ClientID is required.")]
        public int ClientID { get; set; }

        [Required(ErrorMessage = "PersonalTrainerID is required.")]
        public int PersonalTrainerID { get; set; }

        [Required(ErrorMessage = "Schedule is required.")]
        public DateTime Schedule { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [RegularExpression(@"^(ended|scheduled|cancelled)$", ErrorMessage = "Status must have one of the following options: ended, scheduled or cancelled.")]
        [MaxLength(50, ErrorMessage = "Status must have a limit of 50 characters.")]
        public string Status { get; set; }

        [MaxLength(255, ErrorMessage = "255 character limit.")]
        public string Observations { get; set; }

        #endregion

        #region Navigation Properties

        public Client Client { get; set; }

        public PersonalTrainer PersonalTrainer { get; set; }
        #endregion
    }
}
