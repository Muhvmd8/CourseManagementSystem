namespace CMS.BLL.Factories;
public static class CourseFactory
{
    public static IEnumerable<CourseResponse> ToCourseResponse(this IEnumerable<Course> courses) =>
        courses.Select(c => new CourseResponse
        {
            Id = c.Id,
            Title = c.Title,
            Description = c.Description,
            ImageName = c.ImageName
        });
    public static CourseDetails ToCourseDetails(this Course course)
        => new CourseDetails
        {
            Id = course.Id,
            Title = course.Title,
            Hours = course.Hours,
            Price = course.Price,
            Description = course.Description,
            ImageName = course.ImageName,
            TrainerId = course.TrainerId,
            //PictureUrl = course.PictureUrl
        };
    public static Course ToCourseEntity(this CourseCreateRequest request)
        => new Course
        {
            Description = request.Description,
            Title = request.Title,
            Hours = request.Hours,
            TrainerId = request.TrainerId,
            Price = request.Price,
            //PictureUrl = request.PictureUrl,
        };
    public static Course ToCourseEntity(this CourseUpdateRequest request)
         => new Course
         {
            Id = request.Id,
            Description = request.Description,
            Title = request.Title,
            Hours = request.Hours,
            Price = request.Price,
            TrainerId = request.TrainerId,
         };
}
