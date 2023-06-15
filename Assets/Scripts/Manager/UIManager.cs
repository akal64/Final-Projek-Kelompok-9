using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    [Header("Player UI")]
    [SerializeField] private Slider healthSlider;

    [Header("Game UI")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject gameOverPanel;

	[Header("GamePlay UI")]
	[SerializeField] public GameObject protectionIndicator;
	[SerializeField] private TextMeshProUGUI trashCount;
	[SerializeField] private Slider trashSlider;
	[SerializeField] SceneTransition sceneTransition;

    [Header("Trash UI")]
    [SerializeField] private GameObject interactUI;
    [SerializeField] private GameObject pickUI;
    [SerializeField] private GameObject objectActionUI;
    [SerializeField] private GameObject trashActionUI;


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

    public void ShowInteractUI () {
		SetClawUI(true, false, false, false);
	}

	public void ShowPickUI () {
		SetClawUI(false, true, false, false);
	}

	public void ShowTrashObjectActionUI (bool isTrash) {

        if (isTrash) {
			SetClawUI(false, false, true, true);

		} else {
			SetClawUI(false, false, true, false);

		}
    }

    public void ResetClawUI () {
        SetClawUI(false, false,false, false);
	}

    private void SetClawUI (bool interactUIValue, bool pickUIValue, bool objectActionValue, bool trashObjectValue) {
		interactUI.gameObject.SetActive(interactUIValue);
		pickUI.gameObject.SetActive(pickUIValue);
        objectActionUI.gameObject.SetActive(trashObjectValue);
		trashActionUI.gameObject.SetActive(trashObjectValue);
	}

}
