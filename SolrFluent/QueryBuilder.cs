using SolrFluent.FluentInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using SolrFluent.Expressions;

namespace SolrFluent
{
    public class QueryBuilder : IQuery
    {
        private string _solrAddress = "http://localhost:8983/solr";
        private string _core = "new_core";
        private string _wt;
        private string _indent;
        private List<IExpression> _searchExpressions;

        public QueryBuilder()
        {
            _wt = "json";
            _indent = "true";
            _searchExpressions = new List<IExpression>();
        }

        public QueryBuilder(string solrAddress) : this()
        {
            _solrAddress = solrAddress;
        }

        public QueryBuilder(string solrAddress, string coreName) : this(solrAddress)
        {
            _core = coreName;
        }

        public override string ToString()
        {
            Url result = Url.Combine(_solrAddress, _core);

            if(_searchExpressions.Count > 0)
            {
                result = Url.Combine(result, "select?q=");

                foreach (var searchExpr in _searchExpressions)
                {
                    
                }
            }

            result = Url.Combine(result, "wt:", _wt);
            result = Url.Combine(result, "indent", _indent);

            return result;
        }


        public IQuery Search(IExpression expression)
        {
            _searchExpressions.Add(expression);
            return this;
        }
        
        public IQuery Search(string fieldName, string value)
        {
            return Search(SolrFluent.Search.Expression(fieldName, value));
        }

        public IQuery SearchPhrase(string fieldName, string phrase)
        {
            throw new NotImplementedException();
        }
    }
}
