using System;
// basic fizzbuz problem http://www.talentbuddy.co/challenge/51846c184af0110af3822c30
class MyClass {

    public void fizzbuzz(int n) 
    {
        for (int i=1;i<=n;i++)    
        {
            string txt="";
            if (i%3==0)
                txt="Fizz";
            if (i%5==0)
                txt+="Buzz";
            Console.WriteLine(String.IsNullOrEmpty(txt)?i.ToString():txt);
        }
    }
}