using System;
using NUnit.Framework;

namespace DevPuzzle
{
    /*
     * 5:00 five o'clock
     * 5:01 one minute past five
     * 5:10 ten minutes past five
     * 5:15 quarter past five
     * 5:28 twenty eight minutes past five
     * 5:30 half past five
     * 5:40 twenty minutes to six
     * 5:47 quarter to six
     *
     * Write a program which prints the time in words for the input given in the format mentioned above.
     */
    public class Puzzle2
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual("thirteen minutes to six", Solve(5, 47));

            //Assert.AreEqual("three minutes to eleven", Solve(5, 10));
            Assert.AreEqual("three minutes to eleven", Solve(10, 57));

            //Assert.AreEqual("quarter to six", Solve(5, 47));
            Assert.AreEqual("quarter to six", Solve(5, 45));
           
            Assert.AreEqual("twenty eight minutes past five", Solve(5, 28));
            Assert.AreEqual("one minute past five", Solve(5, 1));
        }

        static string Solve(int h, int m)
        {
            if (h < 0 || h > 12 || m < 0 || m > 59) return "Invalid input-data !!!";

            String[] numbers = new[] { "twelve", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty"};
            String[] quartes = new[] { "quarter", "half" };

            string result = "";
            switch(m)
            {
                case 0:
                    result = $"{numbers[h % 12].ToString()} o'clock";
                    break;
                case 1:
                    result = $"{numbers[m].ToString()} minute past {numbers[h % 12].ToString()}";
                    break;
                case 15:
                    result = $"{quartes[0].ToString()} past {numbers[h % 12].ToString()}";
                    break;
                case 30:
                    result = $"{quartes[1].ToString()} past {numbers[h % 12].ToString()}";
                    break;
                case 45:
                    result = $"{quartes[0].ToString()} to {numbers[(h + 1) % 12].ToString()}";
                    break;
                case 59:
                    result = $"{numbers[60 - m].ToString()} minute to {numbers[(h + 1) % 12].ToString()}";
                    break;
                default:
                    if(m<30)
                    {
                        if(m > 20)
                        {
                            result = $"{numbers[20].ToString()} {numbers[m - 20].ToString()} minutes past {numbers[h % 12].ToString()}";
                        } 
                        else
                        { 
                            result = $"{numbers[m].ToString()} minutes past {numbers[h % 12].ToString()}";
                        }
                    
                    } else
                    {
                        if (60 - m > 20)
                        {
                            result = $"{numbers[20].ToString()} {numbers[60 - m - 20].ToString()} minutes to {numbers[(h+1) % 12].ToString()}";
                        }
                        else
                        {
                            result = $"{numbers[60 - m].ToString()} minutes to {numbers[(h+1) % 12].ToString()}";
                        }
                    }

                    break;
            }
            return result;
        }
    }
}