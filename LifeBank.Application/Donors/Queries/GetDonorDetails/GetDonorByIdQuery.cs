using LifeBank.Application.Donors.Models;
using MediatR;

namespace LifeBank.Application.Donors.Queries
{
    public class GetDonorByIdQuery : IRequest<DonorViewModel>
    {
        public long DonorId { get; set; }

        public GetDonorByIdQuery(long donorId)
        {
            DonorId = donorId;
        }
    }
}
