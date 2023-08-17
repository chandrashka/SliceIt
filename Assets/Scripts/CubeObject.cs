using UnityEngine;

public class CubeObject : MonoBehaviour
{
    [SerializeField] private GameObject additionalCubePrefab;
    private GameManager _gameManager;

    private const int Score = 2;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var transformPosition = gameObject.transform.position;
        if (!other.TryGetComponent<CardMovement>(out _)) return;
        
        Instantiate(additionalCubePrefab, transformPosition, Quaternion.identity);
        gameObject.transform.Translate(new Vector3(0, -2));

        gameObject.GetComponent<Collider>().isTrigger = false;

        _gameManager.AddScore(Score);
    }
}
