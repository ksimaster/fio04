using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeactivationObject : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score;
    private void OnMouseDown()
    {
        score = int.Parse(scoreText.text);
        score++;
        scoreText.text = score.ToString();
        gameObject.SetActive(false);

    }

}
