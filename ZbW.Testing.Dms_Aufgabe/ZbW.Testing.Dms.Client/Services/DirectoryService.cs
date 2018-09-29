﻿using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
    public class DirectoryService : IDirectoryService
    {

        public string GetExtension(string sourcePath)
        {
            return Path.GetExtension(sourcePath);
        }

        public string Combine(string targetPath, string valutaYear)
        {
            return Path.Combine(targetPath, valutaYear);
        }

        public void CreateDirectoryFolder(string targetDir)
        {
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }
        }

        public string[] GetFiles(string targetPath, string pathPattern)
        {
            var list = Directory.GetFiles(targetPath, pathPattern);
            return list;
        }

        public DirectoryInfo[] GetSubFolder(string targetPath)
        {
            var parentDirectoryInfo = new DirectoryInfo(targetPath);
            var subFolder = parentDirectoryInfo.GetDirectories();
            return subFolder;
        }

        public void DeleteFile(IMetadataItem metadataItem, bool deleteFile)
        {
            if (deleteFile)
            {
                var task = Task.Factory.StartNew(() =>
                {
                    Task.Delay(500);
                    File.Delete(metadataItem.OrginalPath);
                });
                try
                {
                    Task.WaitAll(task);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}