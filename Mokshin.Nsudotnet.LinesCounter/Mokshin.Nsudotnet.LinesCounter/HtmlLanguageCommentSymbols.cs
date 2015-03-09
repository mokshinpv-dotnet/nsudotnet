namespace Mokshin.Nsudotnet.LinesCounter
{
    public class HtmlLanguageCommentSymbols : ILanguageCommentSymbols
    {
        public string SingleLineCommentStartSymbol
        {
            get { return null; }
        }

        public string MultiLineCommentStartSymbol
        {
            get { return "<!--"; }
        }

        public string MultiLineCommentEndSymbol
        {
            get { return "-->"; }
        }
    }
}
