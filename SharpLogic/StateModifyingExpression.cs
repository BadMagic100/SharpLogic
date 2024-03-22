using System.Linq;

namespace SharpLogic;
public abstract class StateModifyingExpression : ILogicExpression
{
    private class And(StateModifyingExpression left, ILogicExpression right) : StateModifyingExpression, BinaryExpression
    {
        public char Op => '+';
        public ILogicExpression Left => left;
        public ILogicExpression Right => right;

        public override string GetLogic() => $"{left.GetLogic()} + {right.GetLogic()}";
    }

    private class Or(StateModifyingExpression left, ILogicExpression right) : StateModifyingExpression, BinaryExpression
    {
        public char Op => '|';
        public ILogicExpression Left => left;
        public ILogicExpression Right => right;

        public override string GetLogic() => $"({string.Join(" | ", BinaryFlattener.Flatten(this).Select(x => x.GetLogic())})";
    }

    public abstract string GetLogic();

    public static StateModifyingExpression operator +(StateModifyingExpression left, StateModifyingExpression right)
    {
        return new And(left, right);
    }

    public static StateModifyingExpression operator +(StateModifyingExpression left, BoolExpression right)
    {
        // todo - make this commutative
        return new And(left, right);
    }

    public static StateModifyingExpression operator |(StateModifyingExpression left, StateModifyingExpression right)
    {
        return new Or(left, right);
    }
}
