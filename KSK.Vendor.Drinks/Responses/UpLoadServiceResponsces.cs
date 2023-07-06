using Newtonsoft.Json;

namespace KSK.Vendor.Drinks.Responses;

public record S3Url([JsonProperty("value")] string Value);