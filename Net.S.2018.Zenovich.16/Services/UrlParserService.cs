using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Net.S._2018.Zenovich._16.Api;
using Net.S._2018.Zenovich._16.Models;

namespace Net.S._2018.Zenovich._16.Services
{
    /// <summary>
    /// Implements parsing operation.
    /// </summary>
    /// <seealso cref="Net.S._2018.Zenovich._16.Api.IUrlParserService" />
    public class UrlParserService : IUrlParserService
    {
        #region Fields

        public static readonly string UrlPattern;

        public static readonly string SchemaPattern;

        public static readonly string HostPattern;

        public static readonly string ParameterPattern;

        public static readonly string SegmentPattern;

        #endregion Fields

        #region Ctor

        static UrlParserService()
        {
            SchemaPattern = @"http|https";
            HostPattern = @"[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}";
            SegmentPattern = @"[a-zA-Z0-9\-\.]+";
            ParameterPattern = @"([a-zA-Z0-9\-\.]+)=([a-zA-Z0-9\-\.]+)";

            UrlPattern = $@"^({SchemaPattern})\://({HostPattern})((/{SegmentPattern})+)?(\?{ParameterPattern}(&{ParameterPattern})*)?/?$";
        }

        #endregion Ctor

        #region Public properties

        /// <summary>
        /// Get the url.
        /// </summary>
        /// <value>
        /// If url method returns true, url defined.
        /// </value>
        public UrlAddressElement Url { get; protected set; }

        #endregion Public properties

        #region Public methods

        /// <summary>
        /// Determines whether the specified <paramref name="url"/> is Uniform Resource Locator.
        /// </summary>
        /// <param name="url">The specified url.</param>
        /// <returns>
        ///   <c>true</c> if the specified <paramref name="url"/> is URL; otherwise, <c>false</c>.
        /// </returns>
        public bool IsUrl(string url)
        {
            if (Regex.IsMatch(url, UrlPattern))
            {
                Match match = Regex.Match(url, UrlPattern);

                Url = new UrlAddressElement();

                Url.Schema = match.Groups[1].Value;
                Url.Host = match.Groups[2].Value;

                string segments = match.Groups[3].Value;
                string parameters = match.Groups[5].Value;

                if (string.IsNullOrEmpty(segments) == false)
                {
                    var matchSegments = Regex.Matches(segments, SegmentPattern);

                    var list = matchSegments.Cast<Match>().ToList();

                    if (list.Count > 0)
                    {
                        Url.Uri = new List<string>();

                        foreach (var item in list)
                        {
                            Url.Uri.Add(item.Value);
                        }
                    }
                }

                if (string.IsNullOrEmpty(parameters) == false)
                {
                    var matchParameters = Regex.Matches(parameters, ParameterPattern);

                    var dict = matchParameters.Cast<Match>().ToDictionary(
                        m => m.Groups[1].Value,
                        m => m.Groups[2].Value);

                    if (dict.Values.Count > 0)
                    {
                        Url.Parameters = new List<ParameterElement>();

                        foreach (var item in dict)
                        {
                            Url.Parameters.Add(new ParameterElement()
                            {
                                Key = item.Key,
                                Value = item.Value
                            });
                        }
                    }
                }

                return true;
            }

            return false;
        }

        #endregion Public methods
    }
}
