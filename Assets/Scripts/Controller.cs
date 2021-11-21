using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Controller : Model
{
    [SerializeField] private float _distanceNewPoint;

    private NavMeshAgent _agent;
    private Animator _anim;

    private bool _firstEnemy;
    private bool _secondEnemy;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        for(int i = 0; i < 10; i++)
        {
            _bullet = Instantiate(_bullet, _bulletSpawnPos.position, _bulletSpawnPos.rotation) as GameObject;
            _bullet.SetActive(false);
        }
        _anim.SetBool("State", true);
    }

    private void Update()
    {
        TouchMove(_checkPoints[_checkPointLevel].transform.position, _canMove);
        EnemyDetected();
        Finished();
    }

    public void Finished()
    {
        float distance = Vector3.Distance(this.transform.position, _checkPoints[2].transform.position);
        if (distance < _distanceNewPoint)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EnemyDetected()
    {
        float distance = Vector3.Distance(this.transform.position, _checkPoints[_checkPointLevel].transform.position);
        if (distance < _distanceNewPoint)
        {
            _anim.SetBool("State", true);
            if (_enemyLevel1[0] == null && _enemyLevel1[1] == null && _enemyLevel1[2] == null && !_firstEnemy)
            {
                _checkPointLevel++;
                _firstEnemy = true;
                _anim.SetBool("State", false);
                _agent.SetDestination(_checkPoints[_checkPointLevel].transform.position);
            }
            if (_enemyLevel2[0] == null && _enemyLevel2[1] == null && _enemyLevel2[2] == null && !_secondEnemy)
            {
                _checkPointLevel++;
                _secondEnemy = true;
                _anim.SetBool("State", false);
                _agent.SetDestination(_checkPoints[_checkPointLevel].transform.position);
            }
            TouchShoot();
        }
    }

    public void TouchMove(Vector3 checkPointPosition, bool canMove)
    {
        foreach(Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                _anim.SetBool("State", false);
                _agent.SetDestination(checkPointPosition);
            }
        }
    }

    public void TouchShoot()
    {
        if (Input.touchCount > 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out hit))
            {
                this.transform.LookAt(hit.transform.position);
                StartCoroutine(WaitTimeShoot());
            }
        }
    }

    IEnumerator WaitTimeShoot()
    {
        _bullet.transform.position = _bulletSpawnPos.position;
        _bullet.transform.rotation = _bulletSpawnPos.rotation;
        _bullet.SetActive(true);
        yield return new WaitForSeconds(1f);
    }
}
