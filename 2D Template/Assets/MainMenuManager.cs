using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
	public static MainMenuManager _;
	[SerializeField] private bool _debugMode;
	public enum MainMenuButtons { play, options, credits, quit };
	public void Awake()
	{
		if (_ = null)
		{
			_ = this;
		}
		else 
		{
			Debug.LogError("There are more than 1 MainMenuManager's in the scene");
		}
	}
	public void MainMenuButtonClicked(MainMenuButtons buttonClicked) 
	{
		DebugMessage("Button Clicked: " + buttonClicked.ToString());
		switch (buttonClicked) 
		{ 
			case MainMenuButtons.play:
				break;
			case MainMenuButtons.options:
				break;
			case MainMenuButtons.credits:
				break;
			case MainMenuButtons.quit:
				break;
			default:
				Debug.Log("Button clicked that wasn't implemented in MainMenuManager Method");
				break;
		}
	}
	private void DebugMessage(string message) 
	{
		if (_debugMode) 
		{
			Debug.Log(message);
		}
	}
}
