namespace SharpLogic.Atoms;
internal class StatefulCoalescingAtom(StatefulAtom preferred, StatefulAtom alternative) : StatefulAtom
{
    public override string GetLogic() => $"{preferred.GetLogic()} ? {alternative.GetLogic()}";
}

internal class BoolCoalescingAtom(BoolAtom preferred, BoolAtom alternative) : BoolAtom
{
    public override string GetLogic() => $"{preferred.GetLogic()} ? {alternative.GetLogic()}";
}
