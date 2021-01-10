# Sion.CSVParse

.NET 5 DLL that can be used to asynchronously parse .csv files and return the data.

## How to use this DLL in your .NET 5 projects:

### Using NuGet -

1. Right click on the solution in Visual Studio.
2. Click "Manage NuGet Packages for Solution".
3. Search for "Sion.CSVParse" and install the latest package to the appropriate projects.
4. Make sure to add "using Sion.CSVParse;" to the top of your .cs or .vb files.

### Using a local folder -

1. Download the most recent .dll file from this GitHub Repo's Releases.
2. Move the recently downloaded "Sion.CSVParse.dll" file to a known location on your disk.
3. In Visual Studio, with your project open, right click on "Dependencies" for the specific project you wish to install the DLL.
4. In the popup menu, click "Add Project Reference...".
5. A modal will pull up. Click the "Browse..." button towards the bottom right of the modal.
6. Navigate to where you saved "Sion.CSVParse.dll" and add it.
7. Make sure to add "using Sion.CSVParse;" to the top of your .cs or .vb files.

## How to convert from .csv format to .json format (creates a new .json file):

await CSV.ConvertToJSON("filepath.csv", "filepath.json");

## How to fill in empty values (this overwrites your .csv file):

await CSV.FillEmptyValues("filepath.csv", "none");

## How to grab just the data from your .csv file:

### If there are headers -

IEnumerable\<IEnumerable\<string\>\> data = await CSV.GetData("filepath.csv");

### If there are no headers -

IEnumberable\<IEnumberable\<string\>\> data = await CSV.GetData("filepath.csv", false);
<br/>// OR<br/>
IEnumberable\<IEnumberable\<string\>\> data = await CSV.Parse("filepath.csv");

## How to grab just the headers from your .csv file:

IEnumberable\<string\> headers = await CSV.GetHeaders("filepath.csv");

## How to grab just the x values from my data:

IEnumerable\<IEnumerable\<string\>\> xValues = CSV.GetXValues(IEnumerable\<IEnumerable\<string\>\> dataset);

## How to grab just the y values from my data:

IEnumerable\<string\> yValues = CSV.GetYValues(IEnumerable\<IEnumerable\<string\>\> dataset);

## How to normalize the width of all rows (this overwrites your .csv file):

#### This pads each row with some value until they all have the same number of columns

await NormalizeWidth("filepath.csv", "0");

## How to grab all the data, headers included (if there are headers):

IEnumberable\<IEnumberable\<string\>\> data = await CSV.Parse("filepath.csv");

## How to replace a value throughout my .csv (this overwrites your .csv file):

await CSV.Replace("filepath.csv", "NULL", "0");

## What if I use a character other than ',' to delimit my .csv files?:

#### All the methods are overloaded to accept an optional char delimiter! If not provided, ',' is the assumed character

#### CSV.GetXValues and CSV.GetYValues do not need a delimiter

## What if I use an encoding other than UTF8 on my .csv files?:

#### All the methods are also overloaded to accept an optional Encoding. If not provided, UTF8 is the assumed encoding

#### CSV.GetXValues and CSV.GetYValues do not need an Encoding

## All methods for CSV.ConvertToJSON:

public static async Task ConvertToJSON(string path, string jsonPath);<br/>
public static async Task ConvertToJSON(string path, string jsonPath, Encoding encoding);<br/>
public static async Task ConvertToJSON(string path, string jsonPath, char delimiter);<br/>
public static async Task ConvertToJSON(string path, string jsonPath, char delimiter, Encoding encoding);

## All methods for CSV.FillEmptyValues:

public static async Task FillEmptyValues(string path, string value);<br/>
public static async Task FillEmptyValues(string path, string value, Encoding encoding);<br/>
public static async Task FillEmptyValues(string path, string value, char delimiter);<br/>
public static async Task FillEmptyValues(string path, string value, char delimiter, Encoding encoding);

## All methods for CSV.GetData:

public static async Task\<IEnumerable\<IEnumerable\<string\>\>\> GetData(string path);<br/>
public static async Task\<IEnumerable\<IEnumerable\<string\>\>\> GetData(string path, Encoding encoding);<br/>
public static async Task\<IEnumerable\<IEnumerable\<string\>\>\> GetData(string path, char delimiter);<br/>
public static async Task\<IEnumerable\<IEnumerable\<string\>\>\> GetData(string path, char delimiter, Encoding encoding);<br/>
public static async Task\<IEnumerable\<IEnumerable\<string\>\>\> GetData(string path, bool hasHeaders);<br/>
public static async Task\<IEnumerable\<IEnumerable\<string\>\>\> GetData(string path, bool hasHeaders, Encoding encoding);<br/>
public static async Task\<IEnumerable\<IEnumerable\<string\>\>\> GetData(string path, bool hasHeaders, char delimiter);<br/>
public static async Task\<IEnumerable\<IEnumerable\<string\>\>\> GetData(string path, bool hasHeaders, char delimiter, Encoding encoding);

## All methods for CSV.GetHeaders:

public static async Task\<IEnumerable\<string\>\> GetHeaders(string path);<br/>
public static async Task\<IEnumerable\<string\>\> GetHeaders(string path, Encoding encoding);<br/>
public static async Task\<IEnumerable\<string\>\> GetHeaders(string path, char delimiter);<br/>
public static async Task\<IEnumerable\<string\>\> GetHeaders(string path, char delimiter, Encoding encoding);

## All methods for CSV.GetXValues:

public static IEnumerable\<IEnumerable\<string\>\> GetXValues(IEnumerable\<IEnumerable\<string\>\> dataset);

## All methods for CSV.GetYValues:

public static IEnumerable\<string\> GetYValues(IEnumerable\<IEnumerable\<string\>\> dataset);

## All methods for CSV.NormalizeWidth:

public static async Task NormalizeWidth(string path, string padValue);<br/>
public static async Task NormalizeWidth(string path, string padValue, Encoding encoding);<br/>
public static async Task NormalizeWidth(string path, string padValue, char delimiter);<br/>
public static async Task NormalizeWidth(string path, string padValue, char delimiter, Encoding encoding);

## All methods for CSV.Parse:

public static async Task\<IEnumerable\<IEnumerable\<string\>\>\> Parse(string path);<br/>
public static async Task\<IEnumerable\<IEnumerable\<string\>\>\> Parse(string path, Encoding encoding);<br/>
public static async Task\<IEnumerable\<IEnumerable\<string\>\>\> Parse(string path, char delimiter);<br/>
public static async Task\<IEnumerable\<IEnumerable\<string\>\>\> Parse(string path, char delimiter, Encoding encoding);

## All methods for CSV.Replace:

public static async Task Replace(string path, string replace, string newValue);<br/>
public static async Task Replace(string path, string replace, string newValue, Encoding encoding);<br/>
public static async Task Replace(string path, string replace, string newValue, char delimiter);<br/>
public static async Task Replace(string path, string replace, string newValue, char delimiter, Encoding encoding);
