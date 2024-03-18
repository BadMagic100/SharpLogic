namespace SharpLogic.Atoms;
internal class BoolConstant(bool value) : BoolAtom
{
    public override string GetLogic() => value.ToString().ToUpper();
}
