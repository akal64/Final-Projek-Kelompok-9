using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private SFXSoundController sound;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] SceneTransition sceneTransition;
    public void PlayButton()
    {
        sceneTransition.LoadScene("Main");
    }

    public void OptionButton()
    {

        settingsPanel.SetActive(true);
    }

    public void CreditsButton()
    {
        if (creditsPanel.activeSelf) return;
        creditsPanel.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ExitOptionButton()
    {
        sound.BackSound();
        settingsPanel.SetActive(false);
    }

    public void ExitCreditsButton()
    {
        sound.BackSound();
        creditsPanel.SetActive(false);
    }
}
