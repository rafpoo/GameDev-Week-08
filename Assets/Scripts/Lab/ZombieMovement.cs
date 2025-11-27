using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ZombieMovement : MonoBehaviour
{
    [Header("References")]
    public Animator anim;
    public PathFinding pathfinder;
    public Transform hero;

    [Header("Settings")]
    public float speed = 2f;
    public float rotationSpeed = 5f;
    public float detectionRange = 10f;
    public float attackRange = 2f;

    private CharacterController controller;
    private List<Node> path;
    private int targetIndex = 0;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        InvokeRepeating(nameof(UpdatePath), 0f, 0.5f); // update path tiap 0.5 detik
    }

    void UpdatePath()
    {
        if (pathfinder == null || hero == null) return;

        float distanceToHero = Vector3.Distance(transform.position, hero.position);
        if (distanceToHero <= detectionRange)
        {
            path = pathfinder.FindPath(transform.position, hero.position);
            targetIndex = 0;
            anim.SetBool("IsWalking", path != null && path.Count > 0);
        }
        else
        {
            path = null;
            anim.SetBool("IsWalking", false);
        }
    }

    void Update()
    {
        if (anim.GetBool("IsDead")) return;

        if (path != null && path.Count > 0)
        {
            MoveAlongPath();
        }

        // Check attack
        float distanceToHero = Vector3.Distance(transform.position, hero.position);
        if (distanceToHero <= attackRange)
        {
            anim.SetBool("IsAttacking", true);
            anim.SetBool("IsWalking", false);
        }
        else
        {
            anim.SetBool("IsAttacking", false);
        }
    }

    void MoveAlongPath()
    {
        if (targetIndex >= path.Count) return;

        Vector3 targetPos = path[targetIndex].worldPosition;
        Vector3 moveDir = (targetPos - transform.position);
        moveDir.y = 0; // agar tidak naik/turun
        Vector3 move = moveDir.normalized * speed;

        // Rotate smoothly
        if (moveDir != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }

        // Move using CharacterController
        controller.Move(move * Time.deltaTime);

        // Check if reached node
        if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                             new Vector3(targetPos.x, 0, targetPos.z)) < 0.3f)
        {
            targetIndex++;
        }
    }
}




