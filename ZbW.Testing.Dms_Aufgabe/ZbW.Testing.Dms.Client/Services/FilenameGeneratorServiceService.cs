using System;

namespace ZbW.Testing.Dms.Client.Services
{
    public class FilenameGeneratorServiceService : IFilenameGeneratorService
    {
        public string GetContentFilename(Guid guid, string extension)
        {
            return extension != null ? guid + "_Content" + extension : null;
        }

        public string GetMetadataFilename(Guid guid)
        {
            return guid + "_Metadata.xml";
        }
    }
}