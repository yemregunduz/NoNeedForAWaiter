using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITableService
    {
        IResult Add(Table table);
        IResult Delete(Table table);
        IResult Update(Table table);
        IDataResult<List<Table>> GetAllTablesByRestaurantId(int restaurantId);
    }
}
