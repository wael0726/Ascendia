using UnityEngine;

public class LockPlayerScale : MonoBehaviour {
    private Vector3 originalScale;  // Sauvegarde de la taille d'origine du joueur
    private bool isOnPlatform = false;

    void Start() {
        originalScale = transform.localScale;  // Sauvegarde la taille initiale
    }

    void Update() {
        // Ne modifie l'échelle que si le joueur est sur une plateforme
        if (isOnPlatform) {
            transform.localScale = originalScale;  // Applique l'échelle d'origine si sur la plateforme
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Platform")) {
            isOnPlatform = true;  // Le joueur entre en contact avec une plateforme
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Platform")) {
            isOnPlatform = false;  // Le joueur quitte la plateforme
        }
    }
}
