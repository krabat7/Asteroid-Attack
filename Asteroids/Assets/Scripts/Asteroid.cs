using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] Sprite[] _sprites;

    [SerializeField] float size = 1.0f;

    [SerializeField] float minSize = 0.5f;

    [SerializeField] float maxSize = 1.5f;

    private SpriteRenderer _spriteRenderer;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _spriteRenderer.sprite = _sprites[Random.Range(0, _sprites.Length)];

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;
        _rigidbody.mass = this.size;
    }

}
