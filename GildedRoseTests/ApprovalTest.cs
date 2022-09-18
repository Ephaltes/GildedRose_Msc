using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using GildedRose;
using VerifyXunit;
using Xunit;

namespace GildedRoseTests;

[UsesVerify]
public class ApprovalTest
{
    [Fact]
    public Task ThirtyDays()
    {
        StringBuilder fakeoutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeoutput));
        Console.SetIn(new StringReader("a\n"));

        Program.Main(new string[] { });
        string output = fakeoutput.ToString();

        return Verifier.Verify(output);
    }
}