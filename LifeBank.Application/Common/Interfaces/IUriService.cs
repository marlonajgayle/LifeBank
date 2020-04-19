using LifeBank.Application.Pagination;
using System;

namespace LifeBank.Application.Common.Interfaces
{
    public interface IUriService
    {
        Uri GetDonorUri(string apiRoute, string donorId);
        Uri GetAllDonorsUri(PaginationFilter paginationFilter = null);

        Uri GetDonationUri(string apiRoute, string donationId);

        Uri GetAppointmentUri(string apiRoute, string appointmentId);
    }
}
