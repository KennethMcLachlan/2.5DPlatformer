using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _panelLight;

    [SerializeField]
    private int _requiredCoins = 8;

    private Elevator _elevator;

    private bool _elevatorCalled;

    private void Start()
    {
        _elevator = GameObject.Find("Elevator").GetComponent<Elevator>();

        if (_elevator == null)
        {
            Debug.LogError("The elevator is NULL");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyUp(KeyCode.E) && other.GetComponent<Player>().CoinTally() >= _requiredCoins)
            {
                if (_elevatorCalled == true)
                {
                    _panelLight.material.color = Color.red;
                }
                else
                {
                    _panelLight.material.color = Color.cyan;
                    _elevatorCalled = true;
                }

                _elevator.CallElevator();
            }
        }
    }
}
