using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float seconds;
    private int minutes;

    public GameObject timer;

    void Start()
    {
        seconds = 0;
        minutes = 0;
    }

    void Update()
    {
        // �� ������ ��Ÿ Ÿ���� ���Ͽ� �ʸ� ������ŵ�ϴ�.
        seconds += Time.deltaTime;

        // �ʰ� 60�� �ʰ��ϸ� ������ ��ȯ�մϴ�.
        if (seconds >= 60)
        {
            seconds = 0;
            minutes++;
        }

        // �ֿܼ� �ð��� ����մϴ�.
        timer.GetComponent<Text>().text = $"{minutes}�� {seconds:n0}��";
    }
}
