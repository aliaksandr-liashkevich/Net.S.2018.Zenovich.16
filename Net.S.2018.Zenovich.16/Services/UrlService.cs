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

        private bool disposed = false;

        public UrlService(IUrlRepository urlRepository)
        {
            this.urlRepository = urlRepository;
        }

        ~UrlService()
        {
            CleanUp(false);
        }

        public void AddElements(FileStream fileStream)
        {
            if (ReferenceEquals(fileStream, null))
            {
                throw new ArgumentNullException(nameof(fileStream));
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
