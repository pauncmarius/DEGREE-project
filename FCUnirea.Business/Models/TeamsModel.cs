using FCUnirea.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCUnirea.Business.Models
{ 
    public class TeamsModel
    {
        public string TeamName { get; set; }

        public TeamType TeamType { get; set; }

        public bool IsInternal { get; set; }

        [Column(TypeName = "TEXT")]
        public string Record { get; set; }
    }
}
