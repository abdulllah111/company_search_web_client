namespace CompanySearchMVC.Models.Dto
{
    public class CategoryDto
    {
        public Guid? CreatorId { get; set; }
        public required string Name { get; set; }
        public CategoryDto? ParentCategory { get; set; }
        public IList<CategoryDto>? ChildCategories { get; set; }
        public bool IsShared { get; set; } 
    }
}