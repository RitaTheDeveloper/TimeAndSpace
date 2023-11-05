using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _accleration;
    [SerializeField] Gravity _gravityScript;
    [SerializeField] OxygenController _oxygenControllerScript;

    private Rigidbody _rigidbody;
    private bool isLevelStarted = false;


    private void Start()
    {
        Init();
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
        if (isLevelStarted)
        {
            _gravityScript.CalculationOfPlanetaryGravityOnTheShip();
            _oxygenControllerScript.DescreaceInOxygenInFrame();
        }
    }    

    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
        isLevelStarted = false;
    }

    public void StartMove()
    {
        Move();
        _gravityScript.SetArrayOfPlanets(GameManager.instance.GetArrayOfPlanets());
        isLevelStarted = true;
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

