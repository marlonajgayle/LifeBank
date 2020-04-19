using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Common.Models.Responses;
using LifeBank.Application.Pagination;
using System.Collections.Generic;
using System.Linq;

namespace LifeBank.Api.Services
{
    public static class PaginationService
    {
        public static PagedResponse<T> CreatePaginatedResponse<T>(IUriService uriService, PaginationFilter paginationFilter, List<T> reponse)
        {
            if (paginationFilter == null || paginationFilter.Page < 1 || paginationFilter.Size < 1)
            {
                return new PagedResponse<T> { Data = reponse };
            }

            var nextPage = paginationFilter.Size >= 1 ?
                uriService.GetAllDonorsUri(new PaginationFilter(paginationFilter.Page + 1, paginationFilter.Size)).ToString()
                : null;

            var previousPage = paginationFilter.Size - 1 >= 1 ?
                uriService.GetAllDonorsUri(new PaginationFilter(paginationFilter.Page - 1, paginationFilter.Size)).ToString()
                : null;

            return new PagedResponse<T>
            {
                Data = reponse,
                PageNumber = paginationFilter.Page >= 1 ? paginationFilter.Page : (int?)null,
                PageSize = paginationFilter.Size >= 1 ? paginationFilter.Size : (int?)null,
                NextPage = reponse.Any() ? nextPage : null,
                PreviousPage = previousPage
            };
        }
    }
}
