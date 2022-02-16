using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    AudioSource audioSource;

    public AudioClip DropTimeSound;

    public AudioClip DeleteLineSound;

    public AudioClip LevelUpSound;

    public AudioClip StartGameSound;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    
}
