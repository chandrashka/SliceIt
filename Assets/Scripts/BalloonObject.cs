using UnityEngine;

public class BalloonObject : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip audioClip;
    
    private GameManager _gameManager;

    private const int Score = 1;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _gameManager.AddScore(Score);
        if (!other.TryGetComponent<CardMovement>(out _)) return;
        _audioSource.PlayOneShot(audioClip, 1);
        Destroy(gameObject);
        
    }
}
