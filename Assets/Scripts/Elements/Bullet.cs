using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float bounceSearcDistance;
    public LayerMask bounceLayerMask;
    private bool _isMoving;

    private Vector3 _direction;
    public void Init(Vector3 dir)
    {
        _direction = dir;
        StartMoving();
    }
    private void Update()
    {
        if (_isMoving)
        {
            transform.position += _direction * Time.deltaTime * speed;
        }
        var col = Physics2D.Raycast(transform.position, _direction, bounceSearcDistance, bounceLayerMask);
        if (col)
        {
            Bounce(col);
        }
    }
    private void Bounce(RaycastHit2D col)
    {
        var newDir = Vector3.Reflect(_direction, col.normal);
        _direction = newDir;
        if (col.transform.CompareTag("Piece"))
        {
            col.transform.GetComponent<Piece>().ReduceHealth();
        }
    }

    private void StartMoving()
    {
        _isMoving = true;
    }


}
