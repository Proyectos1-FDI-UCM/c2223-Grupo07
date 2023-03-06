using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform _myTransform;
    private Transform _myUpTransform;
    private Transform _myDownTransform;
    [SerializeField]
    private GameObject _katana;
    private Animator _animator;
    private MovementComponent _movementComponent;

    public bool _onAttack = false;
    public bool _onUpAttack = false;
    public bool _onDownAttack = false;


    public void UpAttack()
    {
        if(!_onUpAttack)
        {
            _onUpAttack = true;
            _animator.SetBool("UpAttack", _onUpAttack);
            GameObject item = Instantiate(_katana, _myUpTransform.position, Quaternion.identity);
            item.transform.parent = gameObject.transform;

        }
    

             

    }
    public void DownAttack()
    {
        if(!_movementComponent._onGround && !_onDownAttack)
        {
            _onDownAttack = true;
            _animator.SetBool("DownAttack", _onDownAttack);
            GameObject item = Instantiate(_katana, _myDownTransform.position, Quaternion.identity);
            item.transform.parent = gameObject.transform;
            item.GetComponent<DamageComponent>()._downAttack = true;
        }       
    }

    public void HorizontalAttack()
    {
        if(!_onAttack)
        {
            _onAttack = true;
            _animator.SetBool("Attack", _onAttack);
            GameObject item = Instantiate(_katana, _myTransform.position, Quaternion.identity);
            item.transform.parent = gameObject.transform;
        }
      
        
    }
    public void EndOfAttack()
    {     
        _onAttack = false;
        _animator.SetBool("Attack", _onAttack);
        _onUpAttack = false;
        _animator.SetBool("UpAttack", _onUpAttack);
        _onDownAttack = false;
        _animator.SetBool("DownAttack", _onDownAttack);

    }
    void Start()
    {
        _movementComponent = FindObjectOfType<MovementComponent>();
        _myTransform = gameObject.transform.GetChild(3);
        _animator = GetComponentInParent<Animator>();
        _myUpTransform = gameObject.transform.GetChild(4);
        _myDownTransform = gameObject.transform.GetChild(5);
    }

    // Update is called once per frame
   
}
