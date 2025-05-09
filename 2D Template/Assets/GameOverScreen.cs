using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour {

    public Text pointsText;
    public void SetUp(int score) { 
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }


	public void RestartButton() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
	}

    public void ExitButton() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}
}
