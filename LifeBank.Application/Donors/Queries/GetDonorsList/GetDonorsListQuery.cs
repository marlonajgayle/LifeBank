using LifeBank.Application.Donors.Models;
using LifeBank.Application.Pagination;
using MediatR;
using System.Collections.Generic;

namespace LifeBank.Application.Donors.Queries.GetDonorsList
{
    public class GetDonorsListQuery : IRequest<List<DonorViewModel>>
    {
        public PaginationFilter PaginatioFilter { get; set; }

        public GetDonorsListQuery(PaginationFilter paginatioFilter)
        {
            PaginatioFilter = paginatioFilter;
        }
    }
}
