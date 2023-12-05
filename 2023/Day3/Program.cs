
using System.Diagnostics;
using AOC2023.Day3;

var external = new Day3();

external.SolvePart1And2();

//return;


var data = File.ReadAllLines("../../../Day3_Input.txt");
var numberBuffer = string.Empty;
var numbers = new List<int>();
var valid = false;

for (int i = 0; i < data.Length; i++)
{
    data[i] = data[i].Trim();
}

// y axis traversal down
for (int i = 0; i < data.Length; i++)
{
    //if (i == 5) Debugger.Break();
    
    // x axis traversal right
    for (int j = 0; j < data[i].Length; j++)
    {
        // check if we are at a tree
        if (Char.IsNumber(data[i][j]))
        {
            // add the number to the buffer
            //numberBuffer += data[i][j];
            while (j < data[i].Length && Char.IsNumber(data[i][j]))
            {
                // add the number to the buffer
                numberBuffer += data[i][j];
                // increment j
                j++;
            }
            
            j -= numberBuffer.Length;

            if (numberBuffer == "102") Debugger.Break();
            
            // Check for adjacent Symbols
            for (int m = 0; m < numberBuffer.Length; m++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    for (int y = -1; y <= 1; y++)
                    {
                        // check if we are not at the center
                        //if (x != 0 && y != 0)
                        //{
                            // check if we are not out of bounds
                            if (i + x >= 0 && i + x < data.Length && j + y + m >= 0 && j + y + m < data[i].Length)
                            {
                                // check if we are at a number
                                if (!Char.IsDigit(data[i + x][j + y + m]) && data[i + x][j + y + m] != '.')
                                {
                                    //Debug.Print(data[i + x][j + y + m].ToString());
                                    valid = true;
                                }
                            }
                        //}
                    }
                }

                if (valid)
                {
                    //Debug.Print(numberBuffer + " true");
                    numbers.Add(int.Parse(numberBuffer));
                    j += numberBuffer.Length;
                    numberBuffer = string.Empty;
                    valid = false;
                }

            }

            if (numberBuffer != string.Empty)
            {
                //Debug.Print(numberBuffer + " false");
                j += numberBuffer.Length;
                numberBuffer = string.Empty;
            }
        }
    }
}

Console.WriteLine(numbers.Sum()); 