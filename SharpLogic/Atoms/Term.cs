using System;

namespace SharpLogic.Atoms;
public class BoolTerm : BoolAtom
{
    private string name;
    internal BoolTerm(string name)
    {
        this.name = name;
    }

    public override string GetLogic() => name;

    public static BoolAtom operator >(BoolTerm left, int right) => new GreaterThanComparisonAtom(left, right);

    [Obsolete("Using a less-than comparison can result in false positives where the player irreversably loses access to something by gaining items.")]
    public static BoolAtom operator <(BoolTerm left, int right) => throw new InvalidOperationException();

    public static BoolAtom operator >=(BoolTerm left, int right) => new GreaterThanComparisonAtom(left, right - 1);

    [Obsolete("Using a less-than comparison can result in false positives where the player irreversably loses access to something by gaining items.")]
    public static BoolAtom operator <=(BoolTerm left, int right) => throw new InvalidOperationException();
}

public class StatefulTerm : StatefulAtom
{
    private string name;
    internal StatefulTerm(string name)
    {
        this.name = name;
    }

    public override string GetLogic() => name;
}
