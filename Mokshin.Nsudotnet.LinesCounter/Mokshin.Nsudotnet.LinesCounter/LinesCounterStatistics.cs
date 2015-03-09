using System;

namespace Mokshin.Nsudotnet.LinesCounter
{
    public struct LinesCounterStatistics
    {
        public int FilesCount { get; set; }
        public int TotalLinesCount { get; set; }
        public int CodeLinesCount { get; set; }
        public int WhiteSpaceLinesCount { get; set; }
        public int CommentLinesCount { get; set; }

        public static LinesCounterStatistics operator +(LinesCounterStatistics c1, LinesCounterStatistics c2)
        {
            return new LinesCounterStatistics
            {
                FilesCount = c1.FilesCount + c2.FilesCount,
                TotalLinesCount = c1.TotalLinesCount + c2.TotalLinesCount,
                CodeLinesCount = c1.CodeLinesCount + c2.CodeLinesCount,
                WhiteSpaceLinesCount = c1.WhiteSpaceLinesCount + c2.WhiteSpaceLinesCount,
                CommentLinesCount = c1.CommentLinesCount + c2.CommentLinesCount
            };
        }

        public static LinesCounterStatistics operator -(LinesCounterStatistics c1, LinesCounterStatistics c2)
        {
            return new LinesCounterStatistics
            {
                FilesCount = Math.Max(c1.FilesCount - c2.FilesCount, 0),
                TotalLinesCount = Math.Max(c1.TotalLinesCount - c2.TotalLinesCount, 0),
                CodeLinesCount = Math.Max(c1.CodeLinesCount - c2.CodeLinesCount, 0),
                WhiteSpaceLinesCount = Math.Max(c1.WhiteSpaceLinesCount - c2.WhiteSpaceLinesCount, 0),
                CommentLinesCount = Math.Max(c1.CommentLinesCount - c2.CommentLinesCount, 0)
            };
        }
    }
}
