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
    public class TitleManager : ITitleService
    {
        ITitleDal _titleDal;
        public TitleManager(ITitleDal titleDal)
        {
            _titleDal = titleDal;
        }
        public IResult Add(Title title)
        {
            _titleDal.Add(title);
            return new SuccessResult(Messages.TitleAdded);

        }

        public IResult Delete(Title title)
        {
            _titleDal.Delete(title);
            return new SuccessResult(Messages.TitleDeleted);
        }

        public IDataResult<List<Title>> GetAll()
        {
            return new SuccessDataResult<List<Title>>(_titleDal.GetAll(),Messages.TitleListed);
        }

        public IResult Update(Title title)
        {
            _titleDal.Update(title);
            return new SuccessResult(Messages.TitleUpdated);
        }
    }
}
