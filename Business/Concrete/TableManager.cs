using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
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
        [ValidationAspect(typeof(TableValidator), Priority = 2)]
        [CacheRemoveAspect("ITableService.Get")]
        [SecuredOperation("table.add,admin", Priority = 1)]
        public IResult Add(Table table)
        {
            _tableDal.Add(table);
            return new SuccessResult(Messages.TableAdded);
        }
        [CacheRemoveAspect("ITableService.Get")]
        [SecuredOperation("table.delete,admin", Priority = 1)]
        public IResult Delete(Table table)
        {
            _tableDal.Delete(table);
            return new SuccessResult(Messages.TableDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Table>> GetAllTablesByRestaurantId(int restaurantId)
        {
            return new SuccessDataResult<List<Table>>(_tableDal.GetAll(t => t.RestaurantId == restaurantId), Messages.TablesListedByRestaurantId);
        }
        [SecuredOperation("table.update,admin", Priority = 1)]
        [ValidationAspect(typeof(TableValidator), Priority = 2)]
        [CacheRemoveAspect("ITableService.Get")]
        public IResult Update(Table table)
        {
            _tableDal.Delete(table);
            return new SuccessResult(Messages.TableUpdated);
        }
    }
}
