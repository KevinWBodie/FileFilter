using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSV_Sorter
{
    public class FileFilter
    {
        // string[] originalData and filteredData. These are both made public and can be
        // accessed directly through an instance of the class
        // string[] originalData;

        public string[] originalData { get; set; }
        public string[] filteredData { get; set; }
        
        public Boolean hasHeader;

        public FileFilter(string FilePath)
        {
            Console.WriteLine("Inside: public FileFilter(string FilePath)");

            Console.WriteLine("About to read from:" + FilePath);

            hasHeader = false;

            int count = 0;
            string line;
            var list = new List<string>();

            // Read the file and display it line by line.
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(FilePath);
                while ((line = file.ReadLine()) != null)
                {
                    System.Console.WriteLine(line);
                    list.Add(line);
                    count++;
                }

                file.Close();
                System.Console.WriteLine("There were {0} lines.", count);
                originalData = list.ToArray();
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            int i;
            for (i = 0; i < count; i++)
            {
                Console.WriteLine("Original Data[" + i + "]:" + originalData[i]);
            }    
        }

        public void Filter(string value, int idx)
        {
            Console.WriteLine("Inside public void Filter(string value, int idx)" + value + " " + idx);

            if(hasHeader == true)
            {
                Console.WriteLine("This file has a header");
            }

            int i;
            var list = new List<string>();

            for (i = 0; i < originalData.Length; i++)
            {
                string[] fields = originalData[i].Split(',');

                if (fields[idx].ToUpper().Contains(value.ToUpper()))
                {
                    // string is found
                    list.Add(originalData[i]);
                    // System.Console.WriteLine("Match found:" + originalData[i]);
                }
            }
            filteredData = list.ToArray();
            for (i = 0; i < filteredData.Length; i++)
            {
                Console.WriteLine("Filtered Data[" + i + "]:" + filteredData[i]);
            }
            if (filteredData.Length == 0)
            {
                Console.WriteLine("No matches for in index:" + idx + " for value:" + value);
            }
        }

        public void SortAscend(int idx)
        {
            Console.WriteLine("Inside public void SortAscend(int idx)" + " " + idx);

            // Demonstrates how to return query from a method.  
            // The query is executed here.
            var list = new List<string>();

            // Split the string and sort on field[num], sortQuery
            var sortQuery = from line in filteredData
                            let fields = line.Split(',')
                            orderby fields[idx] ascending
                            select line;

            foreach (string line in sortQuery)
            {
                list.Add(line);
                Console.WriteLine("Sorted Filtered Data:" + line);
            }
        }

        // Returns the query variable, not query results!  
        static IEnumerable<string> RunQuery(IEnumerable<string> source, int num)
        {
            Console.WriteLine("Inside static IEnumerable<string> RunQuery(IEnumerable<string> source, int num)" + " " + num);

            // Split the string and sort on field[num]  
            var sortQuery = from line in source
                             let fields = line.Split(',')
                             orderby fields[num] ascending
                             select line;

            return sortQuery;
        }

        public void Save(string fileName)
        {


            File.WriteAllLines(fileName, filteredData);


        }
    }    
}
