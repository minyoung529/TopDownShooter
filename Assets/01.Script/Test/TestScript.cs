using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // 대리자 반환형 이름(매개변수)
    public delegate int Add(int x);
    delegate int Calculate(int a, int b);


    void Start()
    {
        Add a = x => x + 4;

        Calculate clac = (a, b) => a + b;

        List<GameObject> gameObjects = new List<GameObject>();
        gameObjects.FindAll(x => x.activeSelf).ForEach(x => x.SetActive(false));
    }

    void Update()
    {
    }

    public int Add4(int a)
    {
        return a + 4;
    }

    public int Add8(int a)
    {
        return a + 8;
    }
}
