using UnityEngine;

public class MainMenuButtomManger : MonoBehaviour
{
	[SerializeField] MainMenuManager.MainMenuButtons _buttonType;
	public void ButtonClicked() 
	{ 
		MainMenuManager._.MainMenuButtonClicked(_buttonType);
	}
}
