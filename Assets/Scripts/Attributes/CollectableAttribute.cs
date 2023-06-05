using UnityEngine;
using TMPro;

[AddComponentMenu("Playground/Attributes/Collectable")]
public class CollectableAttribute : MonoBehaviour
{
    private static int points = 0;
    private static TextMeshProUGUI counterText;

    public AudioClip collectSound; // Agrega el AudioClip para el sonido de recolección

    private void Start()
    {
        if (counterText == null)
        {
            counterText = FindObjectOfType<TextMeshProUGUI>();
        }
    }

    // This will create a dialog window asking for which dialog to add
    private void Reset()
    {
        Utils.Collider2DDialogWindow(this.gameObject, true);
    }

    // This function gets called every time this object collides with another
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        string playerTag = otherCollider.gameObject.tag;

        // Is the other object a player?
        if (playerTag == "Player" || playerTag == "Player2")
        {
            // Play the collect sound
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            // Increment the global points counter
            points++;

            // Update the counter text
            if (counterText != null)
            {
                counterText.text = "Coin: " + points.ToString();
            }

            // Destroy this object
            Destroy(gameObject);
        }
    }
}
