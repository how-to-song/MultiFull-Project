using UnityEngine;

public class GroundReposition : MonoBehaviour
{
    public float minX = -19f;
    public float groundSpeed = 5f;

    private float currentPositionX;

    private void Awake()
    {
        currentPositionX = transform.position.x;
    }

    private void FixedUpdate()
    {
        currentPositionX -= groundSpeed * Time.deltaTime;
        transform.position = new Vector3(currentPositionX, 0, 0);
        if (currentPositionX < minX)
        {
            transform.position = new Vector3(19f, 0, 0);
            currentPositionX = transform.position.x;
        }
    }
}
