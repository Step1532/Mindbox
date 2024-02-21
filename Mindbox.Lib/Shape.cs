namespace Mindbox.Lib;

/// <summary>
/// Class that represents a shape - geometric figure with area
/// </summary>
public abstract class Shape
{
    private readonly Lazy<double> _area;

    /// <summary>
    /// Property that contains area of the current shape
    /// </summary>
    public double Area => _area.Value;

    protected Shape()
    {
        _area = new Lazy<double>(CalcArea);
    }

    /// <summary>
    /// Finds the area of the current shape
    /// </summary>
    /// <returns>double</returns>
    protected abstract double CalcArea();
}