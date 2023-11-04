using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] Gravity _gravityScript;

    private Rigidbody _rigidbody;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Move();
    }

    private void FixedUpdate()
    {
        _gravityScript.CalculationOfPlanetaryGravityOnTheShip();
    }    

    private void Move()
    {
        _rigidbody.AddForce(transform.forward * _startSpeed);
    }

    public void Death()
    {
        Destroy(gameObject, 0.4f);
    }
}

