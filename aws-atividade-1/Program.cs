using static ServiceReference.CountryInfoServiceSoapTypeClient;

Console.BackgroundColor = ConsoleColor.Blue;

Console.Write("DataFlex Web Service for Country information");

Console.BackgroundColor = ConsoleColor.Black;

Console.WriteLine("\n");

var client = new ServiceReference.CountryInfoServiceSoapTypeClient(EndpointConfiguration.CountryInfoServiceSoap);

Console.ForegroundColor = ConsoleColor.Green;

Console.WriteLine("List of Continents");

Console.ForegroundColor = ConsoleColor.White;

var continents = client.ListOfContinentsByNameAsync().Result.Body.ListOfContinentsByNameResult;

foreach (var continent in continents)
{
    Console.WriteLine($"\t{continent.sCode} - {continent.sName}");
}

Console.WriteLine("\n");

Console.ForegroundColor = ConsoleColor.Green;

Console.WriteLine("Searching Brazil by ISO Code");

Console.ForegroundColor = ConsoleColor.White;

var countries = client.ListOfCountryNamesByCodeAsync().Result.Body.ListOfCountryNamesByCodeResult;

string brazilISOCode = "BR";

var brazil = countries
    .Where(country => country.sISOCode.Equals(brazilISOCode))
    .FirstOrDefault();

if (brazil != null)
{
    Console.WriteLine($"\t{brazil.sName}");
}

Console.WriteLine("\n");

Console.ForegroundColor = ConsoleColor.Green;

Console.WriteLine("Informations of Brazil");

Console.ForegroundColor = ConsoleColor.White;

string brazilCurrencyISOCode = "BRL";

var brazilInfo = client.FullCountryInfoAsync(brazilCurrencyISOCode).Result.Body.FullCountryInfoResult;

Console.WriteLine($"\tContinent code: {brazilInfo.sContinentCode}");
Console.WriteLine($"\tISO Code: {brazilInfo.sISOCode}");
Console.WriteLine($"\tCapital city: {brazilInfo.sCapitalCity}");
Console.WriteLine($"\tInternational phone code: {brazilInfo.sPhoneCode}");
Console.WriteLine($"\tFlag: {brazilInfo.sCountryFlag}");

Console.WriteLine("\tLanguages");

var brazilLanguages = brazilInfo.Languages;

foreach (var brazilLanguage in brazilLanguages)
{
    Console.WriteLine($"\t\t{brazilLanguage.sISOCode} - {brazilLanguage.sName}");
}