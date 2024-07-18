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
                if (number == 0) SkillText.text = "전사첫번째 스킬";
                else if (number == 1) SkillText.text = "전사두번째 스킬";
                else if (number == 2) SkillText.text = "전사세번째 스킬";
                break;
            case Define.Player.Archer:
                if (number == 0) SkillText.text = "아처첫번째 스킬";
                else if (number == 1) SkillText.text = "아처두번째 스킬";
                else if (number == 2) SkillText.text = "아처세번째 스킬";
                break;
            case Define.Player.Mage:
                if (number == 0) SkillText.text = "마법사첫번째 스킬";
                else if (number == 1) SkillText.text = "마법사두번째 스킬";
                else if (number == 2) SkillText.text = "마법사ㄴ세번째 스킬";
                break;
        }

        Invoke("ExitExplain", 5f);
    }

    private void ExitExplain()
    {
        SkillExplainUi.SetActive(false);
    }
}
