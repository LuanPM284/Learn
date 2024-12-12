# Notes for the CodeWars challenges

This is a notes files to store my ideas and solutions from [CodeWars](https://www.codewars.com/). The language used will be C#, since it's the one I want to get the most familiar with.

Guide:

- Start with a good function name
- prep method:
  - p - for parameters
  - r - returns
  - e - example
  - p - pseudocode

## The challenges

**Intructions:**
Complete the solution so that it reverses the string passed into it.

'world'  =>  'dlrow'
'word'   =>  'drow'

**My Solution Attempt:**

```cs
using System;

public static class Kata
{
  public static string Solution(string str) 
  {
    /*
    * p - a string
    * r - a True or False, True if the string returnes is the reverse
    * e - Assert.That(Kata.Solution("world"), Is.EqualTo("dlrow"));
    * p - strin1 and string 2, string2.Reverse(), check string1 = string2.Reversed()
    *
    *
    */
    // throw new NotImplementedException("TODO: Kata.Solution(string) => string");

    // First attempt
    //   bool Kata(string str){
    //   string str1;
    //   str1 = str.Reverse();
    //   return Equality(str1, str);

    // Seconf attempt
    // bool Kata(string str){
    // string str;
    // string str1;
    // char[] charArray = str.ToCharArray();
    // Array.Reverse(charArray)
    // str1 = new string(charArray)
    // return Equality(str1,str)
    // }


  }
}
```

**Solutions:**

```cs
// simplest
using System;
using System.Linq;

public static class Kata
{
  public static string Solution(string str) 
  {
     return new string(str.ToArray().Reverse().ToArray());
  }
}

// good
using System;
using System.Linq;

public static class Kata
{
  public static string Solution(string str) 
  {
    char[] newstr = str.ToCharArray();
    Array.Reverse(newstr);
    return new String(newstr);
  }
}

// no System.Linq - Language-Integrated Query (LINQ).
using System;
public static class Kata
{
  /* Шешімді оған берілген жол мәнін беретіндей етіп аяқтаңыз.
  
    Kata.Solution("world") //returns "dlrow"
    
    
  */
  public static string Solution(string str) 
  {  
       string rev = "";
        for(int c = str.Length ; c > 0; c--){
         
          rev += str[c-1];
     }
     return rev;
  }
}
```

---

**Intructions:**
Description
We need a function that can transform a string into a number. What ways of achieving this do you know?

Note: Don't worry, all inputs will be strings, and every string is a perfectly valid representation of an integral number.

Examples
"1234" --> 1234
"605"  --> 605
"1405" --> 1405
"-7" --> -7

**My Solution Attempt:**

```cs
/*
* p - a string
* r - an int
* e - Assert.That(Kata.StringToNumber("1234"), Is.EqualTo(1234));
* p - str.toString, save int to new var
*
*/
using System;
  public class Kata
  {
    public static int StringToNumber(String str) {
        //TODO: Convert str into a number
        int number;
        return number = int.Parse(str);
  }
}
```

**Solutions:**

```cs
// simplest
using System;
  public class Kata
  {
    public static int StringToNumber(String str) {
         return (int.Parse(str));
  }
}
// other
using System;
public class Kata {
  public static int StringToNumber(String str) => int.Parse(str);
}
// another
using System;
  public class Kata
  {
    public static int StringToNumber(String str) {
        //TODO: Convert str into a number
        return Convert.ToInt32(str);
  }
}
// another
using System;

public class Kata
{
    public static int StringToNumber(String str)
    {
        int n;
        if (!int.TryParse(str, out n))
            throw new ArgumentException("str");
            
        return n;
    }
}
```

---

**Intructions:**
Convert number to reversed array of digits
Given a random non-negative number, you have to return the digits of this number within an array in reverse order.

Example(Input => Output):
35231 => [1,3,2,5,3]
0 => [0]
**My Solution Attempt:**

```cs
/*
* p - an int
* r - an array of the reverse order
* e - Assert.That(Digitizer.Digitize(35231), Is.EqualTo(new long[] { 1, 3, 2, 5, 3 }));
      Assert.That(Digitizer.Digitize(0), Is.EqualTo(new long[] { 0 }));
* p - new Array = int; for(i = Array.Length); insert into return array
*
*/

using System;
using System.Collections.Generic;

namespace Solution
{
  class Digitizer
  {
    public static long[] Digitize(long n)
    {
      // Code goes here
      int nSize = (int)Math.Floor(Math.Log10(n) + 1);
      long[] array = new long[nSize];
      for(int i = 0; i > nSize; i++){
        array[i] = n % 10; // Get the last digit
        n /= 10; // Remove the last digit
      }
    Array.Reverse(array);
    
    return array;
    }
  }
}
```

**Solutions:**

```cs
// fastest
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution
{
  class Digitizer
  {
    public static long[] Digitize(long n)
    {
      return n.ToString()
              .Reverse()
              .Select(t => Convert.ToInt64(t.ToString()))
              .ToArray();
    }
  }
}
// other
using System.Linq;

class Digitizer
{
  public static long[] Digitize(long n)
  {
    return $"{n}".Select(c => (long) c - '0').Reverse().ToArray();
  }
}
// another
using System.Collections.Generic;

namespace Solution
{
    public class Digitizer
    {
        public static long[] Digitize(long number)
        {
            List<long> digits = new List<long>();
            do
            {
                const byte RADIX = 10;
                long digit = number % RADIX;
                digits.Add(digit);
                number /= RADIX;
            }
            while (number > 0);
            return digits.ToArray();
        }
    }
}
```

---

**Intructions:**

**My Solution Attempt:**

```cs
/*
* p -
* r -
* e - 
* p - 
*
*/
```

**Solutions:**

```cs

```
