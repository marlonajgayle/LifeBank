using LifeBank.Application.Donations.Models;
using LifeBank.Application.Pagination;
using MediatR;
using System.Collections.Generic;

namespace LifeBank.Application.Donations.Queries.GetDonationsList
{
    public class GetDonationsListQuery : IRequest<List<DonationViewModel>>
    {
        public PaginationFilter PaginationFilter { get; set; }

        public GetDonationsListQuery(PaginationFilter paginationFilter)
        {
            PaginationFilter = paginationFilter;
        }
    }
}
