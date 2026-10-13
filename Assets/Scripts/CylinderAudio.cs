using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CylinderAudio : MonoBehaviour
{
    private AudioSource audio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter()
    {
        audio.Play();
    }
}
