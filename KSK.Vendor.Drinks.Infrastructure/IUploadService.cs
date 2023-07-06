namespace KSK.Vendor.Drinks.Infrastructure;

public interface IUploadService
{
    Task<string> GetSignedUrl(string filename);
    Task<string> GetReadUrl(string filename);
}
