using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce = 5;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        
        _rigidbody.AddForce(new Vector3(horizontal, 0, vertical) * _speed);
        
        //if(Input.GetKeyDown(KeyCode.Space))
        //    _rigidbody.AddForce(new Vector3(0,_jumpForce,0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            GameObject referenceObject;
            ScoreManager referenceScript;
            referenceObject = GameObject.FindGameObjectWithTag("Canvas");
            referenceScript = referenceObject.GetComponent<ScoreManager>();
            referenceScript._score += 1;
        }
        if (other.gameObject.CompareTag("WallCube"))
        {
            var Destroyable = GameObject.FindGameObjectsWithTag("Collectible");
            GameObject referenceObject;
            SpawnPlatform referenceScript;
            WallSpawner referenceScriptTwo;
            ScoreManager referenceScriptThree;
            foreach (var item in Destroyable)
            {
                GameObject.Destroy(item);
            }
            referenceObject = GameObject.FindGameObjectWithTag("Spawner");
            referenceScript = referenceObject.GetComponent<SpawnPlatform>();
            referenceScript._isSpawning = false;
            referenceObject = GameObject.FindGameObjectWithTag("WallSpawner");
            referenceScriptTwo = referenceObject.GetComponent<WallSpawner>();
            referenceScriptTwo._isSpawning = false;
            referenceObject = GameObject.FindGameObjectWithTag("Canvas");
            referenceScriptThree = referenceObject.GetComponent<ScoreManager>();
            referenceScriptThree._vege = " - JÁTÉK VÉGE";

        }
    }
}