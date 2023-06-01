using UnityEngine;

public class GradientSprite : MonoBehaviour
{
    public Gradient gradient;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        ApplyGradient();
        AdjustScale();
    }

    private void ApplyGradient()
    {
        int textureWidth = 256;
        int textureHeight = 256;

        Texture2D texture = new Texture2D(textureWidth, textureHeight);
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Bilinear;

        Color[] colors = new Color[textureWidth * textureHeight];

        for (int y = 0; y < textureHeight; y++)
        {
            for (int x = 0; x < textureWidth; x++)
            {
                float t = (float)x / (textureWidth - 1);
                colors[y * textureWidth + x] = gradient.Evaluate(t);
            }
        }

        texture.SetPixels(colors);
        texture.Apply();

        Rect spriteRect = new Rect(0, 0, textureWidth, textureHeight);
        Vector2 pivot = new Vector2(0.5f, 0.5f);
        float pixelsPerUnit = 100; // Ajusta esto según tu escala de sprite

        spriteRenderer.sprite = Sprite.Create(texture, spriteRect, pivot, pixelsPerUnit);
    }

    private void AdjustScale()
    {
        float spriteWidth = spriteRenderer.sprite.bounds.size.x;
        float spriteHeight = spriteRenderer.sprite.bounds.size.y;

        transform.localScale = new Vector3(spriteWidth, spriteHeight, 1f);
    }
}
