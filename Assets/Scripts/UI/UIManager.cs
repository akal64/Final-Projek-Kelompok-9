using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsPanel;

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
        SceneManager.LoadScene("Main Menu");
    }

}
