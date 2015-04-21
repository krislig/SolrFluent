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
        //public static IExpression Expression(string fieldName, string value)
        //{
        //    return new Expression(new SearchParameter(fieldName, value));       
        //}

        public static ISearchParameter CreateSearchParameter(string fieldName, string value)
        {
            return new SearchParameter(fieldName, value);
        }

        //public static IParameter CreateParameter(IExpression expression)
        //{
        //    return new ComplexParameter(expression);
        //}
    }   
}
