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
    [SerializeField] bool _canDraw;

    int _curIdWayPoint = 0;
    //int _curIdWayPointForLoop = 0;

    LineRenderer _line;

    private void Start()
    {
        _currentWayPoint = transform.position;
        _wayPoints.Add(transform.position);
     
        _slider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        _line = GetComponent<LineRenderer>();
        
        
        
    }


    private void Update()
    {
        _speed = _slider.value;
        
        if(_wayPoints.Count >= 2)
        {
            
            if (Vector3.Distance(transform.position, _currentWayPoint) <= 0.1)
            {
                _canDraw = true;
                _currentWayPoint = _wayPoints[_curIdWayPoint];
                if (_curIdWayPoint < _wayPoints.Count - 1)//Чтобы индекс не стал длинее массива
                    _curIdWayPoint++;
            }
            else
            {
                _canDraw = false;
            }

            transform.position = Vector3.MoveTowards(
            transform.position,
            _currentWayPoint,
            _speed * Time.deltaTime);

            _line.positionCount = _curIdWayPoint;

            for (int index = 0; index < _curIdWayPoint; index++)
            {

                Vector3 posPoint = _wayPoints[index];
                posPoint.z = -1;

                _line.SetPosition(index, posPoint);//Т.к. вначале добавил один

            }
            
        }
        
                
    }


}
