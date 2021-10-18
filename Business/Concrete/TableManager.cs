using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class TableManager : ITableService
    {
        ITableDal _tableDal;
        public TableManager(ITableDal tableDal)
        {
            _tableDal = tableDal;
        }
        public IResult Add(Table table)
        {
            _tableDal.Add(table);
            return new SuccessResult(Messages.TableAdded);
        }

        public IResult Delete(Table table)
        {
            _tableDal.Delete(table);
            return new SuccessResult(Messages.TableDeleted);
        }

        public IDataResult<List<Table>> GetAllTablesByRestaurantId(int restaurantId)
        {
            return new SuccessDataResult<List<Table>>(_tableDal.GetAll(t => t.RestaurantId == restaurantId), Messages.TablesListedByRestaurantId);
        }

        public IResult Update(Table table)
        {
            _tableDal.Delete(table);
            return new SuccessResult(Messages.TableUpdated);
        }
    }
}
