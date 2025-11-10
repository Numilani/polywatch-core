using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("GDELTEvents")]
public class GDELTEvent
{
  [Key]
  public required string Id {get;set;}

  public string? Title {get;set;}
  public string? Description {get;set;}

  public DateTime EventDate {get;set;}
  
  public CAMEOActor? Actor1 {get;set;}
  public CAMEOActor? Actor2 {get;set;}

  public CAMEOActorGeodata? Actor1Geodata {get;set;}
  public CAMEOActorGeodata? Actor2Geodata {get;set;}
  public CAMEOActorGeodata? ActionGeodata {get;set;}

  public bool IsRootEvent {get;set;}
  public required string EventCode {get;set;}
  public int QuadClass {get;set;}
 
  public float GoldsteinScale {get;set;}
  public float AverageTone {get;set;}
  
  public int TotalMentionsAtUpdate {get;set;}
  public int TotalSourcesAtUpdate {get;set;}
  public int TotalArticlesAtUpdate {get;set;}

  public DateTime DateAdded {get;set;}
  public required string SourceUrl {get;set;}
}
