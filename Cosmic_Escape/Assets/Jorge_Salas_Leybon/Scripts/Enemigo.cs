using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemigo : MonoBehaviour
{
    Animator anim;
    private string currentState = "Idle";
    private bool running = false;

    NavMeshAgent agent;
    public Transform Player;
    public float DetectionRadius = 10f;

    public string SceneName;

    private float DistanceToPlayer;

    private bool _playerDetected = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        DistanceToPlayer = Vector3.Distance(Player.position, transform.position);

        if (DistanceToPlayer <= DetectionRadius)
        {
            agent.SetDestination(Player.transform.position);
            _playerDetected = true;
            running = true;
        }
        else if (_playerDetected)
        {
            agent.SetDestination(Player.position);
        }

        var state = GetState();
        if (state.Equals(currentState))
        {
            return;
        }
        currentState = state;
        anim.CrossFade(currentState, 0.2f, 0);
    }

    private string GetState()
    {
        if (running)
        {
            return "Run";
        }
        return "Idle";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            SceneManager.LoadScene(SceneName);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DetectionRadius);
    }
}
