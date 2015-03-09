namespace Mokshin.Nsudotnet.LinesCounter
{
    public interface ILanguageCommentSymbols
    {
        string SingleLineCommentStartSymbol { get; }
        string MultiLineCommentStartSymbol { get; }
        string MultiLineCommentEndSymbol { get; }
    }
}
