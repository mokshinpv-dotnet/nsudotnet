using System;

namespace Mokshin.Nsudotnet.LinesCounter
{
    internal class Program
    {
        private static void PrintLine(string name, object value)
        {
            Console.WriteLine("{0, 10}: {1}", name, value);
        }

        public static void Main(string[] args)
        {
            const string sourceCodeFileExtension = "*.cs";

            var counter = new LinesCounter();
            var statistics = counter.GetStatistics(sourceCodeFileExtension, new CSharpLanguageCommentSymbols());

            PrintLine("Всего файлов", statistics.FilesCount);
            PrintLine("Всего строк", statistics.TotalLinesCount);
            PrintLine("Строк кода", statistics.CodeLinesCount);
            PrintLine("Пустых строк", statistics.WhiteSpaceLinesCount);
            PrintLine("Строк комментариев", statistics.CommentLinesCount);
        }
    }
}
