using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.BehavioralDesignPattern.Interpreter
{
    public class DayExpression : AbstractExpression
    {
        public void Evaluate(Context context)
        {
            string expression = context.expression;
            context.expression = expression.Replace("DD", context.date.Day.ToString());
        }
    }
}
