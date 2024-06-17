using System;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Prime{
    class Prime{
        static void Main(string[] args){
            Greetings();
            string userInput = Console.ReadLine();
            getFactors(userInput);
        }

        static void Greetings(){
            Console.WriteLine("Hello! This program will give out the prime factors of an integer (if there are any) you inputted.");
        }

        static List<int> getFactors(string userInput){
            List<int> primeFactors = new List<int>();

            if (Int32.TryParse(userInput, out int number)){
                if (number <= 1){
                    Console.WriteLine("ERROR: The number provided is 1");
                }
                else if (number == 2){
                    primeFactors.Add(1);
                    primeFactors.Add(1);
                }
            }
            else {
                Console.WriteLine("ERROR: Not an integer.");
                return new List<int>{0, 0};
            }

            if (isPrime(number)){
                primeFactors.Add(1);
                primeFactors.Add(number);
            }

            printFactors(Factor(number));

            return primeFactors;
        }

        static bool isPrime(int input){
            var limit = (int)Math.Floor(Math.Sqrt(input));
            
            if (input % 2 == 0){
                return false;
            }

            for (int i = 3; i <= limit; i += 2){
                if (input % i == 0){
                    return false;
                }
            }
            return true;
        }

        static List<int> Factor(int number){
            List<int> factors = new List<int>();
            int prime = 2;
            int index = 0;

            while (number != 1){
                if (number % prime == 0){
                    number = number / prime;
                    factors.Insert(index, prime);
                    index++;
                }
                else {
                    prime = getNextPrime(prime, number);
                }

               
            }
            return factors;
        }

        static int getNextPrime(int prime, int number){
            if(isPrime(number)){
                prime = number;
            }
            else {
                prime++;

                while(!isPrime(prime) && prime < number){
                    prime++;
                }
            }
            return prime;
        }

        static void printFactors(List<int> factors){
            foreach(int factor in factors){
                Console.Write($"{factor},");
            }
        }
    }
}