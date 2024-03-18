namespace SharpLogic.Atoms;
public abstract class StatefulAtom : StatefulLogicExpression
{
    public StatefulAtom OrElse(StatefulAtom other) => new StatefulCoalescingAtom(this, other);

    public BoolLogicExpression ToBool() => new ProjectionAtom(this);
}
