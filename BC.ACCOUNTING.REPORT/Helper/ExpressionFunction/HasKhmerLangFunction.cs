using DevExpress.Data.Filtering;
using DevExpress.XtraReports.Design;
using DevExpress.XtraReports.Expressions;

namespace BC.ACCOUNTING.REPORT.Helper.ExpressionFunction
{
    [VSDesignerCustomFunction(VSDesignerCustomFunctionScope.Reports)]
    public class HasKhmerLangFunction : ReportCustomFunctionOperatorBase
    {
        public override string Name => "HasKhmer";
        public override string FunctionCategory => "Custom";
        public override string Description => "HasKhmer(string text) -> returns true if text contains Khmer characters";

        public override int MinOperandCount => 1;
        public override int MaxOperandCount => 1;

        public override bool IsValidOperandCount(int count) => count == 1;

        public override bool IsValidOperandType(int operandIndex, int operandCount, Type type)
            => type == typeof(string) || type == typeof(object);

        public override Type ResultType(params Type[] operands) => typeof(bool);

        public override object Evaluate(params object[] operands)
        {
            var s = operands?[0]?.ToString();
            if (string.IsNullOrEmpty(s)) return false;

            foreach (char c in s)
            {
                if (c >= '\u1780' && c <= '\u17FF') // Khmer Unicode block
                    return true;
            }

            return false;
        }

    }
}
