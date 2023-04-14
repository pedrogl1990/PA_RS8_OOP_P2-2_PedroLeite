using RSGymPT_DAL.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_DAL.Model
{
    public class Location : ILocation
    {
        #region Scalar Properties

        // PK
        [Key]
        public int LocationID { get; set; }


        [Required(ErrorMessage = "Postal Code is required.")]
        [RegularExpression(@"^\d{4}-\d{3}$", ErrorMessage = "Postal code must be in the format XXXX-XXX.")]
        [MaxLength(8, ErrorMessage = "Postal code must have a limit of 8 characters.")]
        [Column(TypeName = "CHAR")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [MaxLength(100, ErrorMessage = "100 character limit.")]
        public string City { get; set; }


        #endregion

        #region Navigation Properties

        public ICollection<Client> Client { get; set; }

        public ICollection<PersonalTrainer> PersonalTrainer { get; set; }

        #endregion
    }
}
