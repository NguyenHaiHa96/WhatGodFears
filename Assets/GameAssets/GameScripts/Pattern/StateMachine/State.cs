using System.Collections;

public abstract class State<T>
{
    public abstract void OnEnter(T go);

    public abstract void OnExecute(T go);

    public abstract void OnExit(T go);
}

public class StateMachine<T>
{
    private T owner;
    private State<T> currentState;
    private State<T> previousState;
    private State<T> controlState;
    private State<T> globalState;
    private State<T> nextState;


    public State<T> CurrentState { get { return currentState; } }
    public State<T> PreviousState { get { return previousState; } }
    public State<T> NextState { get { return nextState; } }
    public State<T> ControlState { get { return controlState; } }
    public State<T> GlobalState { get { return globalState; } }
    public bool isInState(State<T> st) { return (currentState == st) ? true : false; }
    public void SetCurrentState(State<T> state) { currentState = state; }
    public void SetPreviousState(State<T> state) { previousState = state; }
    public void SetControlState(State<T> state) { controlState = state; }
    public void SetGlobalState(State<T> state) { globalState = state; }

    public StateMachine(T owner)
    {
        this.owner = owner;
        currentState = null;
        previousState = null;
        globalState = null;
    }

    public void Update()
    {
        //if (GameManager.Instance.IsPauseGame()) return;
        globalState?.OnExecute(owner);
        currentState?.OnExecute(owner);
        controlState?.OnExecute(owner);
    }

    public void ChangeState(State<T> newState)
    {
        previousState = currentState;
        currentState.OnExit(owner);
        currentState = newState;
        currentState.OnEnter(owner);
    }

    public void RevertToPreviousState()
    {
        ChangeState(previousState);
    }
}