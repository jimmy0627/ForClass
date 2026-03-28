using UnityEngine;
// This script demonstrates the use of abstract classes and interfaces in Unity.
public class SquareArea : Abstract
{
    public int sideLength;
    public override int GetArea()
    {
        return sideLength * sideLength; // Area of a square is side length squared
    }
    void Start()
    {
        Debug.Log("Area of the square: " + GetArea());
    }
}
public class CircleArea : Abstract
{
    public int radius;
    public override int GetArea()
    {
        return (int)(Mathf.PI * radius * radius); // Area of a circle is π times radius squared
    }
    void Start()
    {
        Debug.Log("Area of the circle: " + GetArea());
    }
}
public class TriangleArea : Abstract
{
    public int baseLength;
    public int height;
    public override int GetArea()
    {
        return (int)(0.5 * baseLength * height); // Area of a triangle is half the product of base and height
    }
    void Start()
    {
        Debug.Log("Area of the triangle: " + GetArea());
    }
}