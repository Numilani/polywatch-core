using Flurl.Http;
using nietras.SeparatedValues;
using System.IO.Compression;
namespace polywatchcore.Services;

public class GDELTNewsService(AppDbContext db)
{
  private AppDbContext Db = db;

  public async Task<byte[]> FetchEventFileContents()
  {
    string quarter = "";
    if (DateTime.Now.Minute >= 15 && DateTime.Now.Minute < 30) quarter = "15";
    else if (DateTime.Now.Minute >= 30 && DateTime.Now.Minute < 45) quarter = "30";
    else if (DateTime.Now.Minute >= 45) quarter = "45";
    else quarter = "00";

    string url = "http://data.gdeltproject.org/gdeltv2/" + DateTime.Now.ToString("yyyyMMddHH") + quarter + "00.export.CSV.zip";
    var bytes = await url.GetBytesAsync();
    var stream = new MemoryStream(bytes);
    using ZipArchive archive = new(stream);

    if (archive.Entries.Count > 1) throw new Exception("Too many files in GDELT event zip!");

    var copystream = new MemoryStream();
    archive.Entries[0].Open().CopyTo(copystream);
    return copystream.ToArray();
  }

  public async Task<List<GDELTEvent>> ParseEventFile(byte[] csv)
  {
    List<GDELTEvent> rv = new();
    using var reader = Sep.Reader(cfg => cfg with { HasHeader = false }).From(csv);
    foreach (var row in reader)
    {
      var record = new GDELTEvent()
      {
        Id = row[0].ToString(),
        EventDate = DateTime.ParseExact(row[1].ToString(), "yyyyMMdd", null),
        IsRootEvent = Convert.ToBoolean(row[25].Parse<int>()),
        EventCode = row[26].ToString(),
        QuadClass = row[29].Parse<int>(),
        GoldsteinScale = row[30].Parse<float>(),
        TotalMentionsAtUpdate = row[31].Parse<int>(),
        TotalSourcesAtUpdate = row[32].Parse<int>(),
        TotalArticlesAtUpdate = row[33].Parse<int>(),
        AverageTone = row[34].Parse<float>(),
        DateAdded = DateTime.ParseExact(row[59].ToString(), "yyyyMMddHHmmss",null),
        SourceUrl = row[60].ToString(),
      };

      if (!string.IsNullOrWhiteSpace(row[5].ToString()) && !string.IsNullOrWhiteSpace(row[6].ToString()))
      {
        record.Actor1 = new CAMEOActor()
        {
          Code = row[5].ToString(),
          Name = row[6].ToString(),
          CountryCode = row[7].ToString(),
          KnownGroupCode = row[8].ToString(),
          EthnicCode = row[9].ToString(),
          ReligionCode = row[10].ToString(),
          ReligionSubgroupCode = row[11].ToString(),
          TypeCodeA = row[12].ToString(),
          TypeCodeB = row[13].ToString(),
          TypeCodeC = row[14].ToString()
        };
      }
      if (!string.IsNullOrWhiteSpace(row[15].ToString()) && !string.IsNullOrWhiteSpace(row[16].ToString()))
      {
        record.Actor2 = new CAMEOActor()
        {
          Code = row[15].ToString(),
          Name = row[16].ToString(),
          CountryCode = row[17].ToString(),
          KnownGroupCode = row[18].ToString(),
          EthnicCode = row[19].ToString(),
          ReligionCode = row[20].ToString(),
          ReligionSubgroupCode = row[21].ToString(),
          TypeCodeA = row[22].ToString(),
          TypeCodeB = row[23].ToString(),
          TypeCodeC = row[24].ToString()
        };
      }

      if (row[35].Parse<int>() != 0)
      {
        record.Actor1Geodata = new CAMEOActorGeodata()
        {
          GeoType = row[35].Parse<int>(),
          GeoName = row[36].ToString(),
          CountryCode = row[37].ToString(),
          ADM1Code = row[38].ToString(),
          ADM2Code = row[39].ToString(),
          Latitude = row[40].Parse<float>(),
          Longitude = row[41].Parse<float>(),
          FeatureID = row[42].ToString()
        };
      }
      if (row[43].Parse<int>() != 0)
      {
        record.Actor2Geodata = new CAMEOActorGeodata()
        {
          GeoType = row[43].Parse<int>(),
          GeoName = row[44].ToString(),
          CountryCode = row[45].ToString(),
          ADM1Code = row[46].ToString(),
          ADM2Code = row[47].ToString(),
          Latitude = row[48].Parse<float>(),
          Longitude = row[49].Parse<float>(),
          FeatureID = row[50].ToString()
        };
      }
      if (row[51].Parse<int>() != 0)
      {
        record.ActionGeodata = new CAMEOActorGeodata()
        {
          GeoType = row[51].Parse<int>(),
          GeoName = row[52].ToString(),
          CountryCode = row[53].ToString(),
          ADM1Code = row[54].ToString(),
          ADM2Code = row[55].ToString(),
          Latitude = row[56].Parse<float>(),
          Longitude = row[57].Parse<float>(),
          FeatureID = row[58].ToString()
        };
      }

      rv.Add(record);
    }
    return rv;
  }

  public async Task SaveEvents(List<GDELTEvent> events){
    await db.GDELTEvents.AddRangeAsync(events);
    await db.SaveChangesAsync();
  }

}
