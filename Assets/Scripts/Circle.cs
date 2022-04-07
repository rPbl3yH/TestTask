using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Vector2 _currentWayPoint;
    public List<Vector2> _wayPoints = new List<Vector2>();
    [SerializeField] Slider _slider;

    int _curIdWayPoint = 0;

    LineRenderer _line;

    private void Start()
    {
        _currentWayPoint = transform.position;
        _wayPoints.Add(transform.position);
     
        _slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        _line = GetComponent<LineRenderer>();
        _line.positionCount = 0;


        
    }


    private void Update()
    {
        _speed = _slider.value;
        
        if(_curIdWayPoint >= 1)
        {
            
            if (Vector3.Distance(transform.position, _currentWayPoint) <= 0.1)
            {

                _currentWayPoint = _wayPoints[_curIdWayPoint];
                if (_curIdWayPoint < _wayPoints.Count)
                    _curIdWayPoint++;
            }

            transform.position = Vector3.MoveTowards(
            transform.position,
            _currentWayPoint,
            _speed * Time.deltaTime);
            
        }
        else
        {
            _curIdWayPoint = _wayPoints.Count - 1;
        }
                
    }


}
