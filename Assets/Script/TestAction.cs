using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;

public class TestAction : MonoBehaviour
{
    //A ������ B... �̰� ���� ���� �� deleagate

    //public delegate void ABC(int a);

    //��ü�� ����
    //�ܺο��� �������� ���ϰ�
    //public event ABC a

    //void, ��
    [field: SerializeField]

    // �빮��!
    // �ٵ� ���ſ�
    // �ٵ� ����
    public UnityEvent MyEvent;

    public Action<int> a;

    //�μ� X ��ȯ�� int
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

        //true�� ������ �ֵ鸸,,
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
            //a�� �����?
            //��������
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
