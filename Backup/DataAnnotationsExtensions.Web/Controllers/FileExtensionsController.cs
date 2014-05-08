using DataAnnotationsExtensions.Core;

namespace DataAnnotationsExtensions.Web.Controllers
{
    public class FileExtensionsController : ValidationControllerBase<FileExtensionsEntity>
    {
        protected override void AddMessage()
        {
            Message =
                "File Extension Validation:  For the ImageFileName input the following extensions are valid {png,jpg,jpeg,gif}.  For the DocumentFileName input, the following extensions are valid {doc,docx,txt,rtf,pdf}";
        }
    }
}
