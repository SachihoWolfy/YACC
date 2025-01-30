using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Transform player;
    public TMP_Text scoreText;
    void Update()
    {
        scoreText.text = player.position.z.ToString("0");
    }
}
