namespace CMS.BLL.Services;
public interface ICourseService
{
    int Add(CourseCreateRequest request);
    bool Delete(int id);
    IEnumerable<CourseResponse> GetAll(bool withTracking = false);
    CourseDetails? GetById(int id);
    int Update(CourseUpdateRequest course);
    IEnumerable<CourseResponse> GetAllByTrainerId(string trainerId);
    int NumberOfTraineesInCourse(int courseId);
    int NumberOfTraineesForTrainer(string trainerId);
}
