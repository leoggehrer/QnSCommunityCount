//@QnSCodeCopy
//MdStart

using System.Collections.Generic;

namespace QnSCommunityCount.AspMvc.Models.Modules.Export
{
    public class ImportProtocol : ModelObject
    {
        public string FilePath { get; set; }
        public IEnumerable<ImportLog> LogInfos { get; set; } = new ImportLog[0];
    }
}
//MdEnd
