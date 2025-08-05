namespace CMS.BLL.Services;
public class TraineeService(ITraineeRepository traineeRepository)
    : ITraineeService
{
    public async Task<IEnumerable<CourseResponse>> GetAllCourses(bool withTracking = false)
    {
        var courses = await traineeRepository.GetAllCourses(withTracking);
        return courses.ToCourseResponse();
    }
    public async Task<CourseDetails?> GetById(int id)
    {
        var course = await traineeRepository.GetById(id);
        return course is null? null : course.ToCourseDetails();
    }
    public async Task<IEnumerable<CourseResponse>> MyCourses(string traineeId)
    {
        var courses = await traineeRepository.MyCourses(traineeId);
        return courses.ToCourseResponse();
    }
    public async Task<bool> RegisterToCourse(string traineeId, int courseId)
    {
        var alreadyEnrolled = await traineeRepository.IsTraineeEnrolledInCourse(traineeId, courseId);

        if (alreadyEnrolled)
            return false;

        var enrollment = new Enrollment
        {
            TraineeId = traineeId,
            CourseId = courseId
        };

        // Add email notification service using SignalR    // Next feature
        return traineeRepository.RegisterToCourse(enrollment) > 0;

    }
}
