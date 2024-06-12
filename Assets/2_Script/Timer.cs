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
        // 매 프레임 델타 타임을 더하여 초를 증가시킵니다.
        seconds += Time.deltaTime;

        // 초가 60을 초과하면 분으로 변환합니다.
        if (seconds >= 60)
        {
            seconds = 0;
            minutes++;
        }

        // 콘솔에 시간을 출력합니다.
        timer.GetComponent<Text>().text = $"{minutes}분 {seconds:n0}초";
    }
}
