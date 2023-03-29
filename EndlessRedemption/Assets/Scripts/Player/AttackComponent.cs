using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _swordTrailUp;
    [SerializeField]
    private GameObject _swordTrail;
    [SerializeField]
    private GameObject _swordTrailDown;
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

    private SoundManager _soundManager;
    public void UpAttack()
    {
        if(!_onUpAttack)
        {
            _swordTrailUp.SetActive(true);
            _onUpAttack = true;
            _animator.SetBool("UpAttack", _onUpAttack);
            GameObject item = Instantiate(_katana, _myUpTransform.position, Quaternion.identity);
            item.transform.parent = gameObject.transform;
            _soundManager.SeleccionAudio(0, 0.5f);
        }
    }
    public void DownAttack()
    {
        if(!_movementComponent._onGround && !_onDownAttack)
        {
            _swordTrailDown.SetActive(true);
            _onDownAttack = true;
            _animator.SetBool("DownAttack", _onDownAttack);
            GameObject item = Instantiate(_katana, _myDownTransform.position, Quaternion.identity);
            item.transform.parent = gameObject.transform;
            item.GetComponent<DamageComponent>()._downAttack = true;
            _soundManager.SeleccionAudio(0, 0.5f);
        }       
    }

    public void HorizontalAttack()
    {
        if(!_onAttack)
        {
           _swordTrail.SetActive(true);
            _swordTrail.transform.Rotate(new Vector3(0, transform.rotation.eulerAngles.y + 180, transform.rotation.eulerAngles.z + 180));
            _onAttack = true;
            _animator.SetBool("Attack", _onAttack);                      
            GameObject item = Instantiate(_katana, _myTransform.position, Quaternion.identity);
            item.transform.parent = gameObject.transform;
            _soundManager.SeleccionAudio(0, 0.5f);
        }
      
        
    }
    public void EndOfAttack()
    {
        _swordTrailUp.SetActive(false);
        _swordTrailDown.SetActive(false);
        _swordTrail.SetActive(false);
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
        _soundManager = FindObjectOfType<SoundManager>();
    }
   
}
