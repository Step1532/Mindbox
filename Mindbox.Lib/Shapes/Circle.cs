namespace Mindbox.Lib.Shapes;

/// <inheritdoc cref="Shape"/>
/// <summary>
/// Class that represents a circle - geometric figure with area
/// </summary>
public class Circle : Shape
{
    #region Properties

    /// <summary>
    /// Radius of the circle
    /// </summary>
    public double Radius { get; init; }

    #endregion

    #region Constructors

    /// <summary>
    /// Constructor that creates a circle
    /// </summary>
    /// <param name="radius">Radius of the circle</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if radius is less than 0</exception>
    public Circle(double radius)
    {
        if (radius < 0)
            throw new ArgumentOutOfRangeException($"{nameof(radius)} can't be less than 0");

        Radius = radius;
    }

    #endregion

    #region Overridden methods

    protected override double CalcArea()
    {
        return Math.PI * Radius * Radius;
    }

    #endregion
}