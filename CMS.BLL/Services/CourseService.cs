namespace CMS.BLL.Services;
public class CourseService(ICourseRepository courseRepository)
    : ICourseService
{
    public int Add(CourseCreateRequest request)
    {
        var course = request.ToCourseEntity();
        return courseRepository.Add(course);
    }
    public int Update(CourseUpdateRequest request)
    {
        var course = request.ToCourseEntity();
        return courseRepository.Update(course);
    }
    public bool Delete(int id)
    {
        var course = courseRepository.GetById(id);
        return course is null? false : courseRepository.Delete(course) > 0;
    }
    public CourseDetails? GetById(int id)
    {
        var course = courseRepository.GetById(id);
        return course is not null? course.ToCourseDetails() : null;
    }
    public IEnumerable<CourseResponse> GetAll(bool withTracking = false)
    {
        var courses = courseRepository.GetAll(withTracking);
        return courses.ToCourseResponse();
    }
    public IEnumerable<CourseResponse> GetAllByTrainerId(string trainerId)
    {
        var courses = courseRepository.GetAllByTrainerId(trainerId);
        return courses.ToCourseResponse();
    }
    public int NumberOfTraineesForTrainer(string trainerId)
        => courseRepository.NumberOfTraineesForTrainer(trainerId);
    public int NumberOfTraineesInCourse(int courseId)
        => courseRepository.NumberOfTraineesInCourse(courseId);
}
