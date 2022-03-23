using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;

public class TestAction : MonoBehaviour
{
    //A 다음에 B... 이게 힘들어서 만든 게 deleagate

    //public delegate void ABC(int a);

    //주체가 있음
    //외부에서 발행하지 못하게
    //public event ABC a

    //void, ㅂ
    [field: SerializeField]

    // 대문자!
    // 근데 무거워
    // 근데 ㄱㅊ
    public UnityEvent MyEvent;

    public Action<int> a;

    //인수 X 반환이 int
    public Func<int, int, int> b;

    List<int> list = new List<int>();

    private void Start()
    {
        /*   ABC a = null;

        a?.Invoke(3);

        a += sdf;
        a += dfd;
        a.Invoke(3);

        a -= dfd;
        a.Invoke(3);

        v += GGM3;
        int result = v.Invoke();  */

        //true를 리턴한 애들만,,
        List<int> a = list.FindAll(x => x % 2 == 0).FindAll(x => x != 0);

        b += (a, b) => a + b;
        b +=  ( a,  b) =>a + b;

        int result = b.Invoke(3, 4);
        Debug.Log(result);
    }

    public void Test()
    {
        int a = 10;
        b += (x,a) =>
        {
            return x + a;
            //a가 사라져?
            //ㄴㄴㄴㄴ
        };
    }

    public void sdf(int a)
    {
        Debug.Log(a);
    }

    public void dfd (int b)
    {
        Debug.Log($"this is {b}");
    }

    public int GGM3()
    {
        return 0;
    }
}
