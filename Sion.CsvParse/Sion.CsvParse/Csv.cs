using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sion.CsvParse {
    public static class Csv {
        public static async Task<IEnumerable<IEnumerable<string>>> Parse(string path) {
            IEnumerable<string> lines = await System.IO.File.ReadAllLinesAsync(path, Encoding.UTF8);
            List<List<string>> data = new List<List<string>>();

            foreach(var line in lines) {
                data.Add(line.Split(',').ToList());
            }

            return data;
        }

        public static async Task<IEnumerable<IEnumerable<string>>> Parse(string path, char delimiter) {
            IEnumerable<string> lines = await System.IO.File.ReadAllLinesAsync(path, Encoding.UTF8);
            List<List<string>> data = new List<List<string>>();

            foreach(var line in lines) {
                data.Add(line.Split(delimiter).ToList());
            }

            return data;
        }
    }
}
