namespace YNL.Technic.Command
{
    public abstract class Command
    {
        public object Data;

        public abstract void Execute();
    }
}