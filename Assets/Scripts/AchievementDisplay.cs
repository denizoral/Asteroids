using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievementDisplay : MonoBehaviour
{
    public Achievement achievement;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descText;
    public Canvas canvas;


    public IEnumerator setAchievement(float delay)
    {
        canvas.gameObject.SetActive(true);
        nameText.text = achievement.name;
        descText.text = achievement.description;
        yield return new WaitForSeconds(delay);
        canvas.gameObject.SetActive(false);
    }
}