using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public List<int> numbers;
    private void Start()
    {
        for (int i = 0; i < 10; i++)
            numbers.Add(Random.Range(0, 10));
        print(numbers[4]);
    }

    
}
