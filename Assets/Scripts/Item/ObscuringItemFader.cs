using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ObscuringItemFader : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutRoutine());
    }
    
    public void FadeIn()
    {
        StartCoroutine(FadeInRoutine());
    }

    IEnumerator FadeInRoutine()
    {
        float currentAlpha = spriteRenderer.color.a;
        float distance = 1 - currentAlpha;

        while (currentAlpha < 1)
        {
            currentAlpha += distance/Settings.fadeInSeconds * Time.deltaTime;
            spriteRenderer.color = new Color(1, 1, 1, currentAlpha);
            yield return null;
        }
        
        spriteRenderer.color = new Color(1, 1, 1, 1);

    }
    IEnumerator FadeOutRoutine()
    {
        float currentalpha = spriteRenderer.color.a;
        float distance = currentalpha - Settings.targetAlpha;

        while (currentalpha - Settings.targetAlpha > 0.01f)
        {
            currentalpha -= distance/Settings.fadeOutSeconds * Time.deltaTime;
            spriteRenderer.color = new Color(1, 1, 1, currentalpha);

            yield return null;
        }

        spriteRenderer.color = new Color(1, 1, 1, Settings.targetAlpha);
    }
}
