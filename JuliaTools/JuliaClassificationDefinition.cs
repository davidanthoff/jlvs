using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace JuliaTools
{
    internal static class JuliaClassificationDefinition
    {
        // This disables "The field is never used" compiler's warning. Justification: the field is used by MEF.
#pragma warning disable 169

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("function")]
        private static ClassificationTypeDefinition functionDefinition;

#pragma warning restore 169
    }
}
