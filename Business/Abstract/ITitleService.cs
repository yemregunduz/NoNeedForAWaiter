using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITitleService
    {
        IResult Add(Title title);
        IResult Delete(Title title);
        IResult Update(Title title);
        IDataResult<List<Title>> GetAll();
    }
}
