var text = File.ReadAllText(@"..\..\..\data\input.txt");

var lines = text.Split('\n');
var totalCalories = 0;
var maxCalories = 0;
var top3 = new int[3] { 0, 0, 0 };

foreach (var line in lines)
{
    if (!string.IsNullOrWhiteSpace(line))
    {
        totalCalories += int.Parse(line);
    }
    else
    {
        if (totalCalories > maxCalories)
        {
            maxCalories = totalCalories;
        }

        UpdateTop3(totalCalories);

        totalCalories = 0;
    }
}

void UpdateTop3(int totalCalories)
{
    if (totalCalories > top3[0])
    {
        top3[2] = top3[1];
        top3[1] = top3[0];
        top3[0] = totalCalories;
    }
    else if (totalCalories > top3[1])
    {
        top3[2] = top3[1];
        top3[1] = totalCalories;
    }
    else if (totalCalories > top3[2])
    {
        top3[2] = totalCalories;
    }
}

Console.WriteLine($"maxCalories={maxCalories}");
Console.WriteLine($"top3={top3[0]}, {top3[1]}, {top3[2]} = {top3.Sum()}");
