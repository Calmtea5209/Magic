using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public int id;
    public AudioClip clip;
    [Range(0f, 1f)]public float volume;
    [Range(.1f, 3f)]public float pitch = 1f;

    [HideInInspector]
    public AudioSource source;
    
}