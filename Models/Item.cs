using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mfiles.Models
{
    public class Item
    {
        public string Title { get; set; }
        public string Fileurl { get; set; }
        public string EscapedTitleWithID { get; set; }
        public string DisplayID { get; set; }
        public ObjVer ObjVer { get; set; }
        public int Class { get; set; }
        public DateTime CheckedOutAtUtc { get; set; }
        public DateTime CheckedOutAt { get; set; }
        public DateTime LastModifiedUtc { get; set; }
        public DateTime LastModified { get; set; }
        public bool ObjectCheckedOut { get; set; }
        public bool ObjectCheckedOutToThisUser { get; set; }
        public int CheckedOutTo { get; set; }
        public bool SingleFile { get; set; }
        public bool HasRelationshipsFrom { get; set; }
        public bool HasRelationshipsTo { get; set; }
        public bool HasRelationshipsFromThis { get; set; }
        public bool HasRelationshipsToThis { get; set; }
        public bool HasAssignments { get; set; }
        public bool Deleted { get; set; }
        public bool IsStub { get; set; }
        public bool ThisVersionLatestToThisUser { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime Created { get; set; }
        public IList<File> Files { get; set; }
        public bool VisibleAfterOperation { get; set; }
        public string PathInIDView { get; set; }
        public string LastModifiedDisplayValue { get; set; }
        public string CheckedOutAtDisplayValue { get; set; }
        public string CreatedDisplayValue { get; set; }
        public int ObjectVersionFlags { get; set; }
        public int Score { get; set; }
        public DateTime LastAccessedByMe { get; set; }
        public DateTime AccessedByMeUtc { get; set; }
        public DateTime AccessedByMe { get; set; }
        public string ObjectGUID { get; set; }
        public int ObjectCapabilityFlags { get; set; }
        public int ObjectFlags { get; set; }
        public int propertyID { get; set; }
        public int LatestCheckedInVersion { get; set; }
        public IList<object> BaseProperties { get; set; }
    }
}
