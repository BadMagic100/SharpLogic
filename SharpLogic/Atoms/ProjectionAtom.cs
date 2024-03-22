namespace SharpLogic.Atoms;
internal class ProjectionAtom(StateProvidingAtom inner) : BoolAtom
{
    public override string GetLogic() => inner.GetLogic() + "/";
}
