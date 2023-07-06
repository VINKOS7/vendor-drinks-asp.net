namespace KSK.Vendor.Drinks.Infrastructure.Options;

public class S3StorageSettings
{
    public string Url { get; set; }

    public string AccessKey { get; set; }

    public string SecretKey { get; set; }

    public string ProductsBucketName { get; set; }

    public bool SSL { get; set; }
}
