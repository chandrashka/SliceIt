using UnityEngine;

public class CardSpawnerManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.TryGetComponent<CardMovement>(out _)) return;
        gameManager.SpawnNewCard();
        Destroy(other.gameObject);
    }
}
