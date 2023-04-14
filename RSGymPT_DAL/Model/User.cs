using RSGymPT_DAL.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_DAL.Model
{
    public class User : Person, IUser
    {
        #region Scalar Properties
        public enum ProfileType : byte
        {
            admin = 0,
            colab = 1
        }

        // PK
        [Key]
        public int UserID { get; set; }


        [Required(ErrorMessage = "Code is required.")]
        [MaxLength(6, ErrorMessage = "Code must have 6 characters or less.")]
        [MinLength(4, ErrorMessage = "Code must be at least 4 characters.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(12, ErrorMessage = "Password must be 12 characters or less.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Profile is required.")]
        public ProfileType Profile { get; set; }

        #endregion

        #region Navigation Properties


        #endregion
    }
}
