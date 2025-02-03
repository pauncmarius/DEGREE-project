﻿using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services.IServices
{
    public interface IStadiumsService
    {
        IEnumerable<Stadiums> GetStadiums();
        Stadiums GetStadium(int id);
        int AddStadium(StadiumsModel stadium);
        void UpdateStadium(Stadiums stadium);
        void DeleteStadium(int id);
    }
}
