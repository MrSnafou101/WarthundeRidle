using Blazicons;
using Blazicons.Base;
using Microsoft.AspNetCore.Components;

namespace Warthuneridle.Components.Customs
{
    public partial class AttributeCell
    {
        [Parameter]
        public string Value { get; set; } = "err";
        [Parameter]
        public int IsCorrectVal { get; set; } = -1;
        [Parameter]
        public SvgIcon? FlagIcon { get; set; }
        public string getClassFromHint(int resVal)
        {
            return resVal == 1 ? "correct" : resVal == 2 ? "partialCorrect" : "incorrect";
        }
    }
}
