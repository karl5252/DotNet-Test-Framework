using System.Configuration;
using System.Text.RegularExpressions;

namespace SelfServicePortal.Specs.Utils
{
    /// <summary>
    /// Helper class to get auhtorization code from email. 
    /// Note that currently only viable solution is to use restmail.net domain. Possible WA is to setup GMAIL API and use that one instead.
    /// </summary>
    class EmailApiHelper
    {
        public async Task<Tuple<bool, string>> ExtractEmailCodeAsync(string user) 
        {
            string email = "automationuser@restmail.net";//ConfigurationManager.AppSettings[$"{user}.email"];
            string username = email.Substring(0, email.IndexOf("@"));
            string url = $"http://restmail.net/mail/{username}";

            string emailCode = String.Empty;
            using var client = new HttpClient();
            var response = await client.GetStringAsync(url);

            if (!string.IsNullOrWhiteSpace(response) && response.Length > 2)
            {
                string pattern = @"\b\s*?(\d{8})\D*?";
                Regex re = new Regex(pattern);
                MatchCollection matchedNumbers = re.Matches(response);
                if(matchedNumbers.Count > 0) 
                {
                    emailCode = matchedNumbers[0].Value;
                    await client.DeleteAsync(url);
                    return Tuple.Create(true, emailCode);

                }

            }
            return Tuple.Create(false, emailCode);

        }
    }
        
}
