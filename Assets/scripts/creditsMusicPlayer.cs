using UnityEngine;

public class creditsMusicPlayer : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source.clip = clip;
        source.Play();
    }

    
}
