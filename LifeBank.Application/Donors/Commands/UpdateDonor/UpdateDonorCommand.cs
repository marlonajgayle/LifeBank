using LifeBank.Application.Donors.Models;
using MediatR;

namespace LifeBank.Application.Donors.Commands.UpdateDonor
{
    public class UpdateDonorCommand : IRequest<DonorViewModel>
    {
        public long DonorId { get; set; }
    }
}
