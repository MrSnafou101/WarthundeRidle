using Microsoft.AspNetCore.Components;

namespace Warthuneridle.Components.Customs
{
    public partial class AttributeCell
    {
        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public int IsCorrectVal { get; set; }

        public string getClassFromHint(int resVal)
        {
            return resVal == 1 ? "correct" : resVal == 2 ? "incorrect" : "partialCorrect";
        }
    }
}
