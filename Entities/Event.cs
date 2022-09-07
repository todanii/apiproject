namespace WebApi.Entities;

public class Event
{
    public string Id { get; set; }
    public string ServerId { get; set; }
    public string EventType { get; set; }
    public string RelativeUrl { get; set; }
    public Payload Payload { get; set; }
    public string When { get; set; }
    public string CorrelationId { get; set; }
    public string CausationId { get; set; }

}