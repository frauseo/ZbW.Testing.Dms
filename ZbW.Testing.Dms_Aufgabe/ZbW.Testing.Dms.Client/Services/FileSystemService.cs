﻿using System.Collections.Generic;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
    public class FileSystemService
    {
        private const string TargetPath = @"C:\Temp\DMS";

        public FileSystemService()
        {
            XmlService = new XmlService();
            FilenameGeneratorService = new FilenameGeneratorServiceService();
            DirectoryService = new DirectoryService();
            GuidGeneratorService = new GuidGeneratorService();
        }

        public FileSystemService(IXmlService xmlService, IFilenameGeneratorService filenameGeneratorService, IDirectoryService directoryService, IGuidGeneratorService guidGeneratorService)
        {
            XmlService = xmlService;
            FilenameGeneratorService = filenameGeneratorService;
            DirectoryService = directoryService;
            GuidGeneratorService = guidGeneratorService;
        }

        private IXmlService XmlService { get; }
        private IFilenameGeneratorService FilenameGeneratorService { get; }
        private IDirectoryService DirectoryService { get; }
        private IMetadataItem MetaDataIteam { get; set; }
        private IGuidGeneratorService GuidGeneratorService { get; }

        public void AddFile(IMetadataItem metadataItem, bool isRemoveFileEnabled, string sourcePath)
        {
            MetaDataIteam = metadataItem;

            var documentId = GuidGeneratorService.GetNewGuid();
            var extension = DirectoryService.GetExtension(sourcePath);
            MetaDataIteam.ContentFilename = FilenameGeneratorService.GetContentFilename(documentId, extension);
            MetaDataIteam.MetadataFilename = FilenameGeneratorService.GetMetadataFilename(documentId);

            var targetDir = DirectoryService.Combine(TargetPath, MetaDataIteam.ValutaYear);

            MetaDataIteam.OrginalPath = sourcePath;
            MetaDataIteam.PathInRepo = targetDir + @"\" + MetaDataIteam.ContentFilename;
            MetaDataIteam.ContentFileExtension = extension;
            MetaDataIteam.ContentFilename = MetaDataIteam.ContentFilename;
            MetaDataIteam.DocumentId = documentId;

            DirectoryService.CreateDirectoryFolder(targetDir);

            XmlService.MetadataItemToXml(MetaDataIteam, targetDir);
            DirectoryService.DeleteFile(MetaDataIteam, isRemoveFileEnabled);
        }

        public IList<IMetadataItem> LoadMetadata()
        {
            var metadataFile = GetAllFiles();
            var metadataList = XmlService.XmlToMetadataItems(metadataFile);
            return metadataList;
        }

        private IList<string> GetAllFiles()
        {
            var metadataFile = new List<string>();
            var nameOfAllSubFolder = GetAllSubFolder();
            foreach (var d in nameOfAllSubFolder)
            {

                var list = DirectoryService.GetFiles(TargetPath + @"\" + d, @"*_Metadata.xml");
                metadataFile.AddRange(list);
            }

            return metadataFile;
        }

        private IList<string> GetAllSubFolder()
        {
            var nameOfAllSubFolder = new List<string>();
            var subFolder = DirectoryService.GetSubFolder(TargetPath);
            foreach (var n in subFolder)
            {
                nameOfAllSubFolder.Add(n.Name);
            }

            return nameOfAllSubFolder;
        }
    }
}