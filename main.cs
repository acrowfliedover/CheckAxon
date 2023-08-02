using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

namespace Axon
//To Generate a Random Chart for a music with certain BPM and Length
class ChartGenerator{
    static void Main(string[] args)
    {
        Console.WriteLine("Please give Chart Title");
        string chartTitle = Console.ReadLine;

        Console.WriteLine("Please give BPM");
        string bpm = Console.ReadLine;
        float bpmNumber=float.Parse(bpm);

        Console.WriteLine("Please give length in seconds");
        string seconds= Console.ReadLine;
        float secondsNumber=float.Parse(seconds);

        Console.WriteLine("Please give initial delay in seconds");
        string initialDelay = Console.ReadLine;
        float initialDelayNumber=float.Parse(initialDelay);

        Console.WriteLine("Please give number of cells");
        string numberCells = Console.ReadLine;
        int numberOfCells = float.Parse(numberCells);

        Console.WriteLine("Please give number of sheaths each cell");
        string numberSheaths = Console.ReadLine;
        int numberOfSheaths = float.Parse(numberSheaths);

        Console.WriteLine("Please give note density (1-100)");
        string noteDensity = Console.ReadLine;
        int noteDensityNumber = float.Parse(noteDensity);




    }
