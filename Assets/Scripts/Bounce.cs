using UnityEngine;

public class Bounce : MonoBehaviour
{
    #region --Fields / Properties--

    /// <summary>
    /// How fast the ball should move.
    /// </summary>
    [SerializeField]
    private float _speed;
    
    /// <summary>
    /// How fast the ball is moving and in what direction.
    /// </summary>
    private Vector3 _velocity;
    
    /// <summary>
    /// Cached Transform component.
    /// </summary>
    private Transform _transform;
    
    #endregion
    
    #region --Unity Specific Methods--

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter(Collision _other)
    {
        _velocity = Vector3.Reflect(_velocity, _other.contacts[0].normal);
    }
    
    #endregion
    
    #region --Custom Methods--

    /// <summary>
    /// Initializes variables and caches components.
    /// </summary>
    private void Init()
    {
        _transform = transform;
        _velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    /// <summary>
    /// Handles movement of the ball.
    /// </summary>
    private void Move()
    {
        _transform.position += _velocity * _speed;
    }
    
    #endregion
    
}