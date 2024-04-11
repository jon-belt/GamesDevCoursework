using UnityEngine;
using TMPro;
using System.Collections;

public class UpgradeMenuText : MonoBehaviour
{
    public TextMeshProUGUI messageText;

    public void UpdateMessage(string message)
    {
        if (messageText != null)
        {
            StopAllCoroutines();
            StartCoroutine(ShowAndFadeMessage(message));
        }
        else
        {
            Debug.LogError("Text not assigned.");
        }
    }

    private IEnumerator ShowAndFadeMessage(string message)
    {
        messageText.text = message;
        messageText.alpha = 1;

        yield return new WaitForSeconds(1);     //wait 1s

        //fade out
        float fadeDuration = 1f;
        float startAlpha = messageText.alpha;

        for (float t = 0; t < 1; t += Time.deltaTime / fadeDuration)
        {
            messageText.alpha = Mathf.Lerp(startAlpha, 0, t);
            yield return null;
        }

        messageText.alpha = 0;
    }
}
