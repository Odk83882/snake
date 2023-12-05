using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{

    [SerializeField] private ParticleSystem deathParticles;
    [SerializeField]
    public BoxCollider2D gridArea;
    public SpriteRenderer enemy;
    [SerializeField]
    private LayerMask layerMask;
    

    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        var newPos = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);

        int safelock = 0;
        while(Physics2D.OverlapCircle(newPos, 0.2f, layerMask) && safelock < 100)
        {
            safelock++;
            newPos = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
        }

        this.transform.position = newPos;

    }

    private void Start()
    {
        RandomizePosition();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        deathParticles.Play();
        ScoreManager.instance.timeValue -= 2;
        if (other.tag == "Player") 
        {
            StartCoroutine(DeathDelay());
        }
      
    }

    IEnumerator DeathDelay()
    {
        enemy.enabled = false;
        yield return new WaitForSeconds(2f);
        enemy.enabled = true;
        RandomizePosition();
    }
}