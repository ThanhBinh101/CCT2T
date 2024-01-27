using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillCount : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textMP;
    [SerializeField] public GameObject image;
    [SerializeField] public SpecialMove character;

    private void FixedUpdate()
    {
        if (gameObject.tag == "Initial")
        {
            image.SetActive(character.count1 == 0);
            textMP.text = character.count1.ToString();
        }
        if (gameObject.tag == "JumpPush")
        {
            image.SetActive(character.count2 == 0);
            textMP.text = character.count2.ToString();
        }
        if (gameObject.tag == "Portal")
        {
            image.SetActive(character.count3 == 0);
            textMP.text = character.count3.ToString();
        }
        if (gameObject.tag == "Swap")
        {
            image.SetActive(character.count4 == 0);
            textMP.text = character.count4.ToString();
        }
    }
}
