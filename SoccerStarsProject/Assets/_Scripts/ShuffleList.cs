using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleList : MonoBehaviour
{
    // shuffles list
    public static Stack<T> CreateShuffledStack<T>(IList<T> values)
                    where T : Object
    {
        var stack = new Stack<T>();
        var stacks = new Stack<T>();
        var list = new List<T>(values);
        var i = 0;
        while( list.Count > 0)
        {
            //var randomIndex = Random.Range(0, list.Count - 1);
            //var randomItem = list[randomIndex];
            
            stack.Push(list[i]);
            list.RemoveAt(i);
            //i++;
        }
        while( stack.Count > 0)
        {
            //var randomIndex = Random.Range(0, list.Count - 1);
            //var randomItem = list[randomIndex];
            
            stacks.Push(stack.Pop());
            //list.RemoveAt(i);
            //i++;
        }
        /*while( stacks.Count > 0)
        {
            Debug.Log("stacks: " + stacks.Pop());
        }*/
        return stacks;
    }
    
}
