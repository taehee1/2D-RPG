using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public GameObject SkillExplainUi;
    public Image SkillImage;
    public Text SkillText;

    public void ExplainSkillBtn(int number)
    {
        SkillExplainUi.SetActive(true);
        SkillImage.sprite = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite;

        switch (GameManager.Instance.SelectedPlayer)
        {
            case Define.Player.Warrior:
                if (number == 0) SkillText.text = "����ù��° ��ų";
                else if (number == 1) SkillText.text = "����ι�° ��ų";
                else if (number == 2) SkillText.text = "���缼��° ��ų";
                break;
            case Define.Player.Archer:
                if (number == 0) SkillText.text = "��óù��° ��ų";
                else if (number == 1) SkillText.text = "��ó�ι�° ��ų";
                else if (number == 2) SkillText.text = "��ó����° ��ų";
                break;
            case Define.Player.Mage:
                if (number == 0) SkillText.text = "������ù��° ��ų";
                else if (number == 1) SkillText.text = "������ι�° ��ų";
                else if (number == 2) SkillText.text = "�����礤����° ��ų";
                break;
        }

        Invoke("ExitExplain", 5f);
    }

    private void ExitExplain()
    {
        SkillExplainUi.SetActive(false);
    }
}
