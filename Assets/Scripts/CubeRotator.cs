using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    public enum Direction 
    { 
        Clockwise, 
        CounterClockwise 
    }

    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private int count = 8;

    [SerializeField] private float radius = 3f;
    [SerializeField] private float speed = 90f;
    [SerializeField] private Direction direction;

    [SerializeField] private bool evenlyDistributed = true;
    [SerializeField] private float angleStep = 15f;

    private Transform[] cubes;
    private float baseAngle;
    private float sign;
    private float step;
    private float angle;
    private Vector3 offset;
    private int i;

    private void Awake()
    {
        cubes = new Transform[count];
        for (i = 0; i < count; i++)
        {
            cubes[i] = Instantiate(cubePrefab, transform).transform;
        }
    }

    private void Update()
    {
        sign = direction == Direction.Clockwise ? -1f : 1f;
        baseAngle += sign * speed * Time.deltaTime;

        step = evenlyDistributed ? 360f / count : angleStep;

        for (i = 0; i < count; i++)
        {
            angle = (baseAngle + i * step) * Mathf.Deg2Rad;
            offset.x = Mathf.Cos(angle) * radius;
            offset.z = Mathf.Sin(angle) * radius;
            cubes[i].position = transform.position + offset;
        }
    }
}
