using System.IO;
using System.Threading.Tasks;

namespace Services.WriteFile
{
    public class WriteFile : IWriteFile
    {
        public async Task WriteTextAsync(string filePath, string contentText)
        {
            using (StreamWriter file = File.AppendText(filePath))
            {
                await file.WriteLineAsync(contentText);
            }
        }
    }
}
