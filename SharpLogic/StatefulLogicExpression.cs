namespace SharpLogic;

public abstract class StatefulLogicExpression : ILogicExpression
{
    public abstract string GetLogic();

    public static StatefulLogicExpression operator &(StatefulLogicExpression left, ILogicExpression right) => new StatefulAnd(left, right);
    public static StatefulLogicExpression operator &(ILogicExpression left, StatefulLogicExpression right) => new StatefulAnd(left, right);
    public static StatefulLogicExpression operator |(StatefulLogicExpression left, ILogicExpression right) => new StatefulOr(left, right);
    public static StatefulLogicExpression operator |(ILogicExpression left, StatefulLogicExpression right) => new StatefulOr(left, right);
}

internal class StatefulAnd(ILogicExpression left, ILogicExpression right) : StatefulLogicExpression
{
    public override string GetLogic() => $"{left.GetLogic()} + {right.GetLogic()}";
}

internal class StatefulOr(ILogicExpression left, ILogicExpression right) : StatefulLogicExpression
{
    // todo - try and flatten this out to remove unneeded parens
    public override string GetLogic() => $"({left.GetLogic()} | {right.GetLogic()})";
}
