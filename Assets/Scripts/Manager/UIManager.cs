using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] public GameObject protectionIndicator;
    [SerializeField] private Slider trashSlider;
    [SerializeField] private TextMeshProUGUI trashCount;
    [SerializeField] SceneTransition sceneTransition;

    private Gradient gradient;
    private Image fill;

    private void Awake() {
        fill = healthSlider.fillRect.GetComponent<Image>();
        gradient = new Gradient();
        
    }

    public void SetMaxHealth(int health) {
        healthSlider.maxValue = health;
        healthSlider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health) {
        healthSlider.value = health;

        fill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }

    public void OnGameOver() {
        gameOverPanel.SetActive(true);
    }

    public void UpdateTrashCount(int trashValue) {
        trashSlider.value = trashValue;
        trashCount.SetText(trashValue.ToString());
    }

    public void OnRadiationProtectionPicked() {
        protectionIndicator.SetActive(true);
    }

    // button
    public void PauseButton() {
        if (pauseMenu.activeSelf) return;
        pauseMenu.SetActive(true);
    }

    public void ResumeButton() {
        pauseMenu.SetActive(false);
    }

    public void OptionsButton() {
        if (optionsPanel.activeSelf) return;
        optionsPanel.SetActive(true);
    }

    public void ExitOptionsButton() {
        optionsPanel.SetActive(false);
    }

    public void MainMenuButton() {
        sceneTransition.LoadScene("Main Menu");
    }

    public void RestartButton() {
        SceneManager.LoadScene("Main");
    }

    public void QuitBUtton() {
        Application.Quit();
    }
}
