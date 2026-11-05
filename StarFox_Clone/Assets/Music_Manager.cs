using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Manager : MonoBehaviour
{
    public static AudioSource currentMusic;
    [SerializeField] private AudioClip[] tracks;
    [SerializeField] private AudioClip[] curTracks;


    void Start()
    {
        resetTrackList(); 
    }

// Update is called once per frame
void Update()
    {
        if(!currentMusic.isPlaying) pickTrack(); 
    }

    private void pickTrack() {

        if (curTracks.Length < 0) resetTrackList();  


        int indexrand = Random.Range(0, curTracks.Length);
        currentMusic.clip = curTracks[indexrand];
        AudioClip[] t = new AudioClip[curTracks.Length - 1];

        for (int i = 0; i < curTracks.Length - 1; i++) {
            if (i == indexrand) continue;
            t[i] = curTracks[i]; 
        }
        curTracks = t;

    }

    private void resetTrackList() {
        curTracks = new AudioClip[tracks.Length];
        for (int i = 0; i < tracks.Length; i++)
        {
            curTracks[i] = tracks[i];
        }
    }

}
