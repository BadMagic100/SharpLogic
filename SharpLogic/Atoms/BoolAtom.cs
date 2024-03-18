namespace SharpLogic.Atoms;
public abstract class BoolAtom : BoolLogicExpression
{
    public BoolAtom OrElse(BoolAtom other) => new BoolCoalescingAtom(this, other);

    public static implicit operator BoolAtom(bool value) => new BoolConstant(value);
}
