using System.Collections.Generic;

namespace FCUnirea.Domain.Entities
{
    public class Stadiums : BaseEntity
    {
        public string StadiumName { get; set; }

        public string StadiumLocation { get; set; }

        public int Capacity { get; set; }

        //--------------Relations--------------------//

        public ICollection<Seats> Seats { get; set; }
        public ICollection<Games> Games { get; set; }
    }
}
