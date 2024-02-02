namespace CompanySearchMVC.Models.Dto
{
    public class EventDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public int MinParticipants { get; set; }
        public int MaxParticipants { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime RegistrationDeadline { get; set; }
        public IList<CategoryDto>? EventCategories { get; set; }
        public int MembersCount { get; set; }

    }
}