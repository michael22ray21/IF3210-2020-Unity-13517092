using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	[SerializeField]
	string hoverOverSound = "ButtonHover";

	[SerializeField]
	string pressButtonSound = "ButtonPress";

	AudioManager audioManager;
	public Button playButton;
	public Button quitButton;

	void Start ()
	{
		playButton.onClick.AddListener(StartGame);
		quitButton.onClick.AddListener(QuitGame);
		audioManager = AudioManager.instance;
		if (audioManager == null)
		{
			Debug.LogError("No audiomanager found!");
		}
	}

	public void StartGame ()
	{
		audioManager.PlaySound(pressButtonSound);

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitGame()
	{
		audioManager.PlaySound(pressButtonSound);

		Debug.Log("WE QUIT THE GAME!");
		Application.Quit();
	}

	public void OnMouseOver ()
	{
		audioManager.PlaySound(hoverOverSound);
	}

}
