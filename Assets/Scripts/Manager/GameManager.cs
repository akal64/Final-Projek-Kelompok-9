using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public static GameManager instance;

	[SerializeField] private UIManager uiManager;
	[SerializeField] private GameObject radiationProtection;

	[Header("Player Control")]
	[SerializeField] private PlayerControl playerControl;
	[SerializeField] private Player player;
	[SerializeField] private ClawAction clawAction;

	[Header("Scene Management")]
	[SerializeField] private string surfaceSceneName;

	[SerializeField] private bool isPlayerHasProtection = false;
	[SerializeField] private bool isRadiationItemExist = false;

	private void Awake () {

		if (instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
		}

		if (SceneManager.GetSceneByName(surfaceSceneName).isLoaded == false) {
			SceneManager.LoadScene(surfaceSceneName, LoadSceneMode.Additive);
		}

		int checkRadiationItem = PlayerPrefs.GetInt("radiationProtection");

		if (checkRadiationItem < 1) {
			PlayerPrefs.SetInt("radiationProtection", 0);
			radiationProtection.SetActive(true);

		} else if (checkRadiationItem == 1) {
			isPlayerHasProtection = true;
			radiationProtection.SetActive(false);

		}
	}

	private void Start () {
		playerControl.Initialize();
		player.Initialize();
		uiManager.SetMaxHealth(player.GetMaxHealth());
		uiManager.SetHealth(player.GetCurrentHealth());
	}

	private void OnEnable () {
		playerControl.PauseClicked += OnPauseClicked;
		clawAction.RadiationProtectionPicked += OnRadiationProtectionPicked;
	}

	private void Update () {
		if (radiationProtection.activeSelf) {
			isRadiationItemExist = true;
		} else {
			isRadiationItemExist = false;
		}

		if (!isPlayerHasProtection && !isRadiationItemExist) {
			radiationProtection.SetActive(true);
		}
	}

	private void OnDisable () {
		playerControl.PauseClicked -= OnPauseClicked;
		clawAction.RadiationProtectionPicked -= OnRadiationProtectionPicked;
	}

	private void OnPauseClicked () {
		// TODO Pause Game
		Debug.Log("Pause Clicked");
	}

	private void OnRadiationProtectionPicked () {
		// Save that we picked up the radiation protection
		PlayerPrefs.SetInt("radiationProtection", 1);
		PlayerPrefs.Save();
		isPlayerHasProtection = true;

		// SetActive false the radiation protection
		if (radiationProtection != null) {
			radiationProtection.SetActive(false);
		}

	}

	public void DamageByRadiation (int damage) {
		if (!isPlayerHasProtection) {
			player.TakeDamage(damage);
			uiManager.SetHealth(player.GetCurrentHealth());
		}
	}
}
