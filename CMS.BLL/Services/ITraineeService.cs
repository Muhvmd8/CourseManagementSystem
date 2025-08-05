namespace CMS.BLL.Services;
public interface ITraineeService
{
    Task<bool> RegisterToCourse(string traineeId, int courseId);
    Task<IEnumerable<CourseResponse>> MyCourses(string traineeId);
    Task<IEnumerable<CourseResponse>> GetAllCourses(bool withTracking = false);
    Task<CourseDetails?> GetById(int id);
}
