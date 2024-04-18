namespace YNL.Technic.StateMachine
{
    public abstract class State
    {
        public string Name = "";

        public State(string name)
        {
            Name = name;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }

        public virtual void Transition(string name) { }
    }
}