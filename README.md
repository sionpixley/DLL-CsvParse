# DLL-CSVParse
.NET 5 DLL that can be used to parse .csv files and return the data.

## How to use this DLL in your .NET 5 projects:
1. Download the most recent .dll file from this GitHub Repo's Releases.
2. Move the recently downloaded "Sion.CsvParse.dll" file to a known location on your disk.
3. In Visual Studio, with your project open, right click on "Dependencies" for the specific project you wish to install the DLL.
4. In the popup menu, click "Add Project Reference...".
5. A modal will pull up. Click the "Browse..." button towards the bottom right of the modal.
6. Navigate to where you saved "Sion.CsvParse.dll" and add it.
7. Make sure to add "using Sion.CsvParse;" to the top of your .cs or .vb files.

### How to fill in empty columns:
await Csv.FillEmptyValues("filepath.csv", "none");

### How to grab just the headers from your .csv file:
IEnumberable\<string\> headers = await Csv.GetHeaders("filepath.csv");

### How to grab just the data from your .csv file (if there are headers):
IEnumerable\<IEnumerable\<string\>\> data = await Csv.GetData("filepath.csv");

### How to grab just the data from your .csv file (if there are no headers):
IEnumberable\<IEnumberable\<string\>\> data = await Csv.GetData("filepath.csv", false);
<br/>// OR<br/>
IEnumberable\<IEnumberable\<string\>\> data = await Csv.Parse("filepath.csv");

### How to grab all the data, headers included:
IEnumberable\<IEnumberable\<string\>\> data = await Csv.Parse("filepath.csv");

## What if I use a character other than ',' to delimit my .csv files?
All the methods are overloaded to accept an optional char delimiter! If not provided, ',' is the assumed character.

<br/>Csv.FillEmptyValues(string path, string value, char delimiter);<br/>
Csv.Parse(string path, char delimiter);<br/>
Csv.GetHeaders(string path, char delimiter);<br/>
Csv.GetData(string path, char delimiter, bool hasHeaders);
