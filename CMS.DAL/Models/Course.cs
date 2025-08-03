namespace CMS.DAL.Models;
public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string? ImageName { get; set; }
    public int Hours { get; set; }
    public decimal Price { get; set; }
    // Foreign key for the Trainer who teaches this course
    public string TrainerId { get; set; }
    public ApplicationUser Trainer { get; set; }
    // Navigation property for enrollments (many-to-many with Trainees)
    public ICollection<Enrollment> Enrollments { get; set; }
}
