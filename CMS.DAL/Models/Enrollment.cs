namespace CMS.DAL.Models;
public class Enrollment
{
    // Foreign key for the Trainee
    public string TraineeId { get; set; }
    public ApplicationUser Trainee { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public DateTime EnrollmentDate { get; set; }
}