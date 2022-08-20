using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbStandardObjects.Objects;

namespace UbReviewer.Classes
{
    internal class ReviewerBook : Book
    {
        public override void DeleteAnnotations(TOC_Entry entry)
        {
            throw new NotImplementedException();
        }

        public override void StoreAnnotations(TOC_Entry entry, List<UbAnnotationsStoreData> annotations)
        {
            throw new NotImplementedException();
        }
    }
}
