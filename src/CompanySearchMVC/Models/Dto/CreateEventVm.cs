using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CompanySearchMVC.Common.Mappings;

namespace CompanySearchMVC.Models.Dto
{
    public class CreateEventVm : IMapFrom<CreateEventDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public LocationPoint? Location { get; set; }
        public EventType EventType { get; set; }
        public int MinParticipants { get; set; }
        public int MaxParticipants { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public DateTime RegistrationDeadline { get; set; }
        public Gender ParticipantsGender { get; set; }
        public IList<CategoryDto> EventCategories { get; set; } = new List<CategoryDto>();

        public IList<Guid?> SelectedCategories { get; set; }
        public IList<CategoryDto>? AvailableCategories { get; set; } = new List<CategoryDto>();
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEventVm, CreateEventDto>()
            .ForMember(eventDto => eventDto.EventCategories,
            opt => opt.MapFrom(eventVM => eventVM.EventCategories));
        }
    }
}