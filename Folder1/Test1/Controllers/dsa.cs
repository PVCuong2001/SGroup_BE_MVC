namespace Test1.Controllers
{
    public class dsa
    {
        
		// some code hidden for display purpose
        /*[Route("add-file")]
        [HttpPost]
        public async Task<IActionResult> SaveFileToPhysicalFolder()
        {
            var boundary = HeaderUtilities.RemoveQuotes(
                MediaTypeHeaderValue.Parse(Request.ContentType).Boundary
            ).Value;

            var reader = new MultipartReader(boundary, Request.Body);

            var section = await reader.ReadNextSectionAsync();

            var formAccumelator = new KeyValueAccumulator();

            while (section != null)
            {
                var hasContentDisposition = ContentDispositionHeaderValue.TryParse(
                    section.ContentDisposition, out var contentDisposition
                );

                if (hasContentDisposition)
                {
                    if (contentDisposition.DispositionType.Equals("form-data") &&
                    (!string.IsNullOrEmpty(contentDisposition.FileName.Value) ||
                    !string.IsNullOrEmpty(contentDisposition.FileNameStar.Value)))
                    {
                        string fileStoragePath = $"{_webHostEnvironment.WebRootPath}/images/";
                        string fileName = Path.GetRandomFileName() + ".jpg";
                        // uploaded files form fileds
                        byte[] fileByteArray;
                        using (var memoryStream = new MemoryStream())
                        {
                            await section.Body.CopyToAsync(memoryStream);
                            fileByteArray = memoryStream.ToArray();
                        }
                        using (var fileStream = System.IO.File.Create(Path.Combine(fileStoragePath,fileName)))
                        {
                            await fileStream.WriteAsync(fileByteArray);
                        }
                    }
                    else
                    {
                        var key = HeaderUtilities.RemoveQuotes(contentDisposition.Name).Value;

                        using(var streamReader = new StreamReader(section.Body,
                        encoding: Encoding.UTF8,
                        detectEncodingFromByteOrderMarks:true,
                        bufferSize:1024,
                        leaveOpen:true)){
                            var value = await streamReader.ReadToEndAsync();
                            if(string.Equals(value, "undefined",StringComparison.OrdinalIgnoreCase)){
                                value = string.Empty;
                            }
                            formAccumelator.Append(key, value);
                        }
                    }
                }
                section = await reader.ReadNextSectionAsync();
            }

            var profile = new Profile();
            var formValueProvidere = new FormValueProvider(
                BindingSource.Form,
                new FormCollection(formAccumelator.GetResults()),
                CultureInfo.CurrentCulture
            );

            var bindindSuccessfully = await TryUpdateModelAsync(profile,"",formValueProvidere);
            if(ModelState.IsValid){
                // write log to save profile data to database
            }

            return Content("Uploaded successfully");
        }*/
    }
    }
