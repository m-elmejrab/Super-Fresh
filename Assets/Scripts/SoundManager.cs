using UnityEngine;

public class SoundManager : MonoBehaviour //Singleton class responsible for playing music/sfx
{
    public static SoundManager instance;
    private AudioSource audioSource;
    public AudioClip backgroundMusic;
    public AudioClip collectFruit;
    public AudioClip discardFruit;
    public AudioClip customerServed;
    public AudioClip levelFinished;
    public AudioClip clickSound;


    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayCollectFruit()
    {
        audioSource.PlayOneShot(collectFruit, 0.5f);
    }

    public void PlayDiscardFruit()
    {
        audioSource.PlayOneShot(discardFruit);
    }

    public void PlayCustomerServed()
    {
        audioSource.PlayOneShot(customerServed);
    }

    public void PlayLevelComplete()
    {
        audioSource.Stop();

        audioSource.PlayOneShot(levelFinished);
    }

    public void PlayUIClick()
    {
        audioSource.PlayOneShot(clickSound, 2f);
    }    
}
