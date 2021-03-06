﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndGame : MonoBehaviour {

    [SerializeField]
    GameObject endScreen;

    [SerializeField]
	Text infoText;

	[SerializeField]
	Image winnerAvatar;

	[SerializeField]
	FadeSound fadeSound;

	[SerializeField]
	AudioClip cukooClip;
	[SerializeField]
	AudioClip killerClip;

	[SerializeField]
	AudioSource source;


    public void TimerFinished()
    {
        ShowEndGameScreen(false);
        infoText.text = "The killer ran out of time.\nThe detective wins the game.";
    }

    public void WrongKillerKilled()
    {
        ShowEndGameScreen(true);
        infoText.text = "The detective killed the wrong guy.\nThat one was not the killer.";
    }

    public void KillerWins()
    {
        ShowEndGameScreen(true);
        infoText.text = "The killer has finished his ritual.\nThe apocalypse has started.";
    }

    public void DetectiveWins()
    {
        ShowEndGameScreen(false);
        infoText.text = "The detective unmasked the killer.\nThe killer has lost the game.";
    }

	void ShowEndGameScreen(bool hasKillerWon)
    {
        Time.timeScale = 0f;
        endScreen.SetActive(true);
		if (hasKillerWon)
			winnerAvatar.sprite = Resources.Load<Sprite>("Sprites/Titlescreen/win_nobody");
		else
			winnerAvatar.sprite = Resources.Load<Sprite>("Sprites/Titlescreen/win_bourricot");

		fadeSound.Stop();

		AudioClip clip = hasKillerWon ? killerClip : null;
		source.PlayOneShot(clip);

		Cursor.SetCursor(null, Vector3.zero, CursorMode.Auto);

        FindObjectOfType<Detective>().enabled = false;
    }

    public void MainMenu()
	{
		Time.timeScale = 1f;
		endScreen.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
