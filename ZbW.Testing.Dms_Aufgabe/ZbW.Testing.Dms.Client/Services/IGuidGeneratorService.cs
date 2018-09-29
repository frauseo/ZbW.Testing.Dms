using System;

namespace ZbW.Testing.Dms.Client.Services
{
    public interface IGuidGeneratorService
    {
        Guid GetNewGuid();
    }
}