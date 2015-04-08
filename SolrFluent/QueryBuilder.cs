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

        public QueryBuilder()
        {
            
        }

        public QueryBuilder(string solrAddress)
        {
            _solrAddress = solrAddress;
        }

        public QueryBuilder(string solrAddress, string coreName) : this(solrAddress)
        {
            _core = coreName;
        }

        public override string ToString()
        {
            Uri addressUri = new Uri(_solrAddress);
            Uri result = new Uri(addressUri, _core);

            return Url.Combine(_solrAddress, _core);
        }


        public IQuery Search(IExpression expression)
        {
            throw new NotImplementedException();
        }
        
        public IQuery Search(string fieldName, string value)
        {
            throw new NotImplementedException();
        }

        public IQuery SearchPhrase(string fieldName, string phrase)
        {
            throw new NotImplementedException();
        }
    }
}
