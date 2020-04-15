using LifeBank.Application.Common.Interfaces;
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
