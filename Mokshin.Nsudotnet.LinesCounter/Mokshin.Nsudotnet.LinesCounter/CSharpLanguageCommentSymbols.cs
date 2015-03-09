namespace Mokshin.Nsudotnet.LinesCounter
{
    public class CSharpLanguageCommentSymbols : ILanguageCommentSymbols
    {
        public string SingleLineCommentStartSymbol
        {
            get { return "//"; }
        }

        public string MultiLineCommentStartSymbol
        {
            get { return "/*"; }
        }

        public string MultiLineCommentEndSymbol
        {
            get { return "*/"; }
        }
    }
}
