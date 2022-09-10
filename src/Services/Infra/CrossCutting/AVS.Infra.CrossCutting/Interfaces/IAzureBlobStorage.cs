namespace AVS.Infra.CrossCutting.Interfaces
{
    public interface IAzureBlobStorage
    {
        Task<string> UploadFile(string fileName, Stream buffer, string directory = "");
    }
}
