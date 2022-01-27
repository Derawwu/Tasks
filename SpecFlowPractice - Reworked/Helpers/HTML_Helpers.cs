using System.Text.RegularExpressions;


namespace SpecFlowPractice.Helpers
{
    public class HTML_Helpers
    {
        public HTML_Helpers()
        {

        }

        public static string ScrubHtml(string value)
        {
            var step1 = Regex.Replace(value, @"<[^>]+>|&nbsp;", "").Trim();
            var step2 = Regex.Replace(step1, @"\s", "");
            return step2;
        }
    }
}
