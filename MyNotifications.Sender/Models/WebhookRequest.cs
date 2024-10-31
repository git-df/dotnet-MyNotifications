using Newtonsoft.Json;

namespace MyNotifications.Sender.Models;

public class WebhookRequest
{
    [JsonProperty("username")]
    public string? Username { get; set; }

    [JsonProperty("avatar_url")]
    public string? AvatarUrl { get; set; }

    [JsonProperty("content")]
    public required string Content { get; set; }

    [JsonProperty("embeds")]
    public ICollection<Embed>? Embeds { get; set; }
}

public class Author
{
    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }

    [JsonProperty("icon_url")]
    public string? IconUrl { get; set; }
}

public class Embed
{
    [JsonProperty("author")]
    public Author? Author { get; set; }

    [JsonProperty("title")]
    public string? Title { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }

    [JsonProperty("description")]
    public string? Description { get; set; }

    [JsonProperty("color")]
    public int? Color { get; set; }

    [JsonProperty("fields")]
    public List<Field>? Fields { get; }

    [JsonProperty("thumbnail")]
    public UrlObject? Thumbnail { get; set; }

    [JsonProperty("image")]
    public UrlObject? Image { get; set; }

    [JsonProperty("footer")]
    public Footer? Footer { get; set; }
}

public class Field
{
    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("value")]
    public string? Value { get; set; }

    [JsonProperty("inline")]
    public bool? Inline { get; set; }
}

public class Footer
{
    [JsonProperty("text")]
    public string? Text { get; set; }

    [JsonProperty("icon_url")]
    public string? IconUrl { get; set; }
}

public class Root
{
    [JsonProperty("username")]
    public string? Username { get; set; }

    [JsonProperty("avatar_url")]
    public string? AvatarUrl { get; set; }

    [JsonProperty("content")]
    public string? Content { get; set; }

    [JsonProperty("embeds")]
    public List<Embed>? Embeds { get; }
}

public class UrlObject
{
    [JsonProperty("url")]
    public string? Url { get; set; }
}