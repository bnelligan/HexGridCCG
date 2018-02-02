using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubic
{
    public int x;
    public int y;
    public int z;

    // Directional unit cubes
    public static Cubic N = new Cubic(0, 1, -1);
    public static Cubic NE = new Cubic(1, 0, -1);
    public static Cubic SE = new Cubic(1, -1, 0);
    public static Cubic S = new Cubic(0, -1, 1);
    public static Cubic SW = new Cubic(-1, 0, 1);
    public static Cubic NW = new Cubic(-1, 1, 0);

    // Constructors
    public Cubic()
    {
        x = 0;
        y = 0;
        z = 0;
    }
    public Cubic(int _x, int _y, int _z)
    {
        // Check constraint. sum == 0
        if (_x + _y + _z == 0)
        {
            x = _x;
            y = _y;
            z = _z;
        }
        else
        {
            Debug.LogError("Unable to create a new cube. Sum != 0");
        }

    }


    public bool SetCube(int _x, int _y, int _z)
    {
        // Constrain coords to equal 0
        if (_x + _y + _z == 0)
        {
            x = _x;
            y = _y;
            z = _z;
            return true;
        }
        else
        {
            Debug.LogError("Unable to set cube coordinates. Sum != 0.");
            return false;
        }
    }
    
    // Change cubic coords by a unit vector
    public void Cube_Add(Cubic _direction)
    {
        x += _direction.x;
        y += _direction.y;
        z += _direction.z;
    }

    #region Static Public Methods

    // Increases a cube by a unit cube and returns it
    public static Cubic Cube_Add(Cubic _cube, Cubic _direction)
    {
        _cube.x += _direction.x;
        _cube.y += _direction.y;
        _cube.z += _direction.z;

        return _cube;
    }

    // Calculates the cubic distance between two hexes
    public static int Cube_Distance(Cubic A, Cubic B)
    {
        return Mathf.Max(Mathf.Abs(A.x - B.x), Mathf.Abs(A.y - B.y), Mathf.Abs(A.z - B.z));
    }

    #endregion

    #region Operator Overrides

    // New comparison operators to compare cubic coordinates
    public static bool operator ==(Cubic c1, Cubic c2)
    {
        return (c1.x == c2.x) &&
               (c1.y == c2.y) &&
               (c1.z == c2.z);
    }
    public static bool operator !=(Cubic c1, Cubic c2)
    {
        return (c1.x != c2.x) ||
               (c1.y != c2.y) ||
               (c1.z != c2.z);
    }

    #endregion

}
