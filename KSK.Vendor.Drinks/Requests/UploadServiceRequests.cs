using MediatR;

namespace KSK.Vendor.Drinks.Requests;

public record GetUploadUrlRequest(string Filename) : IRequest<string>;

public record GetReadUrlRequest(string Filename) : IRequest<string>;