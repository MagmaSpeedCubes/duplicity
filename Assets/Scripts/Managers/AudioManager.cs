using MagmaLabs;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    
    [SerializeField]private SerializableDictionary<AudioClip> sounds;
    
    public static AudioManager instance;
    public AudioSource source;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            Debug.LogWarning("Multiple instances of AudioManager detected. Destroying duplicate.");
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void PlayBGM(string songName)
    {
        source.clip = sounds.Get(songName);
        source.loop = true;
        source.Play();
    }

    public void PlayBGM()
    {
        source.Play();
    }

    public void StopBGM()
    {
        source.Stop();
    }

    public void PlaySFX(string soundName)
    {
        source.PlayOneShot(sounds.Get(soundName));
    }

}
