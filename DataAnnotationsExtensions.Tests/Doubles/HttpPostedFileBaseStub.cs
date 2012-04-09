using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DataAnnotationsExtensions.Tests.Doubles
{
    public class HttpPostedFileBaseStub : HttpPostedFileBase
    {
        public HttpPostedFileBaseStub(string fileName)
        {
            _fileName = fileName;
        }

        private string _fileName { set; get; }
        public override string FileName { 
            get
            {
                return _fileName;
            } 
        }
    }
}
