namespace SharpLogic.Atoms;
internal class ProjectionAtom(StatefulAtom inner) : BoolAtom
{
    public override string GetLogic() => inner.GetLogic() + "/";
}
