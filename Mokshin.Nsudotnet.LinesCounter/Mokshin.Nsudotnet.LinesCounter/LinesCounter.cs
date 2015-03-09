using System.Collections.Generic;
using System.IO;

namespace Mokshin.Nsudotnet.LinesCounter
{
    public class LinesCounter
    {
        private static IEnumerable<string> GetFilePaths(string fileExtension)
        {
            var searchPattern = !string.IsNullOrEmpty(fileExtension) ? fileExtension : "*.*";
            return Directory.GetFiles(".", searchPattern, SearchOption.AllDirectories);
        }

        private static bool HasLineNotCommentSymbols(string line, ILanguageCommentSymbols languageCommentSymbols)
        {
            //TODO
        }

        private static LinesCounterStatistics GetFileStatistics(string filePath, ILanguageCommentSymbols languageCommentSymbols)
        {
            var fileLines = File.ReadAllLines(filePath);

            var result = new LinesCounterStatistics
            {
                TotalLinesCount = fileLines.Length,
                FilesCount = 1
            };

            var isMultilineComment = false;

            foreach (var line in fileLines)
            {
                var preparedLine = line.Trim();
                if (string.IsNullOrEmpty(preparedLine))
                {
                    ++result.WhiteSpaceLinesCount;
                    continue;
                }

                if (isMultilineComment)
                {
                    //TODO need check this case: /* */ /* */
                    if (preparedLine.Contains(languageCommentSymbols.MultiLineCommentEndSymbol))
                    {
                        isMultilineComment = false;

                        if (preparedLine.EndsWith(languageCommentSymbols.MultiLineCommentEndSymbol))
                        {
                            ++result.CommentLinesCount;
                        }
                        else
                        {
                            ++result.CodeLinesCount;
                        }
                    }
                    else
                    {
                        ++result.CommentLinesCount;
                    }

                    continue;
                }

                if (preparedLine.StartsWith(languageCommentSymbols.SingleLineCommentStartSymbol))
                {
                    ++result.CommentLinesCount;
                    continue;
                }

                //TODO need check this case: /* */ /* */
                if (preparedLine.Contains(languageCommentSymbols.MultiLineCommentStartSymbol))
                {
                    isMultilineComment = true;

                    if (preparedLine.StartsWith(languageCommentSymbols.MultiLineCommentStartSymbol))
                    {
                        ++result.CommentLinesCount;
                    }
                    else
                    {
                        ++result.CodeLinesCount;
                    }

                    continue;
                }

                ++result.CodeLinesCount;
            }

            return result;
        }

        public LinesCounterStatistics GetStatistics(string sourceCodeFileExtension, ILanguageCommentSymbols languageCommentSymbols)
        {
            var result = new LinesCounterStatistics();

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var filePath in GetFilePaths(sourceCodeFileExtension))
            {
                result += GetFileStatistics(filePath, languageCommentSymbols);
            }
            
            return result;
        }
    }
}
