using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.BusinessPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBusinessPanelService
    {
        IResult ReceiveBook(ReceiveBookDto receiveBookDto);
        IResult GiveBook(GiveBookDto giveBookDto);
        IDataResult<List<BorrowedListDto>> BorrowedList();
    }
}
