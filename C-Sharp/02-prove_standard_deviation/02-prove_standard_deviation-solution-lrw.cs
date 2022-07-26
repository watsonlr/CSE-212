/********
CSE212 
(c) BYU-Idaho
02-Prove - Problem 1.2

It is a violation of BYU-Idaho Honor Code to post or share this code with others or 
to post it online.  Storage into a personal and private repository (e.g. private
GitHub repository, unshared Google Drive folder) is acceptable.

//--- Created from: dotnet new console. See https://aka.ms/new-console-template for more information ---//
********/
Console.WriteLine("CSE212:  02-Prove - Problem 1.2");  // Comment out this line

public class deviations
{
public double standard_deviation_1(int[] numbers)
    {
    int total = 0, count=0;
    foreach(var number in numbers )
        {
            total += number;
            count++;
        }
    double avg = total / count;
    double sum_squared_differences = 0;
    foreach(var number in numbers)
        {
        sum_squared_differences += Math.Pow(number - avg,  2);
        }
    double variance = Math.Sqrt(sum_squared_differences / count);
    return variance ;
    }

    
public double standard_deviation_3(int[] numbers) 
    {
    int count = numbers.Length; // instead of manually counting, use built-in attribute
    int sum = numbers.Sum();      // built-in sum method
    double avg = sum/ count;
    double builtin_average = numbers.Average(); // Short cut
    double sum_squared_differences = 0;
    for number in numbers:
        sum_squared_differences += (number - avg) ** 2

    double variance = Math.Sqrt(sum_squared_differences / count);
    return variance ;
    }


}




public class test_sd
    {
    int[] numbers =  {600, 470, 170, 430, 300};
    double variance1 =  deviations.standard_deviation_1(numbers);  // Should be 147.322 
    double variance2 =  deviations.standard_deviation_1(numbers);  // Should be 147.322 
    double variance3 =  deviations.standard_deviation_1(numbers);  // Should be 147.322 
    Console.WriteLine("std deviation 1" + deviations.standard_deviation_1(numbers));  // Should be 147.322 
    //Console.WriteLine(standard_deviation_2(numbers))  # Should be 147.322 
    //Console.WriteLine(standard_deviation_3(numbers))  # Shou
}

Console.WriteLine();  // Comment out this line