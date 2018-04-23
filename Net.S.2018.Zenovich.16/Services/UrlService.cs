using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._16.Api;

namespace Net.S._2018.Zenovich._16.Services
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepository urlRepository;

        private readonly IUrlParserService urlParserService;

        private bool disposed = false;

        public UrlService(IUrlRepository urlRepository, IUrlParserService urlParserService)
        {
            this.urlRepository = urlRepository;
            this.urlParserService = urlParserService;
        }

        ~UrlService()
        {
            CleanUp(false);
        }

        public void AddElements(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException($"{nameof(filePath)} is null or empty.");
            }

            if (File.Exists(filePath))
            {
                
                using (var streamReader = new StreamReader(filePath))
                {
                    string url = string.Empty;

                    while (streamReader.EndOfStream == false)
                    {
                        url = streamReader.ReadLine();

                        if (urlParserService.IsUrl(url))
                        {
                            urlRepository.Add(urlParserService.Url);
                        }
                    }
                }
            }
        }

        public void Dispose()
        {
            CleanUp(true);
            GC.SuppressFinalize(this);
        }

        private void CleanUp(bool clean)
        {
            if (!this.disposed)
            {
                if (clean)
                {
                    urlRepository.Save();
                }
            }
            this.disposed = true;
        }
    }
}
