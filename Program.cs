using System;

namespace CSV_Sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            string DataFile = "/Users/kwb/Software Development/C#/SampleData/MikeSampleData/SuperBowl.csv";
            Console.WriteLine("Hello Kevin Bodie!");

            FileFilter fileter = new FileFilter(DataFile);

            fileter.hasHeader = true;

            fileter.Filter("Florida", 9);

        //    fileter.Filter("d", 2);

            // fileter.Filter("zip", 2);

            fileter.SortAscend(0);

            fileter.Save("/Users/kwb/Software Development/C#/SampleData/MikeSampleData/InputData.filteredData");
            Console.WriteLine("File written");

            fileter.SortAscend(1);
            fileter.SortAscend(2);
        }
    }
}
