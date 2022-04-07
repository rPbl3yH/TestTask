using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawn : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]Camera _camera;
    [SerializeField] GameObject _prefabCircle;
    GameObject _currentCircle;
    [SerializeField] List<Vector2> _wayPoints = new List<Vector2>();
    bool _canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void OnMouseDown()
    {

        
    }
    

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 clickPos = eventData.position;
        Debug.Log(clickPos);
        Vector2 clickWorldPos = _camera.ScreenToWorldPoint(clickPos);

        if (_currentCircle)
            _currentCircle.GetComponent<Circle>()._wayPoints.Add(clickWorldPos);

        if (_canSpawn)
        {
            _currentCircle = Instantiate(_prefabCircle, clickWorldPos, Quaternion.identity);
            _canSpawn = false;
        }


    }
}
