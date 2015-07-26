using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace JuliaTools
{
    internal static class FileAndContentTypeDefinitions
    {
        [Export]
        [Name("julia")]
        [BaseDefinition("code")]
        internal static ContentTypeDefinition juliaContentTypeDefinition;

        [Export]
        [FileExtension(".jl")]
        [ContentType("julia")]
        internal static FileExtensionToContentTypeDefinition juliaFileExtensionDefinition;
    }
}
