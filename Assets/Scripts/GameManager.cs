using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private CardMovement _cardMovement;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform spawnPoint;
    [Space]
    [SerializeField] private TrajectoryRenderer trajectoryRenderer;
    [Space]
    [SerializeField] private float sideMovement;
    [Space]
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private int _score;
    
    private Vector3 _force;
    private const float SideMovementParameter = 0.6f;
    private const int ForwardSpeed = 30;
    
    private void Start()
    {
        _cardMovement = player.GetComponent<CardMovement>();
    }

    public void MoveCard()
    {
        _force = Vector3.forward * ForwardSpeed + Vector3.left * sideMovement;
        _cardMovement.MoveCard(_force);
        trajectoryRenderer.HideTrajectory();
    }

    public void Swipe(float deltaX)
    {
        switch (sideMovement)
        {
            case >= -6 and <= 6:
                switch (deltaX)
                {
                    case > 0:
                        sideMovement += SideMovementParameter;
                        break;
                    case < 0:
                        sideMovement -= SideMovementParameter;
                        break;
                }

                break;
            case < -6:
                sideMovement = -6;
                break;
            case > 6:
                sideMovement = 6;
                break;
        }
        _force = Vector3.forward * ForwardSpeed + Vector3.left * sideMovement;
        trajectoryRenderer.ShowTrajectory(_cardMovement.gameObject.transform.position, _force);
    }

    public void SpawnNewCard()
    {
        player = Instantiate(cardPrefab, spawnPoint.position, Quaternion.identity);
        _cardMovement = player.GetComponent<CardMovement>();
        trajectoryRenderer.ShowTrajectory(_cardMovement.gameObject.transform.position, _force);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    public void AddScore(int score)
    {
        _score += score;
        scoreText.text = "Score: " + _score;
    }
}
