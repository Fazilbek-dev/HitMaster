using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _targetPos;
    [SerializeField] private Vector3 _offsetPos;
    [SerializeField] private Vector3 _offsetRot;

    private Vector3 _origanlPos;
    private Vector3 _followPos;

    private void Awake()
    {
        _origanlPos = new Vector3();
        _followPos = new Vector3();
        _origanlPos = this.transform.position;
        _followPos = _origanlPos;
    }

    private void Update()
    {
        _followPos = new Vector3(_targetPos.position.x - _offsetPos.x, this.transform.position.y - _offsetPos.y, _targetPos.position.z - _offsetPos.z);
        this.transform.position = _followPos;
        this.transform.eulerAngles = new Vector3(this.transform.rotation.x - _offsetRot.x, this.transform.rotation.y - _offsetRot.y, this.transform.rotation.z - _offsetRot.z);
    }
}
