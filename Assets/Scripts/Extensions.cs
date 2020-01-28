using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine; 

public  static partial class Extensions
{
    /// <summary>
    /// Get a random element from a ienumerable. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ienumerable"></param>
    /// <returns></returns>
    public static T GetRandomElement<T>(this IEnumerable<T> ienumerable)
    {
        return ienumerable.ElementAt(UnityEngine.Random.Range(0, ienumerable.Count() - 1)); 
    }

}

