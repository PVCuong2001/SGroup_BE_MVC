using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Test1.ViewModel;

namespace Test1.Extention
{
    public class IO_Management
    {
        public static async Task<List<string>> UploadedFile(CustomerVM customerVM , string folderPath)
        {
            if (customerVM.ListFormImage != null)
            {
                List<string>listFileNames = new List<string>();
                if (!Directory.Exists(folderPath))
                {
                    try
                    {
                        DirectoryInfo di = Directory.CreateDirectory(folderPath);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Fail to create Folder");
                        return null;
                    }
                }

                foreach (var value in customerVM.ListFormImage)
                {
                    string  uniqueFileName = Guid.NewGuid().ToString() + "_" + value.FileName;
                    string filePath = Path.Combine(folderPath, uniqueFileName);
                   await value.CopyToAsync(new FileStream(filePath,FileMode.Create));
                    listFileNames.Add(uniqueFileName);
                }
                /*using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    customerVM.ListFormImage.CopyTo(fileStream);
                }*/
                return listFileNames;
            }
            return null;
        }
        
        public static async Task deleteFile(List<string> listFullPath)
        {
            try
            {
                foreach (var fullPath in listFullPath)
                {
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                        Console.WriteLine("File deleted : "+fullPath);
                    }
                    else Console.WriteLine("File not found : "+fullPath);
                }
            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }
        }
    }
}