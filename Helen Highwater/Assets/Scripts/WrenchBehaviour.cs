using UnityEngine;
using System.Collections;

public class WrenchBehaviour : MonoBehaviour
{
    public float flightSpeed = 10f;     // speed of the boomerang moving forward and back
    public float maxDistance = 5f;      // distance the boomerang travels before pausing
    public float pauseTime = 0.5f;      // time the boomerang stays at the peak position

    private Vector3 startPosition;      // start position of the boomerang
    private Vector3 targetPosition;     // point where the boomerang will pause
    private Transform player;           // reference to the player's transform
    private bool returning = false;     // whether the boomerang is returning

    void Start()
    {
        startPosition = transform.position;
        // TODO: update the direction based on the player's facing direction once implemented
        targetPosition = startPosition + transform.right * maxDistance; // always moves right
        player = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(BoomerangRoutine());
    }

    IEnumerator BoomerangRoutine()
    {
        // 1. move to the target position
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, flightSpeed * Time.deltaTime);
            yield return null;
        }

        // 2. pause at the peak position
        yield return new WaitForSeconds(pauseTime);

        // 3. return to the player
        returning = true;
        while (Vector3.Distance(transform.position, player.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, flightSpeed * Time.deltaTime);
            yield return null;
        }

        // destroy when reaching the player
        Destroy(gameObject);
    }
}
