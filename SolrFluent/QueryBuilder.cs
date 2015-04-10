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
        private List<IParameter> _searchParameters;

        public QueryBuilder()
        {
            _wt = "json";
            _indent = "true";
            _searchParameters = new List<IParameter>();
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

            if(_searchParameters.Count > 0)
            {
                result = Url.Combine(result, "select?q=");

                foreach (var searchExpr in _searchParameters)
                {
                    
                }
            }

            result.QueryParams.Add("wt", _wt);
            result.QueryParams.Add("indent", _indent);

            return result;
        }


        public IQuery Search(IParameter parameter)
        {
            _searchParameters.Add(parameter);
            return this;
        }
        
        public IQuery Search(string fieldName, string value)
        {
            return Search(SolrFluent.Search.CreateParameter(fieldName, value));
        }

        public IQuery SearchPhrase(string fieldName, string phrase)
        {
            throw new NotImplementedException();
        }
    }
}
