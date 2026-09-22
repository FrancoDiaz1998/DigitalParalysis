using DigitalParalysis.Application.Common.Security;
using DigitalParalysis.Domain.Entities;

namespace DigitalParalysis.Application.Interfaces;

public interface IAccessTokenGenerator
{
    AccessTokenResult Generate(Usuario usuario);
}
