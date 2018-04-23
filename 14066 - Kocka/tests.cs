using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass()]
public class ProgramTests
{
    [TestMethod()]
    public void EvalTest11()
    {
        {
            var arr = new int[,] { { 1 } };
            var res = Program.Eval(arr);
            var expected = @"..+---+
./   /|
+---+ |
|   | +
|   |/.
+---+..".Replace("\r", "");
            Assert.AreEqual(expected, res);
        }
        {
            var arr = new int[,] { { 2 } };
            var res = Program.Eval(arr);
            var expected = @"..+---+
./   /|
+---+ |
|   | +
|   |/|
+---+ |
|   | +
|   |/.
+---+..".Replace("\r", "");
            Assert.AreEqual(expected, res);
        }
    }

    [TestMethod()]
    public void EvalTest12()
    {
        var arr = new int[,] { { 1, 2 } };
        var res = Program.Eval(arr);
        var expected = @"......+---+
...../   /|
....+---+ |
..+-|   | +
./  |   |/|
+---+---+ |
|   |   | +
|   |   |/.
+---+---+..".Replace("\r", "");
        Assert.AreEqual(expected, res);
    }

    [TestMethod]
    public void EvalTest31()
    {
        var arr = new int[,] { { 2 }, { 1 }, { 3 } };
        var res = Program.Eval(arr);
        var expected = @"......+---+
..+---+  /|
./   /|-+ |
+---+ | | +
|   | + |/|
|   |/|-+ |
+---+ |/| +
|   | + |/.
|   |/| +..
+---+ |/...
|   | +....
|   |/.....
+---+......".Replace("\r", "");
        Assert.AreEqual(expected, res);
    }

    [TestMethod]
    public void EvalTest23()
    {
        var arr = new int[,] { { 2, 3, 2 }, { 1, 2, 1 } };
        var res = Program.Eval(arr);
        var expected = @"........+---+....
......./   /|....
......+---+ |....
....+-|   | +---+
.../  |   |/   /|
..+---+---+---+ |
..|  /   /|   | +
..| +---+ |   |/|
..+-|   | +---+ |
./  |   |/   /| +
+---+---+---+ |/.
|   |   |   | +..
|   |   |   |/...
+---+---+---+....".Replace("\r", "");
        Assert.AreEqual(expected, res);
    }
}