using UnityEngine;

public class playMenuMusic : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        source.clip = clip;
        source.Play();
    }

    
     
}
