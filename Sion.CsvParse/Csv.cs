using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sion.CsvParse {
    public static class Csv {
        public static async Task FillEmptyValues(string path, string value) {
            IEnumerable<string> lines = await System.IO.File.ReadAllLinesAsync(path, Encoding.UTF8);
            List<string> newLines = new List<string>();

            foreach(var line in lines) {
                if(line.Contains(",,")) {
                    int index = line.IndexOf(",,");
                    string newLine = $"{line[0..(index + 1)]}{value}{line[(index + 1)..]}";
                    newLines.Add(newLine);
                }
                else {
                    newLines.Add(line);
                }
            }

            await System.IO.File.WriteAllLinesAsync(path, newLines, Encoding.UTF8);
        }

        public static async Task FillEmptyValues(string path, string value, char delimiter) {
            IEnumerable<string> lines = await System.IO.File.ReadAllLinesAsync(path, Encoding.UTF8);
            List<string> newLines = new List<string>();

            foreach(var line in lines) {
                if(line.Contains($"{delimiter}{delimiter}")) {
                    int index = line.IndexOf($"{delimiter}{delimiter}");
                    string newLine = $"{line[0..(index + 1)]}{value}{line[(index + 1)..]}";
                    newLines.Add(newLine);
                }
                else {
                    newLines.Add(line);
                }
            }

            await System.IO.File.WriteAllLinesAsync(path, newLines, Encoding.UTF8);
        }

        public static async Task<IEnumerable<IEnumerable<string>>> Parse(string path) {
            IEnumerable<string> lines = await System.IO.File.ReadAllLinesAsync(path, Encoding.UTF8);
            List<IEnumerable<string>> data = new List<IEnumerable<string>>();

            foreach(var line in lines) {
                data.Add(line.Split(','));
            }

            return data;
        }

        public static async Task<IEnumerable<IEnumerable<string>>> Parse(string path, char delimiter) {
            IEnumerable<string> lines = await System.IO.File.ReadAllLinesAsync(path, Encoding.UTF8);
            List<IEnumerable<string>> data = new List<IEnumerable<string>>();

            foreach(var line in lines) {
                data.Add(line.Split(delimiter));
            }

            return data;
        }

        public static async Task<IEnumerable<string>> GetHeaders(string path) {
            IEnumerable<string> lines = await System.IO.File.ReadAllLinesAsync(path, Encoding.UTF8);
            IEnumerable<string> headers = lines.ElementAt(0).Split(',');
            return headers;
        }

        public static async Task<IEnumerable<string>> GetHeaders(string path, char delimiter) {
            IEnumerable<string> lines = await System.IO.File.ReadAllLinesAsync(path, Encoding.UTF8);
            IEnumerable<string> headers = lines.ElementAt(0).Split(delimiter);
            return headers;
        }

        public static async Task<IEnumerable<IEnumerable<string>>> GetData(string path) {
            return (await Parse(path)).Skip(1);
        }

        public static async Task<IEnumerable<IEnumerable<string>>> GetData(string path, char delimiter) {
            return (await Parse(path, delimiter)).Skip(1);
        }

        public static async Task<IEnumerable<IEnumerable<string>>> GetData(string path, bool hasHeaders) {
            return ((hasHeaders) ? (await Parse(path)).Skip(1) : await Parse(path));
        }

        public static async Task<IEnumerable<IEnumerable<string>>> GetData(string path, char delimiter, bool hasHeaders) {
            return ((hasHeaders) ? (await Parse(path, delimiter)).Skip(1) : await Parse(path, delimiter));
        }
    }
}
