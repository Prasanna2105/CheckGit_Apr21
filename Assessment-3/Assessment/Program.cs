using System;
using System.Collections.Generic;

namespace Assessment
{
    class Program
    {
        static void FirstQuestion()
        {
            int[] arr = new int[10];
            Console.WriteLine("Enter the numbers");
            for (int i = 0; i < 10; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("The numbers divisible by 7 are ");
            for (int i = 0; i < 10; i++)
            {
                if (arr[i] % 7 == 0)
                    Console.WriteLine(arr[i]);
            }
        }
        static void SecondQuestion()
        {
            int min, max, i;
            Console.WriteLine("Enter the minimum value");
            min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the maximum value");
            max = Convert.ToInt32(Console.ReadLine());
            if (min < max)
            {
                Console.WriteLine("The prime numbers between {0} and {1} are", min, max);
                for (i = min + 1; i < max; i++)
                {
                    int j, flag = 1;
                    for (j = 2; j <= i / 2; j++)
                    {
                        if (i % j == 0)
                        {
                            flag = 0;
                            break;
                        }
                    }
                    if (flag == 1)
                        Console.WriteLine(i);
                }
            }
            else
                Console.WriteLine("Invalid entry");

        }
        static void ThirdQuestion()
        {
            List<int> numbers = new List<int>();
            int element = 0;
            do
            {
                Console.WriteLine("Enter the number. Enter a negative number to quit");
                element = Convert.ToInt32(Console.ReadLine());
                numbers.Add(element);
            } while (element >= 0);
            Console.WriteLine("The repeating numbers are:");
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        Console.WriteLine(numbers[j]);
                    }
                }
            }
        }

        static void FourthQuestion()
        {
            List<int> numbers = new List<int>();
            int element = 0;
            do
            {
                Console.WriteLine("Enter a positive number. Enter a zero to quit");
                element = Convert.ToInt32(Console.ReadLine());
                numbers.Add(element);
            } while (element >= 0);
            numbers.Sort();
            Console.WriteLine("The numbers after sorting");
            foreach (var item in numbers)
            {
                if (item != 0)
                    Console.WriteLine(item);
            }
        }

        static void FifthQuestion()
        {

            string username, password;
            int count = 0;
            while (true)
            {
                count++;
                Console.WriteLine("Enter the username");
                username = Console.ReadLine();
                Console.WriteLine("Enter the password");
                password = Console.ReadLine();
                if (username == "Admin" && password == "admin")
                {
                    Console.WriteLine("Welcome....");
                    break;
                }
                else if (count == 3)
                {
                    Console.WriteLine("Sorry you have already tried 3 times");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                    Console.WriteLine("Try again!!!");
                }

            }
        }
        static void SeventhQuestion()
        {
            int[] CardNum = new int[16];
            int c, d, n;
            Console.WriteLine("please enter the card number");
            for (int i = 0; i < CardNum.Length; i++)
            {
                CardNum[i] = Convert.ToInt32(Console.ReadLine());
            }


            int[] REVCardNum = new int[16];
            for (c = REVCardNum.Length - 1, d = 0; c >= 0; c--, d++)
            {
                REVCardNum[d] = CardNum[c];
            }
            Console.WriteLine("the reversed card number is :");
            for (int i = 0; i < REVCardNum.Length; i++)
            {
                Console.WriteLine(REVCardNum[i]);
            }
            Console.WriteLine("changing the even position");
            for (int i = 0; i < REVCardNum.Length; i++)
            {
                if (i % 2 == 0)
                {
                    REVCardNum[i + 1] = REVCardNum[i + 1] * 2;
                }
                Console.WriteLine(REVCardNum[i]);
            }
            Console.WriteLine("changing the even position sum into a single digit");
            for (int i = 0; i < REVCardNum.Length; i++)
            {
                int sum = 0;
                if (i % 2 == 0)
                {
                    if (REVCardNum[i + 1] > 10)
                    {
                        while (REVCardNum[i + 1] > 0)
                        {
                            n = REVCardNum[i + 1] % 10;
                            sum = sum + n;
                            REVCardNum[i + 1] = (REVCardNum[i + 1] / 10);
                        }
                        REVCardNum[i + 1] = sum;
                    }
                }
                Console.WriteLine(REVCardNum[i]);
            }
            Console.WriteLine(" calculating the total sum of the card number.....");
            int sum1 = 0;
            for (int i = 0; i < REVCardNum.Length; i++)
            {
                sum1 = REVCardNum[i] + sum1;
            }
            Console.WriteLine("the total sum is " + sum1);
            if (sum1 % 10 == 0)
                Console.WriteLine("the given card number is valid");
            else
                Console.WriteLine("the card number is not valid");
        }
        static void SixthQuestion()
        {
            string[] arr = { "kite", "four", "neat", "play", "goal" };

            Console.WriteLine("Play.......");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter the guess");
                string GuessWord = Console.ReadLine();
                string guess = arr[i];
                int cow = 0, bulls = 0;
                if (guess.Length == GuessWord.Length)
                {

                    for (i = 0; i < guess.Length; i++)
                    {
                        if (guess[i] == GuessWord[i])
                        {
                            cow += 1;
                        }
                        else
                        {
                            for (int j = 0; j < guess.Length; j++)
                            {
                                if (guess[i] == GuessWord[j] && i != j)
                                {
                                    bulls += 1;
                                }
                            }
                        }

                    }
                    Console.WriteLine("Cows--" + cow + " Bulls--" + bulls);
                    if (cow == guess.Length)
                    {
                        Console.WriteLine("Congratulations You Won the Game");
                    }
                }
                else
                {
                    Console.WriteLine("Must enter " + guess.Length + " letter a Word");
                }
            }
        }

       
        static void PrintMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("1. Print Numbers Divisible by 7");
                Console.WriteLine("2. Prime Numbers between the range");
                Console.WriteLine("3. Print Repeating Numbers");
                Console.WriteLine("4. Print numbers in sorted order");
                Console.WriteLine("5. Check username and password");
                Console.WriteLine("6. Cow bull game");
                Console.WriteLine("7. Card Validation");
                Console.WriteLine("8. Exit");
                Console.WriteLine("------------------------------");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        FirstQuestion();
                        break;
                    case 2:
                        SecondQuestion();
                        break;
                    case 3:
                        ThirdQuestion();
                        break;
                    case 4:
                        FourthQuestion();
                        break;
                    case 5:
                        FifthQuestion();
                        break;
                    case 6:
                        SixthQuestion();
                        break;
                    case 7:
                        SeventhQuestion();
                        break;
                    case 8:
                        Console.WriteLine("Exiting........");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }
            } while (choice != 8);
        }
        static void Main(string[] args)
        {
            //FirstQuestion();
            //SecondQuestion();
            //FifthQuestion();
            //FourthQuestion();
            //ThirdQuestion();
            //SeventhQuestion();
            //SixthQuestion();
            PrintMenu();
        }
    }
    
}
