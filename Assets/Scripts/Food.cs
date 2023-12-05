using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{


    [SerializeField]
    private ScoreManager scoreManager;
    public BoxCollider2D gridArea;
    
    [SerializeField] private ParticleSystem boom;


    [SerializeField]
    private LayerMask layerMask;

    private void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        var newPos = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);

        int safelock = 0;
        while (Physics2D.OverlapCircle(newPos, 0.2f, layerMask) && safelock < 100)
        {
            safelock++;
            newPos = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
        }

        this.transform.position = newPos;

    }
    IEnumerator courutineA()
    {
        yield return new WaitForSeconds(0.1f);
        yield return StartCoroutine(corutineB());
    }

    IEnumerator corutineB()
    {
        yield return new WaitForSeconds(0.1f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        boom.Play();
        ScoreManager.instance.AddPoint();
        if (other.tag == "Player") {
              RandomizePosition();
        }
      ScoreManager.instance.timeValue += 3;
    }
}
