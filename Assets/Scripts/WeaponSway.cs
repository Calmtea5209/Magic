using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public float swaySpeed = 1f;
    public float swayAmount = 1f;
    public float bobbingSpeed = 1f;
    public float bobbingAmount = 1f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.localPosition;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate sway (horizontal movement)
        float swayX = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        float swayY = Mathf.Cos(Time.time * swaySpeed * 2) * swayAmount;

        // Calculate bobbing (vertical movement)
        float bobbingY = Mathf.Sin(Time.time * bobbingSpeed) * bobbingAmount;

        // Apply the calculated positions to the weapon's pivot GameObject
        if(horizontalInput !=0 || verticalInput != 0)
        {
            transform.localPosition = initialPosition + new Vector3(swayX, swayY + bobbingY, 0f);
        }
    }
}
