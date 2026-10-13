using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(MeshRenderer))]
public class Ball : MonoBehaviour
{
    [SerializeField] private GameSettings settings;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async Awaitable Start()
    {
        var audio = GetComponent<AudioSource>();

        GameManager.Instance.Ball = true;

        await Awaitable.WaitForSecondsAsync(settings.ballLifetime);
        audio.Play();

        GetComponent<MeshRenderer>().enabled = false;

        while (audio.isPlaying) await Awaitable.EndOfFrameAsync();

        GameManager.Instance.Ball = false;
        Destroy(gameObject);
    }
}
