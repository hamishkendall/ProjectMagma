using UnityEngine;

public class AnimationHandler : MonoBehaviour {

    public Animator animationHandler;

    void Start()
    {
        animationHandler.SetInteger("State", 2);
    }

    //Animation States: INT
    //0 = idle
    //1 = run
    //2 = attack
    //3 = death

    public void Idle()
    {
        animationHandler.SetInteger("State", 0);
    }

    public void Running()
    {
        animationHandler.SetInteger("State", 1);
    }

    public void Attacking()
    {
        animationHandler.SetInteger("State", 2);
    }

    public void Dead()
    {
        animationHandler.SetInteger("State", 3);
    }
}
