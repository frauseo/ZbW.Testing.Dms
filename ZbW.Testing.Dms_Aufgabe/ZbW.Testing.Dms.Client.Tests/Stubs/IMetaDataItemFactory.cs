﻿using System;
using FakeItEasy;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Tests.Stubs
{
    public class IMetaDataItemFactory
    {
        public IMetadataItem GetMetadataItem()
        {
            var stubMetadataItem = A.Fake<IMetadataItem>();
            stubMetadataItem.Bezeichnung = "Swisscom";
            stubMetadataItem.Typ = "Vertrag";
            stubMetadataItem.ContentFileExtension = ".pdf";
            stubMetadataItem.ContentFilename = "_content.pdf";
            stubMetadataItem.MetadataFilename = "_metadata.xml";
            stubMetadataItem.DocumentId = new Guid("34CB2DFC-EB7F-45BB-8E82-C7CC9A30F871");
            stubMetadataItem.OrginalPath = @"C:\Temp\OrginalPath";
            stubMetadataItem.PathInRepo = @"C:\Temp\Repo";
            stubMetadataItem.Stichwoerter = "Swisscom Vertrag";
            stubMetadataItem.ValutaDatum = new DateTime(2018, 08, 08);
            stubMetadataItem.ValutaYear = stubMetadataItem.ValutaDatum.Year.ToString();
            return stubMetadataItem;
        }
    }
}
