using Donouts.Application.Dto.Activities;
using DonoutsCore.Common.Models;
using MediatR;

namespace Donouts.Application.Activities.Queries.GetAll;

public class GetAllActivities :  IRequest<ResponseDto<List<ActivitiesDTO>>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    public GetAllActivities(int pageNumber, int pageSize)
    {
        this.PageNumber = pageNumber;
        this.PageSize = pageSize;
    }
    public GetAllActivities()
    {

    }
}