using TimeStructures;

namespace TestProject1;

[TestClass]
public class TimeTests
{
    [DataTestMethod]
    [DataRow("ABC")]
    [DataRow("12:11:33:1")]
    [DataRow("")]
    [DataRow("12:b:33:1")]
    [DataRow("12:00:")]
    [ExpectedException(typeof(Exception))]
    public void Test_String_Ctor_Exeption(string test)
    {
        Time t = new Time(test);
    }
    
    [DataTestMethod]
    [DataRow("12:11:33")]
    [DataRow("12:11")]
    [DataRow("12")]
    public void Test_String_Ctor_Pass_String(string test)
    {
        Time t = new Time(test);
        Console.WriteLine(t.ToString());
    }
    
    [DataTestMethod]
    [DataRow(1,2,null)]
    [DataRow(1,null,null)]
    [DataRow(null,null,null)]
    [DataRow(48,null,null)]
    [DataRow(50,null,null)]
    public void Test_Ctor_Pass_int(int a, int b, int c)
    {
        Time t = new Time(a,b,c);
        Console.WriteLine(t.ToString());
    }
    
    [DataTestMethod]
    [DataRow("12:11:33","12:11:33")]
    [DataRow("12:11","12:11:00")]
    [DataRow("12","12:00:00")]
    [DataRow("0:11","00:11:00")]
    public void Test_Operator_To_String(string input, string output)
    {
        Time t = new Time(input);
        Assert.AreEqual(output,t.ToString());
        Console.WriteLine(t.ToString());
    }
    
    [DataTestMethod]
    [DataRow("12:11:33","12:11:33", "00:00:00")]
    [DataRow("28:11:33","4:11:33", "00:00:00")]
    [DataRow("28:11:33","4:0:33", "00:11:00")]
    [DataRow("28:11:33","4:00:00", "00:11:33")]
    public void Test_Operator_Minus(string input, string input2, string output)
    {
        Time t1 = new Time(input);
        Time t2 = new Time(input2);
        Assert.AreEqual(output,(t1-t2).ToString());
        Console.WriteLine($"{input}-{input2}: {output}");
    }
    [DataTestMethod]
    [DataRow("12:11:33","12:11:33", "00:22:06")]
    [DataRow("28:11:33","4:11:33", "08:22:06")]
    [DataRow("28:11:33","4:0:33", "08:11:06")]
    [DataRow("28:11:33","4:00:00", "08:11:33")]
    public void Test_Operator_Plus(string input, string input2, string output)
    {
        Time t1 = new Time(input);
        Time t2 = new Time(input2);
        Assert.AreEqual(output,(t1+t2).ToString());
        Console.WriteLine($"{input}-{input2}: {output}");
    }
    [DataTestMethod]
    [DataRow("12:11:33","12:11:33", true)]
    [DataRow("28:11:33","4:11:33", true)]
    [DataRow("28:11:33","4:0:33", false)]
    [DataRow("28:11:33","4:00:00", false)]
    public void Test_Operator_equal(string input, string input2, bool output)
    {
        Time t1 = new Time(input);
        Time t2 = new Time(input2);
        Assert.AreEqual(output,t1.Equals(t2));
        Assert.AreEqual(output,t1==t2);
        Assert.AreEqual(output,!(t1!=t2));
        Console.WriteLine($"{input}-{input2}: {output}");
    }
    [DataTestMethod]
    [DataRow("12:11:33","12:11:33", 0)]
    [DataRow("28:11:33","4:11:33", 0)]
    [DataRow("28:11:33","4:0:33", 1)]
    [DataRow("28:11:33","6:0:33", -1)]
    [DataRow("28:11:33","4:00:58", 1)]
    [DataRow("28:11:33","4:33:58", -1)]
    public void Test_Operator_Compare(string input, string input2, int output)
    {
        Time t1 = new Time(input);
        Time t2 = new Time(input2);
        Assert.AreEqual(output,t1.CompareTo(t2));
        Console.WriteLine($"{input}-{input2}: {output}");
    }
}