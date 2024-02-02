namespace CompanySearchMVC.Models.Dto
{
    public class CreateCategoryDto
    {
        public required string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}