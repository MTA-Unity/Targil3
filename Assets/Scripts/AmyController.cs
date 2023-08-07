using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AmyController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Transform _characterTransform;
    [SerializeField] private Animator _characterAnimator;
    [SerializeField] private float _movementSpeed;

    [Header("Shooting")] 
    [SerializeField] private Transform _shotsOrigin;
    [SerializeField] private float _shootingCooldownDuration;
    [SerializeField] private Image _cooldownImage;
        
    private bool _onCooldown;
    
    // Animation Constants:
    private const string DirectionParameterName = "Direction";
    private const string MovingParameterName = "Moving";
    private const string ShootTriggerParameterName = "ShootTrigger";
    
    private static readonly int Direction = Animator.StringToHash(DirectionParameterName);
    private static readonly int Moving = Animator.StringToHash(MovingParameterName);
    private static readonly int ShootTrigger = Animator.StringToHash(ShootTriggerParameterName);

    // initialization
    private void Awake()
    {
        _cooldownImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var isClickingOnDirection = Input.GetKeyDown(KeyCode.LeftArrow) ||
                                    Input.GetKeyDown(KeyCode.RightArrow) ||
                                    Input.GetKey(KeyCode.LeftArrow) ||
                                    Input.GetKey(KeyCode.RightArrow); // hack for not going through the idle pose

        var horizontalMovementDelta = horizontalInput * _movementSpeed * Time.deltaTime;
        _characterTransform.localPosition += Vector3.right * horizontalMovementDelta;

        _characterAnimator.SetBool(Moving, isClickingOnDirection);
        
        var mappedValue = (horizontalInput + 1) / 2f; //map the Axis -1 to 1 input to 0 to 1.
        _characterAnimator.SetFloat(Direction, mappedValue);

        var isShooting = Input.GetKeyDown(KeyCode.Space);
        if (isShooting)
        {
            if (!_onCooldown)
            {
                Shoot();    
            }
        }
    }

    private void Shoot()
    {
        _characterAnimator.SetTrigger(ShootTrigger);
            
        // todo: create bullet!
            
        StartCoroutine(ShootingCooldown());
    }

    private IEnumerator ShootingCooldown()
    {
        var elapsedTime = 0f;
        _cooldownImage.fillAmount = 1f;
        _onCooldown = true;
            
        while (elapsedTime < _shootingCooldownDuration)
        {
            _cooldownImage.fillAmount = Mathf.Lerp(1, 0, elapsedTime / _shootingCooldownDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _cooldownImage.fillAmount = 0;
        _onCooldown = false;
    }
}