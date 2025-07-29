namespace CMS.DAL.Models;
public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string PictureUrl { get; set; }
    public DateTime StartDate { get; set; }
    public decimal Price { get; set; }
    // Foreign key for the Trainer who teaches this course
    public string TrainerId { get; set; }
    public ApplicationUser Trainer { get; set; }
    // Path to the uploaded course material file (e.g., PDF)
    public string MaterialFilePath { get; set; }
    // Navigation property for enrollments (many-to-many with Trainees)
    public ICollection<Enrollment> Enrollments { get; set; }
}
