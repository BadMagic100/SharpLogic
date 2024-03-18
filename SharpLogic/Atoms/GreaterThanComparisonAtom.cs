namespace SharpLogic.Atoms;
internal class GreaterThanComparisonAtom(BoolTerm term, int amount) : BoolAtom
{
    public override string GetLogic() => $"{term}>{amount}";
}
