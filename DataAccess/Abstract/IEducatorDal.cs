﻿using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEducatorDal : IEntityRepository<Educator>
    {
        void DeleteId(int id);
    }
}
