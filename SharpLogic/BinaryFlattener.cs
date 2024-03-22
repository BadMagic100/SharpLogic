using System.Collections.Generic;

namespace SharpLogic;

internal interface BinaryExpression
{
    internal char Op { get; }
    internal ILogicExpression Left { get; }
    internal ILogicExpression Right { get; }
}

internal static class BinaryFlattener
{
    public static IEnumerable<ILogicExpression> Flatten(BinaryExpression expr)
    {
        if (expr.Left is BinaryExpression e1 && e1.Op == expr.Op)
        {
            foreach (ILogicExpression n in Flatten(e1))
            {
                yield return n;
            }
        }
        else
        {
            yield return expr.Left;
        }

        if (expr.Right is BinaryExpression e2 && e2.Op == expr.Op)
        {
            foreach (ILogicExpression n in Flatten(e2))
            {
                yield return n;
            }
        }
        else
        {
            yield return expr.Right;
        }
    }
}
