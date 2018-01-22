using System;
using System.Collections.Generic;
using System.Linq;
namespace ArrayPractice
{

    class Solution
    {

        //remove in-
        //remove in extra list-
        //remove in using Array.copy
        //remove in range
        //merge -
        //move 0-
        //move 0 Backward -
        //palindrome - 
        //reverse  -
        //reverseCSharp  -
        //palindrome 2
        //sum3
        //sum3CSharp
        //moving matrix
        public void removeIn(int[] list, int val)
        {
            if (list.Length == 0)
                return;
            int index = -1;
            for (int i = 0; i < list.Length; i++)
            {
                if (val == list[i])
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
                for (int i = index; i < list.Length - 1; i++)
                {
                    list[i] = list[i + 1];
                }

            return;
        }
        public int[] removeInImplementationTwo(int[] list, int val)
        {
            if (list.Length == 0)
                return list;
            int aux = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (val != list[i])
                {
                    list[aux] = list[i];
                    aux++;
                }
            }
            if (aux == 0)
            {
                return list;
            }

            int[] newList = new int[aux];

            for (int i = 0; i < aux; i++)
                newList[i] = list[i];

            return newList;
        }


        public void moveZeroes(int[] list)
        {
            if (list.Length == 0)
                return;

            int aux = 0;

            for (int i = 0; i < list.Length; i++)
            {

                if (list[i] != 0)
                {
                    list[aux] = list[i];
                    aux++;
                }

            }
            if (aux == 0)
                return;


            for (int i = list.Length - 1; i >= aux; i--)
            {
                list[i] = 0;

            }
            return;
        }

        public void moveZeroesBackwards(int[] list)
        {
            if (list.Length == 0)
                return;

            int aux = list.Length - 1;

            for (int i = list.Length - 1; i >= 0; i--)
            {

                if (list[i] != 0)
                {
                    list[aux] = list[i];
                    aux--;
                }

            }
            if (aux + 1 == 0)
                return;


            for (int i = 0; i < aux + 1; i++)
            {
                list[i] = 0;

            }
            return;
        }



        public int[] insertInRange(int[] l1, int[] l2, int at)
        {


            if (l1.Length == 0 || l2.Length == 0 || at > l1.Length)
                return l1;
            int newLength = l1.Length + l2.Length;

            int[] newList = new int[newLength];
            int aux = 0;
            for (int i = 0; i < l1.Length; i++)
            {

                if (i == at)
                {

                    for (int j = 0; j < l2.Length; j++)
                    {

                        newList[aux] = l2[j];
                        aux++;
                    }

                }

                newList[aux] = l1[i];
                aux++;
            }

            return newList;

        }


        public string reverseMain(string word)
        {
            if (word.Length == 0)
                return word;

            word = this.reverse(word, 0, word.Length);
            int startingPoint = 0;
            for (int i = 0; i < word.Length + 1; i++)
            {

                if (i == word.Length || word[i] == ' ')
                {

                    word = this.reverse(word, startingPoint, i);
                    startingPoint = i + 1;
                }
            }
            return word;

        }

        public string reverse(string word, int from, int to)
        {

            if (word.Length == 0)
                return word;

            char[] tmp = word.ToCharArray();
            for (int i = 0; i < (to - from)/2; i++)
            {
                char aux = tmp[i+from];
                tmp[i+from] = tmp[to - i - 1];
                tmp[to - i - 1] = aux;

            }
            return new string(tmp);

        }


        public string reverseMainCShap(string word)
        {
            if (word.Length == 0)
                return word;

            string[] aux = word.Split(' ');
            string newWord = "";
            for (int i = aux.Length - 1; i >= 0; i--)
            {
                newWord += aux[i] + " ";
            }

            return newWord.Remove(newWord.Length - 1);
        }


        public bool isPalindrome(string word)
        {

            if (word.Length == 0)
                return false;

            char[] tmp = word.ToCharArray();
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (Char.ToLower(tmp[i]) != Char.ToLower(tmp[word.Length - 1 - i]))
                    return false;

            }
            return true;

        }

