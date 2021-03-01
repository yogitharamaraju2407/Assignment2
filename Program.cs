using System;
using System.Linq;
using System.Collections.Generic;

namespace Assignment2dis
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1");
            int[] ar1 = { 2, 5, 1, 3, 4, 7 };
            int n1 = 3;
            ShuffleArray(ar1, n1);

            //Question 2 
            Console.WriteLine("Question 2");
            int[] ar2 = { 0, 1, 0, 3, 12 };
            MoveZeroes(ar2);
            Console.WriteLine("");

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 3, 1, 1, 3 };
            CoolPairs(ar3);
            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            int[] ar4 = { 2, 7, 11, 15 };
            int target = 9;
            TwoSum(ar4, target);
            Console.WriteLine();

            //Question 5
            Console.WriteLine("Question 5");
            string s5 = "korfsucy";
            int[] indices = { 6, 4, 3, 2, 1, 0, 5, 7 };
            RestoreString(s5, indices);
            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            string s61 = "bulls";
            string s62 = "sunny";
            if (Isomorphic(s61, s62))
            {
                Console.WriteLine("Yes the two strings are Isomorphic");
            }
            else
            {
                Console.WriteLine("No, the given strings are not Isomorphic");
            }
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int n8 = 19;
            if (HappyNumber(n8))
            {
                Console.WriteLine("{0} is a happy number", n8);
            }
            else
            {
                Console.WriteLine("{0} is not a happy number", n8);
            }
            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] ar9 = { 7, 1, 5, 3, 6, 4 };
            int profit = Stocks(ar9);
            if (profit == 0)
            {
                Console.WriteLine("No Profit is possible");
            }
            else
            {
                Console.WriteLine("Profit is {0}", profit);
            }
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int n10 = 3;
            Stairs(n10);
            Console.WriteLine();
        }

        private static void ShuffleArray(int[] arrayOfNumbers, int pairs)
        {
            try
            {
                int numberOfNumbers = arrayOfNumbers.Length;
                // Array to store the final result
                int[] shuffledArray = new int[numberOfNumbers];
                // arrays to store x and y values
                int[] x = new int[pairs];
                int[] y = new int[pairs];
                // storing the x and y values respectively
                for (int i = 0; i < numberOfNumbers; i++)
                {
                    if (i < pairs)
                    {
                        x[i] = arrayOfNumbers[i];
                    }
                    else
                    {
                        y[i - pairs] = arrayOfNumbers[i];
                    }
                }
                // adding the values of the x and y arrays alternatively
                int p = 0, q = 0, r = 0;
                while (p < pairs && q < pairs)
                {
                    shuffledArray[r++] = x[p++];
                    shuffledArray[r++] = y[q++];
                }
                while (p < pairs)
                    shuffledArray[r++] = x[p++];
                while (q < pairs)
                    shuffledArray[r++] = y[q++];
                // printing the output array
                string seperator = "[";
                foreach (int val in shuffledArray)
                {
                    Console.Write(seperator + val);
                    seperator = ",";
                }
                Console.WriteLine("]");
                Console.WriteLine();
            }
            catch (Exception)
            {
               throw new Exception("Enter a valid input");           
            }
        }

        private static void MoveZeroes(int[] numbersWithZeros)
        {
            try
            {
                int numberOfNumbers = numbersWithZeros.Length;
                int counter = 0;
                // moving the non zero values forward
                for (int i = 0; i < numberOfNumbers; i++)
                {
                    if (numbersWithZeros[i] != 0)
                    {
                        numbersWithZeros[counter] = numbersWithZeros[i];
                        counter++;
                    }
                }
                // filling the last remaining values with zeros
                while (counter < numberOfNumbers)
                {
                    numbersWithZeros[counter] = 0;
                    counter++;
                }
                // printing output
                string seperator = "[";
                foreach (int i in numbersWithZeros)
                {
                    Console.Write(seperator + i);
                    seperator = ",";
                }
                Console.WriteLine("]");
            }
            catch (Exception)
            {
                throw new Exception("Enter a valid input");
            }
        }

        private static void CoolPairs(int[] numbersWithCoolPairs)
        {
            try
            {
                int numberOfCoolPairs = 0;
                int size = numbersWithCoolPairs.Length;
                // dictionary to store the frequency
                Dictionary<int, int> counterDict = new Dictionary<int, int>();
                // storing the frequency of the values
                for (int i = 0; i < size; i++)
                {
                    if (counterDict.ContainsKey((int)numbersWithCoolPairs[i]))
                    {
                        counterDict[(int)numbersWithCoolPairs[i]] += 1;
                    }
                    else
                    {
                        counterDict.Add((int)numbersWithCoolPairs[i], 1);
                    }
                }
                // calculating the cool pairs using the frequencies
                foreach (KeyValuePair<int, int> kvp in counterDict)
                {
                    if (kvp.Value > 1)
                    {
                        numberOfCoolPairs += ((kvp.Value) * (kvp.Value - 1)) / 2;
                    }
                }
                // printing the Output
                Console.WriteLine(numberOfCoolPairs);
            }
            catch (Exception)
            {
                throw new Exception("Enter a valid input");
            }
        }

        private static void TwoSum(int[] numbersToBeProcessed, int target)
        {
            try
            {
                int[] twoSumPair = new int[2];
                // Hashset for storing element and checking
                HashSet<int> hs = new HashSet<int>();
                for (int i = 0; i < numbersToBeProcessed.Length; i++)
                {
                    // Checking if already have the difference
                    if (hs.Contains(target - numbersToBeProcessed[i]))
                    {
                        // storing the index
                        twoSumPair[0] = target - numbersToBeProcessed[i];
                        twoSumPair[1] = i;
                    }
                    // Adding the number to the hashset
                    hs.Add(numbersToBeProcessed[i]);
                }
                for (int i = 0; i < numbersToBeProcessed.Length; i++)
                {
                    if (twoSumPair[0] == numbersToBeProcessed[i])
                    {
                        // storing the index
                        twoSumPair[0] = i;
                    }
                }
                // printing Output
                string seperator = "[";
                foreach (int val in twoSumPair)
                {
                    Console.Write(seperator + val);
                    seperator = ",";
                }
                Console.WriteLine("]");
            }
            catch (Exception)
            {
                throw new Exception("Enter a valid input");
            }
        }

        private static void RestoreString(string testString, int[] indices)
        {
            try
            {
                // converting the string to character array
                char[] testChars = testString.ToCharArray();
                // mapping the given indices to the characters
                var indicesToCharsMap = indices.Zip(testChars, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);
                // sorting the hashmap with respect to indices
                var sortedIndicesToCharsMap = new SortedDictionary<int, char>(indicesToCharsMap);
                // constructing and printing final string
                string restoredString = "";
                foreach (KeyValuePair<int, char> kvp in sortedIndicesToCharsMap)
                {
                    restoredString += kvp.Value;
                }
                Console.WriteLine(restoredString);
            }
            catch (Exception)
            {
                throw new Exception("Enter a valid input");
            }
        }

        private static bool Isomorphic(string string1, string string2)
        {
            try
            {
                // converting string1 and string2 to character arrays
                char[] characters1 = string1.ToCharArray();
                char[] characters2 = string2.ToCharArray();
                // Dictionary to map the characters from both character sets
                Dictionary<char, char> hashmap = new Dictionary<char, char>();
                bool isIsomorphic = true;
                for (int i = 0; i < characters1.Length; i++)
                {
                    if (hashmap.ContainsKey(characters1[i]))
                    {
                        if (hashmap[characters1[i]] == characters2[i])
                        {
                            continue;
                        }
                        else
                        {
                            isIsomorphic = false;
                            break;
                        }
                    }
                    if (hashmap.ContainsValue(characters2[i]))
                    {
                        var myKey = hashmap.FirstOrDefault(x => x.Value == characters2[i]).Key;
                        if (characters1[i] == myKey)
                        {
                            continue;
                        }
                        else
                        {
                            isIsomorphic = false;
                            break;
                        }
                    }
                    else
                    {
                        hashmap.Add(characters1[i], characters2[i]);
                    }
                }
                // if unable to remap the characters, then the strings are not Isomorphic
                if (!isIsomorphic)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Enter a valid input");
            }
        }
        private static void HighFive(int[,] studentDetails)
        {
            try
            {
                // building jagged array to process the information
                int rStart = studentDetails.GetLowerBound(0);
                int rEnd = studentDetails.GetUpperBound(0);
                int nRows = rEnd - rStart + 1;
                int cStart = studentDetails.GetLowerBound(1);
                int cEnd = studentDetails.GetUpperBound(1);
                int nColumns = cEnd - cStart + 1;
                int[][] convertedArray = new int[nRows][];
                for (int i = 0; i < nRows; i++)
                {
                    convertedArray[i] = new int[nColumns];
                    for (int j = 0; j < nColumns; j++)
                    {
                        convertedArray[i][j] = studentDetails[i + rStart, j + cStart];
                    }
                }
                // building Dictionary to map students with their scores
                Dictionary<int, int[]> students = new Dictionary<int, int[]>();
                foreach (int[] x in convertedArray)
                {
                    if (students.ContainsKey(x[0]))
                    {
                        int i = 0;
                        int[] flag = new int[students[x[0]].Length + 1];
                        foreach (int val in students[x[0]])
                        {
                            flag[i] = val;
                            i++;
                        }
                        flag[i] = x[1];
                        students[x[0]] = flag;
                    }
                    else
                    {
                        students[x[0]] = new int[] { x[1] };
                    }
                }
                // averaging the top five scores
                Dictionary<int, int> average = new Dictionary<int, int>();
                foreach (KeyValuePair<int, int[]> kvp in students)
                {
                    int sum = 0;
                    int[] flag = kvp.Value;
                    for (int x = 0; x < 5; x++)
                    {
                        int maxVal = flag.Max();
                        sum += maxVal;
                        int numIdx = Array.IndexOf(flag, maxVal);
                        List<int> flag2 = new List<int>(flag);
                        flag2.RemoveAt(numIdx);
                        flag = flag2.ToArray();
                    }
                    average[kvp.Key] = sum / 5;
                }
                // printing Output
                foreach (KeyValuePair<int, int> kvp in average)
                {
                    Console.Write("[" + kvp.Key + "," + kvp.Value+ "]");
                }
            }
            catch (Exception)
            {
                throw new Exception("Enter a valid input");
            }
        }

        private static bool HappyNumber(int numberToBeTested)
        {
            try
            {
                // converting the string to character srt
                char[] charactersInNumber = numberToBeTested.ToString().ToCharArray();
                int[] integerFormatOfCharacters = Array.ConvertAll(charactersInNumber, c => (int)Char.GetNumericValue(c));
                // processing the logic to make the number into single digit
                while (integerFormatOfCharacters.Length > 1)
                {
                    int sum = 0;
                    for (int i = 0; i < integerFormatOfCharacters.Length; i++)
                    {
                        sum += (int)Math.Pow(integerFormatOfCharacters[i], 2);
                    }
                    charactersInNumber = sum.ToString().ToArray();
                    integerFormatOfCharacters = Array.ConvertAll(charactersInNumber, c => (int)Char.GetNumericValue(c));
                }
                // Checking if the number is lucky
                if (integerFormatOfCharacters[0] == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw new Exception("Enter a valid input");
            }
        }

        private static int Stocks(int[] prices)
        {
            try
            {
                int maximum = 0;
                int flag = -1;
                int n = prices.Length;
                for (int i = 0; i < n; i++)
                {
                    // following if conditions try to bring us minimum stock to buy
                    // if the initiator value is less than zero
                    if (flag < 0)
                    {
                        flag = prices[i];
                    }
                    // if the initiator value is greter than zero
                    if (flag > prices[i])
                    {
                        flag = prices[i];
                    }
                    // else will help us finding the maximum stock to sell
                    else
                    {
                        if (prices[i] - flag > maximum)
                        {
                            maximum = prices[i] - flag;
                        }
                    }
                }
                return maximum;
            }
            catch (Exception)
            {
                throw new Exception("Enter a valid input");
            }
        }

        private static void Stairs(int numberOfSteps)
        {
            try
            {
                int number = numberOfSteps + 1;
                int[] result = new int[number + 1];
                result[0] = 0;
                result[1] = 1;
                // applying Fibonacci logic to find the number of ways to walk the steps
                for (int i = 2; i <= number; i++)
                {
                    result[i] = result[i - 2] + result[i - 1];
                }
                Console.WriteLine(result[number]);
            }
            catch (Exception)
            {
                throw new Exception("Enter a valid input");
            }
        }
    }
}
