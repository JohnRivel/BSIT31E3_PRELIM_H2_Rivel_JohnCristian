using System.Text.Json;

namespace ConsoleApp1
{
    public class JsonFileReader : BaseFileReader
    {
        public override string SupportedFormat => "JSON";

        protected override void ParseContent(string filePath)
        {
            Console.WriteLine(" -> Opening JSON stream...");

            string rawContent = File.ReadAllText(filePath);
            using JsonDocument doc = JsonDocument.Parse(rawContent);

            JsonElement root = doc.RootElement;
            int count = 0;

            if (root.ValueKind == JsonValueKind.Object)
            {
                count = root.EnumerateObject().Count();
                Console.WriteLine($" -> Parsed {count} root properties.");
            }
            else if (root.ValueKind == JsonValueKind.Array)
            {
                count = root.EnumerateArray().Count();
                Console.WriteLine($" -> Parsed {count} root elements.");
            }

            string preview = rawContent.Length > 100 ? rawContent.Substring(0, 100) : rawContent;

            Console.WriteLine();
            Console.WriteLine("--- First 100 Characters ---");
            Console.WriteLine(preview);
            Console.WriteLine("----------------------------");
        }
    }
}