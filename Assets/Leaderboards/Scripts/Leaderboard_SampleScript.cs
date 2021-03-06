using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using GameSparks.Api;
using GameSparks.Api.Messages;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;

public class Leaderboard_SampleScript : MonoBehaviour
{
	public static Leaderboard_SampleScript Instance;

	public TextMeshProUGUI scoreText, rankText;
	public string leaderboardName;

	void Awake()
	{
		Instance = this;
		GameSparks.Api.Messages.NewHighScoreMessage.Listener += HighScoreMessageHandler; // assign the New High Score message
	}

	void HighScoreMessageHandler(GameSparks.Api.Messages.NewHighScoreMessage _message)
	{
		Debug.Log("NEW HIGH SCORE \n " + _message.LeaderboardName);
	}

	public void PostScoreBttn()
	{
		new DeviceAuthenticationRequest().Send((response) =>
		{
			Debug.Log("Posting Score To Leaderboard...");
			rankText.text = "Posting Score To Leaderboard...";
			scoreText.text = "";
			new GameSparks.Api.Requests.LogEventRequest()
				.SetEventKey("ESCAPE_TIME")
				.SetEventAttribute("ESCAPE_TIME", (long) Game.Score)
				.Send((response2) =>
				{

					if (!response2.HasErrors)
					{
						Debug.Log("Score Posted Sucessfully...");
					}
					else
					{
						Debug.Log("Error Posting Score...");
					}
				});
			GetLeaderboard();
		});
	}

	public void GetLeaderboard()
	{
		Debug.Log("Fetching Leaderboard Data...");

		new GameSparks.Api.Requests.LeaderboardDataRequest()
			.SetLeaderboardShortCode(leaderboardName)
			.SetEntryCount(25) // we need to parse this text input, since the entry count only takes long
			.Send((response) =>
			{

				if (!response.HasErrors)
				{
					Debug.Log("Found Leaderboard Data...");
					rankText.text = System.String.Empty; // first clear all the data from the output
					scoreText.text = System.String.Empty;
					foreach (GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in response.Data) // iterate through the leaderboard data
					{
						int rank = (int) entry.Rank; // we can get the rank directly
						string playerName = entry.UserName;
						long score = long.Parse(entry.JSONData["ESCAPE_TIME"].ToString()); // we need to get the key, in order to get the score
						rankText.text += rank + "\n"; // addd the score to the output text
						scoreText.text += Mathf.Floor(score / 60) + ":" + ((score % 60) < 10 ? "0" : "") + Mathf.Floor((score % 60)) + "\n";
					}
				}
				else
				{
					Debug.Log("Error Retrieving Leaderboard Data...");
				}

			});
	}
}