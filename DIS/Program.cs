using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question - 1
            Console.WriteLine("*****Question 1 : Robot Moves*****");
            Console.WriteLine("Please enter Robot Moves in combination of either U/D/R/L:");
            string moves = Console.ReadLine();

            var list = new[] { "U", "D", "L", "R" };
            if (!list.Any(moves.Contains))
            {

                Console.WriteLine("Entered moves are invalid or case sensitive");
            }
            else
            {

                bool final_position = RobotPosition(moves);
                if (final_position)
                {
                    Console.WriteLine("Robot return’s to initial Position (0,0)");
                }
                else
                {
                    Console.WriteLine("Robot is not returning to the Initial Postion (0,0)");
                }

                Console.WriteLine();
            }

            //Question - 2
            Console.WriteLine("*****Question 2 : Paragram Sentence Check*****");
            Console.WriteLine("Enter sentence to check if pangram or not:");

            string Pangram_sentence = Console.ReadLine();
            bool P_check = CheckIfPangram(Pangram_sentence);
            if (P_check)
            {
                Console.WriteLine("Sentence entered is a pangram");
            }
            else
            {
                Console.WriteLine("Sentence entered not a pangram");
            }
            Console.WriteLine();


            //Question - 3
            Console.WriteLine("*****Question 3 : Good Pairs*****");
            //Console.WriteLine("Enter an array of integers 0 to 9:");


            int[] nums = { 1, 7, 3, 6, 5, 6 };

            int GP_count = NumIdenticalPairs(nums);
            Console.WriteLine("Count of Identical Pairs is : " + GP_count);


            //Question - 4:
            Console.WriteLine("*****Question 4 : Pivot Index*****");
            int[] input = { 1, 7, 3, 6, 5, 6 };
            int Pivot_Index = PivotIndex(input);
            if (Pivot_Index > 0)
            {
                Console.WriteLine("Pivot index for the given array : " + Pivot_Index);
            }
            else
            {
                Console.WriteLine("Input has no Pivot index");
            }
            //Console.WriteLine();

            //Question - 5:
            Console.WriteLine("*****Question 5 : Alternatively Merged String*****");
            Console.WriteLine("Enter Word1 - ");
            string Word1 = Console.ReadLine();
            Console.WriteLine("Enter Word2 - ");
            string Word2 = Console.ReadLine();

            if (Word1.Length == 0 || Word2.Length == 0)
            {
                Console.WriteLine("Words passed in are empty or null");

            }

            string merged = MergeAlternately(Word1, Word2);
            Console.WriteLine("The Merged Sentence - " + merged);

            //Question - 6:
            Console.WriteLine("*****Question 6 : Goat Latin*****");
            string phrase = Console.ReadLine();

            string Goat_Latin = ToGoatLatin(phrase);
            Console.WriteLine("Goat Latin Sentence -" + Goat_Latin);
            Console.WriteLine();
        }





        // Method to calcuate final position of Robot after completing all moves

        private static bool RobotPosition(string moves)
        {
            try
            {
                int length_moves = moves.Length; //length of the string of moves entered by user
                int R_count = 0; //Right moves count
                int L_count = 0; //Left moves count
                int D_count = 0; //Down moves count
                int U_count = 0; //Up moves count


                for (int i = 0; i < length_moves; i++) //traversing through the moves string and counting the no. of each moves
                {
                    if (moves[i] == 'U')
                        U_count++;

                    else if (moves[i] == 'D')
                        D_count++;

                    else if (moves[i] == 'L')
                        L_count++;

                    else if (moves[i] == 'R')
                        R_count++;
                }

                Console.WriteLine("Final Position: ("
                          + (R_count - L_count) + ", "
                          + (U_count - D_count) + ")");
                return R_count - L_count == 0 && (U_count - D_count) == 0;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Method to check if sentence is pangram or not

        private static bool CheckIfPangram(string Pangram_sentence)
        {
            try
            {
                //Counting each letter in string as unique group 

                return Pangram_sentence.ToLower().Where(ch => Char.IsLetter(ch)).GroupBy(ch => ch).Count() == 26;
                //Since alphabet count is 26 , so the group count should be 26 to qualify as panagram sentence
            }
            catch (Exception)
            {

                throw;
            }


        }

        private static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                int GoodPair_count = 0;

                //iterating through all the numbers in array integer
                //i<j
                //comparing the number in array at index i & j, if equate then good pair
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        //Console.WriteLine(i + "," + j);
                        if (nums[i] == nums[j])
                        {
                            Console.WriteLine(nums[i] + "," + nums[j] + ": " + "Good Pair");
                            GoodPair_count++;

                        }
                        else
                        {
                            Console.WriteLine(nums[i] + "," + nums[j] + ": " + "Not Good Pair");
                        }
                    }
                }
                return GoodPair_count;

            }
            catch (Exception)
            {

                throw;
            }
        }

        // Method calculating pivot index
        // pivot index is where sum of all the numbers strictly to the left of  the index is equal 
        // sum of all the numbers strictly to the index's right
        private static int PivotIndex(int[] input)
        {
            try
            {
                int Sum_L = 0;
                int Sum_R = input.Sum();
                for (int i = 0; i < input.Length; i++)
                {
                    Sum_L += input[i];
                    if (Sum_L == Sum_R)
                    {
                        Console.WriteLine(i);
                        return i;
                    }
                    Sum_R -= input[i];
                }
                return -1;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Method to merge two words alternatively
        private static string MergeAlternately(string Word1, string Word2)
        {
            try
            {
                string Alt_Merged = "";

                for (int i = 0; (i < Word1.Length || i < Word2.Length); i++)
                {
                    if (i < Word1.Length)
                    {
                        Alt_Merged = Alt_Merged + Word1[i];
                    }
                    if (i < Word2.Length)
                    {
                        Alt_Merged = Alt_Merged + Word2[i];
                    }

                }

                return Alt_Merged;
            }

            catch (Exception)
            {

                throw;
            }

        }

        //Method to form Goat Latin sentence
        private static string ToGoatLatin(string phrase)
        {
            try
            {
                var words = phrase.Split();
                StringBuilder sb = new StringBuilder();
                StringBuilder a = new StringBuilder();
                a.Append("a");

                foreach (var word in words)
                {
                    if ("aeiou".Contains(word[0], StringComparison.OrdinalIgnoreCase))
                    {
                        sb.Append(word);
                    }
                    else
                    {
                        sb.Append(word.Substring(1));
                        sb.Append(word[0]);
                    }
                    sb.Append("ma");
                    sb.Append(a.ToString());
                    a.Append("a");
                    sb.Append(" ");
                }

                sb.Length--;
                return sb.ToString();

            }
            catch (Exception)
            {

                throw;
            }


        }

    }

}





