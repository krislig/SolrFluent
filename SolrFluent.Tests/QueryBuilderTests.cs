using Flurl;
using SolrFluent.Visitors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace SolrFluent.Tests
{
    public class QueryBuilderTests
    {
        const string SOLR_URL = "http://localhost:8983/solr";
        const string CORE_NAME = "new_core";

        [Fact]
        public void Ctor_DefaultAddress_Ok()
        {
            Assert.Equal("http://localhost:8983/solr/new_core", new QueryBuilder().ToString());
        }

        [Fact]
        public void Query_Simple_Ok()
        {
            var expression = Search.CreateSearchParameter("inStock", "true").And(Search.CreateSearchParameter("id", "1234"));

            expression.Or(Search.CreateSearchParameter("id", "5678")).Or(Search.CreateSearchParameter("name", "adata"));

            var qb = new QueryBuilder("", "");

            qb.Search(expression);

            var countVisitor = new CountVisitor();

            countVisitor.CountParameters(qb.SearchParameterTree);

            qb.ToString();
        }

        

        [Fact]
        public void Query_SimpleWordSearch_Ok()
        {
            //var qb = new QueryBuilder(SOLR_URL, CORE_NAME).Search("title", "foo");

            //Assert.Equal(Url.Combine(SOLR_URL, CORE_NAME, "select?q=title:foo&wt=json&indent=true"), qb.ToString());
        }
    }
}
