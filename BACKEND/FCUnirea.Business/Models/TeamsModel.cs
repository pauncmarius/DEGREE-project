//TeamsModel
using System.ComponentModel.DataAnnotations.Schema;

namespace FCUnirea.Business.Models
{ 
    public class TeamsModel
    {
        public int Id { get; set; }

        public string TeamName { get; set; }

        [Column(TypeName = "TEXT")]
        public string Description { get; set; }

        public string CoachName { get; set; }

    }
}
