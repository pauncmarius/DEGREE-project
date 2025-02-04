using System.Collections.Generic;

namespace FCUnirea.Business.Models
{
    public class StadiumsModel
    {
        public string StadiumName { get; set; }

        public string StadiumLocation { get; set; }

        public int Capacity { get; set; }

        //--------------Relations--------------------//

        public ICollection<SeatsModel> Seats { get; set; }
        public ICollection<GamesModel> Games { get; set; }
    }
}
