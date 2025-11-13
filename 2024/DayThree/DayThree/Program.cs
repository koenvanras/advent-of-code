using System.Text.RegularExpressions;

string input = File.ReadAllText("./input.txt");

// Regex to extract all the text before don't() and between do() and don't()
Regex doRegex = new Regex(@"^(.*?)(?=don'?t\(\))|do\(\)(.*?)(?=don'?t\(\)|$)", RegexOptions.Singleline);
// Regex to extract all mul(number, number) where number is 1 to 3 digits
Regex mulRegex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");

var result = 0;

// Loop over all text based on the "do calculate" regex
foreach (Match doMatch in doRegex.Matches(input))
{
    // Get the group of matches before the first don't() (Groups[1]) or between do() and don't() (Groups[2])
    var matchGroup = doMatch.Groups[1].Success ? doMatch.Groups[1].Value : doMatch.Groups[2].Value;

    foreach (Match mulMatch in mulRegex.Matches(matchGroup))
    {
        // Calculate based on mul regex
        var mul = int.Parse(mulMatch.Groups[1].Value) * int.Parse(mulMatch.Groups[2].Value);
        result += mul;
    }
}

// Print the result
Console.WriteLine($"{result}");

Console.ReadLine();