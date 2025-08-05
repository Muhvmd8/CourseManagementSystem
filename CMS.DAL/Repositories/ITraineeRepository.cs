namespace CMS.DAL.Repositories;
public interface ITraineeRepository
{
    int RegisterToCourse(Enrollment enrollment);
    Task<IEnumerable<Course>> MyCourses(string traineeId);
    Task<IEnumerable<Course>> GetAllCourses(bool withTracking = false);
    Task<Course?> GetById(int id);
    Task<bool> IsTraineeEnrolledInCourse(string traineeId, int courseId);
}