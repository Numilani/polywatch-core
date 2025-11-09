using Flurl.Http;
using System.IO.Compression;
namespace polywatchcore.Services;

public class GDELTNewsService
{
  public async Task<byte[]> FetchFileContents()
  {
    string url = "https://data.gdeltproject.org/gdeltv2/" + DateTime.Now.ToString("yyyyMMddHHmm") + "00.export.CSV.zip";
    var bytes = await url.GetBytesAsync();
    var stream = new MemoryStream(bytes);
    using ZipArchive archive = new(stream);
   
    if (archive.Entries.Count > 1) throw new Exception("Too many files in GDELT event zip!");
    
    var copystream = new MemoryStream();
    archive.Entries[0].Open().CopyTo(copystream);
    return copystream.ToArray();
  }

  // TODO: add a function for parsing and adding to DB
}
