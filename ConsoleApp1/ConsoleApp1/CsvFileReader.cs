namespace ConsoleApp1
{
    public class CsvFileReader : BaseFileReader
    {
        public override string SupportedFormat => "CSV";

        protected override void ParseContent(string filePath)
        {
            Console.WriteLine(" -> Opening CSV stream...");

            string[] lines = File.ReadAllLines(filePath);

            int rowCount = lines.Length;
            int columnCount = rowCount > 0 ? lines[0].Split(',').Length : 0;

            Console.WriteLine($" -> Detected {rowCount} rows and {columnCount} columns.");

            string rawContent = string.Join("\n", lines);
            string preview = rawContent.Length > 100 ? rawContent.Substring(0, 100) : rawContent;

            Console.WriteLine();
            Console.WriteLine("--- First 100 Characters ---");
            Console.WriteLine(preview);
            Console.WriteLine("----------------------------");
        }
    }
}