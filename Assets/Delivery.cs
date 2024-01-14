using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 redPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 greenPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 bluePackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    bool hasPackage;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("ya crashed!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Logic for different color package pickups
        if (other.tag == "Red Package" && !hasPackage)
        {
            Debug.Log("Red Package Picked Up");
            hasPackage = true;
            Debug.Log(hasPackage);
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = redPackageColor;
        } else if (other.tag == "Green Package" && !hasPackage) {
            Debug.Log("Green Package Picked Up");
            hasPackage = true;
            Debug.Log(hasPackage);
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = greenPackageColor;
        } else if (other.tag == "Blue Package" && !hasPackage) {
            Debug.Log("Blue Package Picked Up");
            hasPackage = true;
            Debug.Log(hasPackage);
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = bluePackageColor;
        } 

        if (other.tag == "Red Customer" && hasPackage && spriteRenderer.color == redPackageColor)
        {
            Debug.Log("Red Package Delivered");
            hasPackage = false;
            Debug.Log(hasPackage);
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = noPackageColor;
        } else if (other.tag == "Green Customer" && hasPackage && spriteRenderer.color == greenPackageColor)
        {
            Debug.Log("Green Package Delivered");
            hasPackage = false;
            Debug.Log(hasPackage);
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = noPackageColor;
        } else if (other.tag == "Blue Customer" && hasPackage && spriteRenderer.color == bluePackageColor)
        {
            Debug.Log("Blue Package Delivered");
            hasPackage = false;
            Debug.Log(hasPackage);
            Destroy(other.gameObject, destroyDelay);
            spriteRenderer.color = noPackageColor;
        }
    }
}
