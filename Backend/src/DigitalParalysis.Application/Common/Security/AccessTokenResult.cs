namespace DigitalParalysis.Application.Common.Security;

public sealed record AccessTokenResult(
    string Value,
    DateTime ExpiresAtUtc);
