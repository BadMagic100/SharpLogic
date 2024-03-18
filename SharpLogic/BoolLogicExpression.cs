namespace SharpLogic;
public abstract class BoolLogicExpression : ILogicExpression
{
    public abstract string GetLogic();

    public static BoolLogicExpression operator &(BoolLogicExpression left, BoolLogicExpression right) => new BooleanAnd(left, right);

    public static BoolLogicExpression operator |(BoolLogicExpression left, BoolLogicExpression right) => new BooleanOr(left, right);
}

internal class BooleanAnd(BoolLogicExpression left, BoolLogicExpression right) : BoolLogicExpression
{
    public override string GetLogic() => $"{left.GetLogic()} + {right.GetLogic()}";
}

internal class BooleanOr(BoolLogicExpression left, BoolLogicExpression right) : BoolLogicExpression
{
    // todo - try and flatten this out to remove unneeded parens
    public override string GetLogic() => $"({left.GetLogic()} | {right.GetLogic()})";
}
