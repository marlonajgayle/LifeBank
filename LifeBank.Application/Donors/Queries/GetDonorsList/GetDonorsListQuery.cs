using LifeBank.Application.Donors.Models;
using MediatR;
using System.Collections.Generic;

namespace LifeBank.Application.Donors.Queries.GetDonorsList
{
    public class GetDonorsListQuery : IRequest<List<DonorViewModel>>
    {
    }
}
