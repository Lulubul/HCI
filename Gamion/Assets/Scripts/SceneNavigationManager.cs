using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
	public class SceneNavigationManager : MonoBehaviour
	{
		public GameObject CharacterSelectionPanel;
		public GameObject CharacterPreview;
		public GameObject StartButton;
		public GameObject Loading;

		public void LoadHomeScene()
		{
			SceneManager.LoadScene(0);
		}
	
		public void LoadCharacterSelectionScene()
		{
			SceneManager.LoadScene(1);
		}
	
		public void StartGame()
		{
			StartButton.SetActive(false);
			Loading.SetActive(true);
			SceneManager.LoadScene(2);
		}
	
		public void ShowCharacterPreview()
		{
			CharacterSelectionPanel.SetActive(false);
			CharacterPreview.SetActive(true);
		}
		
		public void ShowCharacterSelection()
		{
			CharacterSelectionPanel.SetActive(true);
			CharacterPreview.SetActive(false);
		}
	}
}
