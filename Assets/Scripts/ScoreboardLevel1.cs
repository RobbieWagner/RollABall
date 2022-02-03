using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System.IO;
using TMPro;

public class ScoreboardLevel1 : MonoBehaviour
{
    public GameObject winTextObject;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI scoreText;
    public int score;
    public bool gameContinues; //boolean that determines if the game continues after collecting 10 coins
    private int oldScore; 
    public GameObject player;
    
    public GameObject barrierWalls;

    public GameObject newRoom;
    public GameObject oldRoom;

    // Start is called at the first frame
    void Start()
    {
        SetCountText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(oldScore < score)
        {
            oldScore = (int)score;
            SetCountText();
        }
    }

    // Counts the players score
    void SetCountText()
	{
		scoreText.text = "Count: " + score.ToString();

		if(score == 14 && gameContinues) 
		{
            StartCoroutine(OpenTheMap());
		}
        else if (score == 14)
        {
            winTextObject.SetActive(true);
        }

		if(score == 19)
		{
            barrierWalls.SetActive(false);
		}
	}

    // Continues the game if gameContinues is true
    IEnumerator OpenTheMap()
    {
        winTextObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        winText.text = "YOU WIN?";
        player.transform.position = new Vector3(0, 0.5f, 0);
        newRoom.SetActive(true);
        oldRoom.SetActive(false);

        StopCoroutine(OpenTheMap());
    }
}
