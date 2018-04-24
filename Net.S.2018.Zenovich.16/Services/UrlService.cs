using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Net.S._2018.Zenovich._16.Api;
using Net.S._2018.Zenovich._16.Loggers;

namespace Net.S._2018.Zenovich._16.Services
{
    /// <summary>
    /// Includes business logic operation.
    /// </summary>
    /// <seealso cref="Net.S._2018.Zenovich._16.Api.IUrlService" />
    public class UrlService : IUrlService
    {
        #region Fields

        private readonly IUrlRepository urlRepository;

        private readonly IUrlParserService urlParserService;

        private readonly ILogger logger;

        private bool disposed = false;

        #endregion Fields

        #region Ctor

        public UrlService(
            IUrlRepository urlRepository, 
            IUrlParserService urlParserService)
        {
            this.urlRepository = urlRepository;
            this.urlParserService = urlParserService;
            this.logger = Extensions.GetLogger();
        }

        #endregion Ctor

        #region Destructor

        ~UrlService()
        {
            CleanUp(false);
        }

        #endregion Destructor

        #region Public methods

        /// <summary>
        /// Adds the url elements.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="filePath"/> is null
        /// </exception>
        public void AddElements(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException($"{nameof(filePath)} is null or empty.");
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
                        else
                        {
                            logger.LogInformation("{0} isn't url.", url);
                        }
                    }
                }
            }
            else
            {
                logger.LogInformation("{0} doesn't exist.", filePath);
            }
        }

        public void Dispose()
        {
            CleanUp(true);
            GC.SuppressFinalize(this);
        }

        #endregion Public methods

        #region Private methods

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

        #endregion Private methods
    }
}
