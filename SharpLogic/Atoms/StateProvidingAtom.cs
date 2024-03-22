namespace SharpLogic.Atoms;
public abstract class StateProvidingAtom : StateProvidingExpression
{
    public StateProvidingAtom OrElse(StateProvidingAtom other) => new StateProvidingCoalescingAtom(this, other);

    public BoolExpression ToBool() => new ProjectionAtom(this);
}
