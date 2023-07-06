using Microsoft.Extensions.Options;

using Minio;

using KSK.Vendor.Drinks.Infrastructure.Options;

namespace KSK.Vendor.Drinks.Infrastructure.Services;

public class UploadService : IUploadService
{
    private readonly MinioClient _client;
    private readonly string _bucketName;

    public UploadService(IOptions<S3StorageSettings> options)
    {
        _bucketName = options.Value.ProductsBucketName;

        _client = new MinioClient(options.Value.Url,
            options.Value.AccessKey,
            options.Value.SecretKey
        );

        if (options.Value.SSL)
        {
            _client = _client.WithSSL();
        }
    }

    public async Task<string> GetSignedUrl(string filename)
    {
        var url = await _client.PresignedPutObjectAsync(
            _bucketName,
            filename,
            (int)TimeSpan.FromHours(1).TotalSeconds);

        return url;
    }

    public async Task<string> GetReadUrl(string filename)
    {
        var url = await _client.PresignedGetObjectAsync(
            _bucketName,
            filename,
            (int)TimeSpan.FromHours(3).TotalSeconds);

        return url;
    }
}
