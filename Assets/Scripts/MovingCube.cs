using UnityEngine;

public class MovingCube : MonoBehaviour
{
    [SerializeField] private float movementWidth = 5f; // distance to move left and right
    [SerializeField] private float maxMovementSpeed = 0.3f; // max between 0f-1f

    private float moveSpeed;
    private float currentPosition; // between -1 and 1
    private Vector3 initialPosition; // in world space
    private bool isMovingRight;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Random.Range(maxMovementSpeed / 10f, maxMovementSpeed);
        currentPosition = 0;
        initialPosition = transform.position;
        isMovingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        // move right or left, turning at the ends
        if (isMovingRight) {
            currentPosition += moveSpeed;
            if (currentPosition > 1f) {
                currentPosition = 1f;
                isMovingRight = false;
            }
        } else {
            currentPosition -= moveSpeed;
            if (currentPosition < -1f) {
                currentPosition = -1f;
                isMovingRight = true;
            }
        }
        // apply position accordingly
        transform.position = new Vector3(initialPosition.x + (currentPosition * movementWidth),
            initialPosition.y, initialPosition.z);
    }
}
