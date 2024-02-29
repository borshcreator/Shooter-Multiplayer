using Colyseus.Schema;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 _targetPosition;
    [SerializeField] private float _lerpSpeed = 3f;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _targetPosition, _lerpSpeed * Time.deltaTime);
    }

    public void OnChange(List<DataChange> changes)
    {
        Vector3 position = transform.position;
        Vector3 prevPositon = transform.position;

        foreach (var dataChange in changes)
        {
            switch(dataChange.Field)
            {
                case "x":
                    position.x = (float)dataChange.Value;
                    prevPositon.x = (float)dataChange.PreviousValue;
                    break;
                case "y":
                    position.z = (float)dataChange.Value;
                    prevPositon.z = (float)dataChange.PreviousValue;
                    break;
                default:
                    Debug.LogWarning("Не обрабатывается измнение поля" + dataChange.Field);
                    break;
            }
        }

        Vector3 dir = position - prevPositon;
        _targetPosition = position + dir;
    }
}
