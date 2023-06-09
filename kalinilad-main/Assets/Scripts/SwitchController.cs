using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public Sprite newSprite; // The sprite to change to
    [SerializeField] private AudioSource SwitchActivateSFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Change the sprite of the switch object
            SpriteRenderer switchRenderer = GetComponent<SpriteRenderer>();
            if (switchRenderer != null)
            {
                SwitchActivateSFX.Play();
                switchRenderer.sprite = newSprite;
            }
            // Disable the collider of the switch to prevent multiple collisions
            GetComponent<Collider>().enabled = false;
        }
    }
}
