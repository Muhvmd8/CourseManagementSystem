namespace CMS.BLL.DataTransferObjects;
public class CourseResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string PictureUrl { get; set; }
}