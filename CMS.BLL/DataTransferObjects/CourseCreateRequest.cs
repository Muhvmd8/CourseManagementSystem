namespace CMS.BLL.DataTransferObjects;
public class CourseCreateRequest
{
    public string Title { get; set; }              
    public string Description { get; set; }
    public int Hours { get; set; }
    public decimal Price { get; set; }
    public string TrainerId { get; set; }
    public IFormFile? Image { get; set; }
}