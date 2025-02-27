using UnityEngine;

public class PreventScaleAffect : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.transform.localScale = Vector3.one; // Remet le joueur à une taille normale
        }
    }
    
    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            other.transform.localScale = Vector3.one; // S'assure qu'il garde sa taille
        }
    }
}
