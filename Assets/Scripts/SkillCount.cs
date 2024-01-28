using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillCount : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textMP;
    [SerializeField] public SpecialMove character;

    private void FixedUpdate()
    {
        if (gameObject.tag == "Initial")
        {
            textMP.text = character.count1.ToString();
        }
        if (gameObject.tag == "JumpPush")
        {
            textMP.text = character.count2.ToString();
        }
        if (gameObject.tag == "Portal")
        {
            textMP.text = character.count3.ToString();
        }
        if (gameObject.tag == "Swap")
        {
            textMP.text = character.count4.ToString();
        }
    }
}
