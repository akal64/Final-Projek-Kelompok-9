using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	[Header("Managers")]
	[SerializeField] private UIManager uiManager;
	[SerializeField] private GameSceneManager gameSceneManager;

	[Header("Player Control")]
	[SerializeField] private PlayerControl playerControl;
	[SerializeField] private Player player;
	[SerializeField] private ClawAction clawAction;

	[Header("Level Object Options")]
	[SerializeField] private GameObject radiationProtection;
	[SerializeField] private bool isPlayerHasProtection = false;
	[SerializeField] private bool isRadiationItemExist = false;

	private void Awake () {

		if (instance == null) {
			instance = this;
		}
		else {
			Destroy(gameObject);
		}

        gameSceneManager.Initialize();

		int checkRadiationItem = PlayerPrefs.GetInt("radiationProtection");

		if (checkRadiationItem < 1) {
			PlayerPrefs.SetInt("radiationProtection", 0);
			radiationProtection.SetActive(true);
            uiManager.protectionIndicator.SetActive(false);

        } else if (checkRadiationItem == 1) {
			isPlayerHasProtection = true;
			radiationProtection.SetActive(false);
            uiManager.protectionIndicator.SetActive(true);

		}
	}

	private void Start () {

		playerControl.Initialize();
		player.Initialize();
		uiManager.SetMaxHealth(player.GetMaxHealth());
		uiManager.SetHealth(player.GetCurrentHealth());

}

	private void OnEnable () {
		clawAction.RadiationProtectionPicked += OnRadiationProtectionPicked;
		clawAction.ShowInteractUI += uiManager.ShowInteractUI;
		clawAction.ShowPickUI += uiManager.ShowPickUI;
		clawAction.ShowTrashObjectActionUI += uiManager.ShowTrashObjectActionUI;
		clawAction.ResetClawUI += uiManager.ResetClawUI;
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
		clawAction.RadiationProtectionPicked -= OnRadiationProtectionPicked;
	}

	private void OnRadiationProtectionPicked () {

		PlayerPrefs.SetInt("radiationProtection", 1);
		PlayerPrefs.Save();
		isPlayerHasProtection = true;

		if (radiationProtection != null) {
			radiationProtection.SetActive(false);
            uiManager.OnRadiationProtectionPicked();
        }

	}

	public void DamageByRadiation (int damage) {

		if (!isPlayerHasProtection) {
			player.TakeDamage(damage);
			uiManager.SetHealth(player.GetCurrentHealth());
			CheckGameOver();
		}
	}

    public void OnProcessTrash() {
        player.AddTrash();
        int currentTrash = player.GetCurrentTrash();
        uiManager.UpdateTrashCount(currentTrash);
    }

	private void CheckGameOver() {
        if (player.GetCurrentHealth() <= 0) {
            GameOver();
        }
    }

	private void GameOver() {
		uiManager.OnGameOver();
		DisableController();
	}

    public void EnableController () {
		playerControl.EnableController();
	}

	public void DisableController () {
		playerControl.DisableController();
	}

}
