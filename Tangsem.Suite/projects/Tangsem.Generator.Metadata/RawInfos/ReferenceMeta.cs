namespace Tangsem.Generator.Metadata.RawInfos
{
    public class ReferenceMeta
    {
        public HandleMany Many { get; set; }
    }

    public enum HandleMany
    {
        Unknown = 0,

        Skip = 1,

    }
}