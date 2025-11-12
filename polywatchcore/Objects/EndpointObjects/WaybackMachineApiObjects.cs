namespace polywatchcore.Objects.EndpointObjects;

public record WaybackAvailableResponse(string url, WaybackAvailableSnapshot archived_snapshots);
public record WaybackAvailableSnapshot(string status, bool available, string url, string timestamp);
