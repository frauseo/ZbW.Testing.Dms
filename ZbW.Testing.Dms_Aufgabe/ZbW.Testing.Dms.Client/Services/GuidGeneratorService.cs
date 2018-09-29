using System;

public class GuidGeneratorService { }

namespace ZbW.Testing.Dms.Client.Services
{
    internal class GuidGeneratorService : IGuidGeneratorService
    {
        public Guid GetNewGuid()
        {
            return Guid.NewGuid();
        }
    }
}
