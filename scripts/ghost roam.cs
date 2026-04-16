using UnityEngine;

public class GhostRoam : MonoBehaviour
{
    public float speed = 2f;
    public float roamDistance = 5f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float movement = Mathf.Sin(Time.time) * roamDistance;
        transform.position = startPos + new Vector3(movement, 0, 0);
    }
}