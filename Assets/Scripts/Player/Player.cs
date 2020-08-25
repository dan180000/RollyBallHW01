using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BallMotor))]
public class Player : MonoBehaviour
{
    //TODO offload health into a Health.cs script
    [SerializeField] int maxHealth = 3;
    [SerializeField] int treasureCount = 0;
    [SerializeField] GameObject TreasureNumber;

    private MeshRenderer invinciblemesh;
    public Material invinciblemat;

    int currentHealth;
    int currentTreasure;
    float powerupDuration;

    BallMotor _ballMotor;

    private void Awake()
    {
        _ballMotor = GetComponent<BallMotor>();
        invinciblemesh = GetComponent<MeshRenderer>();
        TreasureNumber = GameObject.FindGameObjectWithTag("Treasure Number");
    }

    private void Start()
    {
        currentHealth = maxHealth;
        currentTreasure = treasureCount;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        ProcessMovement();
    }


    private void ProcessMovement()
    {
        //TODO move into Input script
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        _ballMotor.Move(movement);
    }

    public void IncreaseHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Player's health: " + currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player's health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    public void IncreaseTreasure(int amount)
    {
        Text treasureNumber = TreasureNumber.GetComponent(typeof(Text)) as Text;
        treasureNumber.text = currentTreasure.ToString();
        currentTreasure += amount;
        Debug.Log("Treasure Count: " + currentTreasure);
    }

    public void PowerUp(int amount)
    {
        powerupDuration -= Time.deltaTime;
        invinciblemesh.material = invinciblemat;
        Debug.Log("Player's health: Invincible!");
        if (powerupDuration > 0)
        {
            currentHealth += 1;
        }
    }

    public void PowerDown(int amount)
    {
        if (powerupDuration <= 0)
        {
            currentHealth = maxHealth;
            Debug.Log("Power Down");
        }
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        //play particles
        //play sounds
    }

    /*public void Bounce()
    {
        _ballMotor.Move(transform.position);
        Debug.Log("Bounce!");
    }
    */
}
