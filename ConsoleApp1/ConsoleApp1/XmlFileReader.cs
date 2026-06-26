using System.Xml.Linq;

namespace ConsoleApp1
{
    public class XmlFileReader : BaseFileReader
    {
        public override string SupportedFormat => "XML";

        protected override void ParseContent(string filePath)
        {
            Console.WriteLine(" -> Opening XML stream...");

            XDocument doc = XDocument.Load(filePath);

            string rootName = doc.Root?.Name.LocalName ?? "unknown";
            int descendantCount = doc.Root?.DescendantNodes().Count() ?? 0;

            Console.WriteLine($" -> Root element: <{rootName}> with {descendantCount} descendant nodes.");

            string rawContent = doc.ToString();
            string preview = rawContent.Length > 100 ? rawContent.Substring(0, 100) : rawContent;

            Console.WriteLine();
            Console.WriteLine("--- First 100 Characters ---");
            Console.WriteLine(preview);
            Console.WriteLine("----------------------------");
        }
    }
}