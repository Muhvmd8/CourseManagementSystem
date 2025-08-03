namespace CMS.BLL.DataTransferObjects;
public class CourseDetails
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string TrainerId { get; set; }
    public decimal Price { get; set; }
    public string ImageName { get; set; }
    public int Hours { get; set; }
}