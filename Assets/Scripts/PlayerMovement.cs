using UnityEngine;

public class Script : MonoBehaviour
{
    public Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f; // keep in 2D plane

            targetPosition = mousePos;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            Time.deltaTime * 5f
        );
    }
}