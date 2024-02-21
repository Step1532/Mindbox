namespace Mindbox.Lib.Shapes;

/// <inheritdoc cref="Shape"/>
/// <summary>
/// Class that represents a triangle - geometric figure with area
/// </summary>
public class Triangle : Shape
{
    #region Overridden methods

    /// <summary>
    /// Gets area of the current triangle
    /// </summary>
    /// <returns>Area</returns>
    protected override double CalcArea()
    {
        var s = (A + B + C) / 2;
        return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
    }

    #endregion

    #region Properties

    /// <summary>
    /// First side
    /// </summary>
    public double A => _sides[0];

    /// <summary>
    /// Second side
    /// </summary>
    public double B => _sides[1];

    /// <summary>
    /// Third side
    /// </summary>
    public double C => _sides[2];

    /// <summary>
    /// Flag for checking if triangle is right
    /// </summary>
    public bool IsRightTriangle => _isRightTriangle.Value;

    #endregion

    #region Constructors

    private Triangle()

    {
        _isRightTriangle = new Lazy<bool>(CheckIsRightTriangle);
    }

    /// <param name="sides">Array of length 3 sides</param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public Triangle(double[] sides)
        : this()
    {
        ArgumentNullException.ThrowIfNull(sides);

        if (sides.Length != SidesCount)
            throw new ArgumentOutOfRangeException($"{nameof(sides)} count must be {SidesCount} but was {sides.Length}");
        if (!IsTriangleExists(sides[0], sides[1], sides[2]))
            throw new ArgumentException($"Triangle with sides {sides[0]} {sides[1]} {sides[2]} can't exist");

        _sides = new[] { sides[0], sides[1], sides[2] };
    }

    /// <param name="a">First side</param>
    /// <param name="b">Second side</param>
    /// <param name="c">Third side</param>
    /// <exception cref="ArgumentException"></exception>
    public Triangle(double a, double b, double c)
        : this()
    {
        if (!IsTriangleExists(a, b, c))
            throw new ArgumentException($"Triangle with sides {a} {b} {c} can't exist");

        _sides = new[] { a, b, c };
    }

    #endregion

    #region Private fields

    private readonly double[] _sides;
    private readonly Lazy<bool> _isRightTriangle;
    private const int SidesCount = 3;

    #endregion

    #region Private methods

    /// <summary>
    /// Checks if triangle is right
    /// </summary>
    /// <returns>True if triangle is right</returns>
    private bool CheckIsRightTriangle()
    {
        return Math.Abs(A * A + B * B - C * C) < double.Epsilon ||
               Math.Abs(A * A + C * C - B * B) < double.Epsilon ||
               Math.Abs(B * B + C * C - A * A) < double.Epsilon;
    }

    /// <summary>
    /// Checks if triangle exists
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    private bool IsTriangleExists(double a, double b, double c)
    {
        return a > 0 &&
               b > 0 &&
               c > 0 &&
               a + b > c &&
               a + c > b &&
               b + c > a;
    }

    #endregion
}