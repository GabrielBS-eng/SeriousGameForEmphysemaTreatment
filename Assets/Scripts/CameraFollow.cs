using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private float timeLeft = 1.75f;

    void LateUpdate()
    {
        if (PressController.state != PressController.gameState.theEnd)
        {
            transform.position = target.position + offset;
        }
        else
        {
            if (timeLeft > 0)
            {
                transform.position += 3f * new Vector3(0, 1, 0) * Time.deltaTime;
                timeLeft -= Time.deltaTime;
            }
        }     
    }        
}
