namespace Umbraco.StarterKit.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using umbraco.MacroEngines;

    public static class DynamicNodeExtensions
    {
        public static string GetNonEmptyPropertyValue(this DynamicNode node, string alias, string fallback)
        {
            var property = node.GetProperty(alias);
            if (property == null || string.IsNullOrWhiteSpace(property.Value))
                return fallback;
            return property.Value;
        }
        
        #region "Navigation Extensions"
        public static string NavName(this DynamicNode node)
        {
            return node.GetNonEmptyPropertyValue("navName", node.Name);
        }

        public static string NavTitle(this DynamicNode node)
        {
            return node.GetNonEmptyPropertyValue("navTitle", node.Name);
        }
        #endregion

        #region "Meta"
        public static string FormattedMetaTitle(this DynamicNode node)
        {
            var siteTitleFormat = node.AncestorOrSelf(1).GetPropertyValue("siteTitleFormat", "{0}");
            if (!siteTitleFormat.Contains("{0}"))
            {
                siteTitleFormat = string.Concat("{0}", siteTitleFormat);
            }
            return string.Format(siteTitleFormat, node.MetaTitle());
        }

        public static string MetaTitle(this DynamicNode node)
        {
            return node.GetNonEmptyPropertyValue("metaTitle", node.Name);
        }

        public static string MetaKeywords(this DynamicNode node)
        {
            return node.GetNonEmptyPropertyValue("metaKeywords", string.Empty);
        }

        public static string MetaDescription(this DynamicNode node)
        {
            return node.GetNonEmptyPropertyValue("metaDescription", string.Empty);
        }
        #endregion
    }
}
