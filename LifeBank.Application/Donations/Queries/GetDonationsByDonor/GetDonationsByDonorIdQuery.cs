using LifeBank.Application.Donations.Models;
using MediatR;
using System.Collections.Generic;

namespace LifeBank.Application.Donations.Queries.GetDonationsByDonor
{
    public class GetDonationsByDonorIdQuery : IRequest<List<DonationViewModel>>
    {
        public long DonorId { get; set; }

        public GetDonationsByDonorIdQuery(long donorId)
        {
            DonorId = donorId;
        }
    }
}
