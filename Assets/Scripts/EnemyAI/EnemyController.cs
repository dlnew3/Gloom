using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    private float nextAttackTime = 0f;
    public float attackRate = 5f;
    public AudioSource hitSound;

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance + 1f && Time.time >= nextAttackTime)
            {
                nextAttackTime = Time.time + 1f / attackRate;
                DamagePlayer();
                FaceTarget();
            }
            else if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }

    private void DamagePlayer()
    {
        Player player = PlayerManager.instance.player.GetComponent<Player>();
        Vector3 moveDirection = (target.position - transform.position).normalized;
        player.EnemyDamage(17);
        target.Translate(moveDirection * 75f * Time.deltaTime, Space.World);
        hitSound.Play(0);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
