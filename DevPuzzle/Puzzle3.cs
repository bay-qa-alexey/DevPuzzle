using System;
using System.Diagnostics;
using NUnit.Framework;

using System.Numerics;
using System.Text;

namespace DevPuzzle
{
    /*
     * Calculate and print the factorial of a given integer.
     * Note: Factorials of n>20 can't be stored even in a 64bit long variable. Big integers must be used for such calculations.
     */
    public class Puzzle3
    {
        [Test]
        public void Sample0()
        {
            var res = Solve(25);
            Assert.AreEqual("15511210043330985984000000", res);
        }

        [Test]
        public void Sample1()
        {
            var res = Solve(10);
            Assert.AreEqual("3628800", res);
        }

        [Test]
        public void Sample2()
        {
            var w = Stopwatch.StartNew();
            var res = Solve(300);
            Assert.AreEqual("306057512216440636035370461297268629388588804173576999416776741259476533176716867465515291422477573349939147888701726368864263907759003154226842927906974559841225476930271954604008012215776252176854255965356903506788725264321896264299365204576448830388909753943489625436053225980776521270822437639449120128678675368305712293681943649956460498166450227716500185176546469340112226034729724066333258583506870150169794168850353752137554910289126407157154830282284937952636580145235233156936482233436799254594095276820608062232812387383880817049600000000000000000000000000000000000000000000000000000000000000000000000000", res);
            var ms = w.Elapsed.TotalMilliseconds;
            Console.WriteLine($"Elapsed: {ms:N2}");
            Assert.Less(ms, 30);
        }

        public string Solve(int n)
        {
            if (n < 0) return "Invalid input-data !!!";
            if (n == 0 || n == 1) return "1";

            //SOLUTION 1: (using System.Numerics;) FAST by using BigInteger
            return factorial1(n).ToString();

            //SOLUTION 2: (using System.Numerics;) SLOW Two sets multiplication (Biginteger)
            //return factorial2(1, n).ToString();

            //SOLUTION 3: (using System.Text;) SLOW by using Node->next List, no BigInteger needed!
            //return factorial3(n);         
        }

        BigInteger factorial1(int n)
        {
            BigInteger result = 1;
            for (int i = 1; i <= n; i++)
            {
                result = result * i;
            }
            return result;
        }

        BigInteger factorial2(long start, long n)
        {
            long i;
            if (n <= 16)
            {
                BigInteger r = new BigInteger(start);
                for (i = start + 1; i < start + n; i++) r *= i;
                return r;
            }
            i = n / 2;
            return factorial2(start, i) * factorial2(start + i, n - i);
        }


        public class Node
        {
            public int data { get; set; }
            public Node next { get; set; }
        }
         
        Node insert(Node head, int val)
        {
            Node temp = new Node();
            Node temp1 = head;
            temp.data = val;
            temp.next = null;
            if (head == null)
            {
                head = temp;
                return head;
            }
            temp1 = head;
            while (temp1.next != null)
            {
                temp1 = temp1.next;
            }
            temp1.next = temp;
            return head;
        }

        Node reverse(Node head)
        {
            Node prev, curr, Next;
            prev = null;
            curr = head;

            while (curr != null)
            {
                Next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = Next;
            }
            head = prev;
            return head;

        }

        string print(Node head)
        {
            StringBuilder myString = new StringBuilder();
            while (head != null)
            {
                myString.Append(head.data);
                head = head.next;
            }
            return myString.ToString();
        }

        string factorial3(int n)
        {
            int i, k = 0, index = 1, mult, carry = 0;
            Node a = null, head = null;

            a = insert(a, 1);
            head = a;
            for (i = 2; i <= n; i++)
            {
                k = 0;
                a = head;
                while (k < index)
                {
                    mult = (a.data) * i + carry;
                    a.data = mult % 10;
                    carry = mult / 10;
                    if (carry > 0 && a.next == null)
                    {
                        index++;
                        a = insert(a, 0);
                    }
                    k++;
                    a = a.next;
                }
            }
            return print(reverse(head));

        }


        
    }
}