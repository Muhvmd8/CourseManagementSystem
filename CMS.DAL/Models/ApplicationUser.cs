namespace CMS.DAL.Models;
public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = default!;
    public ICollection<Course> Courses { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }
}
