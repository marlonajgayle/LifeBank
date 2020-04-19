using AutoMapper;
using LifeBank.Api.Contracts.Version1.Requests;
using LifeBank.Application.Pagination;

namespace LifeBank.Api.Mappings
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<PaginationRequest, PaginationFilter>();
        }
    }
}
