
namespace CMS.DAL.Repositories;
public class TraineeRepository(ApplicationDbContext dbContext)
    : ITraineeRepository
{
    public int Register(Enrollment enrollment)
    {
        dbContext.Enrollments.Add(enrollment);
        return dbContext.SaveChanges();
    }
}
