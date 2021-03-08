using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        static string path = System.IO.Directory.GetCurrentDirectory() + @"\wwwroot\Images";
        public static IDataResult<String> AddAsync(IFormFile file)
        {
            if (file.Length > 0)
            {
                var newGuidPath = "\\" + Guid.NewGuid().ToString("N") + Path.GetExtension(path + file.FileName);
                using (FileStream fileStream = System.IO.File.Create(path + newGuidPath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
                String filePath = path + newGuidPath;
                return new SuccessDataResult<String>(filePath, "File Added.");
            }
            return new ErrorDataResult<String>();
        }

        public static IDataResult<String> UpdateAsync(string oldfilepath, IFormFile newfile)
        {
            if (File.Exists(oldfilepath))
            {
                FileHelper.DeleteAsync(oldfilepath);
                var newGuidPath = "\\" + Guid.NewGuid().ToString("N") + Path.GetExtension(path + newfile.FileName);
                using (FileStream fileStream = System.IO.File.Create(path + newGuidPath))
                {
                    newfile.CopyTo(fileStream);
                    fileStream.Flush();
                }
                string newfilePath = path + "\\" + newGuidPath;
                return new SuccessDataResult<String>(newfilePath, "File Added");
            }
            return new ErrorDataResult<String>("File Doesn't Exists");

        }

        public static IResult DeleteAsync(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
    }
}
