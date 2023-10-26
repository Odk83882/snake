using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    [SerializeField]
    private ScoreManager scoreManager;
    
    



    private Vector2 _direction = Vector2.right;
    
    private List<Transform> _segments;
    public Transform segmentPrefab;
    
    public int InitialSize = 4;

    private bool canMoveLeft = false;
    private bool canMoveUp = true;

    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);

        for (int i = 1; i < this.InitialSize; i++) {
            _segments.Add(Instantiate(this.segmentPrefab));
        }

    }

    private void Update()
    {
         if (Input.GetKeyDown(KeyCode.W) && canMoveUp == true) //true because the game started as true
        {
            _direction = Vector2.up;
            canMoveUp = false; //now the player cannot go up or down
            canMoveLeft = true; // so they have to go left or right to make canMoveUp true again
        }
        else if (Input.GetKeyDown(KeyCode.S) && canMoveUp == true) 
        {
            _direction = Vector2.down;
            canMoveUp = false;
            canMoveLeft = true;
        }
        else if (Input.GetKeyDown(KeyCode.A) && canMoveLeft == true) 
        {
            _direction = Vector2.left;
            canMoveUp = true; //now the player can go up or down
            canMoveLeft = false;
        }
        else if (Input.GetKeyDown(KeyCode.D) && canMoveLeft == true) 
        {
            _direction = Vector2.right;
            canMoveUp = true;
            canMoveLeft = false;
        }
    }
    
    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0;  i--) {
            _segments[i].position = _segments[i - 1].position; 
        }
        
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }

    private void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++) {
            Destroy(_segments[i].gameObject);
        } 

        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1; i < this.InitialSize; i++) {
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        ScoreManager.instance.resetScore(); 
        
        this.transform.position = Vector3.zero;
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
    
        _segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food") {
              Grow();
        } else if (other.tag == "Obstacle") {
            ResetState();
        }
        
    }
}