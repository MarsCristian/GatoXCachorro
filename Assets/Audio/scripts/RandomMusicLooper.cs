using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusicLooper : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] peaceMusic;
    [SerializeField]
    public AudioClip[] combatMusic;
    public AudioSource peaceSource;
    public AudioSource combatSource;
    public bool startInCombat = false;
    private bool inCombat;
    public float timeToFade = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        inCombat = startInCombat;
        combatSource.clip = combatMusic[Random.Range(0, combatMusic.Length)];
        peaceSource.clip = peaceMusic[Random.Range(0, peaceMusic.Length)];
        combatSource.Play();
        peaceSource.Play();
        if (startInCombat)
        {
            peaceSource.Pause();
            peaceSource.volume = 0;
        } else
        {
            combatSource.Pause();
            combatSource.volume = 0;
        }
    }

    public void AlternateCombatMusic()
    {
        inCombat = !inCombat;

        StopAllCoroutines();

        StartCoroutine(FadeMusic());
        
    }

    private IEnumerator FadeMusic()
    {
        float timeElapsed = 0;
        if (inCombat)
        {
            combatSource.UnPause();
            combatSource.volume = 1;
            peaceSource.volume = 0;
            peaceSource.Pause();
        } else
        {
            peaceSource.UnPause();
            while (timeElapsed < timeToFade)
            {
                peaceSource.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
                combatSource.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            combatSource.Pause();
        }
    }
}
