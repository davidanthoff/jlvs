using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace JuliaTools
{
    /// <summary>
    /// Defines an editor format for the JuliaEditorClassifier type that has a purple background
    /// and is underlined.
    /// </summary>
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "function")]
    [Name("function")]
    [UserVisible(true)] // This should be visible to the end user
    [Order(Before = Priority.Default)] // Set the priority to be after the default classifiers
    internal sealed class KeywordClassifierFormat : ClassificationFormatDefinition
    {
        public KeywordClassifierFormat()
        {
            this.DisplayName = "function"; // Human readable version of the name
            this.ForegroundColor = System.Windows.Media.Colors.Blue;
        }
    }
}
