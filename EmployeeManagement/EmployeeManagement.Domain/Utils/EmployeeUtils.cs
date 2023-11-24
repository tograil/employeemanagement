namespace EmployeeManagement.Domain.Utils;

public static class EmployeeUtils
{
    public static string GenerateEmployeeId()
    {
        // Generate random numbers for the employee ID
        var random = new Random();
        var part1 = random.Next(100, 999).ToString("D3");
        var part2 = random.Next(10, 99).ToString("D2");
        var part3 = random.Next(1000, 9999).ToString("D4");

        return $"{part1}-{part2}-{part3}";
    }
}