﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Common.FileUploader
{
    public static class GenericFileUploader
    {
        public static async void UploadImage(IFormFile imageFiles, string path, string fileExtensions = "jpeg,png,bmp,gif,svg", int maxSize = 0, int width = 0, int height = 0)
        {

            try
            {
                // full path to file in temp location
                fileExtensions = String.IsNullOrEmpty(fileExtensions) ? "jpeg,png,bmp,gif,svg" : fileExtensions;

                if (imageFiles.Length > 0)
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFiles.CopyToAsync(stream);
                    }
                }

            }
            catch (Exception exception)
            {

                throw new Exception("", exception);
            }
        }
        public static async void UploadVideo(IFormFile videoFiles, string path, string fileExtensions = "mp4,3gp,mkv,wmv,avi", int maxSize = 0)
        {

            try
            {
                fileExtensions = String.IsNullOrEmpty(fileExtensions) ? "mp4,3gp,mkv,wmv,avi" : fileExtensions;
                // full path to file in temp location
                //length of file in bytes

                if (videoFiles.Length > 0 && videoFiles.Length < maxSize || maxSize == 0)
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await videoFiles.CopyToAsync(stream);
                    }
                }

            }
            catch (Exception exception)
            {

                throw new Exception("", exception);
            }
        }
        public static async void UploadSound(IFormFile soundFiles, string path, string fileExtensions = "mp3,voc", int maxSize = 0)
        {

            try
            {
                fileExtensions = String.IsNullOrEmpty(fileExtensions) ? "mp3,voc" : fileExtensions;
                // full path to file in temp location
                //length of file in bytes

                if (soundFiles.Length > 0 && soundFiles.Length < maxSize || maxSize == 0)
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await soundFiles.CopyToAsync(stream);
                    }
                }

            }
            catch (Exception exception)
            {

                throw new Exception("", exception);
            }
        }
        public static async void UploadDocument(IFormFile documentFiles, string path, string fileExtensions = "doc,docx,pdf,txt,html,hml,xls,xlsx,ppt,pptx", int maxSize = 0)
        {

            try
            {
                fileExtensions = String.IsNullOrEmpty(fileExtensions) ? "doc,docx,pdf,txt,html,hml,xls,xlsx,ppt,pptx" : fileExtensions;
                // full path to file in temp location
                //length of file in bytes

                if (documentFiles.Length > 0 && documentFiles.Length < maxSize || maxSize == 0)
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await documentFiles.CopyToAsync(stream);
                    }
                }

            }
            catch (Exception exception)
            {

                throw new Exception("", exception);
            }
        }
        public static async void UploadZip(IFormFile zipFiles, string path, string fileExtensions = "zip,rar,iso", int maxSize = 0)
        {

            try
            {
                fileExtensions = String.IsNullOrEmpty(fileExtensions) ? "zip,rar,iso" : fileExtensions;
                // full path to file in temp location
                //length of file in bytes

                if (zipFiles.Length > 0 && zipFiles.Length < maxSize || maxSize == 0)
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await zipFiles.CopyToAsync(stream);
                    }
                }

            }
            catch (Exception exception)
            {

                throw new Exception("", exception);
            }
        }
        public static async void UploadFiles(IFormFile files, string path, string fileExtensions = "", int maxSize = 0)
        {

            try
            {
                // full path to file in temp location
                //length of file in bytes

                if (files.Length > 0 && files.Length < maxSize || maxSize == 0)
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await files.CopyToAsync(stream);
                    }
                }

            }
            catch (Exception exception)
            {

                throw new Exception("", exception);
            }
        }

    }
}