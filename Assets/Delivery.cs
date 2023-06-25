using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour {

    [SerializeField] Color32 hasPackageColour = new Color32(255,255,255,255);
    [SerializeField] Color32 noPackageColour = new Color32(255,255,255,255);

    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("ouch");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !hasPackage) {
            Debug.Log("Package was picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColour;
            Destroy(other.gameObject, destroyDelay);
        } 
        
        if (other.tag == "Customer" && hasPackage) {
            Debug.Log("Package delivered!");
            spriteRenderer.color = noPackageColour;
            hasPackage = false;
        }
    }
}
