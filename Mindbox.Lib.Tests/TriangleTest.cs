using Mindbox.Lib.Shapes;

namespace Mindbox.Lib.Tests;

public class TriangleTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void IsTriangleExists_InputIsNull_CatchArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var triangle = new Triangle(null);
        });
    }

    [Test]
    public void IsTriangleExists_InputIs4Sides_CatchArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var triangle = new Triangle(new double[] { 1, 2, 3, 4 });
        });
    }

    [Test]
    public void IsTriangleExists_InputIs123_CatchArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var triangle = new Triangle(1, 2, 3);
        });
    }

    [Test]
    public void IsRightTriangle_InputIs223_ReturnFalse()
    {
        Assert.IsFalse(new Triangle(2, 2, 3).IsRightTriangle);
    }

    [Test]
    public void IsRightTriangle_InputIs345_ReturnTrue()
    {
        Assert.IsTrue(new Triangle(3, 4, 5).IsRightTriangle);
    }

    [Test]
    public void CalcArea_InputIs345_Return6()
    {
        Assert.That(new Triangle(3, 4, 5).Area, Is.EqualTo(6).Within(double.Epsilon));
    }
}