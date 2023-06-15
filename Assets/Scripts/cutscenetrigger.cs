using UnityEngine;

public class CutSceneTrigger : MonoBehaviour
{
    [SerializeField] Animator player, boss, blackbar;
    [SerializeField] SceneTransition sceneTransition;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            player.enabled = true;
            boss.enabled = true;
            blackbar.enabled = true;
        }
    }
    private void Update() {
        if (player.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f){
            sceneTransition.LoadScene("Main Menu");
        }
    }
}
