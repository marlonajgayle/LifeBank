using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Pagination;
using Microsoft.AspNetCore.WebUtilities;
using System;

namespace LifeBank.Infrastructure
{
    public class UriService : IUriService
    {
        private readonly string baseUri;

        public UriService(string baseUri)
        {
            this.baseUri = baseUri;
        }

        public Uri GetAllDonorsUri(PaginationFilter paginationFilter = null)
        {
            if (paginationFilter == null)
            {
                return new Uri(baseUri);
            }

            var modifiedUri = QueryHelpers.AddQueryString(baseUri, "Page", paginationFilter.Page.ToString());
            modifiedUri = QueryHelpers.AddQueryString(baseUri, "Size", paginationFilter.Size.ToString());

            return new Uri(modifiedUri);
        }

        public Uri GetAppointmentUri(string apiRoute, string appointmentId)
        {
            return new Uri(baseUri + apiRoute.Replace("{appointmentId}", appointmentId));
        }

        public Uri GetDonationUri(string apiRoute, string donationId)
        {
            return new Uri(baseUri + apiRoute.Replace("{donationId}", donationId));
        }

        public Uri GetDonorUri(string apiRoute, string donorId)
        {
            return new Uri(baseUri + apiRoute.Replace("{donorId}", donorId));
        }
    }
}
