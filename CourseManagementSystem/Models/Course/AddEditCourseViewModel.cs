namespace CMS.PL.Models.Course;
public class AddEditCourseViewModel
{
    public string Title { get; set; }
    public string Description { get; set; } 
    public decimal Price { get; set; }
    public int Hours { get; set; }
    public string? ImageName { get; set; } // Current Image
    public IFormFile? Image { get; set; } // New Image
}
