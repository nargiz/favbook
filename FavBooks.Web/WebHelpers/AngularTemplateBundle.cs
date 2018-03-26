using System.Web.Optimization;

namespace FavBooks.Web.WebHelpers
{
    public class AngularTemplateBundle : Bundle
    {
        public AngularTemplateBundle(string virtualPath, string moduleName)
            : this(virtualPath, (string)null, moduleName)
        {
        }

        public AngularTemplateBundle(string virtualPath, string cdnPath, string moduleName)
            : base(virtualPath, cdnPath, new AngularTemplateBundleTransform(moduleName))
        {
        }
    }
}