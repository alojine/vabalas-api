using AutoMapper;
using vabalas_api.Controllers.Job.Dtos;
using vabalas_api.Models;

namespace vabalas_api.Mappers;

public class JobMapper : Profile
{
    public JobMapper()
    {
        CreateMap<Job, JobAddRequestDto>();
    }
}