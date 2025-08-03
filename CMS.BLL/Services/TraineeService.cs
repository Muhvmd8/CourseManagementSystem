
namespace CMS.BLL.Services;
public class TraineeService(ITraineeRepository traineeRepository)
    : ITraineeService
{
    // enrollment object 
    // Trainee courses page 
    public int RegisterToCourse(EnrollmentDto enrollmentDto)
    {
        var enrollment = new Enrollment
        {
            CourseId = enrollmentDto.CourseId,  
            TraineeId = enrollmentDto.TraineeId,
        };

        return traineeRepository.Register(enrollment);
    }
}
