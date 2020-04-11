using LifeBank.Application.Donations.Models;
using MediatR;
using System.Collections.Generic;

namespace LifeBank.Application.Donations.Queries.GetDonationsList
{
    public class GetDonationsListQuery : IRequest<List<DonationViewModel>>
    {
    }
}
