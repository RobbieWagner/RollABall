using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class IntroducingLevel2 : MonoBehaviour
{

    public TextMeshProUGUI winText;
    public TextMeshProUGUI scoreText;
    public int textDelay;
	public GameObject player;
    public GameObject lastStoryDriver;
	public GameObject cage;
	public GameObject nextStoryDriver;

    void OnEnable()
    {
        lastStoryDriver.SetActive(false);

        StartCoroutine(BuildLevel2());
    }

	IEnumerator BuildLevel2()
	{
		string winTextPath = "Assets/NarratorsLines/WinTextsLinesLevel2Intro.txt";
		string scoreTextPath = "Assets/NarratorsLines/ScoreboardsLinesLevel2Intro.txt";
		string winTextLine;

		StreamReader readWinTextsLines = new StreamReader(winTextPath, true);
		StreamReader readScoreboardsLines = new StreamReader(scoreTextPath, true);


		while((winTextLine = readWinTextsLines.ReadLine()) != null)
		{
			winText.text = winTextLine;
			scoreText.text = readScoreboardsLines.ReadLine();
			yield return new WaitForSeconds(textDelay);
		}

		readWinTextsLines.Close();
		readScoreboardsLines.Close();

		cage.SetActive(false);
		nextStoryDriver.SetActive(true);

		StopCoroutine(BuildLevel2());
	}
}
