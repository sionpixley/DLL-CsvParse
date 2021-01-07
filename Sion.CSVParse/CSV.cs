using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sion.CSVParse {
    public static class CSV {
        public static async Task FillEmptyValues(string path, string value) {
            IEnumerable<string> lines = await System.IO.File.ReadAllLinesAsync(path, Encoding.UTF8);
            List<string> newLines = new List<string>();

            foreach(var line in lines) {
                if(line.Contains(",,")) {
                    string newLine = line;
                    while(newLine.Contains(",,")) {
                        int index = newLine.IndexOf(",,");
                        newLine = $"{newLine[0..(index + 1)]}{value}{newLine[(index + 1)..]}";
                    }
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
                    string newLine = line;
                    while(newLine.Contains($"{delimiter}{delimiter}")) {
                        int index = newLine.IndexOf($"{delimiter}{delimiter}");
                        newLine = $"{newLine[0..(index + 1)]}{value}{newLine[(index + 1)..]}";
                    }
                    newLines.Add(newLine);
                }
                else {
                    newLines.Add(line);
                }
            }

            await System.IO.File.WriteAllLinesAsync(path, newLines, Encoding.UTF8);
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

        public static IEnumerable<IEnumerable<string>> GetXValues(IEnumerable<IEnumerable<string>> dataset) {
            List<List<string>> xValues = new List<List<string>>();
            foreach(var row in dataset) {
                List<string> current = new List<string>();
                List<string> rowList = row.ToList();
                for(int i = 0; i < (rowList.Count - 1); i += 1) {
                    current.Add(rowList[i]);
                }
                xValues.Add(current);
            }
            return xValues;
        }

        public static IEnumerable<string> GetYValues(IEnumerable<IEnumerable<string>> dataset) {
            List<string> yValues = new List<string>();
            foreach(var row in dataset) {
                List<string> rowList = row.ToList();
                yValues.Add(rowList[^1]);
            }
            return yValues;
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

        public static async Task Replace(string path, string replace, string newValue) {
            IEnumerable<string> lines = await System.IO.File.ReadAllLinesAsync(path, Encoding.UTF8);
            List<string> newLines = new List<string>();

            foreach(var line in lines) {
                if(line.Contains(",,")) {
                    string newLine = line;
                    while(newLine.Contains(",,")) {
                        int index = newLine.IndexOf(",,");
                        newLine = $"{newLine[0..(index + 1)]}{newValue}{newLine[(index + 1)..]}";
                    }
                    newLines.Add(newLine);
                }
                else {
                    newLines.Add(line);
                }
            }

            await System.IO.File.WriteAllLinesAsync(path, newLines, Encoding.UTF8);
        }

        public static async Task Replace( string path
                                        , string replace
                                        , string newValue
                                        , char delimiter ) {
            IEnumerable<string> lines = await System.IO.File.ReadAllLinesAsync(path, Encoding.UTF8);
            List<string> newLines = new List<string>();

            foreach(var line in lines) {
                if(line.Contains($"{delimiter}{delimiter}")) {
                    string newLine = line;
                    while(newLine.Contains($"{delimiter}{delimiter}")) {
                        int index = newLine.IndexOf($"{delimiter}{delimiter}");
                        newLine = $"{newLine[0..(index + 1)]}{newValue}{newLine[(index + 1)..]}";
                    }
                    newLines.Add(newLine);
                }
                else {
                    newLines.Add(line);
                }
            }

            await System.IO.File.WriteAllLinesAsync(path, newLines, Encoding.UTF8);
        }
    }
}
