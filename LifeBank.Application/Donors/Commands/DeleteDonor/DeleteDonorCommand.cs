using MediatR;

namespace LifeBank.Application.Donors.Commands.DeleteDonor
{
    public class DeleteDonorCommand : IRequest
    {
        public long DonorId { get; set; }

        public DeleteDonorCommand(long donorId)
        {
            DonorId = donorId;
        }
    }
}
