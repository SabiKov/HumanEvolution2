using UnityEngine;

/// <summary>
/// Abstract class for game items.
/// </summary>
[RequireComponent(typeof(Collider))]
public abstract class AbstractGameItemController : MonoBehaviour {

    private bool isUp;
    private float originalYPosition;
    private float targetYPosition;


    private float animationTimer;

    public float animationLiftingDistance = 2.0f;
    public float rotationSpeed;
    public float movingSpeed;

    public GameItemTypes gameItemType;
    public GameItemAnimationTypes animationType;

    public void Start()
    {
        this.originalYPosition = this.gameObject.transform.position.y;
        this.targetYPosition = this.originalYPosition - animationLiftingDistance;
    }

    public void Update()
    {
        if(this.animationType == GameItemAnimationTypes.NONE)
            return;

        var deltaT = Time.deltaTime;
        if (this.animationType == GameItemAnimationTypes.ANIM_ROTATE)
            this.StepAnimationRotation(deltaT);
        else if (this.animationType == GameItemAnimationTypes.ANIM_LIFT)
            this.StepAnimationLifting(deltaT);
        else if(this.animationType == GameItemAnimationTypes.BOTH) {
            this.StepAnimationRotation(deltaT);
            this.StepAnimationLifting(deltaT);
        }
    }

    /// <summary>
    /// Control lifting animation
    /// </summary>
    /// <param name="deltaT"></param>
    private void StepAnimationLifting(float deltaT)
    {
        var pos = this.transform.position;
        pos.y = Mathf.Lerp(pos.y, this.targetYPosition, deltaT * this.movingSpeed);
        this.transform.position = pos;

        var distance = Mathf.Abs(targetYPosition - this.transform.position.y);
        if(distance <= 0.02f) {
            isUp = !isUp;
            targetYPosition = (isUp) ? this.originalYPosition + animationLiftingDistance : this.originalYPosition - animationLiftingDistance;
        }
    }

    /// <summary>
    /// Control rotating animation
    /// </summary>
    /// <param name="deltaT"></param>
    private void StepAnimationRotation(float deltaT)
    {
        this.gameObject.transform.Rotate(Vector3.up, deltaT * rotationSpeed);
    }


    protected void DoDestroy()
    {
        Destroy(this.gameObject);
    }

    public void DoItemEffect()
    {
        FireItemEffect();
    }

    /// <summary>
    /// Fire item effect. 
    /// Called when item is picked up.
    /// </summary>
    protected virtual void FireItemEffect()
    {
  //      Debug.Log("Abstract game item is fired!");
        this.DoDestroy();
    }
}
