namespace CMS.DAL.Repositories;
public class CourseRepository(ApplicationDbContext dbContext)  
    : ICourseRepository
{
    public int Add(Course course)
    {
        dbContext.Courses.Add(course);
        return dbContext.SaveChanges();
    }
    public int Delete(Course course)
    {
        dbContext.Courses.Remove(course);
        return dbContext.SaveChanges();
    }
    public IEnumerable<Course> GetAll(bool withTracking = false)
            => withTracking ? dbContext.Courses.ToList()
                : dbContext.Courses.AsNoTracking().ToList();
    public Course? GetById(int id)
    {
        var course = dbContext.Courses.FirstOrDefault(c => c.Id == id);
        return course is not null ? course : null;
    }
    public int Update(Course course)
    {
        dbContext.Courses.Update(course);
        return dbContext.SaveChanges();
    }
    public int NumberOfTraineesInCourse(int courseId)
    => dbContext.Enrollments
    .Where(c => c.CourseId == courseId)
    .Count();
    public int NumberOfTraineesForTrainer(string trainerId)
        => (
               from c in dbContext.Courses
               join e in dbContext.Enrollments
               on c.Id equals e.CourseId
               where c.TrainerId == trainerId
               select e.TraineeId
           )
           .Distinct()
           .Count();
    public IEnumerable<Course> GetAllByTrainerId(string trainerId)
        => dbContext.Courses
        .Where(c => c.TrainerId == trainerId)
        .ToList();
}
