using RSGymPT_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_DAL.Interface
{
    public interface IClient
    {

        #region Scalar Properties

        int ClientID { get; }
        int LocationID { get; }
        string Nif { get; }
        DateTime BirthDate { get; }
        string Phone { get; }
        string Email { get; }
        string Observations { get; }
        bool IsActive { get; }

        #endregion

        #region Navigation Properties
        Location Location { get; set; }
        ICollection<Request> Request { get; }

        #endregion



    }
}
