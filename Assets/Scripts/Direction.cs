using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum Direction
{
    None = 0, 
    Left = 1, 
    Up = 2, 
    Right = 3, 
    Down = 4
}


public  static partial class Extensions
{

}

public static partial class Helper
{
    /// <summary>
    /// A random direction. Does not include none. 
    /// </summary>
    /// <returns></returns>
    public static Direction RandomDirection()
    {
        return (Direction)UnityEngine.Random.Range(1, 4); 
    }
}
