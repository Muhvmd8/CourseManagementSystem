namespace CMS.DAL.Repositories;
public class TraineeRepository(ApplicationDbContext dbContext)
    : ITraineeRepository
{
    public async Task<IEnumerable<Course>> GetAllCourses(bool withTracking = false)
        => withTracking ? await dbContext.Courses.ToListAsync()
            : await dbContext.Courses.AsNoTracking().ToListAsync();
    public async Task<Course?> GetById(int id)
         => await dbContext.Courses.FirstOrDefaultAsync(c => c.Id == id);
    public async Task<IEnumerable<Course>> MyCourses(string traineeId)
       =>    await dbContext.Enrollments
            .Where(e => e.TraineeId == traineeId)
            .Include(e => e.Course)
            .Select(e => e.Course).ToListAsync();
    public int RegisterToCourse(Enrollment enrollment)
    {
        dbContext.Enrollments.Add(enrollment);
        return dbContext.SaveChanges();
    }
    public async Task<bool> IsTraineeEnrolledInCourse(string traineeId, int courseId)
        => await dbContext.Enrollments
            .AnyAsync(e => e.TraineeId == traineeId && e.CourseId == courseId);
}
