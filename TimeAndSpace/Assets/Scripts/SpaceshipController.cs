using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _accleration;
    [SerializeField] private float _maxOxygen = 100f; 
    
    [SerializeField] Gravity _gravityScript;

    private float _currentOxygen;
    private Rigidbody _rigidbody;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Move();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GiveAccleration();
        }
    }

    private void FixedUpdate()
    {
        _gravityScript.CalculationOfPlanetaryGravityOnTheShip();
    }    

    private void Move()
    {
        _rigidbody.AddForce(transform.forward * _startSpeed);
    }

    public void GiveAccleration()
    {
        _rigidbody.AddForce(transform.forward * _accleration, ForceMode.Acceleration);
    }

    public void Death()
    {
        Destroy(gameObject, 0.4f);
    }

}

