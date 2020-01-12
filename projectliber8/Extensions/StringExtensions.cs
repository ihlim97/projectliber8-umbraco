namespace projectliber8.Extensions
{
    public static class StringExtensions
    {

        /// <summary>
        /// Strips out <P> and </P> tags if they were used as a wrapper
        /// for other HTML content.
        /// </summary>
        /// <param name="text">The HTML text.</param>
        public static string RemoveParagraphWrapperTags(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            string trimmedText = text.Trim();
            string upperText = trimmedText.ToUpper();
            int paragraphIndex = upperText.IndexOf("<P>");

            if (paragraphIndex != 0 ||
                paragraphIndex != upperText.LastIndexOf("<P>") ||
                upperText.Substring(upperText.Length - 4, 4) != "</P>")
            {
                // Paragraph not used as a wrapper element
                return text;
            }

            // Remove paragraph wrapper tags
            return trimmedText.Substring(3, trimmedText.Length - 7);
        }
    }
}