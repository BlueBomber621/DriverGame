using System;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(0, 255, 0, 255);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);
    [SerializeField] bool hasPackage = false;
    [SerializeField] int packagesDelivered = 0;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Package" && !hasPackage)
        {
            Destroy(other.gameObject, 0.1f);
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Debug.Log("Picked up package!");
        }
        else
        {
            Debug.Log("Bonk!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Delivery Zone" && hasPackage)
        {
            Destroy(other.gameObject, 0.1f);
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
            packagesDelivered++;
            Debug.Log("Delivered Package! (" + packagesDelivered + "/10)");
        }
    }
}
