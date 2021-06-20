using System;
using System.IO;
using System.Threading.Tasks;
using Test1.ViewModel;

namespace Test1.Extention
{
    public class IO_Management
    {
        public static string UploadedFile(CustomerVM customerVM , string folderPath)
        {
            string uniqueFileName = null;
            if (customerVM.ProfileImage != null)
            {
                if (!Directory.Exists(folderPath))
                {
                    try
                    {
                        DirectoryInfo di = Directory.CreateDirectory(folderPath);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Fail to create Folder");
                        return "fail";
                    }
                }
                uniqueFileName = Guid.NewGuid().ToString() + "_" + customerVM.ProfileImage.FileName;
                string filePath = Path.Combine(folderPath, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    customerVM.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        
        public static async Task deleteFile(string fullPath)
        {
            try
            {
// Check if file exists with its full path    
                if (System.IO.File.Exists(fullPath))
                {
// If file found, delete it    
                    System.IO.File.Delete(fullPath);
                    Console.WriteLine("File deleted.");
                }
                else Console.WriteLine("File not found");
            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }
        }
    }
}