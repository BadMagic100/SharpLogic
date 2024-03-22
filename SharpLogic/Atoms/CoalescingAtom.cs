namespace SharpLogic.Atoms;

internal class StateProvidingCoalescingAtom(StateProvidingAtom preferred, StateProvidingAtom alternative) : StateProvidingAtom
{
    public override string GetLogic() => $"{preferred.GetLogic()} ? {alternative.GetLogic()}";
}

internal class StateModifyingCoalescingAtom(StateModifyingAtom preffered, StateModifyingAtom alternative) : StateModifyingAtom
{
    public override string GetLogic() => $"{preffered.GetLogic()} ? {alternative.GetLogic()}";
}

internal class BoolCoalescingAtom(BoolAtom preferred, BoolAtom alternative) : BoolAtom
{
    public override string GetLogic() => $"{preferred.GetLogic()} ? {alternative.GetLogic()}";
}