        //a+b+c = 0

        public int[][] Sum3CSharp(int[] numbers)
        {
            if (numbers.Length == 0)
                return null;

            List<int[]> sumList = new List<int[]>();
            for (int i = 0; i < numbers.Length - 2; i ++)
            {
                for (int j = i + 1; j < numbers.Length - 1;  j++)
                {
                    for (int x = j + 1; x < numbers.Length; x++)
                    {
                        if( numbers[i] +numbers[j] +numbers[x] ==0 )
                        {
                            if(!sumList.Exists(item=> (item[0] ==  numbers[i] &&  item[1] == numbers[j] && item[2] == numbers[x])))
                                sumList.Add(new int[] { numbers[i], numbers[j], numbers[x] });
                          
                        }

                    }
                }

                
            }
            return sumList.ToArray();

    }

        public IList<IList<int>> Sum3(int[] nums){

                if (nums.Length == 0)
                    return null;
            List<List<int>> results = new List<List<int>>();
                Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int ptrL = nums[i + 1];
                int ptrR = nums[nums.Length - 1];
                while (ptrL < ptrR)
                {

                    if (nums[i] + nums[ptrL] + nums[ptrR] == 0)
                    {

                        results.Add( new List<int>(){ nums[i] , nums[ptrL] , nums[ptrR] });
                        ptrR--;
                        ptrL++;
                        while (ptrL < ptrR && nums[ptrL] == nums[ptrL - 1])
                        {
                            ptrL++;
                        }
                        while (ptrL < ptrR && nums[ptrR] == nums[ptrR + 1])
                        {
                            ptrR--;
                        }
                    }
                    else
                    if (nums[i] + nums[ptrL] + nums[ptrR] < 0)
                    {
                        ptrL++;

                    }
                    else
                    {

                        ptrR--;
                    }

                }
            }

                return results.ToArray();
            }





    class MainClass
    {

        public static void TestCase1_1()
        {
            Solution sol = new Solution();

            int[] testList = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            sol.removeIn(testList, 4);
            Console.WriteLine(string.Concat(testList, ","));

        }
        public static void TestCase2_1()
        {
            Solution sol = new Solution();

            int[] testList = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            testList = sol.removeInImplementationTwo(testList, 4);
            Console.WriteLine(string.Concat(testList, ","));

        }

        public static void TestCase2_2()
        {
            Solution sol = new Solution();

            int[] testList = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            testList = sol.removeInImplementationTwo(testList, 10);
            Console.WriteLine(string.Concat(testList, ","));

        }

        public static void TestCase3_1()
        {
            Solution sol = new Solution();

            int[] testList = new int[] { 1, 2, 0, 4, 0, 5, 7 };
            sol.moveZeroes(testList);
            Console.WriteLine(string.Concat(testList, ","));

        }

        public static void TestCase4_1()
        {
            Solution sol = new Solution();

            int[] testList = new int[] { 1, 2, 0, 4, 5, 7, 0 };
            sol.moveZeroesBackwards(testList);
            Console.WriteLine(string.Concat(testList, ","));

        }

        public static void TestCase5_1()
        {
            Solution sol = new Solution();

            int[] testList = new int[] { 1, 6 };

            int[] newList = new int[] { 2, 3, 4, 5 };
            testList = sol.insertInRange(testList, newList, 1);
            Console.WriteLine(string.Concat(testList, ","));

        }


        public static void TestCase6_1()
        {
            Solution sol = new Solution();



            string word = "adh";
            var res = sol.isPalindrome(word);
            Console.WriteLine(res);

        }


        public static void TestCase7_1()
        {
            Solution sol = new Solution();



            string word = "the sky isn blue";
            word = sol.reverseMain(word);
            Console.WriteLine(word);

        }



        public static void Main(string[] args)
        {
            TestCase7_1();


        }
    }
}
