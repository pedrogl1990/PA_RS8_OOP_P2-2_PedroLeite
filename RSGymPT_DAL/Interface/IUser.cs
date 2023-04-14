using RSGymPT_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_DAL.Interface
{
    public interface IUser
    {

        #region Scalar Properties
        int UserID { get; set; }
        string Code { get; set; }
        string Password { get; set; }
        User.ProfileType Profile { get; set; }

        #endregion
    }
}
