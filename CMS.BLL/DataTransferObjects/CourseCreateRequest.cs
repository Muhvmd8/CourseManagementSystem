namespace CMS.BLL.DataTransferObjects;
public class CourseCreateRequest
{
    public string Title { get; set; }              
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public decimal Price { get; set; }
    public string MaterialFilePath { get; set; }
    public string TrainerId { get; set; }
    public string PictureUrl { get; set; }
}