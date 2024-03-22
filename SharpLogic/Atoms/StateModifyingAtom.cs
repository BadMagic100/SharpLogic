namespace SharpLogic.Atoms;
public abstract class StateModifyingAtom : StateModifyingExpression
{
    public StateModifyingAtom OrElse(StateModifyingAtom other) => new StateModifyingCoalescingAtom(this, other);
}
