using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_Client.ApplicationStructure.Interface
{
    public interface IMenus
    {
        string[] LogMenu { get; }
        string[] ValidationMenu { get; }
        string[] MainMenu { get; }
        string[] UsersSubMenu { get; }
        string[] ClientsSubMenu { get; }
        string[] PTsSubMenu { get; }
        string[] RequestsSubMenu { get; }
        string[] LocationsSubMenu { get; }
        string[] UserUpdateSubMenu { get; }
        string[] clientUpdateSubMenu { get; }
    }
}
