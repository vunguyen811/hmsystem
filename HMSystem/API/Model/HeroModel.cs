using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    /// <summary>
    /// HeroModel
    /// </summary>
    public class HeroModel
    {
        /// <summary>
        /// Name
        /// </summary>
        [Required(ErrorMessage ="Name require")]
        public string Name { get; set; }
    }

}
