using System;

namespace LifeBank.Application.Common.Interfaces
{
    public interface IUriService
    {
        Uri GetDonorUri(string apiRoute, string donorId);

        Uri GetDonationUri(string apiRoute, string donationId);

        Uri GetAppointmentUri(string apiRoute, string appointmentId);
    }
}
