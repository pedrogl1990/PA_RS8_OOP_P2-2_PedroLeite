using RSGymPT_DAL.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_DAL.Model
{
    public class Person : IPerson
    {

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "100 character limit.")]
        public string Name { get; set; }

    }
}
