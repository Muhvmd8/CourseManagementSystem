public interface IAttachmentService
{
    bool Delete(string fileName);

    Task<string?> UploadAsync(IFormFile file, string folderName);
}

