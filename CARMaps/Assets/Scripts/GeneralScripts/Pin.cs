using System.Collections;
using System.Collections.Generic;
using System.Numerics;
//using UnityEngine;

public class Pin //: MonoBehaviour
{
    private float[] LocalPosition = { 0, 0, 0 };
    private float[] WorldPosition = { 0, 0, 0 };
    private int Color;
    private string Name;

    public void SetPinLocalPosition(float x, float y, float z)
    {
        LocalPosition[0] = x;
        LocalPosition[1] = y;
        LocalPosition[2] = z;
    }

    public float[] GetPinLocalPosition()
    {
        return LocalPosition;
    }

    public void SetPinWorldPosition(float x, float y, float z)
    {
        WorldPosition[0] = x;
        WorldPosition[1] = y;
        WorldPosition[2] = z;
    }

    public float[] GetPinWorldPosition()
    {
        return WorldPosition;
    }

    public void SetPinColor(int color)
    {
        Color = color;
    }

    public int GetPinColor()
    {
        return Color;
    }

    public void SetPinName(string name)
    {
        Name = name;
    }

    public string GetPinName()
    {
        return Name;
    }
}
