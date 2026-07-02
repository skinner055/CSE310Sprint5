using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public Transform playerSpawn;

    public Transform[] teleportCorners;

    public float lookDotThreshold = 0.95f;
    public float freezeTime = 2f;

    // Distance at which the enemy catches the player.
    public float catchDistance = 1.5f;

    private NavMeshAgent agent;
    private Camera playerCamera;

    private bool teleporting = false;
    private bool catching = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerCamera = Camera.main;

        TeleportRandom();
    }

    void Update()
    {
        if (teleporting || catching)
            return;

        agent.SetDestination(player.position);

        CheckIfPlayerLooking();

        CheckCatchPlayer();
    }

    void CheckCatchPlayer()
    {
        if (Vector3.Distance(transform.position, player.position) <= catchDistance)
        {
            StartCoroutine(CatchPlayer());
        }
    }

    void CheckIfPlayerLooking()
    {
        if (teleporting)
            return;

        Vector3 directionToEnemy =
            (transform.position - playerCamera.transform.position).normalized;

        float dot = Vector3.Dot(playerCamera.transform.forward, directionToEnemy);

        if (dot > lookDotThreshold)
        {
            Ray ray = new Ray(playerCamera.transform.position,
                              playerCamera.transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    StartCoroutine(TeleportRoutine());
                }
            }
        }
    }

    IEnumerator TeleportRoutine()
    {
        teleporting = true;

        agent.isStopped = true;

        yield return new WaitForSeconds(freezeTime);

        TeleportRandom();

        agent.isStopped = false;
        teleporting = false;
    }

    IEnumerator CatchPlayer()
    {
        catching = true;

        agent.isStopped = true;

        CharacterController cc = player.GetComponent<CharacterController>();

        if (cc != null)
            cc.enabled = false;

        player.position = playerSpawn.position;

        if (cc != null)
            cc.enabled = true;

        yield return null;

        TeleportRandom();

        agent.isStopped = false;

        yield return new WaitForSeconds(1f);

        catching = false;
    }

    void TeleportRandom()
    {
        if (teleportCorners.Length == 0)
            return;

        int random = Random.Range(0, teleportCorners.Length);

        agent.ResetPath();
        agent.Warp(teleportCorners[random].position);
    }
}