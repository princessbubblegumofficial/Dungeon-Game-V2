using UnityEngine.Audio;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public bool loop;
    public float pitch;
    [HideInInspector]
    public AudioSource source;
}
