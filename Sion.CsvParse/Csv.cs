using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sion.CsvParse {
    public static class Csv {
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
