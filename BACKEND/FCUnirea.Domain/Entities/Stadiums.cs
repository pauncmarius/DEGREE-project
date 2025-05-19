//Stadiums
using System.Collections.Generic;

namespace FCUnirea.Domain.Entities
{
    public class Stadiums : BaseEntity
    {
        public string StadiumName { get; set; }
        public string StadiumLocation { get; set; }
        public int Capacity { get; set; }
        public bool IsInternal { get; set; }


        //--------------Relations--------------------//

        public ICollection<Seats> Stadiums_Seats { get; set; }
        public ICollection<Games> Stadiums_Games { get; set; }
    }
}
