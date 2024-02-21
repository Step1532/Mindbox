using Mindbox.Lib.Shapes;

namespace Mindbox.Lib.Tests;

public class CircleTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void IsCircleExists_NegativeRadius_CatchArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var circle = new Circle(-1);
        });
    }

    [Test]
    public void CalcArea_InputIs3_Return28_274333()
    {
        Assert.That(new Circle(3).Area, Is.EqualTo(28.274333).Within(1e-6));
    }
}