using System.Linq;

namespace SharpLogic;

public abstract class StateProvidingExpression : ILogicExpression
{
    private class And(StateProvidingExpression left, ILogicExpression right) : StateProvidingExpression, BinaryExpression
    {
        public char Op => '+';
        public ILogicExpression Left => left;
        public ILogicExpression Right => right;

        public override string GetLogic() => $"{left.GetLogic()} + {right.GetLogic()}";
    }

    private class Or(StateProvidingExpression left, ILogicExpression right) : StateProvidingExpression, BinaryExpression
    {
        public char Op => '|';
        public ILogicExpression Left => left;
        public ILogicExpression Right => right;

        public override string GetLogic() => $"({string.Join(" | ", BinaryFlattener.Flatten(this).Select(x => x.GetLogic())})";
    }

    public abstract string GetLogic();

    public static StateProvidingExpression operator +(StateProvidingExpression left, StateModifyingExpression right)
    {
        return new And(left, right);
    }

    public static StateProvidingExpression operator +(StateProvidingExpression left, BoolExpression right)
    {
        // todo - make this commutative
        return new And(left, right);
    }

    public static StateProvidingExpression operator |(StateProvidingExpression left, StateProvidingExpression right)
    {
        return new Or(left, right);
    }
}
