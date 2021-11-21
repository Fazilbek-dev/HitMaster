using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    public GameObject[] _checkPoints;
    public bool _canMove;
    public List<GameObject> _enemyLevel1;
    public List<GameObject> _enemyLevel2;
    public GameObject[] _guns;
    public Transform _bulletSpawnPos;
    public GameObject _bullet;
    public int _checkPointLevel;
    public bool _enemyDie;
}
