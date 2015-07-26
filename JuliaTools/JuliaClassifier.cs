using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System.Text.RegularExpressions;

namespace JuliaTools
{
    internal class JuliaClassifier : IClassifier
    {
        IClassificationTypeRegistryService registry;

        internal JuliaClassifier(IClassificationTypeRegistryService registry)
        {
            this.registry = registry;
        }

        #region IClassifier

#pragma warning disable 67

        /// <summary>
        /// An event that occurs when the classification of a span of text has changed.
        /// </summary>
        /// <remarks>
        /// This event gets raised if a non-text change would affect the classification in some way,
        /// for example typing /* would cause the classification to change in C# without directly
        /// affecting the span.
        /// </remarks>
        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;

#pragma warning restore 67

        /// <summary>
        /// Gets all the <see cref="ClassificationSpan"/> objects that intersect with the given range of text.
        /// </summary>
        /// <remarks>
        /// This method scans the given SnapshotSpan for potential matches for this classification.
        /// In this instance, it classifies everything and returns each span as a new ClassificationSpan.
        /// </remarks>
        /// <param name="span">The span currently being classified.</param>
        /// <returns>A list of ClassificationSpans that represent spans identified to be of this classification.</returns>
        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            var result = new List<ClassificationSpan>();

            var text = span.GetText();
            foreach (Match m in Regex.Matches(text, @"\bfunction\b"))
            {
                var currSpan = new SnapshotSpan(span.Start + m.Groups[0].Index, m.Groups[0].Length);
                result.Add(new ClassificationSpan(currSpan, this.registry.GetClassificationType("function")));
            }
            return result;
        }

        #endregion
    }
}
