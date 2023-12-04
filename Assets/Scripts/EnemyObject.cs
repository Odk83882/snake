using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{

    [SerializeField] private ParticleSystem deathParticles;
    [SerializeField]
    public BoxCollider2D gridArea;
    

        private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private void Start()
    {
        RandomizePosition();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        deathParticles.Play();
        if (other.tag == "Player") 
        {
              RandomizePosition();
        }
      ScoreManager.instance.timeValue -= 2;
    }
}