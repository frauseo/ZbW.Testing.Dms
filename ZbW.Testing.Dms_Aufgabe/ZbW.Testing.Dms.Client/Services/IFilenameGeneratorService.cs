using System;

namespace ZbW.Testing.Dms.Client.Services
{
    public interface IFilenameGeneratorService
    {
        string GetMetadataFilename(Guid guid);
        string GetContentFilename(Guid guid, string extension);
    }
}