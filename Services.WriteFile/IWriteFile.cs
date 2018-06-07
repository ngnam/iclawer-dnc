using System.Threading.Tasks;

namespace Services.WriteFile
{
    public interface IWriteFile
    {
        Task WriteTextAsync(string filePath, string contentText);
    }
}
