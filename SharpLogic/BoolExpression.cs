using System.Linq;

namespace SharpLogic;
public abstract class BoolExpression : ILogicExpression
{
    private class WrappingBoolExpr(ILogicExpression inner) : BoolExpression
    {
        public override string GetLogic() => inner.GetLogic();
    }
    private class And(BoolExpression left, ILogicExpression right) : BoolExpression, BinaryExpression
    {
        public char Op => '+';
        public ILogicExpression Left => left;
        public ILogicExpression Right => right;

        public override string GetLogic() => $"{left.GetLogic()} + {right.GetLogic()}";
    }

    private class Or(BoolExpression left, ILogicExpression right) : BoolExpression, BinaryExpression
    {
        public char Op => '|';
        public ILogicExpression Left => left;
        public ILogicExpression Right => right;

        public override string GetLogic() => $"({string.Join(" | ", BinaryFlattener.Flatten(this).Select(x => x.GetLogic())})";
    }

    public abstract string GetLogic();

    public static BoolExpression operator +(BoolExpression left, BoolExpression right)
    {
        return new And(left, right);
    }

    public static BoolExpression operator |(BoolExpression left, BoolExpression right)
    {
        return new Or(left, right);
    }
}
