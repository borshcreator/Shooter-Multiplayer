using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class EnemeyCharacter : Character
{
    private string _sessionID;
    [SerializeField] private Transform _head;
    [SerializeField] private Health _health;

    public Vector3 TargetPosition { get; private set; } = Vector3.zero;
    private float _velocityMagnitude = 0f;

    public void Init(string sessionID)
    {
        _sessionID = sessionID;
    }

    private void Start()
    {
        TargetPosition = transform.position;
    }

    private void Update()
    {
        if (_velocityMagnitude > .1f)
        {
            float maxDistance = _velocityMagnitude * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, maxDistance);
        }
        else
        {
            transform.position = TargetPosition;
        } 
    }

    public void SetSpeed(float value) => Speed = value;

    public void SetMaxHP(int value)
    {
        MaxHealth = value;
        _health.SetMax(value);
        _health.SetCurrent(value);
    }

    public void RestoreHP(int newValue)
    {
        _health.SetCurrent(newValue);
    }

    public void SetMovement(in Vector3 position, in Vector3 velocity, in float averageInterval)
    {
        TargetPosition = position + (velocity * averageInterval);
        _velocityMagnitude = velocity.magnitude;

        this.Velocity = velocity;
    }

    public void ApplyDamage(int damage)
    {
        _health.ApplyDamage(damage);

        Dictionary<string, object> data = new Dictionary<string, object>()
        {
            {"id", _sessionID},
            {"value", damage}
        };

        MultiplayerManager.Instance.SendMessage("damage", data);

    }

    public void SetRotateX(float value)
    {
        _head.localEulerAngles = new Vector3(value, 0f, 0f);
    }

    public void SetRotateY(float value)
    {
        transform.localEulerAngles = new Vector3(0f, value, 0f);
    }
}
