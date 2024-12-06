using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class FadeAudio : MonoBehaviour
{
    // Update is called once per frame
    public static IEnumerator Fade(bool fadeIn, AudioSource audioSource  ,float duration, float targetVolume)
    {

        float time = 0f;
        float startVol = audioSource.volume;
        while (time < duration)
        {
            time += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVol, targetVolume, time / duration);
            yield return null;
        }
        yield break;
    }
}
