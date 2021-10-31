﻿using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfProductImageDal : EfEntityRepositoryBase<ProductImage,NoNeedForAWaiterContext>,IProductImageDal
    {
    }
}