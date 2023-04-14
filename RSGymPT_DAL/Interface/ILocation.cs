using RSGymPT_DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_DAL.Interface
{
    public interface ILocation
    {
        #region Scalar Properties
        int LocationID { get; }

        string PostalCode { get; }

        string City { get; }

        #endregion

        #region Navigation Properties

        ICollection<Client> Client { get; }

        ICollection<PersonalTrainer> PersonalTrainer { get; }

        #endregion
    }
}
