using System;
using System.Collections.Generic;

namespace Algo
{
    class Program
    {
        /// <summary>
        /// inN power of inM
        /// </summary>
        /// <param name="inN"> the argument, the power</param>
        /// <param name="inM"> the base </param>
        /// <returns></returns>
        public static double Pow(double inN, int inM)
        {
            double exponent = 1.0;
            for (int i = 0; i < inM; i++)
            {
                exponent *= inN;
            }
            return exponent;
        }
        public static double Abs(double inDouble)
        {
            if (inDouble > 0) return inDouble;
            else return -inDouble;
        }
        /// <summary>
        /// Get the inN root of inNumber by Newton-raphson method.
        /// </summary>
        /// <param name="inNumber"></param>
        /// <param name="inN"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static double GetNthRootNewtonRaphson(double inNumber, int inN, out int count)
        {
            double approxSolution = inNumber / inN;
            double initialGuess = inNumber;
            count = 0;
            while (Abs(inNumber - Pow(approxSolution, inN)) > 1e-10)
            {
                count += 1;
                initialGuess = approxSolution;
                approxSolution = initialGuess - (Pow(initialGuess, inN) - inNumber) / (inN * Pow(initialGuess, inN - 1));
            }
            return approxSolution;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="inNumber"></param>
        /// <param name="inN"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static double GetNthRoot(double inNumber, int inN, out int count)
        {
            double infimum = 1;
            double supremum = inNumber;
            double tolerance = 1e-10;
            count = 1;
            while ((supremum - infimum) > tolerance)
            {
                count += 1;
                double approxSolution = (supremum + infimum) * 0.5;
                if (Pow(approxSolution, inN) < inNumber) { infimum = approxSolution; }
                else { supremum = approxSolution; }
            }
            return (infimum + supremum) * 0.5;
        }

       
        static void Main(string[] args)
        {
            #region Find NRoot
            int count1 = -1, count2 = -1;
            Console.WriteLine($"The result of third root of 8 is {GetNthRoot(8, 3, out count1)} after {count1} number of iterations)");
            Console.WriteLine($"The result of third root of 8 is {GetNthRootNewtonRaphson(8, 3, out count2)} after {count2} number of iterations)");
            #endregion

            #region Find 3 strings with same HashCode
            var dict1 = new Dictionary<int, string>();
            var dict2 = new Dictionary<int, string>();
            var dict3 = new Dictionary<int, string>();
            int i = 0;
            string teststring;
            while (true)
            {
                i++;
                teststring = i.ToString();
                var collisionHash = teststring.GetHashCode();
                if (dict1.ContainsKey(collisionHash) && dict2.ContainsKey(collisionHash))
                {
                    dict3[collisionHash] = teststring;
                    Console.WriteLine("HashCode found " + collisionHash.ToString());
                    Console.WriteLine("String 1 " + dict1[collisionHash].ToString());
                    Console.WriteLine("String 2 " + dict2[collisionHash].ToString());
                    Console.WriteLine("String 3 " + dict3[collisionHash].ToString());
                    break;
                }
                else
                {
                    if (dict1.ContainsKey(collisionHash))
                    {
                        dict2[collisionHash] = teststring;
                    }
                    else
                    {
                        dict1.Add(collisionHash, teststring);
                    }
                }
            }
            #endregion
        }
    }
}
