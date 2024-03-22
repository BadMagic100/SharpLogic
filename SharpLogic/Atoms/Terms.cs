using System;

namespace SharpLogic.Atoms;
public class BoolTerm : BoolAtom
{
    protected readonly string name;
    internal BoolTerm(string name)
    {
        this.name = name;
    }

    public override string GetLogic() => name;
}

public class IntTerm : BoolTerm
{
    private class GreaterThanComparison(IntTerm term, int amount) : BoolAtom
    {
        public override string GetLogic() => $"{term.name}>{amount}";
    }

    internal IntTerm(string name) : base(name) { }

    public static BoolAtom operator >(IntTerm left, int right) => new GreaterThanComparison(left, right);

    [Obsolete("Using a less-than comparison can result in false positives where the player irreversably loses access to something by gaining items.")]
    public static BoolAtom operator <(IntTerm left, int right) => throw new InvalidOperationException();

    public static BoolAtom operator >=(IntTerm left, int right) => new GreaterThanComparison(left, right - 1);

    [Obsolete("Using a less-than comparison can result in false positives where the player irreversably loses access to something by gaining items.")]
    public static BoolAtom operator <=(IntTerm left, int right) => throw new InvalidOperationException();
}

public class StatefulTerm : StateProvidingAtom
{
    private string name;
    internal StatefulTerm(string name)
    {
        this.name = name;
    }

    public override string GetLogic() => name;
}
