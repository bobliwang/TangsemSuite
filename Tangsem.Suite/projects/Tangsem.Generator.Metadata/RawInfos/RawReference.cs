using Tangsem.Common.DataAccess;

namespace Tangsem.Generator.Metadata.RawInfos
{
    public class RawReference
    {
        [PropertyColumn("ReferenceName")]
        public string ReferenceName { get; set; }

        [PropertyColumn("ChildTable")]
        public string ChildTable { get; set; }

        [PropertyColumn("ChildColumn")]
        public string ChildColumn { get; set; }

        [PropertyColumn("ParentTable")]
        public string ParentTable { get; set; }

        [PropertyColumn("ParentColumn")]
        public string ParentColumn { get; set; }

        [PropertyColumn("RawComment")]
        public string RawComment { get; set; }

        public dynamic ExtraMetadata { get; set; }
    }
}
