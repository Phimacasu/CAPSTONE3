using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicOnLoad : MonoBehaviour
{
    public AudioClip newTrack;

    private AudioManager theAM;
    
    // Start is called before the first frame update
    void Start()
    {

        if(newTrack != null )
        {
            theAM = FindObjectOfType<AudioManager>();
            theAM.ChangeBGM(newTrack);
        }
            theAM.ChangeBGM(newTrack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
