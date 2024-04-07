using System.Globalization;
using System.Net;
using TestAssig;

Console.WriteLine("file_log: ");
var PathLog = Console.ReadLine();

Console.WriteLine("file_output: ");
var PathOutput = Console.ReadLine();

Console.WriteLine("address_start: ");
var AddressStart = Console.ReadLine();

IPAddress? ipAddressStart = null;
IPAddress? maxAddress = null;

if (AddressStart.Trim().Length > 0)
{
    try
    {
        ipAddressStart = IPAddress.Parse(AddressStart);
    }
    catch
    {
        Console.WriteLine("Invalid format of address. 0.0.0.0 is selected");
        ipAddressStart = IPAddress.Parse("0.0.0.0");
    }
}

if (ipAddressStart != null)
{
    Console.WriteLine("address_mask: ");
    var AddressMask = int.Parse(Console.ReadLine());

    if (AddressMask >= 0 && AddressMask <= 32)
    {
        maxAddress = IPAddress.Parse(AddressHelper.GetMaxAddress(AddressMask));
    }
    else
    {
        Console.WriteLine("Invalid mask of address. 32 is selected");
        maxAddress = IPAddress.Parse("255.255.255.255");
    }
}

Console.WriteLine("time_start: ");
var timeStart = DateTimeControl.GetDateTime();

Console.WriteLine("time_end: ");
var timeEnd = DateTimeControl.GetDateTime();

var ipStart = CustomAddressParser.IPAddressToInt(ipAddressStart);
var ipEnd = CustomAddressParser.IPAddressToInt(maxAddress);

var lines = File.ReadAllLines(PathLog);


var filterLogs = lines.Where(x => { 
    var fileNameParse = x.Split(':', 2);
    var address = CustomAddressParser.IPAddressToInt(IPAddress.Parse(fileNameParse[0]));
    var datetime = DateTime.ParseExact(fileNameParse[1], "yyyy-MM-dd HH:mm:ss", null);
    return (ipStart <= address && address <= ipEnd) && (timeStart <= datetime && datetime <= timeEnd);
}).ToArray();

if (!File.Exists(PathOutput))
{
    Directory.CreateDirectory(Path.GetDirectoryName(PathOutput));
    File.Create(PathOutput).Close();
}
File.AppendAllLines(PathOutput, filterLogs);