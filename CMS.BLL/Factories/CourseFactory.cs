namespace CMS.BLL.Factories;
public static class CourseFactory
{
    public static IEnumerable<CourseResponse> ToCourseResponse(this IEnumerable<Course> courses) =>
        courses.Select(c => new CourseResponse
        {
            Id = c.Id,
            Title = c.Title,
            Price = c.Price,
            Description = c.Description,
            PictureUrl = c.PictureUrl,
        });
    public static CourseDetails ToCourseDetails(this Course course)
        => new CourseDetails
        {
            Id = course.Id,
            Title = course.Title,
            StartDate = course.StartDate,
            Price = course.Price,
            Description = course.Description,
            MaterialFilePath = course.MaterialFilePath,
        };
    public static Course ToCourseEntity(this CourseCreateRequest request)
    => new Course
    {
        Description = request.Description,
        Title = request.Title,
        StartDate = request.StartDate,
        TrainerId = request.TrainerId,
        Price = request.Price,
        MaterialFilePath = request.MaterialFilePath,
    };
    public static Course ToCourseEntity(this CourseUpdateRequest request)
        => new Course
        {
            Id = request.Id,
            Description = request.Description,
            Title = request.Title,
            StartDate = request.StartDate,
            Price = request.Price,
            MaterialFilePath = request.MaterialFilePath,
        };
}
