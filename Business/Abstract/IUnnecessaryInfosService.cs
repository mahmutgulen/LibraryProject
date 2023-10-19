using Core.Utilities.Results;
using Entities.Dtos.UnnecessaryInfos;

namespace Business.Abstract
{
    public interface IUnnecessaryInfosService
    {
        IDataResult<List<MostReadBookListDto>> MostReadBooks();
        IDataResult<List<MostPageBookListDto>> MostPageBooks();
        IDataResult<List<OldestUsersListDto>> OldestUsers();
        IDataResult<List<MostBookReadUser>> MostBookReadUsers();
        IDataResult<HowManyDaysLeftDto> HowManyDaysLeft();

        IResult TryStoredProcedure();
    }
}
