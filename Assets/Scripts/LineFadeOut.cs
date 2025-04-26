using UnityEngine;

public class LineFadeOut : MonoBehaviour
{
    public float fadeDuration = 1f;

    private LineRenderer lineRenderer;
    private float fadeTimer = 0f;
    private Gradient originalGradient;
    private AnimationCurve originalWidthCurve;
    private bool isFading = false;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        // Speichern Originalwerte
        originalGradient = lineRenderer.colorGradient;
        originalWidthCurve = lineRenderer.widthCurve;
    }

    void Update()
    {
        if (isFading)
        {
            fadeTimer += Time.deltaTime;
            float t = fadeTimer / fadeDuration;

            // Alpha reduzieren
            Gradient newGradient = new Gradient();
            GradientColorKey[] colorKeys = originalGradient.colorKeys;
            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[originalGradient.alphaKeys.Length];
            for (int i = 0; i < alphaKeys.Length; i++)
            {
                float newAlpha = Mathf.Lerp(originalGradient.alphaKeys[i].alpha, 0f, t);
                alphaKeys[i] = new GradientAlphaKey(newAlpha, originalGradient.alphaKeys[i].time);
            }
            newGradient.SetKeys(colorKeys, alphaKeys);
            lineRenderer.colorGradient = newGradient;

            // Width reduzieren
            AnimationCurve newWidthCurve = new AnimationCurve();
            foreach (Keyframe key in originalWidthCurve.keys)
            {
                float newValue = Mathf.Lerp(key.value, 0f, t);
                newWidthCurve.AddKey(new Keyframe(key.time, newValue));
            }
            lineRenderer.widthCurve = newWidthCurve;

            if (t >= 1f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void StartFading()
    {
        isFading = true;
    }
}
