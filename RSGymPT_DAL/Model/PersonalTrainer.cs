using RSGymPT_DAL.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_DAL.Model
{
    public class PersonalTrainer : Person, IPersonalTrainer
    {
        #region Scalar Properties

        [Key]
        public int PersonalTrainerID { get; set; }

        [Required(ErrorMessage = "LocationID is required.")]
        public int LocationID { get; set; }

        [Required]
        [RegularExpression(@"^\w{4}$", ErrorMessage = "Code must have exactly 4 characters.")]
        [MaxLength(4, ErrorMessage = "Code must have a limit of 4 digits.")]
        [Column(TypeName = "CHAR")]
        public string Code { get; set; }

        [Required(ErrorMessage = "NIF is required.")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Code must have exactly 9 digits.")]
        [MaxLength(9, ErrorMessage = "NIF must have a limit of 9 digits.")]
        [Column(TypeName = "CHAR")]
        public string Nif { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Phone must have exactly 9 digits.")]
        [MaxLength(9, ErrorMessage = "Phone must have a limit of 9 digits.")]
        [Column(TypeName = "CHAR")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(100, ErrorMessage = "100 characters limit.")]
        public string Email { get; set; }

        #endregion

        #region Navigation Properties

        public Location Location { get; set; }

        public ICollection<Request> Request { get; set; }

        #endregion
    }
}
