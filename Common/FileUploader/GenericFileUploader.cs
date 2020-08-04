using Common.Enumeration;
using Common.Image;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.FileUploader
{
    public static class GenericFileUploader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="path">Location to save file on hard drive.</param>
        /// <param name="maxSize">Maximum allowed file size in bytes.</param>
        /// <param name="fileExtensions">Allowed file extensions (separate with commas and must be valid image formats).</param>
        /// <param name="width">Resize image width.</param>
        /// <param name="height">resize image height</param>
        /// <returns></returns>
        public static async Task UploadImage(IFormFile file, string path, int maxSize = 0, string fileExtensions = "", int width = 0, int height = 0)
        {
            //fileExtensions = String.IsNullOrEmpty(fileExtensions) ? Extensions[FileType.Picture] : fileExtensions;

            ValidateOrSetFileExtensionsListForFileType(ref fileExtensions, FileType.Picture);

            string fileExtension = Path.GetExtension(file.FileName);
            if (fileExtensions.Contains(fileExtension))
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    var mime = GetMimeType(stream).Split("/");
                    string fileType = mime[0];
                    if (fileType == "image")
                    {
                        //await UploadFile(file, stream, path, maxSize);
                        if (file.Length > 0 && (file.Length < maxSize || maxSize == -1))
                        {
                            try
                            {
                                if (width > 0 && height > 0)
                                {
                                    await file.CopyToAsync(ThumbnailMaker.CreateThumbnailFromStream(stream, width, height, path));
                                }
                                else
                                {
                                    await file.CopyToAsync(stream);
                                }
                            }
                            catch (Exception exception)
                            {
                                throw new Exception("", exception);
                            }
                        }
                        throw new Exception("Invalid file size");

                    }
                    throw new Exception("Invalid picture format");
                }
            }
            throw new Exception("Invalid picture file extension");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="path">Location to save file on hard drive.</param>
        /// <param name="maxSize">Maximum allowed file size in bytes.</param>
        /// <param name="fileExtensions">Allowed file extensions (separate with commas and must be valid video formats).</param>
        /// <returns></returns>
        public static async Task UploadVideo(IFormFile file, string path, int maxSize = 0, string fileExtensions = "")
        {

            //fileExtensions = String.IsNullOrEmpty(fileExtensions) ? Extensions[FileType.Video] : fileExtensions;

            ValidateOrSetFileExtensionsListForFileType(ref fileExtensions, FileType.Video);

            string fileExtension = Path.GetExtension(file.FileName);
            if (fileExtensions.Contains(fileExtension))
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    var mime = GetMimeType(stream).Split("/");
                    string fileType = mime[0];
                    if (fileType == "video")
                    {
                        await Upload(file, stream, path, maxSize);
                    }
                    throw new Exception("Invalid video format");
                }
            }
            throw new Exception("Invalid video file extension");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="path">Location to save file on hard drive.</param>
        /// <param name="maxSize">Maximum allowed file size in bytes.</param>
        /// <param name="fileExtensions">Allowed file extensions (separate with commas and must be valid audio formats).</param>
        /// <returns></returns>
        public static async Task UploadAudio(IFormFile file, string path, int maxSize = 0, string fileExtensions = "")
        {
            //fileExtensions = String.IsNullOrEmpty(fileExtensions) ? Extensions[FileType.Audio] : fileExtensions;

            ValidateOrSetFileExtensionsListForFileType(ref fileExtensions, FileType.Audio);

            string fileExtension = Path.GetExtension(file.FileName);
            if (fileExtensions.Contains(fileExtension))
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    var mime = GetMimeType(stream).Split("/");
                    string fileType = mime[0];
                    if (fileType == "audio")
                    {
                        await Upload(file, stream, path, maxSize);
                    }
                    throw new Exception("Invalid audio format");
                }
            }
            throw new Exception("Invalid audio file extension");
        }
        public static async Task UploadDocument(IFormFile documentFiles, string path, int maxSize = 0)
        {

        }
        public static async Task UploadArchive(IFormFile zipFiles, string path, int maxSize = 0, bool allowExecutables = false)
        {

        }


        private static async Task Upload(IFormFile file, Stream fileStream, string path, int maxSize = 0) // do not fucking check extension here 
        {
            if (file.Length > 0 && (file.Length < maxSize || maxSize == -1))
            {
                try
                {
                    await file.CopyToAsync(fileStream);
                }
                catch (Exception exception)
                {
                    throw new Exception("", exception);
                }
            }
            throw new Exception("Invalid file size");
        }

        private static void ValidateOrSetFileExtensionsListForFileType(ref string fileExtensions, FileType fileType)
        {
            if (String.IsNullOrEmpty(fileExtensions))
            {
                fileExtensions = Extensions[fileType];
            }
            else //validate fileExtensions argument against the dictionary
            {
                var set1 = new HashSet<string>((Extensions[fileType]).Split(',').Select(t => t.Trim()));
                var set2 = new HashSet<string>(fileExtensions.Split(',').Select(t => t.Trim()));
                if (!set1.IsSupersetOf(set2))
                {
                    throw new Exception($"Specified extensions are invalid for {fileType} file");
                }
            }
        }

        private static Dictionary<FileType, string> Extensions = new Dictionary<FileType, string>()
        {
            [FileType.Picture] = "jpeg,jpg,png,bmp,gif,svg",
            [FileType.Video] = "mp4,3gp,mkv,wmv,avi",
            [FileType.Archive] = "zip,rar,iso,tar,tar.gz,7z,",
            [FileType.Document] = "doc,docx,pdf,txt,html,hml,xls,xlsx,ppt,pptx",
            [FileType.Audio] = "mp3,voc,m4a,wav"
        };

        private static string GetMimeType(FileStream stream)
        {
            return HeyRed.Mime.MimeGuesser.GuessMimeType(stream);
        }

    }
}
