using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadeout : MonoBehaviour
{
    public Image fadeImage;
    public Text fadeText;
    private float alpha = 1f;

    private AudioSource bgm;

    void Start()
    {
        bgm = GetComponent<AudioSource>();
        StartCoroutine(Fade());
        fadeImage.gameObject.SetActive(true);
    }

    private IEnumerator Fade()
    {
        while (alpha >= 0f)
        {
            alpha -= 0.01f;

            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            fadeText.color = new Color(fadeText.color.r, fadeText.color.g, fadeText.color.b, alpha);

            yield return new WaitForSeconds(0.02f);
        }

        bgm.Play();
    }
}
