using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 500.0f;

    [SerializeField] float maxLifeTime = 10.0f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifeTime);
    }
}
