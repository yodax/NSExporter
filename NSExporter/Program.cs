using NSExporter;

if (args.Length != 6)
{
    Console.WriteLine("USAGE:");
    Console.WriteLine("");
    Console.WriteLine("NSExporter.exe <url> <patientIdentifier> <dob: yyyy-MM-dd> <from: yyyy-MM-dd> <to: yyyy-MM-dd> <filename>");
    return;
}

var path = args[5];
var nightscoutUrl = args[0];
var identifier = args[1];
var dateOfBirth = DateTime.ParseExact(args[2], "yyyy-MM-dd", null);
var from = DateTime.ParseExact(args[3], "yyyy-MM-dd", null);
var to = DateTime.ParseExact(args[4], "yyyy-MM-dd",null);

File.WriteAllLines(path,
    Exporter
    .For(nightscoutUrl, identifier, dateOfBirth, new HttpClient(), from, to)
    .Export());