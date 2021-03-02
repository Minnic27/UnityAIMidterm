using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip gunFire, gunReload, zombieSound, zombieHit;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        gunFire = Resources.Load<AudioClip>("gunshot");
        gunReload = Resources.Load<AudioClip>("reload");
        zombieHit = Resources.Load<AudioClip>("hit");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "gunshot":
                audioSrc.PlayOneShot(gunFire);
                break;
            case "reload":
                audioSrc.PlayOneShot(gunReload);
                break;
            case "hit":
                audioSrc.PlayOneShot(zombieHit);
                break;
        }
    }
}
