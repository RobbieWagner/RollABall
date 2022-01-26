using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class SentienceGranter : MonoBehaviour
{

    public TextMeshProUGUI winText;
    public TextMeshProUGUI scoreText;
    public int textDelay;
	public GameObject player;
	public GameObject curLevel;
	public GameObject nextLevel;

    void OnEnable()
    {
        StartCoroutine(GiveScoreBoardSentience());
    }

	IEnumerator GiveScoreBoardSentience()
	{
		string winTextPath = "Assets/NarratorsLines/WinTextsLinesLevel1.txt";
		string scoreTextPath = "Assets/NarratorsLines/ScoreboardsLinesLevel1.txt";
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
		curLevel.SetActive(false);
		player.transform.position = new Vector3(0,0,0);
		nextLevel.SetActive(true);

		StopCoroutine(GiveScoreBoardSentience());
	}
}
