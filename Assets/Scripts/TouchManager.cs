using UnityEngine;

public class TouchManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            gameManager.MoveCard();
        }

        if (Input.touchCount <= 0) return;

        
        var delta = Input.GetTouch(0).deltaPosition;

        gameManager.Swipe(delta.x);
    }
}