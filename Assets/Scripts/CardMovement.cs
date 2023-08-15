using UnityEngine;

public class CardMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float force = 33;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(Vector3.forward * force, ForceMode.Impulse);
    }
}
