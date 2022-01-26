using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class EndingAndEpilougue : MonoBehaviour
{
    public TextMeshProUGUI winText;
    public TextMeshProUGUI scoreText;
    public GameObject scoreTextGO;
    public GameObject winTextGO;
    public int textDelay;
	public GameObject player;
    public GameObject lastStoryDriver;
    public GameObject gameOverText;


    void OnEnable()
    {
        lastStoryDriver.SetActive(false);

        StartCoroutine(EndGame());
    }

	IEnumerator EndGame()
	{
		string winTextPath = "Assets/NarratorsLines/WinTextsLinesEndOfGame.txt";
		string scoreTextPath = "Assets/NarratorsLines/ScoreboardsLinesEndOfGame.txt";
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

        scoreTextGO.SetActive(false);
        winTextPath = "Assets/NarratorsLines/WinTextsLinesEpilogue.txt";

        StreamReader readFinalLines = new StreamReader(winTextPath, true);

		while((winTextLine = readFinalLines.ReadLine()) != null)
		{
			winText.text = winTextLine;
			yield return new WaitForSeconds(textDelay);
		}

        readFinalLines.Close();
        winTextGO.SetActive(false);

        yield return new WaitForSeconds(5);
        gameOverText.SetActive(true);

		StopCoroutine(EndGame());
	}
}
