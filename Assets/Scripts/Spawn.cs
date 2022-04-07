using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] GameObject _prefabCircle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPos = Input.mousePosition;
            Vector3 spawnPos = _camera.ScreenToWorldPoint(clickPos);
            spawnPos.z = 0;

            GameObject circle = Instantiate(_prefabCircle, spawnPos, Quaternion.identity);
        }
    }
}
