using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Platform : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    [SerializeField] private List<Transform> positions;

    private Rigidbody rigidbody;
    private int currentPos = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if ((rigidbody.position - positions[currentPos].position).sqrMagnitude > settings.platformTreshold) rigidbody.MovePosition(Vector3.MoveTowards(rigidbody.position, positions[currentPos].position, settings.platformSpeed * Time.fixedDeltaTime));
        else currentPos = (currentPos + 1) % positions.Count;
    }
}
