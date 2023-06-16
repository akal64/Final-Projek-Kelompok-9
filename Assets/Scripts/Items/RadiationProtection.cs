using UnityEngine;

public class RadiationProtection : MonoBehaviour
{

	private void Start () {
		int isPickedUp = PlayerPrefs.GetInt("radiationProtection");

		if (isPickedUp == 1) {
			this.gameObject.SetActive(false);
		} else {
			this.gameObject.SetActive(true);
		}

	}
}
