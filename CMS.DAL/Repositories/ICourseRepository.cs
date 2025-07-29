namespace CMS.DAL.Repositories;
public interface ICourseRepository
{
    int Add(Course course);
    int Delete(Course course);
    IEnumerable<Course> GetAll(bool withTracking = false);
    Course? GetById(int id);
    int Update(Course course);
    IEnumerable<Course> GetAllByTrainerId(string trainerId);
    int NumberOfTraineesForTrainer(string trainerId);
    int NumberOfTraineesInCourse(int courseId);
}
