using UnityEngine;

public class MotionBlur : MonoBehaviour
{
    public Material motionBlurMaterial; // El material del shader de motion blur
    private RenderTexture previousFrameTexture; // Textura de la imagen anterior

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        // Si no hay material asignado, se utiliza el RenderTexture de origen directamente
        if (motionBlurMaterial == null)
        {
            Graphics.Blit(src, dest);
            return;
        }

        // Creamos una nueva textura para almacenar la imagen anterior
        if (previousFrameTexture == null || previousFrameTexture.width != src.width || previousFrameTexture.height != src.height)
        {
            DestroyImmediate(previousFrameTexture);
            previousFrameTexture = new RenderTexture(src.width, src.height, 0);
            previousFrameTexture.hideFlags = HideFlags.HideAndDontSave;
            Graphics.Blit(src, previousFrameTexture);
        }

        // Establecemos las propiedades del material
        motionBlurMaterial.SetTexture("_PreviousFrameTex", previousFrameTexture);
        motionBlurMaterial.SetFloat("_BlurAmount", 0.8f); // Ajusta el valor para controlar la cantidad de motion blur

        // Realizamos el efecto de motion blur mediante el shader
        Graphics.Blit(src, dest, motionBlurMaterial);

        // Almacenamos la imagen actual en la textura de imagen anterior
        Graphics.Blit(src, previousFrameTexture);
    }

    private void OnDestroy()
    {
        // Liberamos la textura cuando el objeto se destruye
        if (previousFrameTexture != null)
        {
            DestroyImmediate(previousFrameTexture);
        }
    }
}
