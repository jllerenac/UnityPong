using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour {
	public Text scorePlayerText;
	public Text scoreEnemyText;
	public AudioSource ballAudio;
	int scorePlayerQuantity;
	int scoreEnemyQuantity;

	public SceneChanger sceneChanger;

	private void OnTriggerEnter2D(Collider2D ball) {
		if(gameObject.tag == "Izquierdo") {
			scoreEnemyQuantity++;
			UpdateScoreLabel(scoreEnemyText, scoreEnemyQuantity);
		}
		else if (gameObject.tag == "Derecho") {
			scorePlayerQuantity++;
			UpdateScoreLabel(scorePlayerText, scorePlayerQuantity);
		}
		ballAudio.Play();
		CheckScore();
		ball.GetComponent<BallBehaviour>().gameStarted = false;

	}

	void CheckScore(){
		if (scorePlayerQuantity > 2) {
			sceneChanger.ChangeSceneTo("WinScene");
		}
		
		if (scoreEnemyQuantity > 2) {
			sceneChanger.ChangeSceneTo("LoseScene");
		}
	}

	void UpdateScoreLabel(Text label, int score){
		label.text = score.ToString();
	}

}
