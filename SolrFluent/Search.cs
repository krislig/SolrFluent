using SolrFluent.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolrFluent
{
    public static class Search
    {
        public static IExpression Expression(string fieldName, string value)
        {
            return new SearchExpression(fieldName, value);
        }
    }

    public class Expression
    {
        private string fieldName;
        private string value;

        public Expression(string fieldName, string value)
        {
            this.fieldName = fieldName;
            this.value = value;
        }

        public Expression And(Expression expression)
        {
            return null;
        }

        public Expression Or(Expression expression)
        {
            return null;
        }
    }
}
