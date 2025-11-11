using System.Text.RegularExpressions;

string input = System.IO.File.ReadAllText("./input.txt");
Regex regex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");

var result = 0;

foreach (Match match in regex.Matches(input))
{
    var mul = int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
    result += mul;
}

Console.WriteLine($"{result}");

Console.ReadLine();