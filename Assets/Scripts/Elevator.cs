using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    private Transform _startPosition, _endPosition;

    [SerializeField]
    private float _speed = 2f;

    private bool _goingDown;
    public void CallElevator()
    {
        _goingDown = !_goingDown;
    }

    private void FixedUpdate()
    {
        if (_goingDown == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _endPosition.position, _speed * Time.deltaTime);
        }
        else if (_goingDown == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPosition.position, _speed * Time.deltaTime);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other != null)
            {
            other.transform.parent = gameObject.transform;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other != null)
            {
                other.transform.parent = null;
            }
        }
    }

}
